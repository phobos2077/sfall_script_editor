using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.TextEditor.Document;
using ScriptEditor.CodeTranslation;

namespace ScriptEditor.TextEditorUI
{
    /// <summary>
    /// SSL code folding strategy for ICSharpCode.TextEditor.
    /// </summary>
    public class CodeFolder : IFoldingStrategy
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
