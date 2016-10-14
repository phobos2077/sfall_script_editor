//#define DLL_COMPILER

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ICSharpCode.TextEditor.Document;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ScriptEditor
{
    enum ErrorType { Error, Warning, Message, Search }

    class Error
    {
        public ErrorType type;
        public string msg;
        public string fileName;
        public int line;
        public int column = -1;

        public override string ToString()
        {
            return msg;
        }
    }

    class TabInfo
    {
        public ICSharpCode.TextEditor.TextEditorControl te;
        public int index;
        public string filepath;
        public string filename;
        public bool changed;
        public TabInfo msg;
        public readonly Dictionary<int, string> messages = new Dictionary<int, string>();
        public bool shouldParse;
        public bool needsParse;
        public ProgramInfo parseInfo;
    }

    class CodeFolder : IFoldingStrategy
    {
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            ProgramInfo pi = (ProgramInfo)parseInformation;
            List<FoldMarker> list = new List<FoldMarker>(pi.procs.Length);

            fileName = fileName.ToLowerInvariant();
            for (int i = 0; i < pi.procs.Length; i++) {
                if (pi.procs[i].filename != fileName)
                    continue;
                list.Add(new FoldMarker(document, pi.procs[i].d.start - 1, 0, pi.procs[i].d.end - 1, 0, FoldType.MemberBody));
            }
            return list;
        }
    }    
}
