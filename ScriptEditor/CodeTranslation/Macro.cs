using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptEditor.CodeTranslation
{
    public class Macro : IParserInfo
    {
        public readonly string name;
        public readonly string def;
        public readonly int declared;
        public readonly string fdeclared;

        public NameType Type() { return NameType.Macro; }
        public Reference[] References() { return null; }
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
}
