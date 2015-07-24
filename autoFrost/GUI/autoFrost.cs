using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace autoFrost
{
    public partial class autoFrost : Form
    {
        public autoFrost()
        {
            InitializeComponent();
        }

        string exeFile = "";
        string grayFrostSln = "";
        private void executableToImbed_BT_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Filter = "exe files (*.exe)|*.exe";
            file.Title = "Select a C# exe with a public void main()";
            file.ShowDialog();

            exeFile = file.FileName;
        }

        private void grayFrostCsproj_BT_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Filter = "sln files (*.sln)|*.sln";
            file.Title = "Gray Frost sln";
            file.ShowDialog();
            grayFrostSln = file.FileName;
            if (!grayFrostSln.Contains("GrayFrost.sln"))
                grayFrostSln = "";
            grayFrostSln = grayFrostSln.Replace("\\GrayFrost.sln", String.Empty);
        }

        private void build_BT_Click(object sender, EventArgs e)
        {
            autoBilder.build(grayFrostSln, exeFile);
        }
    }
}
