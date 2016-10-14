using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ScriptEditor {
    static class Program {		
		static Mutex mutex = new Mutex(true, "SFALL_SCRIPT_EDITOR");	
		
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
        	Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
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
	            Application.Run(te);
	            mutex.ReleaseMutex();
        	} else {
        		// pass command line arguments via file
        		File.WriteAllLines(NativeMethods.CommandLineFile, args);
        		// send message to other instance
        		NativeMethods.PostMessage(
        			(IntPtr)NativeMethods.HWND_BROADCAST,
        		    NativeMethods.WM_SFALL_SCRIPT_EDITOR_OPEN, 
        		    IntPtr.Zero, 
        		    IntPtr.Zero);
        	}
        }
    }
}
