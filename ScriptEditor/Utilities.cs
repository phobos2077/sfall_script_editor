//#define DLL_COMPILER

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ICSharpCode.TextEditor.Document;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ScriptEditor {
    enum ErrorType { Error, Warning, Message, Search }
    class Error {
        public ErrorType type;
        public string msg;
        public string fileName;
        public int line;
        public int column = -1;

        public override string ToString() {
            return msg;
        }
    }

    class TabInfo {
        public ICSharpCode.TextEditor.TextEditorControl te;
        public int index;
        public string filepath;
        public string filename;
        public bool changed;
        public TabInfo msg;
        public readonly Dictionary<int, string> messages=new Dictionary<int, string>();
        public bool shouldParse;
        public bool needsParse;
        public ProgramInfo parseInfo;
    }

    class CodeFolder : IFoldingStrategy {
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation) {
            ProgramInfo pi=(ProgramInfo)parseInformation;
            List<FoldMarker> list = new List<FoldMarker>(pi.procs.Length);

            fileName=fileName.ToLowerInvariant();
            for(int i=0;i<pi.procs.Length;i++) {
                if(pi.procs[i].filename!=fileName) continue;
                list.Add(new FoldMarker(document, pi.procs[i].d.start-1, 0, pi.procs[i].d.end-1, 0, FoldType.MemberBody));
            }
            return list;
        }
    }

    struct WindowPos {
        public bool maximized;
        public int x, y, width, height;
    }

    enum SavedWindows { Main, Count }
    static class Settings {
        public static readonly string SettingsFolder=Path.Combine(Environment.CurrentDirectory, "settings");
        private static readonly string SettingsPath=Path.Combine(SettingsFolder, "settings.dat");
        private static readonly string preprocessPath=Path.Combine(Settings.SettingsFolder, "preprocess.ssl");
        
        const int MAX_RECENT = 30;

        public static byte optimize=1;
        public static bool showWarnings=true;
        public static bool showDebug=true;
        public static bool showLogo=true;
        public static bool warnOnFailedCompile=true;
        public static bool multiThreaded=true;
        public static bool autoOpenMsgs=true;
        public static string outputDir;
        public static string scriptsHFile;
        public static string lastMassCompile;
        public static string lastSearchPath;
        private static readonly List<string> recent=new List<string>();
        private static readonly WindowPos[] windowPositions = new WindowPos[(int)SavedWindows.Count];
        public static int editorSplitterPosition=-1;
        public static int editorSplitterPosition2=-1;
        public static string language="english";
        public static bool tabsToSpaces = true;
        public static int tabSize = 3;
        public static bool enableParser = true;
        public static bool shortCircuit = false;
        public static bool autocomplete = true;

        public static void SetupWindowPosition(SavedWindows window, System.Windows.Forms.Form f) {
            WindowPos wp=windowPositions[(int)window];
            if(wp.width==0) return;
            f.Location=new System.Drawing.Point(wp.x, wp.y);
            if(wp.maximized) f.WindowState=System.Windows.Forms.FormWindowState.Maximized;
            else f.ClientSize=new System.Drawing.Size(wp.width, wp.height);
            f.StartPosition=System.Windows.Forms.FormStartPosition.Manual;
        }

        public static void SaveWindowPosition(SavedWindows window, System.Windows.Forms.Form f) {
            WindowPos wp=new WindowPos();
            wp.maximized=f.WindowState==System.Windows.Forms.FormWindowState.Maximized;
            wp.x=f.Location.X;
            wp.y=f.Location.Y;
            wp.width=f.ClientSize.Width;
            wp.height=f.ClientSize.Height;
            windowPositions[(int)window]=wp;
        }

        public static void AddRecentFile(string s) {
            for(int i=0;i<recent.Count;i++) {
                if(string.Compare(recent[i], s, true)==0) recent.RemoveAt(i--);
            }
            if(recent.Count>=MAX_RECENT) recent.RemoveAt(0);
            recent.Add(s);
        }

        public static string[] GetRecent() { return recent.ToArray(); }

        private static void LoadWindowPos(BinaryReader br, int i) {
            windowPositions[i].maximized=br.ReadBoolean();
            windowPositions[i].x=br.ReadInt32();
            windowPositions[i].y=br.ReadInt32();
            windowPositions[i].width=br.ReadInt32();
            windowPositions[i].height=br.ReadInt32();
        }
        private static void LoadInternal(BinaryReader br) {
            int version=br.ReadInt32();
            optimize=br.ReadByte();
            showWarnings=br.ReadBoolean();
            showDebug=br.ReadBoolean();
            showLogo=br.ReadBoolean();
            outputDir=br.ReadString();
            if(outputDir.Length==0) outputDir=null;
            int recentItems=br.ReadByte();
            for(int i=0;i<recentItems;i++) recent.Add(br.ReadString());
            if (version==1) return;
            warnOnFailedCompile=br.ReadBoolean();
            multiThreaded=br.ReadBoolean();
            lastMassCompile=br.ReadString();
            if (lastMassCompile.Length==0) lastMassCompile=null;
            if (version==2) return;
            lastSearchPath=br.ReadString();
            if (lastSearchPath.Length==0) lastSearchPath=null;
            LoadWindowPos(br, 0);
            editorSplitterPosition=br.ReadInt32();
            if (version==3) return;
            autoOpenMsgs=br.ReadBoolean();
            editorSplitterPosition2=br.ReadInt32();
            if (version==4) return;
            scriptsHFile=br.ReadString();
            if (scriptsHFile.Length==0) scriptsHFile=null;
            if (version==5) return;
            language=br.ReadString();
            if (language.Length==0) language="english";
            if (version==6) return;
            tabsToSpaces=br.ReadBoolean();
            tabSize=br.ReadInt32();
            if (version==7) return;
            enableParser=br.ReadBoolean();
            if (version == 8) return;
            shortCircuit = br.ReadBoolean();
            if (version == 9) return;
            autocomplete = br.ReadBoolean();
        }
        public static void Load() {
            if(!File.Exists(SettingsPath)) return;
            recent.Clear();
            BinaryReader br=new BinaryReader(File.OpenRead(SettingsPath));
            LoadInternal(br);
            br.Close();
        }

        private static void WriteWindowPos(BinaryWriter bw, int i) {
            bw.Write(windowPositions[i].maximized);
            bw.Write(windowPositions[i].x);
            bw.Write(windowPositions[i].y);
            bw.Write(windowPositions[i].width);
            bw.Write(windowPositions[i].height);
        }
        public static void Save() {
            if(!Directory.Exists(SettingsFolder)) Directory.CreateDirectory(SettingsFolder);
            BinaryWriter bw=new BinaryWriter(File.Create(SettingsPath));
            bw.Write(10);
            bw.Write(optimize);
            bw.Write(showWarnings);
            bw.Write(showDebug);
            bw.Write(showLogo);
            bw.Write(outputDir==null?"":outputDir);
            bw.Write((byte)recent.Count);
            for(int i=0;i<recent.Count;i++) bw.Write(recent[i]);
            bw.Write(warnOnFailedCompile);
            bw.Write(multiThreaded);
            bw.Write(lastMassCompile==null?"":lastMassCompile);
            bw.Write(lastSearchPath==null?"":lastSearchPath);
            WriteWindowPos(bw, 0);
            bw.Write(editorSplitterPosition);
            bw.Write(autoOpenMsgs);
            bw.Write(editorSplitterPosition2);
            bw.Write(scriptsHFile==null?"":scriptsHFile);
            bw.Write(language==null?"english":language);
            bw.Write(tabsToSpaces);
            bw.Write(tabSize);
            bw.Write(enableParser);
            bw.Write(shortCircuit);
            bw.Write(autocomplete);
            bw.Close();
        }

        public static string GetPreprocessedFile() {
            if(!File.Exists(preprocessPath)) return null;
            return File.ReadAllText(preprocessPath);
        }

        public static string GetOutputPath(string infile) {
            return Path.Combine(outputDir, Path.GetFileNameWithoutExtension(infile))+".int";
        }

        
#if DLL_COMPILER
        public static string[] GetSslcCommandLine(string infile, bool preprocess) {
            return new string[] {
                "--", "-q",
                preprocess?"-P":"-p",
                optimize?"-O":"--",
                showWarnings?"--":"-n ",
                showDebug?"-d":"--",
                showLogo?"":"-l",
                Path.GetFileName(infile),
                "-o",
                preprocess?preprocessPath:GetOutputPath(infile),
                null
            };
#else
        public static string GetSslcCommandLine(string infile, bool preprocess) {
            return (preprocess ? "-P " : "-p ")
            	+ ("-O" + optimize + " ") 
            	+ (showWarnings ? "" : "-n ") 
            	+ (showDebug ? "-d " : "") 
            	+ (showLogo ? "" : "-l ")
            	+ (shortCircuit ? "-s " : "")
            	+ "\""+Path.GetFileName(infile)+"\" -o \""+(preprocess?preprocessPath:GetOutputPath(infile))+"\"";
#endif
        }
    }

    enum ValueType : int { Int=1, Float=2, String=3 }
    enum VarType : int { Local=1, Global=2, Import=3, Export=4 }
    [Flags]
    enum ProcType : int { None=0, Timed=0x01, Conditional=0x02, Import=0x04, Export=0x08, Critical=0x10, Pure=0x20, Inline=0x40 }
    enum NameType { None, Macro, LVar, GVar, Proc }

    interface IParserInfo {
        NameType Type();
        Ref[] References();
        void Deceleration(out string file, out int line);
    }
    class Ref {
        public readonly int line;
        public readonly string file;

        public Ref(int line, int file) {
            this.line=line;
            this.file=Marshal.PtrToStringAnsi(new IntPtr(file));
            if (this.file != null)
            	this.file = Path.GetFullPath(this.file);
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    struct ProcedureData {
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
    class Procedure : IParserInfo {
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
        public void Deceleration(out string file, out int line) {
            file=fdeclared;
            line=d.declared;
        }

        public string ToString(bool fullSpec = true) {
            System.String s = "";
            if (fullSpec) {
	            if((d.type&ProcType.Import)!=ProcType.None) s += "imported ";
	            if((d.type&ProcType.Export)!=ProcType.None) s += "exported ";
	            if((d.type&ProcType.Pure)!=ProcType.None) s += "pure ";
	            if((d.type&ProcType.Inline)!=ProcType.None) s += "inline ";
	            if((d.type&ProcType.Timed)!=ProcType.None) s += "timed ";
	            if((d.type&ProcType.Conditional)!=ProcType.None) s += "conditional ";
	            if((d.type&ProcType.Critical)!=ProcType.None) s += "critical ";
	            s += "procedure ";
            }
            s += name;
            s += "(";
            for (int i = 0; i < d.args; i++) {
                if (i > 0) s += ", ";
                s += (i >= variables.Length) ? "x" : variables[i].name;
                if (fullSpec && i < variables.Length && variables[i].initialValue != null)
                	s += " := " + variables[i].initialValue;
            }
            s += ")";
            return s;
        }
        public bool IsImported() {
        	return (d.type & ProcType.Import) > 0;
        }
        public override string ToString() {
        	return ToString(true);
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    struct VariableData {
        [FieldOffset(0)] public int name;
        [FieldOffset(8)] public int numRefs;
        [FieldOffset(12)] public ValueType initialType;
        [FieldOffset(16)] public int intValue;
        [FieldOffset(16)] public float floatValue;
        [FieldOffset(20)] public VarType type;
        [FieldOffset(24)] public int arrayLen;
        [FieldOffset(28)] public int declared;
        [FieldOffset(32)] public IntPtr fdeclared;
        [FieldOffset(40)] public int initialized;
    }
    class Variable : IParserInfo {
        public string name;
        public string fdeclared;
        public string filename;
        public VariableData d;
        public Ref[] references;
        public string initialValue;

        public NameType Type() { return d.type==VarType.Local?NameType.LVar:NameType.GVar; }
        public Ref[] References() { return references; }
        public void Deceleration(out string file, out int line) {
            file=fdeclared;
            line=d.declared;
        }

        public override string ToString() {
        	string s = "";
            switch(d.type) {
			case VarType.Local: s = "Local variable "; break;
            case VarType.Global: s = "Variable "; break;
            case VarType.Import: s = "Imported variable "; break;
            case VarType.Export: s = "Exported variable "; break;
            }
        	s += name;
        	if (initialValue != null)
        		s += " := " + initialValue;
        	return s;
        }
        public bool IsImported() {
        	return d.type == VarType.Import;
        }
    }
    class Macro : IParserInfo {
        public readonly string name;
        public readonly string def;
        public readonly int declared;
        public readonly string fdeclared;

        public NameType Type() { return NameType.Macro; }
        public Ref[] References() { return null; }
        public void Deceleration(out string file, out int line) {
            file=fdeclared;
            line=declared;
        }

        public Macro(string name, string def, string file, int line) {
            this.name=name;
            this.def=def;
            this.fdeclared=file;
            this.declared=line;
        }

        public override string ToString() {
            return name+" := "+def;
        }
    }
   
    class ProgramInfo {
        public readonly Procedure[] procs;
        public readonly Variable[] vars;
        public static Dictionary<string, string> opcodes;
        public static List<string> opcodes_list;
        private readonly Dictionary<string, Procedure> procLookup;
        private readonly Dictionary<string, Variable> varLookup;
        public readonly Dictionary<string, Macro> macros;
        public TabInfo tab;
        public bool parsed = false;

        public IParserInfo Lookup(string token, string file, int line) {
            token=token.ToLowerInvariant();
            if(macros.ContainsKey(token)) return macros[token];
            if(file!=null) {
                file=file.ToLowerInvariant();
                for (int i=0;i<procs.Length;i++) {
                	if (line >= procs[i].d.start && line <= procs[i].d.end && String.Compare(file, procs[i].fstart, true) == 0) {
                        foreach (Variable var in procs[i].variables) {
                            if (string.Compare(var.name, token, true) == 0) return var;
                        }
                    }
                }
            }
            if(procLookup.ContainsKey(token)) return procLookup[token];
            else if(varLookup.ContainsKey(token)) return varLookup[token];
            return null;
        }

        public string LookupToken(string token, string file, int line) {
        	token=token.ToLowerInvariant();
        	if (opcodes.ContainsKey(token)) return opcodes[token];
            IParserInfo pi=Lookup(token, file, line);
            if(pi==null) return null;
            else return pi.ToString();
        }

        public NameType LookupTokenType(string token, string file, int line) {
            IParserInfo pi=Lookup(token, file, line);
            if(pi==null) return NameType.None;
            else return pi.Type();
        }

        public Ref[] LookupReferences(string token, string file, int line) {
            IParserInfo pi=Lookup(token, file, line);
            if(pi==null) return null;
            else return pi.References();
        }

        public void LookupDecleration(string token, string file, int line, out string ofile, out int oline) {
            IParserInfo pi=Lookup(token, file, line);
            if(pi==null) {
                ofile=null;
                oline=-1;
            } else pi.Deceleration(out ofile, out oline);
        }
        public void LookupDefinition(string token, out string ofile, out int oline) {
            token=token.ToLowerInvariant();
            oline=-1;
            ofile=null;
            if(procLookup.ContainsKey(token)) {
                ofile=procLookup[token].fstart;
                oline=procLookup[token].d.start;
            }
        }

        public void BuildDictionaries() {
            for(int i=0;i<procs.Length;i++) {
                procLookup[procs[i].name.ToLowerInvariant()]=procs[i];
            }
            for(int i=0;i<vars.Length;i++) {
                varLookup[vars[i].name.ToLowerInvariant()]=vars[i];
            }
        }

        public ProgramInfo(int procs, int vars) {
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
        
        public static void LoadOpcodes() {
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
        
        public List<string> LookupAutosuggest(string part) {
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
        
        public static List<string> LookupOpcode(string part) {
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

    static class Compiler {
        private static readonly string decompilationPath=Path.Combine(Settings.SettingsFolder, "decomp.ssl");
        private static readonly string parserPath=Path.Combine(Settings.SettingsFolder, "parser.ssl");

        [DllImport("resources\\parser.dll")]
        private static extern int parse_main(string file, string orig, string dir);
        [DllImport("resources\\parser.dll")]
        private static extern int numProcs();
        [DllImport("resources\\parser.dll")]
        private static extern void getProc(int proc, out ProcedureData data);
        [DllImport("resources\\parser.dll")]
        private static extern int getProcNamespaceSize(int proc);
        [DllImport("resources\\parser.dll")]
        private static extern void getProcNamespace(int proc, byte[] names);
        [DllImport("resources\\parser.dll")]
        private static extern int numVars();
        [DllImport("resources\\parser.dll")]
        private static extern void getVar(int var, out VariableData data);
        //[DllImport("resources\\parser.dll")]
        //private static extern int numExternals();
        //[DllImport("resources\\parser.dll")]
        //private static extern void getExternal(int var, out VariableData data);
        [DllImport("resources\\parser.dll")]
        private static extern void getProcVar(int proc, int var, out VariableData data);
        [DllImport("resources\\parser.dll")]
        private static extern int namespaceSize();
        [DllImport("resources\\parser.dll")]
        private static extern void getNamespace(byte[] names);
        [DllImport("resources\\parser.dll")]
        private static extern int stringspaceSize();
        [DllImport("resources\\parser.dll")]
        private static extern void getStringspace(byte[] names);
        [DllImport("resources\\parser.dll")]
        private static extern void getProcRefs(int proc, int[] refs);
        [DllImport("resources\\parser.dll")]
        private static extern void getVarRefs(int var, int[] refs);
        [DllImport("resources\\parser.dll")]
        private static extern void getProcVarRefs(int proc, int var, int[] refs);

        private static System.Text.StringBuilder sb=new System.Text.StringBuilder();
        public static int lastStatus;
        private static void AddMacro(string line, Dictionary<string, Macro> macros, string file, int lineno) {
            string token, macro, def;
            int firstspace=line.IndexOf(' ');
            if(firstspace==-1) return;
            int firstbracket=line.IndexOf('(');
            if(firstbracket!=-1&&firstbracket<firstspace) {
                int closebracket=line.IndexOf(')');
                if(line.Length==closebracket+1) return; //second check, because spaces are allowed between macro arguments
                macro=line.Remove(closebracket+1);
                token=line.Remove(firstbracket).ToLowerInvariant();
                def=line.Substring(closebracket+1).TrimStart();
            } else {
                macro=line.Remove(firstspace);
                token=macro.ToLowerInvariant();
                def=line.Substring(firstspace).TrimStart();
            }
            macros[token]=new Macro(macro, def, file, lineno+1);
        }
        private static void GetMacros(string file, string dir, Dictionary<string, Macro> macros) {
            if(!File.Exists(file)) return;
            string[] lines=File.ReadAllLines(file);
            if(dir==null) dir=Path.GetDirectoryName(file);
            for(int i=0;i<lines.Length;i++) {
                lines[i]=lines[i].Trim();
                if(lines[i].StartsWith("#include ")) {
                    string[] text=lines[i].Split('"');
                    if(text.Length<2) continue;
                    if(text[1].IndexOfAny(Path.GetInvalidPathChars())!=-1) continue;
                    if(!Path.IsPathRooted(text[1])) text[1]=Path.Combine(dir, text[1]);
                    GetMacros(text[1], null, macros);
                } else if(lines[i].StartsWith("#define ")) {
                    if(lines[i].EndsWith("\\")) {
                        sb.Length=0;
                        int lineno=i;
                        lines[i]=lines[i].Substring(8);
                        do {
                            sb.Append(lines[i].Remove(lines[i].Length-1).TrimEnd());
                            sb.Append(Environment.NewLine);
                            i++;
                            lines[i]=lines[i].Trim();
                        } while(lines[i].EndsWith("\\"));
                        sb.Append(lines[i]);
                        AddMacro(sb.ToString(), macros, file, lineno);
                    } else AddMacro(lines[i].Substring(8), macros, file, i);
                }
            }
        }
        private static string ParseName(byte[] namelist, int name) {
            int strlen=(namelist[name-5] << 8) + namelist[name-6];
            return System.Text.Encoding.ASCII.GetString(namelist, name-4, strlen).TrimEnd('\0');
        }
        public static ProgramInfo Parse(string file, string path) {
            File.WriteAllText(parserPath, file);
            lastStatus = parse_main(parserPath, path, Path.GetDirectoryName(path));
            if (lastStatus >= 2) // preprocess failed
            	return null;
            ProgramInfo pi = (lastStatus == 1)
			            	? new ProgramInfo(0, 0)
			            	: new ProgramInfo(numProcs(), numVars());
            GetMacros(parserPath, Path.GetDirectoryName(path), pi.macros);
            if (lastStatus == 1)  // parse failed, return only macros
            	return pi;
            pi.parsed = true;
            byte[] names = new byte[namespaceSize()];
            int stringsSize = stringspaceSize();
            getNamespace(names);
            byte[] strings = null;
            if (stringsSize > 0) {
            	strings = new byte[stringsSize];
            	getStringspace(strings);
            }
            //Variables
            for(int i=0;i<pi.vars.Length;i++) {
                pi.vars[i]=new Variable();
                getVar(i, out pi.vars[i].d);
                pi.vars[i].name=ParseName(names, pi.vars[i].d.name);
                if (pi.vars[i].d.initialized != 0) {
	                switch (pi.vars[i].d.initialType) {
	            		case ValueType.Int:
	                		pi.vars[i].initialValue = pi.vars[i].d.intValue.ToString();
	                		break;
	            		case ValueType.Float:
	                		pi.vars[i].initialValue = pi.vars[i].d.floatValue.ToString();
	                		break;
	                	case ValueType.String:
	                		pi.vars[i].initialValue = '"' + ParseName(strings, pi.vars[i].d.intValue) + '"';
	                		break;
	                }
                }
                
                if (pi.vars[i].d.fdeclared != IntPtr.Zero) {
	                pi.vars[i].fdeclared=Path.GetFullPath(Marshal.PtrToStringAnsi(pi.vars[i].d.fdeclared));
	                pi.vars[i].filename=Path.GetFileName(pi.vars[i].fdeclared).ToLowerInvariant();
                }
                if(pi.vars[i].d.numRefs==0) {
                    pi.vars[i].references=new Ref[0];
                } else {
                    int[] tmp=new int[pi.vars[i].d.numRefs*2];
                    getVarRefs(i, tmp);
                    pi.vars[i].references=new Ref[pi.vars[i].d.numRefs];
                    for(int j=0;j<pi.vars[i].d.numRefs;j++) pi.vars[i].references[j]=new Ref(tmp[j*2], tmp[j*2+1]);
                }
            }
            //Procedures
            for(int i=0;i<pi.procs.Length;i++) {
                pi.procs[i]=new Procedure();
                getProc(i, out pi.procs[i].d);
                pi.procs[i].name=ParseName(names, pi.procs[i].d.name);
                if (pi.procs[i].d.fdeclared != IntPtr.Zero) {
                	//pi.procs[i].fdeclared=Marshal.PtrToStringAnsi(pi.procs[i].d.fdeclared);
	                pi.procs[i].fdeclared=Path.GetFullPath(Marshal.PtrToStringAnsi(pi.procs[i].d.fdeclared));
	                pi.procs[i].filename=Path.GetFileName(pi.procs[i].fdeclared).ToLowerInvariant();
                }
                if (pi.procs[i].d.fstart != IntPtr.Zero) {
                	//pi.procs[i].fstart = Marshal.PtrToStringAnsi(pi.procs[i].d.fstart);
                	pi.procs[i].fstart = Path.GetFullPath(Marshal.PtrToStringAnsi(pi.procs[i].d.fstart));
                }
                //pi.procs[i].fend=Marshal.PtrToStringAnsi(pi.procs[i].d.fend);
                if(pi.procs[i].d.numRefs==0) {
                    pi.procs[i].references=new Ref[0];
                } else {
                    int[] tmp=new int[pi.procs[i].d.numRefs*2];
                    getProcRefs(i, tmp);
                    pi.procs[i].references = new Ref[pi.procs[i].d.numRefs];
                    for(int j=0;j<pi.procs[i].d.numRefs;j++) pi.procs[i].references[j]=new Ref(tmp[j*2], tmp[j*2+1]);
                }
                //Procedure variables
                if(getProcNamespaceSize(i)==-1) {
                    pi.procs[i].variables = new Variable[0];
                } else {
                    byte[] procnames = new byte[getProcNamespaceSize(i)];
                    getProcNamespace(i, procnames);
                    pi.procs[i].variables = new Variable[pi.procs[i].d.numVariables];
                    for(int j = 0; j < pi.procs[i].variables.Length; j++) {
                        Variable var = pi.procs[i].variables[j] = new Variable();
                        getProcVar(i, j, out var.d);
                        var.name = ParseName(procnames, var.d.name);
                        if (var.d.initialized != 0) {
	                        switch (var.d.initialType) {
			            		case ValueType.Int:
			                		var.initialValue = var.d.intValue.ToString();
			                		break;
			            		case ValueType.Float:
			                		var.initialValue = var.d.floatValue.ToString();
			                		break;
			                	case ValueType.String:
			                		var.initialValue = '"' + ParseName(strings, var.d.intValue) + '"';
			                		break;
			                }
                        }
                        var.fdeclared=Marshal.PtrToStringAnsi(var.d.fdeclared);
                        if (var.d.numRefs==0) {
                            var.references=new Ref[0];
                        } else {
                            int[] tmp = new int[var.d.numRefs*2];
                            getProcVarRefs(i, j, tmp);
                            var.references = new Ref[var.d.numRefs];
                            for (int k = 0; k < var.d.numRefs; k++) 
                            	var.references[k] = new Ref(tmp[k*2], tmp[k*2+1]);
                        }
                    }
                }
            }
            pi.BuildDictionaries();
            return pi;
        }

#if DLL_COMPILER
        [System.Runtime.InteropServices.DllImport("resources\\sslc.dll")]
        private static extern int compile_main(int argc, string[] argv);

        [System.Runtime.InteropServices.DllImport("resources\\sslc.dll")]
        private static extern IntPtr FetchBuffer();
#endif

        public static bool Compile(string infile, out string output, List<Error> errors, bool preprocessOnly) {
            if(errors!=null) errors.Clear();
            if(infile==null) {
                output="No filename specified";
                return false;
            }
            infile=Path.GetFullPath(infile);
#if DLL_COMPILER
            string origpath=Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(Path.GetDirectoryName(infile));
            string[] args=Settings.GetSslcCommandLine(infile, preprocessOnly);
            bool success=compile_main(args.Length, args)==0;
            output=System.Runtime.InteropServices.Marshal.PtrToStringAnsi(FetchBuffer());
            Directory.SetCurrentDirectory(origpath);
#else

#if DEBUG
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Games\Fallout2\Tools\Mapper\scripts\compile.exe", Settings.GetSslcCommandLine(infile, preprocessOnly));
#else
            ProcessStartInfo psi = new ProcessStartInfo("resources\\compile.exe", Settings.GetSslcCommandLine(infile, preprocessOnly));
#endif
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.UseShellExecute=false;
            psi.CreateNoWindow=true;
            psi.WorkingDirectory=Path.GetDirectoryName(infile);
            Process p = Process.Start(psi);
            p.StandardInput.WriteLine();
            output = p.StandardOutput.ReadToEnd();
            p.StandardInput.WriteLine();
        	p.WaitForExit(1000);
            bool success=p.ExitCode==0;
            p.Dispose();
#endif
            if(errors!=null) {
                foreach(string s in output.Split(new char[] { '\n' })) {
                    if(s.StartsWith("[Error]")||s.StartsWith("[Warning]")||s.StartsWith("[Message]")) {
                        Error e=new Error();
                        if(s[1]=='E') e.type=ErrorType.Error; else if(s[1]=='W') e.type=ErrorType.Warning; else e.type=ErrorType.Message;
                        Match m = Regex.Match(s, @"\[\w+\]\s*\<([^\>]+)\>\s*\:(\-?\d+):?(\-?\d+)?\:\s*(.*)");
                        e.fileName = m.Groups[1].Value;
                    	e.line = int.Parse(m.Groups[2].Value);
                        if (m.Groups[3].Value.Length > 0)
                        	e.column = int.Parse(m.Groups[3].Value);
                        e.msg = m.Groups[4].Value;
                        if (e.fileName != "none" && !Path.IsPathRooted(e.fileName)) 
                        	e.fileName=Path.GetFullPath(Path.Combine(Path.GetDirectoryName(infile), e.fileName));
                        errors.Add(e);
                    }
                }
            }
#if DLL_COMPILER
            output=output.Replace("\n", "\r\n");
#endif

            //Debugging section to locate scripts which fail to compile with optimization
            /*if(!success||preprocessOnly) return success;
            psi=new ProcessStartInfo(@"C:\Games\Fallout2\Tools\Mapper\scripts\compile.exe", "-O "+Settings.GetSslcCommandLine(infile, false));
            psi.RedirectStandardOutput=true;
            psi.UseShellExecute=false;
            psi.CreateNoWindow=true;
            psi.WorkingDirectory=Path.GetDirectoryName(infile);
            p=Process.Start(psi);
            output=p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            if(p.ExitCode!=0) {
                int iii=0;
            }
            p.Dispose();*/

            return success;
        }

        public static string Decompile(string infile) {
#if DEBUG
            ProcessStartInfo psi=new ProcessStartInfo(@"C:\Games\Fallout2\Tools\Mapper\scripts\int2ssl.exe", "\""+infile+"\" \""+decompilationPath+"\"");
#else
            ProcessStartInfo psi=new ProcessStartInfo("resources\\int2ssl.exe", "\""+infile+"\" \""+decompilationPath+"\"");
#endif
            psi.UseShellExecute=false;
            psi.CreateNoWindow=true;
            Process p=Process.Start(psi);
            p.WaitForExit(3000);
            if(!p.HasExited) return null;
            if(!File.Exists(decompilationPath)) return null;
            string result=File.ReadAllText(decompilationPath);
            File.Delete(decompilationPath);
            return result;
        }
    }
}
