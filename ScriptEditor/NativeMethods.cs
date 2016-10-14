using System;
using System.Runtime.InteropServices;

namespace ScriptEditor
{
	/// <summary>
	/// A set of user32.dll bindings to interact with another copy of application.
	/// </summary>
	public static class NativeMethods
	{		
		public const int HWND_BROADCAST = 0xffff;
		
		public const string CommandLineFile = "commandline.txt";
		
	    [DllImport("user32")]
	    public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
	    
	    [DllImport("user32")]
	    public static extern int RegisterWindowMessage(string message);
	    
	    public static readonly int WM_SFALL_SCRIPT_EDITOR_OPEN = RegisterWindowMessage("WM_SFALL_SCRIPT_EDITOR_OPEN");
	}
}
