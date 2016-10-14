using System;
using System.IO;
using System.Windows.Forms;

namespace ScriptEditor
{
    public partial class HeadsFrmPatcher : Form
    {
        public HeadsFrmPatcher()
        {
            InitializeComponent();
        }

        private void bRun_Click(object sender, EventArgs e)
        {
            if (ofdFrm.ShowDialog() != DialogResult.OK) {
                return;
            }
            byte[] name = new byte[8];
            foreach (string s in ofdFrm.FileNames) {
                string fname = Path.GetFileNameWithoutExtension(s);
                for (int i = 0; i < fname.Length; i++) {
                    name[i] = (byte)fname[i];
                }
                for (int i = fname.Length; i < 8; i++) {
                    name[i] = 0;
                }
                for (int i = 0; i < 4; i++) {
                    byte b = name[i * 2];
                    name[i * 2] = name[i * 2 + 1];
                    name[i * 2 + 1] = b;
                }
                if (fname.Length > 8) {
                    MessageBox.Show("Skipping '" + s + "'; the file name is too long to be supported", "Warning");
                    continue;
                }
                BinaryWriter bw = new BinaryWriter(File.Open(s, FileMode.Open, FileAccess.ReadWrite));
                bw.BaseStream.Position = 12;
                bw.Write((ushort)0xcdab);
                for (int i = 0; i < 8; i++) {
                    bw.Write(name[i]);
                }
                bw.BaseStream.Position += 2;
                bw.Write((short)0);
                bw.Write((int)0);
                if (cbIncludesBackground.Checked) {
                    bw.Write((byte)1);
                } else {
                    bw.Write((byte)0);
                }
                if (cbDisableHighlighting.Checked) {
                    bw.Write((byte)0);
                } else {
                    bw.Write((byte)1);
                }
                bw.Close();
            }
            MessageBox.Show("Done");
        }

    }
}
