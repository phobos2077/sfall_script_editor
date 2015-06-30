namespace ScriptEditor {
    partial class TextEditor {
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
        	System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        	System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        	System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.lbAutocomplete = new System.Windows.Forms.ListBox();
        	this.splitContainer2 = new System.Windows.Forms.SplitContainer();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.tabControl1 = new DraggableTabControl();
        	this.tabControl2 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.tbOutput = new System.Windows.Forms.TextBox();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.dgvErrors = new System.Windows.Forms.DataGridView();
        	this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.cFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.cLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.cMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.tbOutputParse = new System.Windows.Forms.TextBox();
        	this.treeView1 = new System.Windows.Forms.TreeView();
        	this.MainMenu = new System.Windows.Forms.MenuStrip();
        	this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        	this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.outlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.goToLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
        	this.uPPERCASEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.lowecaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.compileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.compileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.compileAllOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.massCompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.preprocessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.roundtripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.registerScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.editRegisteredScriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.associateMsgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.headsFrmPatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.readmeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.cmsTabControls = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.closeAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.ofdScripts = new System.Windows.Forms.OpenFileDialog();
        	this.sfdScripts = new System.Windows.Forms.SaveFileDialog();
        	this.fbdMassCompile = new System.Windows.Forms.FolderBrowserDialog();
        	this.bwSyntaxParser = new System.ComponentModel.BackgroundWorker();
        	this.editorMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.findReferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.findDeclerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.findDefinitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.openIncludeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolTipAC = new System.Windows.Forms.ToolTip(this.components);
        	toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        	this.panel1.SuspendLayout();
        	this.splitContainer2.Panel1.SuspendLayout();
        	this.splitContainer2.Panel2.SuspendLayout();
        	this.splitContainer2.SuspendLayout();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.tabControl2.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
        	this.tabPage3.SuspendLayout();
        	this.MainMenu.SuspendLayout();
        	this.cmsTabControls.SuspendLayout();
        	this.editorMenuStrip.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// toolStripSeparator1
        	// 
        	toolStripSeparator1.Name = "toolStripSeparator1";
        	toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
        	// 
        	// toolStripSeparator2
        	// 
        	toolStripSeparator2.Name = "toolStripSeparator2";
        	toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
        	// 
        	// toolStripSeparator5
        	// 
        	toolStripSeparator5.Name = "toolStripSeparator5";
        	toolStripSeparator5.Size = new System.Drawing.Size(208, 6);
        	// 
        	// panel1
        	// 
        	this.panel1.Controls.Add(this.lbAutocomplete);
        	this.panel1.Controls.Add(this.splitContainer2);
        	this.panel1.Controls.Add(this.MainMenu);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel1.Location = new System.Drawing.Point(0, 0);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(503, 424);
        	this.panel1.TabIndex = 2;
        	// 
        	// lbAutocomplete
        	// 
        	this.lbAutocomplete.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.lbAutocomplete.FormattingEnabled = true;
        	this.lbAutocomplete.IntegralHeight = false;
        	this.lbAutocomplete.ItemHeight = 16;
        	this.lbAutocomplete.Location = new System.Drawing.Point(246, 0);
        	this.lbAutocomplete.Name = "lbAutocomplete";
        	this.lbAutocomplete.Size = new System.Drawing.Size(226, 108);
        	this.lbAutocomplete.TabIndex = 5;
        	this.lbAutocomplete.Visible = false;
        	this.lbAutocomplete.SelectedIndexChanged += new System.EventHandler(this.LbAutocompleteSelectedIndexChanged);
        	this.lbAutocomplete.VisibleChanged += new System.EventHandler(this.LbAutocompleteVisibleChanged);
        	this.lbAutocomplete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LbAutocompleteKeyDown);
        	// 
        	// splitContainer2
        	// 
        	this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer2.Location = new System.Drawing.Point(0, 24);
        	this.splitContainer2.Name = "splitContainer2";
        	// 
        	// splitContainer2.Panel1
        	// 
        	this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
        	// 
        	// splitContainer2.Panel2
        	// 
        	this.splitContainer2.Panel2.Controls.Add(this.treeView1);
        	this.splitContainer2.Size = new System.Drawing.Size(503, 400);
        	this.splitContainer2.SplitterDistance = 374;
        	this.splitContainer2.TabIndex = 4;
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 0);
        	this.splitContainer1.Name = "splitContainer1";
        	this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
        	this.splitContainer1.Size = new System.Drawing.Size(374, 400);
        	this.splitContainer1.SplitterDistance = 261;
        	this.splitContainer1.TabIndex = 3;
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.AllowDrop = true;
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Location = new System.Drawing.Point(0, 0);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.ShowToolTips = true;
        	this.tabControl1.Size = new System.Drawing.Size(374, 261);
        	this.tabControl1.TabIndex = 1;
        	this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
        	this.tabControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextEditorDragDrop);
        	this.tabControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextEditorDragEnter);
        	this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
        	// 
        	// tabControl2
        	// 
        	this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
        	this.tabControl2.Controls.Add(this.tabPage1);
        	this.tabControl2.Controls.Add(this.tabPage2);
        	this.tabControl2.Controls.Add(this.tabPage3);
        	this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl2.Location = new System.Drawing.Point(0, 0);
        	this.tabControl2.Name = "tabControl2";
        	this.tabControl2.SelectedIndex = 0;
        	this.tabControl2.Size = new System.Drawing.Size(374, 135);
        	this.tabControl2.TabIndex = 1;
        	this.tabControl2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl2_MouseClick);
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.tbOutput);
        	this.tabPage1.Location = new System.Drawing.Point(4, 4);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Size = new System.Drawing.Size(366, 109);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Build output";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// tbOutput
        	// 
        	this.tbOutput.AcceptsReturn = true;
        	this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tbOutput.Location = new System.Drawing.Point(0, 0);
        	this.tbOutput.Multiline = true;
        	this.tbOutput.Name = "tbOutput";
        	this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.tbOutput.Size = new System.Drawing.Size(366, 109);
        	this.tbOutput.TabIndex = 0;
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.dgvErrors);
        	this.tabPage2.Location = new System.Drawing.Point(4, 4);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Size = new System.Drawing.Size(366, 109);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Errors";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// dgvErrors
        	// 
        	this.dgvErrors.AllowUserToAddRows = false;
        	this.dgvErrors.AllowUserToDeleteRows = false;
        	this.dgvErrors.BackgroundColor = System.Drawing.SystemColors.ControlLight;
        	this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.cType,
        	        	        	this.cFile,
        	        	        	this.cLine,
        	        	        	this.cMessage});
        	this.dgvErrors.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvErrors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        	this.dgvErrors.GridColor = System.Drawing.SystemColors.ControlLight;
        	this.dgvErrors.Location = new System.Drawing.Point(0, 0);
        	this.dgvErrors.MultiSelect = false;
        	this.dgvErrors.Name = "dgvErrors";
        	this.dgvErrors.ReadOnly = true;
        	this.dgvErrors.RowHeadersVisible = false;
        	this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
        	this.dgvErrors.Size = new System.Drawing.Size(366, 109);
        	this.dgvErrors.TabIndex = 0;
        	this.dgvErrors.DoubleClick += new System.EventHandler(this.dgvErrors_DoubleClick);
        	// 
        	// cType
        	// 
        	this.cType.HeaderText = "Type";
        	this.cType.Name = "cType";
        	this.cType.ReadOnly = true;
        	this.cType.Width = 80;
        	// 
        	// cFile
        	// 
        	this.cFile.HeaderText = "File";
        	this.cFile.Name = "cFile";
        	this.cFile.ReadOnly = true;
        	// 
        	// cLine
        	// 
        	this.cLine.HeaderText = "Line";
        	this.cLine.Name = "cLine";
        	this.cLine.ReadOnly = true;
        	this.cLine.Width = 40;
        	// 
        	// cMessage
        	// 
        	this.cMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.cMessage.HeaderText = "Message";
        	this.cMessage.Name = "cMessage";
        	this.cMessage.ReadOnly = true;
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.Controls.Add(this.tbOutputParse);
        	this.tabPage3.Location = new System.Drawing.Point(4, 4);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Size = new System.Drawing.Size(366, 109);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "Parser output";
        	this.tabPage3.UseVisualStyleBackColor = true;
        	// 
        	// tbOutputParse
        	// 
        	this.tbOutputParse.AcceptsReturn = true;
        	this.tbOutputParse.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tbOutputParse.Location = new System.Drawing.Point(0, 0);
        	this.tbOutputParse.Margin = new System.Windows.Forms.Padding(0);
        	this.tbOutputParse.Multiline = true;
        	this.tbOutputParse.Name = "tbOutputParse";
        	this.tbOutputParse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.tbOutputParse.Size = new System.Drawing.Size(366, 109);
        	this.tbOutputParse.TabIndex = 1;
        	// 
        	// treeView1
        	// 
        	this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.treeView1.Location = new System.Drawing.Point(0, 0);
        	this.treeView1.Name = "treeView1";
        	this.treeView1.ShowNodeToolTips = true;
        	this.treeView1.ShowRootLines = false;
        	this.treeView1.Size = new System.Drawing.Size(125, 400);
        	this.treeView1.TabIndex = 0;
        	this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
        	// 
        	// MainMenu
        	// 
        	this.MainMenu.AllowMerge = false;
        	this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.fileToolStripMenuItem,
        	        	        	this.editToolStripMenuItem,
        	        	        	this.compileToolStripMenuItem,
        	        	        	this.toolsToolStripMenuItem,
        	        	        	this.helpToolStripMenuItem});
        	this.MainMenu.Location = new System.Drawing.Point(0, 0);
        	this.MainMenu.Name = "MainMenu";
        	this.MainMenu.Size = new System.Drawing.Size(503, 24);
        	this.MainMenu.TabIndex = 2;
        	// 
        	// fileToolStripMenuItem
        	// 
        	this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.newToolStripMenuItem,
        	        	        	this.templatesToolStripMenuItem,
        	        	        	this.openToolStripMenuItem,
        	        	        	this.saveToolStripMenuItem,
        	        	        	this.saveAsToolStripMenuItem,
        	        	        	this.saveAllToolStripMenuItem,
        	        	        	toolStripSeparator2,
        	        	        	this.recentToolStripMenuItem,
        	        	        	toolStripSeparator1,
        	        	        	this.closeToolStripMenuItem,
        	        	        	this.closeAllToolStripMenuItem,
        	        	        	this.exitToolStripMenuItem});
        	this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        	this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
        	this.fileToolStripMenuItem.Text = "File";
        	// 
        	// newToolStripMenuItem
        	// 
        	this.newToolStripMenuItem.Name = "newToolStripMenuItem";
        	this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
        	this.newToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.newToolStripMenuItem.Text = "New";
        	this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
        	// 
        	// templatesToolStripMenuItem
        	// 
        	this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
        	this.templatesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.templatesToolStripMenuItem.Text = "Templates";
        	// 
        	// openToolStripMenuItem
        	// 
        	this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        	this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
        	this.openToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.openToolStripMenuItem.Text = "Open";
        	this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
        	// 
        	// saveToolStripMenuItem
        	// 
        	this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        	this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
        	this.saveToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.saveToolStripMenuItem.Text = "Save";
        	this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
        	// 
        	// saveAsToolStripMenuItem
        	// 
        	this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
        	this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.saveAsToolStripMenuItem.Text = "Save as";
        	this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
        	// 
        	// saveAllToolStripMenuItem
        	// 
        	this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
        	this.saveAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
        	        	        	| System.Windows.Forms.Keys.S)));
        	this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.saveAllToolStripMenuItem.Text = "Save all";
        	this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
        	// 
        	// recentToolStripMenuItem
        	// 
        	this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
        	this.recentToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.recentToolStripMenuItem.Text = "Recent";
        	// 
        	// closeToolStripMenuItem
        	// 
        	this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
        	this.closeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.closeToolStripMenuItem.Text = "Close";
        	this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
        	// 
        	// closeAllToolStripMenuItem
        	// 
        	this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
        	this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.closeAllToolStripMenuItem.Text = "Close All";
        	this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItemClick);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
        	this.exitToolStripMenuItem.Text = "Exit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
        	// 
        	// editToolStripMenuItem
        	// 
        	this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.cutToolStripMenuItem,
        	        	        	this.copyToolStripMenuItem,
        	        	        	this.pasteToolStripMenuItem,
        	        	        	this.toolStripSeparator4,
        	        	        	this.undoToolStripMenuItem,
        	        	        	this.redoToolStripMenuItem,
        	        	        	this.toolStripSeparator3,
        	        	        	this.outlineToolStripMenuItem,
        	        	        	this.findToolStripMenuItem,
        	        	        	this.goToLineToolStripMenuItem,
        	        	        	this.toolStripMenuItem1,
        	        	        	this.uPPERCASEToolStripMenuItem,
        	        	        	this.lowecaseToolStripMenuItem});
        	this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        	this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
        	this.editToolStripMenuItem.Text = "Edit";
        	// 
        	// cutToolStripMenuItem
        	// 
        	this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
        	this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
        	this.cutToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.cutToolStripMenuItem.Text = "Cut";
        	this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
        	// 
        	// copyToolStripMenuItem
        	// 
        	this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
        	this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
        	this.copyToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.copyToolStripMenuItem.Text = "Copy";
        	this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
        	// 
        	// pasteToolStripMenuItem
        	// 
        	this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
        	this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
        	this.pasteToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.pasteToolStripMenuItem.Text = "Paste";
        	this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
        	// 
        	// toolStripSeparator4
        	// 
        	this.toolStripSeparator4.Name = "toolStripSeparator4";
        	this.toolStripSeparator4.Size = new System.Drawing.Size(208, 6);
        	// 
        	// undoToolStripMenuItem
        	// 
        	this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
        	this.undoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Z";
        	this.undoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.undoToolStripMenuItem.Text = "Undo";
        	this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
        	// 
        	// redoToolStripMenuItem
        	// 
        	this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
        	this.redoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Y";
        	this.redoToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.redoToolStripMenuItem.Text = "Redo";
        	this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(208, 6);
        	// 
        	// outlineToolStripMenuItem
        	// 
        	this.outlineToolStripMenuItem.Name = "outlineToolStripMenuItem";
        	this.outlineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
        	this.outlineToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.outlineToolStripMenuItem.Text = "Outline";
        	this.outlineToolStripMenuItem.Click += new System.EventHandler(this.outlineToolStripMenuItem_Click);
        	// 
        	// findToolStripMenuItem
        	// 
        	this.findToolStripMenuItem.Name = "findToolStripMenuItem";
        	this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
        	this.findToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.findToolStripMenuItem.Text = "Find";
        	this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
        	// 
        	// goToLineToolStripMenuItem
        	// 
        	this.goToLineToolStripMenuItem.Name = "goToLineToolStripMenuItem";
        	this.goToLineToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
        	this.goToLineToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.goToLineToolStripMenuItem.Text = "GoTo Line";
        	this.goToLineToolStripMenuItem.Click += new System.EventHandler(this.GoToLineToolStripMenuItemClick);
        	// 
        	// toolStripMenuItem1
        	// 
        	this.toolStripMenuItem1.Name = "toolStripMenuItem1";
        	this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
        	// 
        	// uPPERCASEToolStripMenuItem
        	// 
        	this.uPPERCASEToolStripMenuItem.Name = "uPPERCASEToolStripMenuItem";
        	this.uPPERCASEToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
        	        	        	| System.Windows.Forms.Keys.A)));
        	this.uPPERCASEToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.uPPERCASEToolStripMenuItem.Text = "UPPERCASE";
        	this.uPPERCASEToolStripMenuItem.Click += new System.EventHandler(this.UPPERCASEToolStripMenuItemClick);
        	// 
        	// lowecaseToolStripMenuItem
        	// 
        	this.lowecaseToolStripMenuItem.Name = "lowecaseToolStripMenuItem";
        	this.lowecaseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
        	        	        	| System.Windows.Forms.Keys.Z)));
        	this.lowecaseToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.lowecaseToolStripMenuItem.Text = "lowecase";
        	this.lowecaseToolStripMenuItem.Click += new System.EventHandler(this.LowecaseToolStripMenuItemClick);
        	// 
        	// compileToolStripMenuItem
        	// 
        	this.compileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.compileToolStripMenuItem1,
        	        	        	this.compileAllOpenToolStripMenuItem,
        	        	        	this.massCompileToolStripMenuItem,
        	        	        	this.settingsToolStripMenuItem,
        	        	        	this.preprocessToolStripMenuItem,
        	        	        	this.roundtripToolStripMenuItem,
        	        	        	this.registerScriptToolStripMenuItem,
        	        	        	this.editRegisteredScriptsToolStripMenuItem,
        	        	        	this.associateMsgToolStripMenuItem});
        	this.compileToolStripMenuItem.Name = "compileToolStripMenuItem";
        	this.compileToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
        	this.compileToolStripMenuItem.Text = "Script";
        	// 
        	// compileToolStripMenuItem1
        	// 
        	this.compileToolStripMenuItem1.Name = "compileToolStripMenuItem1";
        	this.compileToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F8;
        	this.compileToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
        	this.compileToolStripMenuItem1.Text = "Compile";
        	this.compileToolStripMenuItem1.Click += new System.EventHandler(this.compileToolStripMenuItem1_Click);
        	// 
        	// compileAllOpenToolStripMenuItem
        	// 
        	this.compileAllOpenToolStripMenuItem.Name = "compileAllOpenToolStripMenuItem";
        	this.compileAllOpenToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.compileAllOpenToolStripMenuItem.Text = "Compile all open";
        	this.compileAllOpenToolStripMenuItem.Click += new System.EventHandler(this.compileAllOpenToolStripMenuItem_Click);
        	// 
        	// massCompileToolStripMenuItem
        	// 
        	this.massCompileToolStripMenuItem.Name = "massCompileToolStripMenuItem";
        	this.massCompileToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.massCompileToolStripMenuItem.Text = "Mass compile";
        	this.massCompileToolStripMenuItem.Click += new System.EventHandler(this.massCompileToolStripMenuItem_Click);
        	// 
        	// settingsToolStripMenuItem
        	// 
        	this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
        	this.settingsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.settingsToolStripMenuItem.Text = "Settings";
        	this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
        	// 
        	// preprocessToolStripMenuItem
        	// 
        	this.preprocessToolStripMenuItem.Name = "preprocessToolStripMenuItem";
        	this.preprocessToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
        	this.preprocessToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.preprocessToolStripMenuItem.Text = "Preprocess";
        	this.preprocessToolStripMenuItem.Click += new System.EventHandler(this.preprocessToolStripMenuItem_Click);
        	// 
        	// roundtripToolStripMenuItem
        	// 
        	this.roundtripToolStripMenuItem.Name = "roundtripToolStripMenuItem";
        	this.roundtripToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
        	this.roundtripToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.roundtripToolStripMenuItem.Text = "Roundtrip";
        	this.roundtripToolStripMenuItem.Click += new System.EventHandler(this.roundtripToolStripMenuItem_Click);
        	// 
        	// registerScriptToolStripMenuItem
        	// 
        	this.registerScriptToolStripMenuItem.Name = "registerScriptToolStripMenuItem";
        	this.registerScriptToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
        	this.registerScriptToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.registerScriptToolStripMenuItem.Text = "Register script";
        	this.registerScriptToolStripMenuItem.Click += new System.EventHandler(this.registerScriptToolStripMenuItem_Click);
        	// 
        	// editRegisteredScriptsToolStripMenuItem
        	// 
        	this.editRegisteredScriptsToolStripMenuItem.Name = "editRegisteredScriptsToolStripMenuItem";
        	this.editRegisteredScriptsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.editRegisteredScriptsToolStripMenuItem.Text = "Edit registered Scripts";
        	this.editRegisteredScriptsToolStripMenuItem.Click += new System.EventHandler(this.editRegisteredScriptsToolStripMenuItem_Click);
        	// 
        	// associateMsgToolStripMenuItem
        	// 
        	this.associateMsgToolStripMenuItem.Name = "associateMsgToolStripMenuItem";
        	this.associateMsgToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
        	this.associateMsgToolStripMenuItem.Text = "Associate msg";
        	this.associateMsgToolStripMenuItem.Click += new System.EventHandler(this.associateMsgToolStripMenuItem_Click);
        	// 
        	// toolsToolStripMenuItem
        	// 
        	this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.headsFrmPatcherToolStripMenuItem});
        	this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
        	this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
        	this.toolsToolStripMenuItem.Text = "Tools";
        	// 
        	// headsFrmPatcherToolStripMenuItem
        	// 
        	this.headsFrmPatcherToolStripMenuItem.Name = "headsFrmPatcherToolStripMenuItem";
        	this.headsFrmPatcherToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
        	this.headsFrmPatcherToolStripMenuItem.Text = "Heads frm patcher";
        	this.headsFrmPatcherToolStripMenuItem.Click += new System.EventHandler(this.headsFrmPatcherToolStripMenuItem_Click);
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.readmeToolStripMenuItem,
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.helpToolStripMenuItem.Text = "Help";
        	// 
        	// readmeToolStripMenuItem
        	// 
        	this.readmeToolStripMenuItem.Name = "readmeToolStripMenuItem";
        	this.readmeToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
        	this.readmeToolStripMenuItem.Text = "Docs folder";
        	this.readmeToolStripMenuItem.Click += new System.EventHandler(this.readmeToolStripMenuItem_Click);
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
        	this.aboutToolStripMenuItem.Text = "About";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
        	// 
        	// cmsTabControls
        	// 
        	this.cmsTabControls.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.closeToolStripMenuItem1,
        	        	        	this.closeAllToolStripMenuItem1,
        	        	        	this.closeAllButThisToolStripMenuItem});
        	this.cmsTabControls.Name = "cmsTabControls";
        	this.cmsTabControls.Size = new System.Drawing.Size(167, 70);
        	// 
        	// closeToolStripMenuItem1
        	// 
        	this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
        	this.closeToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
        	this.closeToolStripMenuItem1.Text = "Close";
        	this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
        	// 
        	// closeAllToolStripMenuItem1
        	// 
        	this.closeAllToolStripMenuItem1.Name = "closeAllToolStripMenuItem1";
        	this.closeAllToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
        	this.closeAllToolStripMenuItem1.Text = "Close All";
        	this.closeAllToolStripMenuItem1.Click += new System.EventHandler(this.CloseAllToolStripMenuItemClick);
        	// 
        	// closeAllButThisToolStripMenuItem
        	// 
        	this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
        	this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
        	this.closeAllButThisToolStripMenuItem.Text = "Close All But This";
        	this.closeAllButThisToolStripMenuItem.Click += new System.EventHandler(this.CloseAllButThisToolStripMenuItemClick);
        	// 
        	// ofdScripts
        	// 
        	this.ofdScripts.Filter = "All supported files|*.ssl;*.int;*.h;*.msg|Script files|*.ssl|Header files|*.h|Com" +
        	"piled scripts|*.int|Message files|*.msg|All files|*.*";
        	this.ofdScripts.Multiselect = true;
        	this.ofdScripts.RestoreDirectory = true;
        	this.ofdScripts.Title = "Select script or header to open";
        	// 
        	// sfdScripts
        	// 
        	this.sfdScripts.DefaultExt = "ssl";
        	this.sfdScripts.Filter = "Script file (.ssl)|*.ssl|Header file (.h)|*.h|All files|*.*";
        	this.sfdScripts.RestoreDirectory = true;
        	this.sfdScripts.Title = "Save script as";
        	// 
        	// fbdMassCompile
        	// 
        	this.fbdMassCompile.Description = "Select folder to compile";
        	this.fbdMassCompile.RootFolder = System.Environment.SpecialFolder.MyComputer;
        	// 
        	// bwSyntaxParser
        	// 
        	this.bwSyntaxParser.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSyntaxParser_DoWork);
        	this.bwSyntaxParser.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSyntaxParser_RunWorkerCompleted);
        	// 
        	// editorMenuStrip
        	// 
        	this.editorMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.cutToolStripMenuItem1,
        	        	        	this.copyToolStripMenuItem1,
        	        	        	this.pasteToolStripMenuItem1,
        	        	        	toolStripSeparator5,
        	        	        	this.findReferencesToolStripMenuItem,
        	        	        	this.findDeclerationToolStripMenuItem,
        	        	        	this.findDefinitionToolStripMenuItem,
        	        	        	this.openIncludeToolStripMenuItem});
        	this.editorMenuStrip.Name = "editorMenuStrip1";
        	this.editorMenuStrip.Size = new System.Drawing.Size(212, 164);
        	this.editorMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.editorMenuStrip_Opening);
        	// 
        	// cutToolStripMenuItem1
        	// 
        	this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
        	this.cutToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
        	this.cutToolStripMenuItem1.Text = "Cut";
        	this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
        	// 
        	// copyToolStripMenuItem1
        	// 
        	this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
        	this.copyToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
        	this.copyToolStripMenuItem1.Text = "Copy";
        	this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
        	// 
        	// pasteToolStripMenuItem1
        	// 
        	this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
        	this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
        	this.pasteToolStripMenuItem1.Text = "Paste";
        	this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
        	// 
        	// findReferencesToolStripMenuItem
        	// 
        	this.findReferencesToolStripMenuItem.Name = "findReferencesToolStripMenuItem";
        	this.findReferencesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.findReferencesToolStripMenuItem.Text = "Find references";
        	this.findReferencesToolStripMenuItem.Click += new System.EventHandler(this.findReferencesToolStripMenuItem_Click);
        	// 
        	// findDeclerationToolStripMenuItem
        	// 
        	this.findDeclerationToolStripMenuItem.Name = "findDeclerationToolStripMenuItem";
        	this.findDeclerationToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F12)));
        	this.findDeclerationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.findDeclerationToolStripMenuItem.Text = "Find decleration";
        	this.findDeclerationToolStripMenuItem.Click += new System.EventHandler(this.findDeclerationToolStripMenuItem_Click);
        	// 
        	// findDefinitionToolStripMenuItem
        	// 
        	this.findDefinitionToolStripMenuItem.Name = "findDefinitionToolStripMenuItem";
        	this.findDefinitionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
        	this.findDefinitionToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.findDefinitionToolStripMenuItem.Text = "Find definition";
        	this.findDefinitionToolStripMenuItem.Click += new System.EventHandler(this.findDefinitionToolStripMenuItem_Click);
        	// 
        	// openIncludeToolStripMenuItem
        	// 
        	this.openIncludeToolStripMenuItem.Name = "openIncludeToolStripMenuItem";
        	this.openIncludeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
        	this.openIncludeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
        	this.openIncludeToolStripMenuItem.Text = "Open include";
        	this.openIncludeToolStripMenuItem.Click += new System.EventHandler(this.openIncludeToolStripMenuItem_Click);
        	// 
        	// toolTipAC
        	// 
        	this.toolTipAC.AutoPopDelay = 50000;
        	this.toolTipAC.InitialDelay = 500;
        	this.toolTipAC.ReshowDelay = 100;
        	// 
        	// TextEditor
        	// 
        	this.AllowDrop = true;
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(503, 424);
        	this.Controls.Add(this.panel1);
        	this.Icon = global::ScriptEditor.Properties.Resources.Icon_1;
        	this.Name = "TextEditor";
        	this.Text = "sfall Script Editor";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextEditor_FormClosing);
        	this.Load += new System.EventHandler(this.TextEditor_Load);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.splitContainer2.Panel1.ResumeLayout(false);
        	this.splitContainer2.Panel2.ResumeLayout(false);
        	this.splitContainer2.ResumeLayout(false);
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	this.splitContainer1.ResumeLayout(false);
        	this.tabControl2.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.tabPage1.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
        	this.tabPage3.ResumeLayout(false);
        	this.tabPage3.PerformLayout();
        	this.MainMenu.ResumeLayout(false);
        	this.MainMenu.PerformLayout();
        	this.cmsTabControls.ResumeLayout(false);
        	this.editorMenuStrip.ResumeLayout(false);
        	this.ResumeLayout(false);
        }
        private System.Windows.Forms.ToolTip toolTipAC;
        private System.Windows.Forms.ListBox lbAutocomplete;
        private System.Windows.Forms.TextBox tbOutputParse;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAllButThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lowecaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uPPERCASEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToLineToolStripMenuItem;

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog ofdScripts;
        private System.Windows.Forms.SaveFileDialog sfdScripts;
        private DraggableTabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readmeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massCompileToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog fbdMassCompile;
        private System.Windows.Forms.ToolStripMenuItem compileAllOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem outlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMessage;
        private System.Windows.Forms.ToolStripMenuItem preprocessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundtripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRegisteredScriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem associateMsgToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bwSyntaxParser;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip editorMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem findReferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findDeclerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findDefinitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIncludeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cmsTabControls;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headsFrmPatcherToolStripMenuItem;
    }
}