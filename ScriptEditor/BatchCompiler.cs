using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ScriptEditor
{
    public partial class BatchCompiler : Form
    {
        private int failed;
        private int compiled;
        private readonly BackgroundWorker[] workers;
        private int completed;

        private BatchCompiler(string[] files)
        {
            InitializeComponent();
            progressBar1.Maximum = files.Length;
            label1.Text = "Fail count: 0";
            workers = new BackgroundWorker[Settings.multiThreaded ? Math.Min(Environment.ProcessorCount, files.Length) : 1];
            for (int i = 0; i < workers.Length; i++) {
                workers[i] = new BackgroundWorker();
                workers[i].ProgressChanged += new ProgressChangedEventHandler(BatchCompiler_ProgressChanged);
                workers[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(BatchCompiler_RunWorkerCompleted);
                workers[i].DoWork += new DoWorkEventHandler(BatchCompiler_DoWork);
                workers[i].WorkerSupportsCancellation = true;
                workers[i].WorkerReportsProgress = true;
            }
            if (workers.Length == 1) {
                workers[0].RunWorkerAsync(files);
            } else {
                int threadswithextras = files.Length % workers.Length;
                int filesperthread = (files.Length - (threadswithextras)) / workers.Length;
                int upto = 0;
                for (int i = 0; i < workers.Length; i++) {
                    string[] subblock = new string[filesperthread + (i < threadswithextras ? 1 : 0)];
                    for (int j = 0; j < subblock.Length; j++)
                        subblock[j] = files[upto++];
                    workers[i].RunWorkerAsync(subblock);
                }
            }
        }

        void BatchCompiler_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] files = (string[])e.Argument;
            BackgroundWorker worker = (BackgroundWorker)sender;
            int failed;
            string unused;
            foreach (string s in files) {
                if (worker.CancellationPending) {
                    e.Cancel = true;
                    break;
                }
                if (Compiler.Compile(s, out unused, null, false))
                    failed = 0;
                else
                    failed = 1;
                worker.ReportProgress(failed);
            }
        }

        void BatchCompiler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (++completed == workers.Length)
                Close();
        }

        void BatchCompiler_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value++;
            if (e.ProgressPercentage == 1) {
                failed++;
                label1.Text = "Fail count: " + failed;
            } else
                compiled++;
        }

        public static void CompileFolder(string path)
        {
            string[] infiles = System.IO.Directory.GetFiles(path, "*.ssl", System.IO.SearchOption.AllDirectories);
            if (infiles.Length == 0) {
                MessageBox.Show("Nothing found to compile", "Warning");
                return;
            }
            BatchCompiler bc = new BatchCompiler(infiles);
            bc.ShowDialog();
            int found = infiles.Length;
            int failed = bc.failed;
            int compiled = bc.compiled;
            int skipped = found - (failed + compiled);
            MessageBox.Show(String.Format("{0} scripts found.\n{1} successfully compiled\n{2} failed to compile\n{3} skipped", found, compiled, failed, skipped));
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < workers.Length; i++)
                workers[i].CancelAsync();
            bCancel.Enabled = false;
        }
    }
}
