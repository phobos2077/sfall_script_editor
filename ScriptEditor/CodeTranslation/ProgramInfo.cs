using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ScriptEditor.CodeTranslation
{
    public enum ValueType : int { Int = 1, Float = 2, String = 3 }
    public enum VarType : int { Local = 1, Global = 2, Import = 3, Export = 4 }
    [Flags]
    public enum ProcType : int { None = 0, Timed = 0x01, Conditional = 0x02, Import = 0x04, Export = 0x08, Critical = 0x10, Pure = 0x20, Inline = 0x40 }
    public enum NameType { None, Macro, LVar, GVar, Proc }    


    [StructLayout(LayoutKind.Sequential)]
    public struct ProcedureData
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

    [StructLayout(LayoutKind.Explicit)]
    public struct VariableData
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

    public class ProgramInfo
    {
        public readonly Procedure[] procs;
        public readonly Variable[] vars;
        public static Dictionary<string, string> opcodes;
        public static List<string> opcodes_list;
        private readonly Dictionary<string, Procedure> procLookup;
        private readonly Dictionary<string, Variable> varLookup;
        public readonly Dictionary<string, Macro> macros;
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

        public Reference[] LookupReferences(string token, string file, int line)
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
                lines = File.ReadAllLines(Path.Combine(Settings.ResourcesFolder, "opcodes.txt"));
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
