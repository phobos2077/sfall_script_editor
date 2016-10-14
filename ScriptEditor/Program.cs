using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScriptEditor {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
        	Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Settings.Load();
            TextEditor te=new TextEditor();
            foreach(string s in args) te.Open(s, TextEditor.OpenType.File);
            Application.Run(te);
        }
    }
}
