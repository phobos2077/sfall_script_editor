using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptEditor
{
    public class AutoCompleteItem
    {
        public string name;
        public string hint;

        public AutoCompleteItem(string _name, string _hint)
        {
            name = _name;
            hint = _hint;
        }

        public override string ToString()
        {
            return name;
        }

        public string GetHint()
        {
            return hint;
        }
    }
}
