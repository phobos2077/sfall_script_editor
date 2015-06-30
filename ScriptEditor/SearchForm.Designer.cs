namespace ScriptEditor {
    partial class SearchForm {
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
        	System.Windows.Forms.Label label1;
        	this.tbSearch = new System.Windows.Forms.TextBox();
        	this.cbRegular = new System.Windows.Forms.CheckBox();
        	this.rbCurrent = new System.Windows.Forms.RadioButton();
        	this.rbAll = new System.Windows.Forms.RadioButton();
        	this.rbFolder = new System.Windows.Forms.RadioButton();
        	this.label2 = new System.Windows.Forms.Label();
        	this.bChange = new System.Windows.Forms.Button();
        	this.cbSearchSubfolders = new System.Windows.Forms.CheckBox();
        	this.bSearch = new System.Windows.Forms.Button();
        	this.fbdSearchFolder = new System.Windows.Forms.FolderBrowserDialog();
        	this.cbFindAll = new System.Windows.Forms.CheckBox();
        	this.tbReplace = new System.Windows.Forms.TextBox();
        	this.bReplace = new System.Windows.Forms.Button();
        	label1 = new System.Windows.Forms.Label();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	label1.AutoSize = true;
        	label1.Location = new System.Drawing.Point(12, 81);
        	label1.Name = "label1";
        	label1.Size = new System.Drawing.Size(86, 13);
        	label1.TabIndex = 5;
        	label1.Text = "Folder to search:";
        	// 
        	// tbSearch
        	// 
        	this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbSearch.Location = new System.Drawing.Point(12, 12);
        	this.tbSearch.Name = "tbSearch";
        	this.tbSearch.Size = new System.Drawing.Size(379, 20);
        	this.tbSearch.TabIndex = 0;
        	// 
        	// cbRegular
        	// 
        	this.cbRegular.AutoSize = true;
        	this.cbRegular.Location = new System.Drawing.Point(12, 38);
        	this.cbRegular.Name = "cbRegular";
        	this.cbRegular.Size = new System.Drawing.Size(116, 17);
        	this.cbRegular.TabIndex = 1;
        	this.cbRegular.Text = "Regular expression";
        	this.cbRegular.UseVisualStyleBackColor = true;
        	// 
        	// rbCurrent
        	// 
        	this.rbCurrent.AutoSize = true;
        	this.rbCurrent.Checked = true;
        	this.rbCurrent.Location = new System.Drawing.Point(12, 61);
        	this.rbCurrent.Name = "rbCurrent";
        	this.rbCurrent.Size = new System.Drawing.Size(75, 17);
        	this.rbCurrent.TabIndex = 2;
        	this.rbCurrent.TabStop = true;
        	this.rbCurrent.Text = "Current file";
        	this.rbCurrent.UseVisualStyleBackColor = true;
        	// 
        	// rbAll
        	// 
        	this.rbAll.AutoSize = true;
        	this.rbAll.Location = new System.Drawing.Point(93, 61);
        	this.rbAll.Name = "rbAll";
        	this.rbAll.Size = new System.Drawing.Size(72, 17);
        	this.rbAll.TabIndex = 3;
        	this.rbAll.Text = "Open files";
        	this.rbAll.UseVisualStyleBackColor = true;
        	// 
        	// rbFolder
        	// 
        	this.rbFolder.AutoSize = true;
        	this.rbFolder.Location = new System.Drawing.Point(176, 61);
        	this.rbFolder.Name = "rbFolder";
        	this.rbFolder.Size = new System.Drawing.Size(86, 17);
        	this.rbFolder.TabIndex = 4;
        	this.rbFolder.Text = "Files in folder";
        	this.rbFolder.UseVisualStyleBackColor = true;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 94);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(35, 13);
        	this.label2.TabIndex = 6;
        	this.label2.Text = "label2";
        	// 
        	// bChange
        	// 
        	this.bChange.Enabled = false;
        	this.bChange.Location = new System.Drawing.Point(12, 114);
        	this.bChange.Name = "bChange";
        	this.bChange.Size = new System.Drawing.Size(104, 23);
        	this.bChange.TabIndex = 7;
        	this.bChange.Text = "Change";
        	this.bChange.UseVisualStyleBackColor = true;
        	// 
        	// cbSearchSubfolders
        	// 
        	this.cbSearchSubfolders.AutoSize = true;
        	this.cbSearchSubfolders.Enabled = false;
        	this.cbSearchSubfolders.Location = new System.Drawing.Point(149, 118);
        	this.cbSearchSubfolders.Name = "cbSearchSubfolders";
        	this.cbSearchSubfolders.Size = new System.Drawing.Size(111, 17);
        	this.cbSearchSubfolders.TabIndex = 8;
        	this.cbSearchSubfolders.Text = "Search subfolders";
        	this.cbSearchSubfolders.UseVisualStyleBackColor = true;
        	// 
        	// bSearch
        	// 
        	this.bSearch.Location = new System.Drawing.Point(149, 143);
        	this.bSearch.Name = "bSearch";
        	this.bSearch.Size = new System.Drawing.Size(104, 23);
        	this.bSearch.TabIndex = 10;
        	this.bSearch.Text = "Search";
        	this.bSearch.UseVisualStyleBackColor = true;
        	// 
        	// fbdSearchFolder
        	// 
        	this.fbdSearchFolder.Description = "Pick folder to search";
        	this.fbdSearchFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
        	// 
        	// cbFindAll
        	// 
        	this.cbFindAll.AutoSize = true;
        	this.cbFindAll.Location = new System.Drawing.Point(149, 38);
        	this.cbFindAll.Name = "cbFindAll";
        	this.cbFindAll.Size = new System.Drawing.Size(102, 17);
        	this.cbFindAll.TabIndex = 11;
        	this.cbFindAll.Text = "Find all matches";
        	this.cbFindAll.UseVisualStyleBackColor = true;
        	// 
        	// tbReplace
        	// 
        	this.tbReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tbReplace.Location = new System.Drawing.Point(12, 172);
        	this.tbReplace.Name = "tbReplace";
        	this.tbReplace.Size = new System.Drawing.Size(379, 20);
        	this.tbReplace.TabIndex = 12;
        	// 
        	// bReplace
        	// 
        	this.bReplace.Location = new System.Drawing.Point(149, 198);
        	this.bReplace.Name = "bReplace";
        	this.bReplace.Size = new System.Drawing.Size(104, 23);
        	this.bReplace.TabIndex = 13;
        	this.bReplace.Text = "Replace";
        	this.bReplace.UseVisualStyleBackColor = true;
        	// 
        	// SearchForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(404, 230);
        	this.Controls.Add(this.bReplace);
        	this.Controls.Add(this.tbReplace);
        	this.Controls.Add(this.cbFindAll);
        	this.Controls.Add(this.bSearch);
        	this.Controls.Add(this.cbSearchSubfolders);
        	this.Controls.Add(this.bChange);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(label1);
        	this.Controls.Add(this.rbFolder);
        	this.Controls.Add(this.rbAll);
        	this.Controls.Add(this.rbCurrent);
        	this.Controls.Add(this.cbRegular);
        	this.Controls.Add(this.tbSearch);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.KeyPreview = true;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "SearchForm";
        	this.Text = "Search & Replace";
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox tbSearch;
        internal System.Windows.Forms.CheckBox cbRegular;
        internal System.Windows.Forms.RadioButton rbCurrent;
        internal System.Windows.Forms.RadioButton rbAll;
        internal System.Windows.Forms.RadioButton rbFolder;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button bChange;
        internal System.Windows.Forms.CheckBox cbSearchSubfolders;
        internal System.Windows.Forms.Button bSearch;
        internal System.Windows.Forms.FolderBrowserDialog fbdSearchFolder;
        internal System.Windows.Forms.CheckBox cbFindAll;
        internal System.Windows.Forms.TextBox tbReplace;
        internal System.Windows.Forms.Button bReplace;

    }
}