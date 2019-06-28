using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolkitLibrary;

namespace CTIToolkit
{
    public partial class ToolkitMain : Form
    {
        CTICustomControls.PsychrometricsTabPage PsychrometricsUserControl { get; set; }
        CTICustomControls.MerkelTabPage MerkelUserControl { get; set; }
        CTICustomControls.DemandCurveTabPage DemandCurveUserControl { get; set; }

        public ToolkitMain()
        {
            InitializeComponent();

            PsychrometricsUserControl = new CTICustomControls.PsychrometricsTabPage();
            PsychrometricsUserControl.Dock = DockStyle.Top;
            TabPage psychrometricsTabPage = new TabPage("Psychrometrics");
            psychrometricsTabPage.Controls.Add(PsychrometricsUserControl);
            tabControl1.TabPages.Add(psychrometricsTabPage);

            MerkelUserControl = new CTICustomControls.MerkelTabPage();
            MerkelUserControl.Dock = DockStyle.Top;
            TabPage merkelTabPage = new TabPage("Merkel");
            merkelTabPage.Controls.Add(MerkelUserControl);
            tabControl1.TabPages.Add(merkelTabPage);

            DemandCurveUserControl = new CTICustomControls.DemandCurveTabPage();
            DemandCurveUserControl.Dock = DockStyle.Top;
            TabPage demandCurveTabPage = new TabPage("Demand Curve");
            demandCurveTabPage.Controls.Add(DemandCurveUserControl);
            tabControl1.TabPages.Add(demandCurveTabPage);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void unitedStatesCustomaryUnitsIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            internationalSystemOfUnitsSIToolStripMenuItem.Checked = false;
            Globals.UnitsSelection = UnitsSelection.United_States_Customary_Units_IP;
            PsychrometricsUserControl.SetUnitsStandard();
        }

        private void internationalSystemOfUnitsSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unitedStatesCustomaryUnitsIPToolStripMenuItem.Checked = false;
            Globals.UnitsSelection = UnitsSelection.International_System_Of_Units_SI;
            PsychrometricsUserControl.SetUnitsStandard();
        }
    }
}
