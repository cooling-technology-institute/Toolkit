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
            TabPage psychrometricsTabPage = new TabPage("Psychrometrics");
            psychrometricsTabPage.Controls.Add(psychrometricsUserControl);
            tabControl1.TabPages.Add(psychrometricsTabPage);

            CTICustomControls.MerkelTabPage merkelUserControl = new CTICustomControls.MerkelTabPage();
            merkelUserControl.Dock = DockStyle.Top;
            TabPage merkelTabPage = new TabPage("Merkel");
            merkelTabPage.Controls.Add(merkelUserControl);
            tabControl1.TabPages.Add(merkelTabPage);

            CTICustomControls.DemandCurveTabPage demandCurveUserControl = new CTICustomControls.DemandCurveTabPage();
            demandCurveUserControl.Dock = DockStyle.Top;
            TabPage demandCurveTabPage = new TabPage("Demand Curve");
            demandCurveTabPage.Controls.Add(demandCurveUserControl);
            tabControl1.TabPages.Add(demandCurveTabPage);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
