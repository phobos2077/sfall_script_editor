using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Path=System.IO.Path;
using File=System.IO.File;

namespace ScriptEditor {
    public partial class RegisterScript : Form {
        private class Entry {
            public int row;
            public string script;
            public string desc;
            public string name;
            public int vars;

            public Entry(int row, string line) {
                this.row=row;
                script=line.Remove(16).Trim();
                desc=line.Substring(18, 64-18).Trim();
                int.TryParse(line.Substring(77), out vars);
            }

            public string GetAsString() {
                return script.PadRight(16)+"; "+desc.PadRight(46)+"# local_vars="+vars.ToString();
            }

            public string GetMsgAsString() {
                return ("{"+(row+101)+"}{}{"+name+"}").PadRight(40)+"# "+script.PadRight(16)+"; "+desc;
            }

            public override string ToString() {
                return script;
            }
        }

        private readonly int editingLine=-1;
        private readonly int editingLineMsg=-1;
        private readonly List<string> lines;
        private readonly List<string> linesMsg;
        
        private readonly string lstPath;
        private readonly string msgPath;
        private readonly string headerPath;
        private bool cancel=false;
        private bool doAdd=false;

        private void AddRow(Entry e) {
            dgvScripts.Rows.Add(e.row+1, e, e.name, e.desc, e.vars);
        }

        private RegisterScript(string script, string lst, string msg, string header) {
            lstPath=lst;
            msgPath=msg;
            headerPath=header;
            InitializeComponent();
            lines=new List<string>(File.ReadAllLines(lst));
            linesMsg=new List<string>(File.ReadAllLines(msg));
            char[] space = new char[] { ' ' };
            if(script!=null) {
                Entry e=null;
                for(int i=0;i<lines.Count;i++) {
                    if(string.Compare(lines[i].Split(space, StringSplitOptions.RemoveEmptyEntries)[0], script, true)==0) {
                        editingLine=i;
                        e=new Entry(i, lines[i]);
                        break;
                    }
                }
                if(editingLine==-1) {
                    editingLine=lines.Count;
                    doAdd=true;
                    lines.Add(script.PadRight(16)+"; [description] ".PadRight(48)+"# local_vars=0");
                    e=new Entry(editingLine, lines[lines.Count-1]);
                }
                for(int i=0;i<linesMsg.Count;i++) {
                    string[] line=linesMsg[i].Split('}');
                    if(line.Length!=4) continue;
                    line[0]=line[0].TrimStart(' ', '{');
                    int lineno;
                    if(!int.TryParse(line[0], out lineno)) continue;
                    if(lineno==editingLine+101) {
                        editingLineMsg=lineno;
                        e.name=line[2].TrimStart(' ', '{');
                        break;
                    }
                }
                if(editingLineMsg==-1) {
                    e.name="";
                    editingLineMsg=linesMsg.Count;
                    linesMsg.Add(e.GetMsgAsString());
                }
                AddRow(e);
            } else {
                dgvScripts.RowHeadersVisible=true;
                dgvScripts.SelectionMode=DataGridViewSelectionMode.RowHeaderSelect;
                //dgvScripts.AllowUserToDeleteRows=true;
                //dgvScripts.AllowUserToAddRows=true;
                //cScript.ReadOnly=false;
                Entry[] entries=new Entry[lines.Count];
                for(int i=0;i<lines.Count;i++) {
                    entries[i]=new Entry(i, lines[i]);
                }
                lines.Clear();
                for(int i=0;i<linesMsg.Count;i++) {
                    string[] line=linesMsg[i].Split('}');
                    if(line.Length!=4) continue;
                    line[0]=line[0].TrimStart(' ', '{');
                    int lineno;
                    if(!int.TryParse(line[0], out lineno)||lineno>entries.Length+101) continue;
                    entries[lineno-101].name=line[2].TrimStart(' ', '{');
                }
                linesMsg.Clear();
                for(int i=0;i<entries.Length;i++) {
                    AddRow(entries[i]);
                }
            }
            dgvScripts.CellValueChanged+=dgvScripts_CellValueChanged;
        }

        public static void EditRegistration(string script) {
            if(Settings.outputDir==null) {
                MessageBox.Show("No output path selected.", "Error");
                return;
            }
            if(Settings.scriptsHFile==null) {
                MessageBox.Show("The path to scripts.h has not been set.", "Error");
                return;
            }
            string lstPath=Path.Combine(Settings.outputDir, "scripts.lst");
            if(!File.Exists(lstPath)) {
                MessageBox.Show("scripts.lst does not exist in your scripts output directory", "Error");
                return;
            }
            string msgPath=Path.Combine(Settings.outputDir, "../text/english/game/scrname.msg");
            if(!File.Exists(msgPath)) {
                MessageBox.Show("Could not find scrname.msg", "Error");
                return;
            }
            (new RegisterScript(script, lstPath, msgPath, Settings.scriptsHFile)).ShowDialog();
        }

        private void RegisterScript_FormClosing(object sender, FormClosingEventArgs e) {
            if(cancel) return;
            if(editingLine==-1) {
                for(int i=0;i<dgvScripts.Rows.Count;i++) {
                    Entry entry=(Entry)dgvScripts.Rows[i].Cells[1].Value;
                    lines.Add(entry.GetAsString());
                    linesMsg.Add(entry.GetMsgAsString());
                }
            } else {
                Entry entry=(Entry)dgvScripts.Rows[0].Cells[1].Value;
                lines[editingLine]=entry.GetAsString();
                linesMsg[editingLineMsg]=entry.GetMsgAsString();
                if(doAdd) {
                    List<string> hlines=new List<string>(File.ReadAllLines(headerPath));
                    for(int j=hlines.Count-1;j>=0;j++) {
                        if(hlines[j].IndexOf('#')!=-1||j==0) {
                            hlines.Insert(j, ("#define SCRIPT_"+Path.GetFileNameWithoutExtension(entry.script).ToUpperInvariant()).PadRight(31)+" ("+(editingLine+1)+") // "+entry.script.PadRight(16)+"; "+entry.desc);
                            break;
                        }
                    }
                    File.WriteAllLines(headerPath, hlines.ToArray());
                }
            }
            File.WriteAllLines(lstPath, lines.ToArray());
            File.WriteAllLines(msgPath, linesMsg.ToArray());
        }

        private void RegisterScript_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode==Keys.Escape) {
                cancel=true;
                e.Handled=true;
                Close();
            }
        }

        private void dgvScripts_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if(e.RowIndex==-1||e.ColumnIndex==-1) return;
            DataGridViewCell cell=dgvScripts.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Entry entry=(Entry)dgvScripts.Rows[e.RowIndex].Cells[1].Value;
            string val=(string)cell.Value;
            switch(e.ColumnIndex) {
            case 2:
                if(val.IndexOfAny(new char[] { '{', '}' })==-1) entry.name=val;
                break;
            case 3:
                if(val.Length>64-20) val=val.Remove(64-20);
                entry.desc=val;
                break;
            case 4:
                int.TryParse(val, out entry.vars);
                break;
            }
        }
    }
}
