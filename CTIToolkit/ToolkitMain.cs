// Copyright Cooling Technology Institute 2019-2021

using CTIToolkit.Properties;
using System;
using System.Drawing;
using System.Drawing.Printing;
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
            foreach (Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
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
                                MessageBox.Show(calculatePrintUserControl.ErrorMessage);
                            }
                        }
                    }
                    break;
                }
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
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
                                MessageBox.Show(calculatePrintUserControl.ErrorMessage);
                            }
                        }
                    }
                    break;
                }
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;
                    if (!calculatePrintUserControl.SaveDataFile())
                    {
                        MessageBox.Show(calculatePrintUserControl.ErrorMessage);
                    }
                }
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
            {
                if (control is CalculatePrintUserControl)
                {
                    CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");

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
                                MessageBox.Show(calculatePrintUserControl.ErrorMessage);
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
            if (tabControl1.SelectedIndex != -1)
            {
                foreach (Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
                {
                    if (control is CalculatePrintUserControl)
                    {
                        CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;
                        calculatePrintUserControl.PrintControl.Label = string.Empty;
                        calculatePrintUserControl.PrintControl.IsDesignData = false;

                        PrintLabelForm printLabelForm = new PrintLabelForm((tabControl1.SelectedIndex == 3));
                        printLabelForm.Height = (tabControl1.SelectedIndex == 3) ? 170 : 105;

                        if (printLabelForm.ShowDialog() == DialogResult.OK)
                        {
                            calculatePrintUserControl.PrintControl.Label = printLabelForm.GetLabel();
                            if (tabControl1.SelectedIndex == 3)
                            {
                                calculatePrintUserControl.PrintControl.IsDesignData = printLabelForm.IsDesignData();
                            }    
                        }
                        
                        PrintDialog printDialog = new PrintDialog()
                        {
                            AllowSelection = true,
                            AllowPrintToFile = true,
                            AllowSomePages = true
                        };

                        PrintDocument printDocument = new PrintDocument()
                        {
                            DocumentName = tabControl1.TabPages[tabControl1.SelectedIndex].Text,
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
            if(tabControl1.SelectedIndex != -1)
            {
                foreach (Control control in tabControl1.TabPages[tabControl1.SelectedIndex].Controls)
                {
                    if (control is CalculatePrintUserControl)
                    {
                        CalculatePrintUserControl calculatePrintUserControl = control as CalculatePrintUserControl;

                        PrintLabelForm printLabelForm = new PrintLabelForm((tabControl1.SelectedIndex == 3));
                        printLabelForm.Height = (tabControl1.SelectedIndex == 3) ? 170 : 105;

                        if (printLabelForm.ShowDialog() == DialogResult.OK)
                        {
                            calculatePrintUserControl.PrintControl.Label = printLabelForm.GetLabel();
                            if (tabControl1.SelectedIndex == 3)
                            {
                                calculatePrintUserControl.PrintControl.IsDesignData = printLabelForm.IsDesignData();
                            }
                        }

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
