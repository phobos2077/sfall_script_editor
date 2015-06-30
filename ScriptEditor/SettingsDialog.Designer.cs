namespace ScriptEditor {
    partial class SettingsDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
        	this.components = new System.ComponentModel.Container();
        	System.Windows.Forms.Label label1;
        	System.Windows.Forms.Label label4;
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
        	this.cbWarnings = new System.Windows.Forms.CheckBox();
        	this.cbDebug = new System.Windows.Forms.CheckBox();
        	this.cbLogo = new System.Windows.Forms.CheckBox();
        	this.bChange = new System.Windows.Forms.Button();
        	this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        	this.label2 = new System.Windows.Forms.Label();
        	this.cbWarnFailedCompile = new System.Windows.Forms.CheckBox();
        	this.cbMultiThread = new System.Windows.Forms.CheckBox();
        	this.cbAutoOpenMessages = new System.Windows.Forms.CheckBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.bScriptsH = new System.Windows.Forms.Button();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.tbLanguage = new System.Windows.Forms.TextBox();
        	this.label5 = new System.Windows.Forms.Label();
        	this.cbOptimize = new System.Windows.Forms.ComboBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.tbTabSize = new System.Windows.Forms.TextBox();
        	this.cbTabsToSpaces = new System.Windows.Forms.CheckBox();
        	this.label7 = new System.Windows.Forms.Label();
        	this.cbEnableParser = new System.Windows.Forms.CheckBox();
        	this.cbShortCircuit = new System.Windows.Forms.CheckBox();
        	this.toolTip = new System.Windows.Forms.ToolTip(this.components);
        	this.cbAutocomplete = new System.Windows.Forms.CheckBox();
        	label1 = new System.Windows.Forms.Label();
        	label4 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	label1.AutoSize = true;
        	label1.Location = new System.Drawing.Point(12, 91);
        	label1.Name = "label1";
        	label1.Size = new System.Drawing.Size(107, 13);
        	label1.TabIndex = 5;
        	label1.Text = "Compiled scripts path";
        	// 
        	// label4
        	// 
        	label4.AutoSize = true;
        	label4.Location = new System.Drawing.Point(12, 148);
        	label4.Name = "label4";
        	label4.Size = new System.Drawing.Size(70, 13);
        	label4.TabIndex = 11;
        	label4.Text = "scripts.h path";
        	// 
        	// cbWarnings
        	// 
        	this.cbWarnings.AutoSize = true;
        	this.cbWarnings.Location = new System.Drawing.Point(12, 12);
        	this.cbWarnings.Name = "cbWarnings";
        	this.cbWarnings.Size = new System.Drawing.Size(101, 17);
        	this.cbWarnings.TabIndex = 0;
        	this.cbWarnings.Text = "Show Warnings";
        	this.cbWarnings.UseVisualStyleBackColor = true;
        	// 
        	// cbDebug
        	// 
        	this.cbDebug.AutoSize = true;
        	this.cbDebug.Location = new System.Drawing.Point(12, 35);
        	this.cbDebug.Name = "cbDebug";
        	this.cbDebug.Size = new System.Drawing.Size(119, 17);
        	this.cbDebug.TabIndex = 1;
        	this.cbDebug.Text = "Show debug output";
        	this.cbDebug.UseVisualStyleBackColor = true;
        	// 
        	// cbLogo
        	// 
        	this.cbLogo.AutoSize = true;
        	this.cbLogo.Location = new System.Drawing.Point(156, 35);
        	this.cbLogo.Name = "cbLogo";
        	this.cbLogo.Size = new System.Drawing.Size(111, 17);
        	this.cbLogo.TabIndex = 3;
        	this.cbLogo.Text = "Show startup logo";
        	this.cbLogo.UseVisualStyleBackColor = true;
        	// 
        	// bChange
        	// 
        	this.bChange.Location = new System.Drawing.Point(12, 120);
        	this.bChange.Name = "bChange";
        	this.bChange.Size = new System.Drawing.Size(110, 23);
        	this.bChange.TabIndex = 4;
        	this.bChange.Text = "Change";
        	this.bChange.UseVisualStyleBackColor = true;
        	this.bChange.Click += new System.EventHandler(this.bChange_Click);
        	// 
        	// folderBrowserDialog1
        	// 
        	this.folderBrowserDialog1.Description = "Select compiled scripts folder";
        	this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 104);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(35, 13);
        	this.label2.TabIndex = 6;
        	this.label2.Text = "label2";
        	// 
        	// cbWarnFailedCompile
        	// 
        	this.cbWarnFailedCompile.AutoSize = true;
        	this.cbWarnFailedCompile.Location = new System.Drawing.Point(12, 58);
        	this.cbWarnFailedCompile.Name = "cbWarnFailedCompile";
        	this.cbWarnFailedCompile.Size = new System.Drawing.Size(134, 17);
        	this.cbWarnFailedCompile.TabIndex = 7;
        	this.cbWarnFailedCompile.Text = "Warn on failed compile";
        	this.cbWarnFailedCompile.UseVisualStyleBackColor = true;
        	// 
        	// cbMultiThread
        	// 
        	this.cbMultiThread.AutoSize = true;
        	this.cbMultiThread.Location = new System.Drawing.Point(156, 58);
        	this.cbMultiThread.Name = "cbMultiThread";
        	this.cbMultiThread.Size = new System.Drawing.Size(156, 17);
        	this.cbMultiThread.TabIndex = 8;
        	this.cbMultiThread.Text = "Multithreaded mass compile";
        	this.cbMultiThread.UseVisualStyleBackColor = true;
        	// 
        	// cbAutoOpenMessages
        	// 
        	this.cbAutoOpenMessages.AutoSize = true;
        	this.cbAutoOpenMessages.Location = new System.Drawing.Point(156, 120);
        	this.cbAutoOpenMessages.Name = "cbAutoOpenMessages";
        	this.cbAutoOpenMessages.Size = new System.Drawing.Size(141, 17);
        	this.cbAutoOpenMessages.TabIndex = 9;
        	this.cbAutoOpenMessages.Text = "Auto-open message files";
        	this.cbAutoOpenMessages.UseVisualStyleBackColor = true;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 161);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(35, 13);
        	this.label3.TabIndex = 12;
        	this.label3.Text = "label3";
        	// 
        	// bScriptsH
        	// 
        	this.bScriptsH.Location = new System.Drawing.Point(12, 177);
        	this.bScriptsH.Name = "bScriptsH";
        	this.bScriptsH.Size = new System.Drawing.Size(110, 23);
        	this.bScriptsH.TabIndex = 10;
        	this.bScriptsH.Text = "Change";
        	this.bScriptsH.UseVisualStyleBackColor = true;
        	this.bScriptsH.Click += new System.EventHandler(this.bScriptsH_Click);
        	// 
        	// openFileDialog1
        	// 
        	this.openFileDialog1.DefaultExt = "h";
        	this.openFileDialog1.FileName = "scripts.h";
        	this.openFileDialog1.Filter = "Header files|*.h";
        	this.openFileDialog1.RestoreDirectory = true;
        	this.openFileDialog1.Title = "Select scripts.h";
        	// 
        	// tbLanguage
        	// 
        	this.tbLanguage.Location = new System.Drawing.Point(156, 139);
        	this.tbLanguage.MaxLength = 8;
        	this.tbLanguage.Name = "tbLanguage";
        	this.tbLanguage.Size = new System.Drawing.Size(95, 20);
        	this.tbLanguage.TabIndex = 13;
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(257, 140);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(73, 13);
        	this.label5.TabIndex = 14;
        	this.label5.Text = "msg language";
        	// 
        	// cbOptimize
        	// 
        	this.cbOptimize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cbOptimize.FormattingEnabled = true;
        	this.cbOptimize.Items.AddRange(new object[] {
        	        	        	"None",
        	        	        	"Basic",
        	        	        	"Full",
        	        	        	"Experimental"});
        	this.cbOptimize.Location = new System.Drawing.Point(156, 10);
        	this.cbOptimize.Name = "cbOptimize";
        	this.cbOptimize.Size = new System.Drawing.Size(95, 21);
        	this.cbOptimize.TabIndex = 15;
        	this.toolTip.SetToolTip(this.cbOptimize, resources.GetString("cbOptimize.ToolTip"));
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(257, 13);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(64, 13);
        	this.label6.TabIndex = 16;
        	this.label6.Text = "Optimization";
        	// 
        	// tbTabSize
        	// 
        	this.tbTabSize.Location = new System.Drawing.Point(156, 198);
        	this.tbTabSize.MaxLength = 8;
        	this.tbTabSize.Name = "tbTabSize";
        	this.tbTabSize.Size = new System.Drawing.Size(40, 20);
        	this.tbTabSize.TabIndex = 17;
        	this.tbTabSize.TextChanged += new System.EventHandler(this.TbTabSizeTextChanged);
        	// 
        	// cbTabsToSpaces
        	// 
        	this.cbTabsToSpaces.AutoSize = true;
        	this.cbTabsToSpaces.Location = new System.Drawing.Point(156, 177);
        	this.cbTabsToSpaces.Name = "cbTabsToSpaces";
        	this.cbTabsToSpaces.Size = new System.Drawing.Size(135, 17);
        	this.cbTabsToSpaces.TabIndex = 18;
        	this.cbTabsToSpaces.Text = "Convert tabs to spaces";
        	this.cbTabsToSpaces.UseVisualStyleBackColor = true;
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Location = new System.Drawing.Point(202, 201);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(91, 13);
        	this.label7.TabIndex = 19;
        	this.label7.Text = "tab size in spaces";
        	// 
        	// cbEnableParser
        	// 
        	this.cbEnableParser.AutoSize = true;
        	this.cbEnableParser.Location = new System.Drawing.Point(156, 224);
        	this.cbEnableParser.Name = "cbEnableParser";
        	this.cbEnableParser.Size = new System.Drawing.Size(91, 17);
        	this.cbEnableParser.TabIndex = 8;
        	this.cbEnableParser.Text = "Enable parser";
        	this.toolTip.SetToolTip(this.cbEnableParser, "Enable parsing currently opened scripts.\r\nThis includes \"Find declaration\", \"Find" +
        	        	" references\" and similar functions,\r\nas well as right panel with program globals" +
        	        	".");
        	this.cbEnableParser.UseVisualStyleBackColor = true;
        	// 
        	// cbShortCircuit
        	// 
        	this.cbShortCircuit.AutoSize = true;
        	this.cbShortCircuit.Location = new System.Drawing.Point(156, 81);
        	this.cbShortCircuit.Name = "cbShortCircuit";
        	this.cbShortCircuit.Size = new System.Drawing.Size(134, 17);
        	this.cbShortCircuit.TabIndex = 20;
        	this.cbShortCircuit.Text = "Short-circuit evaluation";
        	this.toolTip.SetToolTip(this.cbShortCircuit, resources.GetString("cbShortCircuit.ToolTip"));
        	this.cbShortCircuit.UseVisualStyleBackColor = true;
        	// 
        	// toolTip
        	// 
        	this.toolTip.AutoPopDelay = 30000;
        	this.toolTip.InitialDelay = 500;
        	this.toolTip.ReshowDelay = 100;
        	// 
        	// cbAutocomplete
        	// 
        	this.cbAutocomplete.AutoSize = true;
        	this.cbAutocomplete.Location = new System.Drawing.Point(156, 247);
        	this.cbAutocomplete.Name = "cbAutocomplete";
        	this.cbAutocomplete.Size = new System.Drawing.Size(126, 17);
        	this.cbAutocomplete.TabIndex = 21;
        	this.cbAutocomplete.Text = "Enable autocomplete";
        	this.toolTip.SetToolTip(this.cbAutocomplete, "Enable displaying box with a list of suggested procedure names, \r\nvariables, cons" +
        	        	"tants and macros as you type.");
        	this.cbAutocomplete.UseVisualStyleBackColor = true;
        	// 
        	// SettingsDialog
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(335, 267);
        	this.Controls.Add(this.cbAutocomplete);
        	this.Controls.Add(this.cbShortCircuit);
        	this.Controls.Add(this.label7);
        	this.Controls.Add(this.cbTabsToSpaces);
        	this.Controls.Add(this.tbTabSize);
        	this.Controls.Add(this.label6);
        	this.Controls.Add(this.cbOptimize);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.tbLanguage);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(label4);
        	this.Controls.Add(this.bScriptsH);
        	this.Controls.Add(this.cbAutoOpenMessages);
        	this.Controls.Add(this.cbEnableParser);
        	this.Controls.Add(this.cbMultiThread);
        	this.Controls.Add(this.cbWarnFailedCompile);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(label1);
        	this.Controls.Add(this.bChange);
        	this.Controls.Add(this.cbLogo);
        	this.Controls.Add(this.cbDebug);
        	this.Controls.Add(this.cbWarnings);
        	this.Name = "SettingsDialog";
        	this.Text = "Settings";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDialog_FormClosing);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.CheckBox cbAutocomplete;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbShortCircuit;
        private System.Windows.Forms.CheckBox cbEnableParser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTabSize;
        private System.Windows.Forms.CheckBox cbTabsToSpaces;

        #endregion

        private System.Windows.Forms.CheckBox cbWarnings;
        private System.Windows.Forms.CheckBox cbDebug;
        private System.Windows.Forms.CheckBox cbLogo;
        private System.Windows.Forms.Button bChange;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbWarnFailedCompile;
        private System.Windows.Forms.CheckBox cbMultiThread;
        private System.Windows.Forms.CheckBox cbAutoOpenMessages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bScriptsH;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbLanguage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbOptimize;
        private System.Windows.Forms.Label label6;
    }
}