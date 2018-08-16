using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class ToolkitMain : Form
    {
        public ToolkitMain()
        {
            InitializeComponent();

            CTICustomControls.PsychrometricsTabPage psychrometricsUserControl = new CTICustomControls.PsychrometricsTabPage();
            psychrometricsUserControl.Dock = DockStyle.Top;
            TabPage psychrometricsTabPage = new TabPage();
            psychrometricsTabPage.Controls.Add(psychrometricsUserControl);
            tabControl1.TabPages.Add(psychrometricsTabPage);

            //tabControl1.TabPages.Add(CTICustomControls.PsychrometricsTabPage);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
