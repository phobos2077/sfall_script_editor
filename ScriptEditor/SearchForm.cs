using System;
using System.Windows.Forms;

namespace ScriptEditor {
    public partial class SearchForm : Form {
        public SearchForm() {
            InitializeComponent();
            if(Settings.lastSearchPath==null) {
                label2.Text="<unset>";
            } else {
                label2.Text=Settings.lastSearchPath;
                fbdSearchFolder.SelectedPath=Settings.lastSearchPath;
            }
        }
    }
}
