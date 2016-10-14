using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ScriptEditor
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "SFALL_SCRIPT_EDITOR");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // check if another instance is already running
            if (mutex.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Settings.Load();
                TextEditor te = new TextEditor();
                // open documents passed from command line
                foreach (string s in args) {
                    te.Open(s, TextEditor.OpenType.File);
                }
                // reset working folder to EXE directory (to resolve possible issues in parse_main)
                Directory.SetCurrentDirectory(Settings.ProgramFolder);
                Application.Run(te);
                mutex.ReleaseMutex();
            } else {
                // only show message if opened normally without command line arguments
                if (args.Length == 0) {
                    MessageBox.Show("Another instance is already running!", "Sfall Script Editor");
                }

                // pass command line arguments via file
                SingleInstanceManager.SaveCommandLine(args);
                // send message to other instance
                SingleInstanceManager.SendEditorOpenMessage();
            }
        }
    }
}
