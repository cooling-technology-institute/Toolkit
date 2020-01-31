using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CTIToolkit.Properties;

namespace CTIToolkit
{
    public partial class ToolkitMain : Form
    {
        public ApplicationSettings ApplicationSettings = new ApplicationSettings();

        PsychrometricsTabPage PsychrometricsUserControl { get; set; }
        MerkelTabPage MerkelUserControl { get; set; }
        DemandCurveTabPage DemandCurveUserControl { get; set; }
        MechanicalDraftPerformanceCurveTabPage MechanicalDraftPerformanceCurveUserControl { get; set; }

        public ToolkitMain()
        {
            InitializeComponent();

            ApplicationSettings.Read();
            if (ApplicationSettings.UnitsSelection == UnitsSelection.United_States_Customary_Units_IP)
            {
                unitedStatesCustomaryUnitsIPToolStripMenuItem.Checked = true;
                internationalSystemOfUnitsSIToolStripMenuItem.Checked = false;
            }
            else
            {
                unitedStatesCustomaryUnitsIPToolStripMenuItem.Checked = false;
                internationalSystemOfUnitsSIToolStripMenuItem.Checked = true;
            }

            PsychrometricsUserControl = new PsychrometricsTabPage(ApplicationSettings);
            PsychrometricsUserControl.Dock = DockStyle.Top;
            TabPage psychrometricsTabPage = new TabPage("Psychrometrics");
            psychrometricsTabPage.Controls.Add(PsychrometricsUserControl);
            tabControl1.TabPages.Add(psychrometricsTabPage);

            MerkelUserControl = new MerkelTabPage(ApplicationSettings);
            MerkelUserControl.Dock = DockStyle.Top;
            TabPage merkelTabPage = new TabPage("Merkel");
            merkelTabPage.Controls.Add(MerkelUserControl);
            tabControl1.TabPages.Add(merkelTabPage);

            DemandCurveUserControl = new DemandCurveTabPage(ApplicationSettings);
            TabPage demandCurveTabPage = new TabPage("Demand Curve");
            demandCurveTabPage.Controls.Add(DemandCurveUserControl);
            tabControl1.TabPages.Add(demandCurveTabPage);

            MechanicalDraftPerformanceCurveUserControl = new MechanicalDraftPerformanceCurveTabPage(ApplicationSettings);
            TabPage mechanicalDraftPerformanceCurveTabPage = new TabPage("Mechanical Draft Performance Curve");
            mechanicalDraftPerformanceCurveTabPage.Controls.Add(MechanicalDraftPerformanceCurveUserControl);
            tabControl1.TabPages.Add(mechanicalDraftPerformanceCurveTabPage);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void unitedStatesCustomaryUnitsIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            internationalSystemOfUnitsSIToolStripMenuItem.Checked = false;
            unitedStatesCustomaryUnitsIPToolStripMenuItem.Checked = true;
            ApplicationSettings.UnitsSelection = UnitsSelection.United_States_Customary_Units_IP;
            updateSettings();
        }

        private void internationalSystemOfUnitsSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            internationalSystemOfUnitsSIToolStripMenuItem.Checked = true;
            unitedStatesCustomaryUnitsIPToolStripMenuItem.Checked = false;
            ApplicationSettings.UnitsSelection = UnitsSelection.International_System_Of_Units_SI;
            updateSettings();
        }

        private void updateSettings()
        {
            PsychrometricsUserControl.SetUnitsStandard(ApplicationSettings);
            MerkelUserControl.SetUnitsStandard(ApplicationSettings);
            DemandCurveUserControl.SetUnitsStandard(ApplicationSettings);
        }
    }
}
