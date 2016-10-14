using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ScriptEditor
{
    public enum SavedWindows { Main, Count }

    public static class Settings
    {
        public static readonly string SettingsFolder = Path.Combine(Environment.CurrentDirectory, "settings");
        private static readonly string SettingsPath = Path.Combine(SettingsFolder, "settings.dat");
        private static readonly string preprocessPath = Path.Combine(Settings.SettingsFolder, "preprocess.ssl");

        const int MAX_RECENT = 30;

        public static byte optimize = 1;
        public static bool showWarnings = true;
        public static bool showDebug = true;
        public static bool showLogo = true;
        public static bool warnOnFailedCompile = true;
        public static bool multiThreaded = true;
        public static bool autoOpenMsgs = true;
        public static string outputDir;
        public static string scriptsHFile;
        public static string lastMassCompile;
        public static string lastSearchPath;
        private static readonly List<string> recent = new List<string>();
        private static readonly WindowPos[] windowPositions = new WindowPos[(int)SavedWindows.Count];
        public static int editorSplitterPosition = -1;
        public static int editorSplitterPosition2 = -1;
        public static string language = "english";
        public static bool tabsToSpaces = true;
        public static int tabSize = 3;
        public static bool enableParser = true;
        public static bool shortCircuit = false;
        public static bool autocomplete = true;

        public static void SetupWindowPosition(SavedWindows window, System.Windows.Forms.Form f)
        {
            WindowPos wp = windowPositions[(int)window];
            if (wp.width == 0)
                return;
            f.Location = new System.Drawing.Point(wp.x, wp.y);
            if (wp.maximized)
                f.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            else
                f.ClientSize = new System.Drawing.Size(wp.width, wp.height);
            f.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        }

        public static void SaveWindowPosition(SavedWindows window, System.Windows.Forms.Form f)
        {
            WindowPos wp = new WindowPos();
            wp.maximized = f.WindowState == System.Windows.Forms.FormWindowState.Maximized;
            wp.x = f.Location.X;
            wp.y = f.Location.Y;
            wp.width = f.ClientSize.Width;
            wp.height = f.ClientSize.Height;
            windowPositions[(int)window] = wp;
        }

        public static void AddRecentFile(string s)
        {
            for (int i = 0; i < recent.Count; i++) {
                if (string.Compare(recent[i], s, true) == 0)
                    recent.RemoveAt(i--);
            }
            if (recent.Count >= MAX_RECENT)
                recent.RemoveAt(0);
            recent.Add(s);
        }

        public static string[] GetRecent() { return recent.ToArray(); }

        private static void LoadWindowPos(BinaryReader br, int i)
        {
            windowPositions[i].maximized = br.ReadBoolean();
            windowPositions[i].x = br.ReadInt32();
            windowPositions[i].y = br.ReadInt32();
            windowPositions[i].width = br.ReadInt32();
            windowPositions[i].height = br.ReadInt32();
        }
        private static void LoadInternal(BinaryReader br)
        {
            int version = br.ReadInt32();
            optimize = br.ReadByte();
            showWarnings = br.ReadBoolean();
            showDebug = br.ReadBoolean();
            showLogo = br.ReadBoolean();
            outputDir = br.ReadString();
            if (outputDir.Length == 0)
                outputDir = null;
            int recentItems = br.ReadByte();
            for (int i = 0; i < recentItems; i++)
                recent.Add(br.ReadString());
            if (version == 1)
                return;
            warnOnFailedCompile = br.ReadBoolean();
            multiThreaded = br.ReadBoolean();
            lastMassCompile = br.ReadString();
            if (lastMassCompile.Length == 0)
                lastMassCompile = null;
            if (version == 2)
                return;
            lastSearchPath = br.ReadString();
            if (lastSearchPath.Length == 0)
                lastSearchPath = null;
            LoadWindowPos(br, 0);
            editorSplitterPosition = br.ReadInt32();
            if (version == 3)
                return;
            autoOpenMsgs = br.ReadBoolean();
            editorSplitterPosition2 = br.ReadInt32();
            if (version == 4)
                return;
            scriptsHFile = br.ReadString();
            if (scriptsHFile.Length == 0)
                scriptsHFile = null;
            if (version == 5)
                return;
            language = br.ReadString();
            if (language.Length == 0)
                language = "english";
            if (version == 6)
                return;
            tabsToSpaces = br.ReadBoolean();
            tabSize = br.ReadInt32();
            if (version == 7)
                return;
            enableParser = br.ReadBoolean();
            if (version == 8)
                return;
            shortCircuit = br.ReadBoolean();
            if (version == 9)
                return;
            autocomplete = br.ReadBoolean();
        }
        public static void Load()
        {
            if (!File.Exists(SettingsPath))
                return;
            recent.Clear();
            BinaryReader br = new BinaryReader(File.OpenRead(SettingsPath));
            LoadInternal(br);
            br.Close();
        }

        private static void WriteWindowPos(BinaryWriter bw, int i)
        {
            bw.Write(windowPositions[i].maximized);
            bw.Write(windowPositions[i].x);
            bw.Write(windowPositions[i].y);
            bw.Write(windowPositions[i].width);
            bw.Write(windowPositions[i].height);
        }
        public static void Save()
        {
            if (!Directory.Exists(SettingsFolder))
                Directory.CreateDirectory(SettingsFolder);
            BinaryWriter bw = new BinaryWriter(File.Create(SettingsPath));
            bw.Write(10);
            bw.Write(optimize);
            bw.Write(showWarnings);
            bw.Write(showDebug);
            bw.Write(showLogo);
            bw.Write(outputDir == null ? "" : outputDir);
            bw.Write((byte)recent.Count);
            for (int i = 0; i < recent.Count; i++)
                bw.Write(recent[i]);
            bw.Write(warnOnFailedCompile);
            bw.Write(multiThreaded);
            bw.Write(lastMassCompile == null ? "" : lastMassCompile);
            bw.Write(lastSearchPath == null ? "" : lastSearchPath);
            WriteWindowPos(bw, 0);
            bw.Write(editorSplitterPosition);
            bw.Write(autoOpenMsgs);
            bw.Write(editorSplitterPosition2);
            bw.Write(scriptsHFile == null ? "" : scriptsHFile);
            bw.Write(language == null ? "english" : language);
            bw.Write(tabsToSpaces);
            bw.Write(tabSize);
            bw.Write(enableParser);
            bw.Write(shortCircuit);
            bw.Write(autocomplete);
            bw.Close();
        }

        public static string GetPreprocessedFile()
        {
            if (!File.Exists(preprocessPath))
                return null;
            return File.ReadAllText(preprocessPath);
        }

        public static string GetOutputPath(string infile)
        {
            return Path.Combine(outputDir, Path.GetFileNameWithoutExtension(infile)) + ".int";
        }


#if DLL_COMPILER
        public static string[] GetSslcCommandLine(string infile, bool preprocess) {
            return new string[] {
                "--", "-q",
                preprocess?"-P":"-p",
                optimize?"-O":"--",
                showWarnings?"--":"-n ",
                showDebug?"-d":"--",
                showLogo?"":"-l",
                Path.GetFileName(infile),
                "-o",
                preprocess?preprocessPath:GetOutputPath(infile),
                null
            };
#else
        public static string GetSslcCommandLine(string infile, bool preprocess)
        {
            return (preprocess ? "-P " : "-p ")
                + ("-O" + optimize + " ")
                + (showWarnings ? "" : "-n ")
                + (showDebug ? "-d " : "")
                + (showLogo ? "" : "-l ")
                + (shortCircuit ? "-s " : "")
                + "\"" + Path.GetFileName(infile) + "\" -o \"" + (preprocess ? preprocessPath : GetOutputPath(infile)) + "\"";
#endif
        }

        struct WindowPos
        {
            public bool maximized;
            public int x, y, width, height;
        } 
    }
}
