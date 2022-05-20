// Copyright Cooling Technology Institute 2019-2021

using CTIToolkit.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CTIToolkit
{
    public partial class ToolkitMain : Form
    {
        public ApplicationSettings ApplicationSettings = new ApplicationSettings();

        string HelpFilename { get; set; }
        string InputFilename { get; set; }
        int TabControlIndex { get; set; }

        PsychrometricsTabPage PsychrometricsUserControl { get; set; }
        MerkelTabPage MerkelUserControl { get; set; }
        DemandCurveTabPage DemandCurveUserControl { get; set; }
        MechanicalDraftPerformanceCurveTabPage MechanicalDraftPerformanceCurveUserControl { get; set; }

        public ToolkitMain()
        {
            InitializeComponent();

            // get full path to your startup EXE
            string exeFile = Assembly.GetEntryAssembly().CodeBase;
            // get directory of your EXE file
            string exeDir = Path.GetDirectoryName(exeFile);
            HelpFilename = Path.Combine(exeDir, "ctitoolkit.chm");
            helpProvider1.HelpNamespace = HelpFilename;

            ApplicationSettings.Read();

            if(ApplicationSettings.IsDemo)
            {
                this.Text = "Cooling Technology Institute Toolkit Demo";
                MessageBox.Show(this, "The Toolkit is running in Demo mode. To enter your serial number click on to Help, About.", "Demo Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateUnits(ApplicationSettings.UnitsSelection);

            PsychrometricsUserControl = new PsychrometricsTabPage(ApplicationSettings);
            TabPage psychrometricsTabPage = new TabPage("Psychrometrics");
            psychrometricsTabPage.Controls.Add(PsychrometricsUserControl);
            CalculationTabControl.TabPages.Add(psychrometricsTabPage);

            MerkelUserControl = new MerkelTabPage(ApplicationSettings);
            TabPage merkelTabPage = new TabPage("Merkel");
            merkelTabPage.Controls.Add(MerkelUserControl);
            CalculationTabControl.TabPages.Add(merkelTabPage);

            DemandCurveUserControl = new DemandCurveTabPage(ApplicationSettings);
            DemandCurveUserControl.Dock = DockStyle.Top | DockStyle.Right;
            //DemandCurveUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabPage demandCurveTabPage = new TabPage("Demand Curve");
            demandCurveTabPage.Controls.Add(DemandCurveUserControl);
            CalculationTabControl.TabPages.Add(demandCurveTabPage);

            MechanicalDraftPerformanceCurveUserControl = new MechanicalDraftPerformanceCurveTabPage(ApplicationSettings);
            TabPage mechanicalDraftPerformanceCurveTabPage = new TabPage("Mechanical Draft Performance Curve");
            mechanicalDraftPerformanceCurveTabPage.Controls.Add(MechanicalDraftPerformanceCurveUserControl);
            CalculationTabControl.TabPages.Add(mechanicalDraftPerformanceCurveTabPage);

            string[] args = Environment.GetCommandLineArgs();
            InputFilename = string.Empty;
            if ((args != null) && (args.Length >= 2))
            {
                InputFilename = args[1];
                if (!string.IsNullOrWhiteSpace(InputFilename))
                {
                    string extension = Path.GetExtension(InputFilename);
                    if (!string.IsNullOrWhiteSpace(extension))
                    {
                        if(extension.ToLower() == "." + PsychrometricsUserControl.DefaultExt)
                        {
                            TabControlIndex = 0;
                        }
                        else if (extension.ToLower() == "." + MerkelUserControl.DefaultExt)
                        {
                            TabControlIndex = 1;
                        }
                        else if (extension.ToLower() == "." + DemandCurveUserControl.DefaultExt)
                        {
                            TabControlIndex = 2;
                        }
                        else if (extension.ToLower() == "." + MechanicalDraftPerformanceCurveUserControl.DefaultExt)
                        {
                            TabControlIndex = 3;
                        }
                        else
                        {
                            InputFilename = string.Empty;
                        }
                    }
                    else
                    {
                        InputFilename = string.Empty;
                    }
                }
                else
                {
                    InputFilename = string.Empty;
                }
            }

        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool isDemo = ApplicationSettings.IsDemo;

            About about = new About(ApplicationSettings);
            about.ShowDialog();
            
            if (ApplicationSettings.IsDemo)
            {
                this.Text = "Cooling Technology Institute Toolkit Demo";
                UpdateDemo(ApplicationSettings.IsDemo);
            }
            else
            {
                this.Text = "Cooling Technology Institute Toolkit";
                UpdateDemo(ApplicationSettings.IsDemo);
            }
        }

        private void UnitedStatesCustomaryUnitsIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUnits(UnitsSelection.United_States_Customary_Units_IP);
        }

        private void InternationalSystemOfUnitsSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateUnits(UnitsSelection.International_System_Of_Units_SI);
        }

        private void UnitedStatesCustomaryUnitsIPButton_Click(object sender, EventArgs e)
        {
            UnitedStatesCustomaryUnitsIPToolStripMenuItem_Click(sender, e);
        }

        private void InternationalSystemOfUnitsSIButton_Click(object sender, EventArgs e)
        {
            InternationalSystemOfUnitsSIToolStripMenuItem_Click(sender, e);
        }

        private void UpdateDemo(bool isDemo)
        {
            if (PsychrometricsUserControl != null)
            {
                PsychrometricsUserControl.UpdateDemo(isDemo);
            }
            if (MerkelUserControl != null)
            {
                MerkelUserControl.UpdateDemo(isDemo);
            }
            if (DemandCurveUserControl != null)
            {
                DemandCurveUserControl.UpdateDemo(isDemo);
            }
            if (MechanicalDraftPerformanceCurveUserControl != null)
            {
                MechanicalDraftPerformanceCurveUserControl.UpdateDemo(isDemo);
            }
        }

        public void UpdateUnits(UnitsSelection units)
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
            UpdateSettings();
        }

        private void UpdateSettings()
        {
            bool isSI = ApplicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI;
            if(PsychrometricsUserControl != null)
            {
                PsychrometricsUserControl.SetUnitsStandard(isSI);
            }
            if (MerkelUserControl != null)
            {
                MerkelUserControl.SetUnitsStandard(isSI);
            }
            if (DemandCurveUserControl != null)
            {
                DemandCurveUserControl.SetUnitsStandard(isSI);
            }
            if (MechanicalDraftPerformanceCurveUserControl != null)
            {
                MechanicalDraftPerformanceCurveUserControl.SetUnitsStandard(isSI);
            }
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cooling Technology Institute", "CTI Toolkit 4.0");
                        saveFileDialog.Filter = calculatePrintUserControl.Filter;
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.DefaultExt = calculatePrintUserControl.DefaultExt;
                        saveFileDialog.OverwritePrompt = true;
                        saveFileDialog.CheckPathExists = true;
                        saveFileDialog.Title = "New " + calculatePrintUserControl.Title + " File";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (!calculatePrintUserControl.OpenNewDataFile(saveFileDialog.FileName))
                            {
                                MessageBox.Show(calculatePrintUserControl.ErrorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                }
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cooling Technology Institute", "CTI Toolkit 4.0");
                        openFileDialog.Filter = calculatePrintUserControl.Filter;
                        openFileDialog.FilterIndex = 1;
                        openFileDialog.AddExtension = true;
                        openFileDialog.CheckFileExists = true;
                        openFileDialog.CheckPathExists = true;
                        openFileDialog.DefaultExt = calculatePrintUserControl.DefaultExt;
                        openFileDialog.Title = "Open " + calculatePrintUserControl.Title + " File";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (!calculatePrintUserControl.OpenDataFile(openFileDialog.FileName))
                            {
                                MessageBox.Show(calculatePrintUserControl.ErrorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    break;
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;
                    if (!calculatePrintUserControl.SaveDataFile())
                    {
                        MessageBox.Show(calculatePrintUserControl.ErrorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cooling Technology Institute", "CTI Toolkit 4.0");

                        saveFileDialog.Filter = calculatePrintUserControl.Filter;
                        saveFileDialog.FilterIndex = 1;
                        saveFileDialog.DefaultExt = calculatePrintUserControl.DefaultExt;
                        saveFileDialog.OverwritePrompt = true;
                        saveFileDialog.CheckPathExists = true;
                        saveFileDialog.Title = "Save " + calculatePrintUserControl.Title + " File As";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if (!calculatePrintUserControl.SaveAsDataFile(saveFileDialog.FileName))
                            {
                                MessageBox.Show(calculatePrintUserControl.ErrorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                break;
            }
        }

        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            string label = string.Empty;

            // determine which is the current tab call it caculate click method
            if (CalculationTabControl.SelectedIndex != -1)
            {
                foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
                {
                    if (control is CalculatePrintUserControl)
                    {
                        CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;
                        calculatePrintUserControl.PrintControl.Label = string.Empty;
                        calculatePrintUserControl.PrintControl.IsDesignData = false;

                        PrintLabelForm printLabelForm = new PrintLabelForm((CalculationTabControl.SelectedIndex == 3));
                        printLabelForm.Height = (CalculationTabControl.SelectedIndex == 3) ? 170 : 105;

                        if (printLabelForm.ShowDialog() == DialogResult.OK)
                        {
                            calculatePrintUserControl.PrintControl.Label = printLabelForm.GetLabel();
                            if (CalculationTabControl.SelectedIndex == 3)
                            {
                                calculatePrintUserControl.PrintControl.IsDesignData = printLabelForm.IsDesignData();
                            }    
                        }
                        calculatePrintUserControl.PrintControl.UserControl = null;

                        PrintDialog printDialog = new PrintDialog()
                        {
                            AllowSelection = true,
                            AllowPrintToFile = true,
                            AllowSomePages = true
                        };

                        PrintDocument printDocument = new PrintDocument()
                        {
                            DocumentName = CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Text,
                        };

                        printDocument.PrintPage += new PrintPageEventHandler(calculatePrintUserControl.PrintPage);
                        DialogResult userResponse = printDialog.ShowDialog();
                        if (userResponse == DialogResult.OK)
                        {
                            printDocument.PrinterSettings = printDialog.PrinterSettings;
                            printDocument.Print();
                        }
                        break;
                    }

                }

            }
        }

        private void PrintPreviewMenuItem_Click(object sender, EventArgs e)
        {
            if(CalculationTabControl.SelectedIndex != -1)
            {
                foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
                {
                    if (control is CalculatePrintUserControl)
                    {
                        CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                        PrintLabelForm printLabelForm = new PrintLabelForm((CalculationTabControl.SelectedIndex == 3));
                        printLabelForm.Height = (CalculationTabControl.SelectedIndex == 3) ? 170 : 105;

                        if (printLabelForm.ShowDialog() == DialogResult.OK)
                        {
                            calculatePrintUserControl.PrintControl.Label = printLabelForm.GetLabel();
                            if (CalculationTabControl.SelectedIndex == 3)
                            {
                                calculatePrintUserControl.PrintControl.IsDesignData = printLabelForm.IsDesignData();
                            }
                        }
                        calculatePrintUserControl.PrintControl.UserControl = null;

                        PrintDocument printDocument = new PrintDocument();
                        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog()
                        {
                            ClientSize = new Size(600, 800)
                        };
                        printDocument.PrintPage += new PrintPageEventHandler(calculatePrintUserControl.PrintPage);
                        printPreviewDialog.Document = printDocument;
                        printPreviewDialog.ShowDialog();
                        break;
                    }

                }
            }
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

        private void HelpContentMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, HelpFilename);
        }

        private void ToolkitMain_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            switch (CalculationTabControl.SelectedIndex)
            {
                case 0: // psychrometrics
                    Help.ShowHelp(this, HelpFilename, HelpNavigator.Index, "Psychrometrics");
                    break;
                case 1: // Merkel
                    Help.ShowHelp(this, HelpFilename, HelpNavigator.Index, "Merkel");
                    break;
                case 2: // DemandCurve
                    Help.ShowHelp(this, HelpFilename, HelpNavigator.Index, "Demand Curve");
                    break;
                case 3: // MechanicalDraftPerformanceCurve
                    Help.ShowHelp(this, HelpFilename, HelpNavigator.Index, "Mechanical Draft Performance Curve");
                    break;
                default:
                    Help.ShowHelp(this, HelpFilename);
                    break;
            }
        }

        private void ToolkitMain_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InputFilename))
            {
                CalculationTabControl.SelectedIndex = TabControlIndex;
                foreach (Control control in CalculationTabControl.TabPages[CalculationTabControl.SelectedIndex].Controls)
                {
                    if (control is CalculatePrintUserControl)
                    {
                        CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                        if (!calculatePrintUserControl.OpenDataFile(InputFilename))
                        {
                            MessageBox.Show(calculatePrintUserControl.ErrorMessage, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                }
            }
        }

        private void DocumentationMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cooling Technology Institute", "CTI Toolkit 4.0");
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.AddExtension = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.DefaultExt = "pdf";
                openFileDialog.Title = "Open PDF File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    new Process
                    {
                        StartInfo = new ProcessStartInfo(openFileDialog.FileName)
                        {
                            UseShellExecute = true
                        }
                    }.Start();
                }
            }
        }
    }
}
