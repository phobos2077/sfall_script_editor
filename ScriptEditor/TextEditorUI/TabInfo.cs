using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.TextEditor;
using ScriptEditor.CodeTranslation;

namespace ScriptEditor.TextEditorUI
{
    /// <summary>
    /// Represents opened document tab.
    /// </summary>
    public class TabInfo
    {
        /// <summary>
        /// The tab index.
        /// </summary>
        public int index;

        /// <summary>
        /// The TextEditor control of this tab.
        /// </summary>
        public TextEditorControl textEditor;

        public string filepath;

        public string filename;

        public bool changed;

        /// <summary>
        /// An opened tab with MSG file associated with currently opened SSL.
        /// </summary>
        public TabInfo msgFileTab;

        public readonly Dictionary<int, string> messages = new Dictionary<int, string>();

        /// <summary>
        /// Indicates whether parsing is required for this tab (usually true for .SSL or .H files).
        /// </summary>
        public bool shouldParse;

        /// <summary>
        /// Indicates whether this tab is pending parsing (eg. after text change).
        /// </summary>
        public bool needsParse;

        public ProgramInfo parseInfo;
    }
}
