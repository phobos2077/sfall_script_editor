using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptEditor.TextEditorUI
{
    public enum ErrorType { Error, Warning, Message, Search }

    public class Error
    {
        public ErrorType type = ErrorType.Error;
        public string message;
        public string fileName;
        public int line;
        public int column;

        public Error() { }

        public Error(ErrorType type, string message, string fileName, int line, int column = -1)
        {
            this.type = type;
            this.message = message;
            this.fileName = fileName;
            this.line = line;
            this.column = column;
        }

        public Error(string message, string fileName, int line, int column = -1)
        {
            this.message = message;
            this.fileName = fileName;
            this.line = line;
            this.column = column;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
