namespace ScriptEditor {
    partial class RegisterScript {
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
            this.dgvScripts = new System.Windows.Forms.DataGridView();
            this.cLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cScript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvScripts
            // 
            this.dgvScripts.AllowUserToAddRows = false;
            this.dgvScripts.AllowUserToDeleteRows = false;
            this.dgvScripts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScripts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cLine,
            this.cScript,
            this.cName,
            this.cDescription,
            this.cVars});
            this.dgvScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScripts.Location = new System.Drawing.Point(0, 0);
            this.dgvScripts.MultiSelect = false;
            this.dgvScripts.Name = "dgvScripts";
            this.dgvScripts.RowHeadersVisible = false;
            this.dgvScripts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvScripts.Size = new System.Drawing.Size(545, 171);
            this.dgvScripts.TabIndex = 0;
            // 
            // cLine
            // 
            this.cLine.HeaderText = "Line Number";
            this.cLine.Name = "cLine";
            this.cLine.ReadOnly = true;
            this.cLine.Width = 60;
            // 
            // cScript
            // 
            this.cScript.HeaderText = "Script";
            this.cScript.Name = "cScript";
            this.cScript.ReadOnly = true;
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            // 
            // cDescription
            // 
            this.cDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cDescription.HeaderText = "Description";
            this.cDescription.Name = "cDescription";
            // 
            // cVars
            // 
            this.cVars.HeaderText = "Local Vars";
            this.cVars.Name = "cVars";
            this.cVars.Width = 60;
            // 
            // RegisterScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 171);
            this.Controls.Add(this.dgvScripts);
            this.KeyPreview = true;
            this.Name = "RegisterScript";
            this.Text = "RegisterScript";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterScript_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RegisterScript_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScripts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvScripts;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn cScript;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVars;
    }
}