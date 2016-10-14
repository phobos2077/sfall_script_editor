using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ScriptEditor
{
    enum ValueType : int { Int = 1, Float = 2, String = 3 }
    enum VarType : int { Local = 1, Global = 2, Import = 3, Export = 4 }
    [Flags]
    enum ProcType : int { None = 0, Timed = 0x01, Conditional = 0x02, Import = 0x04, Export = 0x08, Critical = 0x10, Pure = 0x20, Inline = 0x40 }
    enum NameType { None, Macro, LVar, GVar, Proc }

    interface IParserInfo
    {
        NameType Type();
        Ref[] References();
        void Deceleration(out string file, out int line);
    }

    class Ref
    {
        public readonly int line;
        public readonly string file;

        public Ref(int line, int file)
        {
            this.line = line;
            this.file = Marshal.PtrToStringAnsi(new IntPtr(file));
            if (this.file != null) {
                this.file = Path.GetFullPath(this.file);
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    struct ProcedureData
    {
        public int name;
        public ProcType type;
        public int time;
        private readonly int unused0; // larger union
        private readonly int unused1; //namelist
        public int args;
        public int defined;
        private readonly int unused2;
        public int numVariables;
        private readonly int unused3;
        public int numRefs;
        private readonly int unused4;
        public int declared;
        public IntPtr fdeclared;
        public int start;
        public IntPtr fstart;
        public int end;
        public IntPtr fend;
    }

    class Procedure : IParserInfo
    {
        public string name;
        public string fdeclared;
        public string fstart;
        //public string fend; //just assume this is the same file as fstart
        public string filename;
        public ProcedureData d;
        public Variable[] variables;
        public Ref[] references;

        public NameType Type() { return NameType.Proc; }
        public Ref[] References() { return references; }
        public void Deceleration(out string file, out int line)
        {
            file = fdeclared;
            line = d.declared;
        }

        public string ToString(bool fullSpec = true)
        {
            System.String s = "";
            if (fullSpec) {
                if ((d.type & ProcType.Import) != ProcType.None)
                    s += "imported ";
                if ((d.type & ProcType.Export) != ProcType.None)
                    s += "exported ";
                if ((d.type & ProcType.Pure) != ProcType.None)
                    s += "pure ";
                if ((d.type & ProcType.Inline) != ProcType.None)
                    s += "inline ";
                if ((d.type & ProcType.Timed) != ProcType.None)
                    s += "timed ";
                if ((d.type & ProcType.Conditional) != ProcType.None)
                    s += "conditional ";
                if ((d.type & ProcType.Critical) != ProcType.None)
                    s += "critical ";
                s += "procedure ";
            }
            s += name;
            s += "(";
            for (int i = 0; i < d.args; i++) {
                if (i > 0)
                    s += ", ";
                s += (i >= variables.Length) ? "x" : variables[i].name;
                if (fullSpec && i < variables.Length && variables[i].initialValue != null)
                    s += " := " + variables[i].initialValue;
            }
            s += ")";
            return s;
        }
        public bool IsImported()
        {
            return (d.type & ProcType.Import) > 0;
        }
        public override string ToString()
        {
            return ToString(true);
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    struct VariableData
    {
        [FieldOffset(0)]
        public int name;
        [FieldOffset(8)]
        public int numRefs;
        [FieldOffset(12)]
        public ValueType initialType;
        [FieldOffset(16)]
        public int intValue;
        [FieldOffset(16)]
        public float floatValue;
        [FieldOffset(20)]
        public VarType type;
        [FieldOffset(24)]
        public int arrayLen;
        [FieldOffset(28)]
        public int declared;
        [FieldOffset(32)]
        public IntPtr fdeclared;
        [FieldOffset(40)]
        public int initialized;
    }

    class Variable : IParserInfo
    {
        public string name;
        public string fdeclared;
        public string filename;
        public VariableData d;
        public Ref[] references;
        public string initialValue;

        public NameType Type() { return d.type == VarType.Local ? NameType.LVar : NameType.GVar; }
        public Ref[] References() { return references; }
        public void Deceleration(out string file, out int line)
        {
            file = fdeclared;
            line = d.declared;
        }

        public override string ToString()
        {
            string s = "";
            switch (d.type) {
                case VarType.Local:
                    s = "Local variable ";
                    break;
                case VarType.Global:
                    s = "Variable ";
                    break;
                case VarType.Import:
                    s = "Imported variable ";
                    break;
                case VarType.Export:
                    s = "Exported variable ";
                    break;
            }
            s += name;
            if (initialValue != null)
                s += " := " + initialValue;
            return s;
        }
        public bool IsImported()
        {
            return d.type == VarType.Import;
        }
    }

    class Macro : IParserInfo
    {
        public readonly string name;
        public readonly string def;
        public readonly int declared;
        public readonly string fdeclared;

        public NameType Type() { return NameType.Macro; }
        public Ref[] References() { return null; }
        public void Deceleration(out string file, out int line)
        {
            file = fdeclared;
            line = declared;
        }

        public Macro(string name, string def, string file, int line)
        {
            this.name = name;
            this.def = def;
            this.fdeclared = file;
            this.declared = line;
        }

        public override string ToString()
        {
            return name + " := " + def;
        }
    }

    class ProgramInfo
    {
        public readonly Procedure[] procs;
        public readonly Variable[] vars;
        public static Dictionary<string, string> opcodes;
        public static List<string> opcodes_list;
        private readonly Dictionary<string, Procedure> procLookup;
        private readonly Dictionary<string, Variable> varLookup;
        public readonly Dictionary<string, Macro> macros;
        public TabInfo tab;
        public bool parsed = false;

        public IParserInfo Lookup(string token, string file, int line)
        {
            token = token.ToLowerInvariant();
            if (macros.ContainsKey(token))
                return macros[token];
            if (file != null) {
                file = file.ToLowerInvariant();
                for (int i = 0; i < procs.Length; i++) {
                    if (line >= procs[i].d.start && line <= procs[i].d.end && String.Compare(file, procs[i].fstart, true) == 0) {
                        foreach (Variable var in procs[i].variables) {
                            if (string.Compare(var.name, token, true) == 0)
                                return var;
                        }
                    }
                }
            }
            if (procLookup.ContainsKey(token))
                return procLookup[token];
            else if (varLookup.ContainsKey(token))
                return varLookup[token];
            return null;
        }

        public string LookupToken(string token, string file, int line)
        {
            token = token.ToLowerInvariant();
            if (opcodes.ContainsKey(token))
                return opcodes[token];
            IParserInfo pi = Lookup(token, file, line);
            if (pi == null)
                return null;
            else
                return pi.ToString();
        }

        public NameType LookupTokenType(string token, string file, int line)
        {
            IParserInfo pi = Lookup(token, file, line);
            if (pi == null)
                return NameType.None;
            else
                return pi.Type();
        }

        public Ref[] LookupReferences(string token, string file, int line)
        {
            IParserInfo pi = Lookup(token, file, line);
            if (pi == null)
                return null;
            else
                return pi.References();
        }

        public void LookupDecleration(string token, string file, int line, out string ofile, out int oline)
        {
            IParserInfo pi = Lookup(token, file, line);
            if (pi == null) {
                ofile = null;
                oline = -1;
            } else
                pi.Deceleration(out ofile, out oline);
        }
        public void LookupDefinition(string token, out string ofile, out int oline)
        {
            token = token.ToLowerInvariant();
            oline = -1;
            ofile = null;
            if (procLookup.ContainsKey(token)) {
                ofile = procLookup[token].fstart;
                oline = procLookup[token].d.start;
            }
        }

        public void BuildDictionaries()
        {
            for (int i = 0; i < procs.Length; i++) {
                procLookup[procs[i].name.ToLowerInvariant()] = procs[i];
            }
            for (int i = 0; i < vars.Length; i++) {
                varLookup[vars[i].name.ToLowerInvariant()] = vars[i];
            }
        }

        public ProgramInfo(int procs, int vars)
        {
            this.procs = new Procedure[procs];
            this.vars = new Variable[vars];
            procLookup = new Dictionary<string, Procedure>(procs);
            varLookup = new Dictionary<string, Variable>(vars);
            macros = new Dictionary<string, Macro>();
        }

        /*public ProgramInfo() {
        	
            this.procs = new Procedure[procs];
            this.vars = new Variable[vars];
            procLookup = new Dictionary<string, Procedure>(procs);
            varLookup = new Dictionary<string, Variable>(vars);
        }*/

        public static void LoadOpcodes()
        {
            String[] lines;
            opcodes = new Dictionary<string, string>();
            opcodes_list = new List<string>();
            try {
                lines = File.ReadAllLines("resources\\opcodes.txt");
            } catch (FileNotFoundException) {
                return;
            }
            foreach (String line in lines) {
                Match m = Regex.Match(line, @"^[\w\|]+\*?\s+(\w+).*");
                if (m.Success) {
                    // wrap words
                    String[] words = line.Split(' ');
                    String wrapped = "";
                    int lineLen = 0;
                    foreach (String word in words) {
                        if ((lineLen + word.Length) > 100 || word == "-") {
                            wrapped += "\n";
                            lineLen = 0;
                        }
                        if (wrapped != "")
                            wrapped += " ";
                        wrapped += word;
                        lineLen += (word.Length + 1);
                    }
                    opcodes[m.Groups[1].ToString()] = wrapped;
                }
            }
            foreach (var entry in opcodes) {
                opcodes_list.Add(entry.Key);
            }
            opcodes_list.Sort();
        }

        public List<string> LookupAutosuggest(string part)
        {
            part = part.ToLower();
            var matches = LookupOpcode(part);
            foreach (var entry in procLookup) {
                if (entry.Key.IndexOf(part) == 0) {
                    matches.Add(entry.Value.name + "|" + entry.Value.ToString(true));
                    if (matches.Count >= 10)
                        break;
                }
            }
            if (matches.Count < 10) {
                foreach (var entry in varLookup) {
                    if (entry.Key.IndexOf(part) == 0) {
                        matches.Add(entry.Value.name);
                        if (matches.Count >= 10)
                            break;
                    }
                }
            }
            if (matches.Count < 10) {
                foreach (var entry in macros) {
                    if (entry.Key.IndexOf(part) == 0) {
                        matches.Add(entry.Value.name + "|" + entry.Value.def);
                        if (matches.Count >= 10)
                            break;
                    }
                }
            }
            return matches;
        }

        public static List<string> LookupOpcode(string part)
        {
            var matches = new List<string>();
            part = part.ToLower();
            foreach (string key in opcodes_list) {
                if (key.IndexOf(part) == 0) {
                    matches.Add(key + "|" + opcodes[key]);
                    if (matches.Count >= 10)
                        break;
                }
            }
            return matches;
        }
    }
}
