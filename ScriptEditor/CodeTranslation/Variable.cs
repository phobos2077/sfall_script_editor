using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptEditor.CodeTranslation
{
    public class Variable : IParserInfo
    {
        public string name;
        public string fdeclared;
        public string filename;
        public VariableData d;
        public Reference[] references;
        public string initialValue;

        public NameType Type() { return d.type == VarType.Local ? NameType.LVar : NameType.GVar; }
        public Reference[] References() { return references; }
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
}
