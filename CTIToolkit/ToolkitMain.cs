// Copyright Cooling Technology Institute 2019-2021
using CTIToolkit.Properties;
using System;
using System.IO;
using System.Windows.Forms;

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
            UpdateUnits(ApplicationSettings.UnitsSelection);

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

        private void UnitedStatesCustomaryUnitsIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUnits(UnitsSelection.United_States_Customary_Units_IP);
            UpdateSettings();
        }

        private void InternationalSystemOfUnitsSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUnits(UnitsSelection.International_System_Of_Units_SI);
            UpdateSettings();
        }

        private void UnitedStatesCustomaryUnitsIPButton_Click(object sender, EventArgs e)
        {
            UnitedStatesCustomaryUnitsIPToolStripMenuItem_Click(sender, e);
        }

        private void InternationalSystemOfUnitsSIButton_Click(object sender, EventArgs e)
        {
            InternationalSystemOfUnitsSIToolStripMenuItem_Click(sender, e);
        }

        private void UpdateUnits(UnitsSelection units)
        {
            ApplicationSettings.UnitsSelection = units;
            if (ApplicationSettings.UnitsSelection == UnitsSelection.United_States_Customary_Units_IP)
            {
                UnitedStatesCustomaryUnitsIPMenuItem.Checked = true;
                InternationalSystemOfUnitsSIMenuItem.Checked = false;

                UnitedStatesCustomaryUnitsIPButton.Image = Resources.IPselected;
                InternationalSystemOfUnitsSIButton.Image = Resources.SI;
            }
            else
            {
                InternationalSystemOfUnitsSIMenuItem.Checked = true;
                UnitedStatesCustomaryUnitsIPMenuItem.Checked = false;

                UnitedStatesCustomaryUnitsIPButton.Image = Resources.IP;
                InternationalSystemOfUnitsSIButton.Image = Resources.SIselected;
            }
        }

        private void UpdateSettings()
        {
            PsychrometricsUserControl.SetUnitsStandard(ApplicationSettings);
            MerkelUserControl.SetUnitsStandard(ApplicationSettings);
            DemandCurveUserControl.SetUnitsStandard(ApplicationSettings);
            MechanicalDraftPerformanceCurveUserControl.SetUnitsStandard(ApplicationSettings);
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
                //                saveFileDialog.InitialDirectory = Application.UserAppDataPath;
                saveFileDialog.Filter = "Mechanical Draft Performance Curve files (*.mdpc)|*.mdpc|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "mdpc";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.Title = "New Mechanical Draft Performance Curve File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string errorMessage = string.Empty;

                    if (!MechanicalDraftPerformanceCurveUserControl.OpenNewDataFile(saveFileDialog.FileName, out errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Application.UserAppDataPath;
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
                //MechanicalDraftPerformanceCurve .mdpc
                openFileDialog.Filter = "Mechanical Draft Performance Curve files (*.mdpc)|*.mdpc|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.AddExtension = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.DefaultExt = "mdpc";
                openFileDialog.Title = "Open Mechanical Draft Performance Curve File";
                 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string errorMessage = string.Empty;

                    if(!MechanicalDraftPerformanceCurveUserControl.OpenDataFile(openFileDialog.FileName, out errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }
//                    if (!MechanicalDraftPerformanceCurveSplitTabPage.OpenDataFile(openFileDialog.FileName, out errorMessage))
  //                  {
    //                    MessageBox.Show(errorMessage);
      //              }
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveUserControl.SaveDataFile(out errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
//                saveFileDialog.InitialDirectory = Application.UserAppDataPath;
                saveFileDialog.Filter = "Mechanical Draft Performance Curve files (*.mdpc)|*.mdpc|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.DefaultExt = "mdpc";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.Title = "Save Mechanical Draft Performance Curve File As";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string errorMessage = string.Empty;

                    if (!MechanicalDraftPerformanceCurveUserControl.OpenDataFile(saveFileDialog.FileName, out errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }
                }
            }
        }

        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            // determine which is the current tab call it caculate click method
            foreach(Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;
                    calculatePrintUserControl.Print();
                    break;
                }
            }
        }

        private void PrintPreviewMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PrintSetupMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenMenuItem_Click(sender, e);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            NewFile_Click(sender, e);
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveMenuItem_Click(sender, e);
        }

        private void SaveAsFileButton_Click(object sender, EventArgs e)
        {
            SaveAsMenuItem_Click(sender, e);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintMenuItem_Click(sender, e);
        }

        private void Calculate_Click(object sender, EventArgs e)
        {

        }
    }
}
