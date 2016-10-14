using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptEditor.CodeTranslation
{
    public interface IParserInfo
    {
        NameType Type();

        Reference[] References();
        void Deceleration(out string file, out int line);
    }
}
