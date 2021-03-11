using Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurveTabPage : UserControl
    {
        private MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }

        private TowerDesignDataUserControl TowerDesignDataUserControl { get; set; }

        private TowerDesignDataForm TowerDesignDataForm { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public MechanicalDraftPerformanceCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI_);

            TowerDesignDataForm = new TowerDesignDataForm();
            TowerDesignDataUserControl = new TowerDesignDataUserControl(IsDemo, IsInternationalSystemOfUnits_SI_);
            TowerDesignDataForm.Controls.Add(TowerDesignDataUserControl);
            TowerDesignDataForm.AddControlEvents();

            TestPointTabControl.TabPages.Clear();

            string errorMessage = string.Empty;
            LoadTestPoints(out errorMessage);

            if (Setup(out errorMessage))
            {
            }
        }

        public bool OpenDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            MechanicalDraftPerformanceCurveFileData fileData;

            try
            {
                fileData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveFileData>(File.ReadAllText(fileName));
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to read file: {0}. Exception: {1}", Path.GetFileName(fileName), e.ToString());
                return false;
            }

            if(fileData != null)
            {
                if (IsInternationalSystemOfUnits_SI_ != fileData.IsInternationalSystemOfUnits_SI)
                {
                    IsInternationalSystemOfUnits_SI_ = fileData.IsInternationalSystemOfUnits_SI;
                }

                if (!MechanicalDraftPerformanceCurveViewModel.LoadData(fileData, out errorMessage))
                {
                    //TestWaterFlowRate_Validating(null, null);
                    stringBuilder.AppendLine(errorMessage);
                    returnValue = false;
                    errorMessage = string.Empty;
                }

                if (!TowerDesignDataUserControl.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    returnValue = false;
                    errorMessage = string.Empty;
                }

                // enable controls
                AddTestPointButton.Enabled = true;
                AddTestPointName.Enabled = true;

                if (MechanicalDraftPerformanceCurveViewModel.TestPoints.Count > 0)
                {
                    Calculate.Enabled = true;
                    ViewGraph.Enabled = true;
                }

                if (!LoadTestPoints(out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    returnValue = false;
                    errorMessage = string.Empty;
                }

                if (!Setup(out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    returnValue = false;
                    errorMessage = string.Empty;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
            }

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        public bool LoadTestPoints(out string errorMessage)
        {
            bool returnValue = true;

            errorMessage = string.Empty;

            TestPointTabControl.TabPages.Clear();
            foreach (TowerTestPoint towerTestPoint in MechanicalDraftPerformanceCurveViewModel.TestPoints)
            {
                //TabPage tabPage = new TabPage();
                //tabPage.Text = title;
                //TestPointUserControl testPointUserControl = new TestPointUserControl();
                //testPointUserControl.LoadData(data, out errorMessage);
                //tabPage.Controls.Add(testPointUserControl);
                //TestPointTabControl.TabPages.Add(tabPage);

                TestPointUserControl testPointUserControl = new TestPointUserControl();
                if(!testPointUserControl.LoadData(towerTestPoint, out errorMessage))
                {
                    returnValue = false;
                }
                TabPage tabPage = new TabPage();
                tabPage.Controls.Add(testPointUserControl);
                tabPage.Text = towerTestPoint.TestName;
                TestPointTabControl.TabPages.Add(tabPage);
            }
            return returnValue;
        }

        public bool SaveDataFile(out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            errorMessage = string.Empty;

            //if (!MechanicalDraftPerformanceCurveViewModel.SaveDataFile(out errorMessage))
            //{
            //    stringBuilder.AppendLine(errorMessage);
            //    returnValue = false;
            //    errorMessage = string.Empty;
            //}

            if (!Setup(out errorMessage))
            {
                stringBuilder.AppendLine(errorMessage);
                returnValue = false;
                errorMessage = string.Empty;
            }

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        //public bool SaveAsDataFile(string fileName, out string errorMessage)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    bool returnValue = true;
        //    errorMessage = string.Empty;
            
        //    if (!MechanicalDraftPerformanceCurveViewModel.SaveAsDataFile(fileName, out errorMessage))
        //    {
        //        stringBuilder.AppendLine(errorMessage);
        //        returnValue = false;
        //        errorMessage = string.Empty;
        //    }

        //    if (!Setup(out errorMessage))
        //    {
        //        stringBuilder.AppendLine(errorMessage);
        //        returnValue = false;
        //        errorMessage = string.Empty;
        //    }

        //    errorMessage = stringBuilder.ToString();

        //    return returnValue;
        //}

        private bool Setup(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                //WaterFlowRateLabel.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputMessage + ":";
                //WaterFlowRateLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestWaterFlowRate.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputValue;
                //toolTip1.SetToolTip(TestWaterFlowRate, MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueTooltip);

                //HotWaterTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueInputMessage + ":";
                //HotWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestHotWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueInputValue;
                //toolTip1.SetToolTip(TestHotWaterTemperature, MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueTooltip);

                //ColdWaterTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueInputMessage + ":";
                //ColdWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestColdWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueInputValue;
                //toolTip1.SetToolTip(TestColdWaterTemperature, MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueTooltip);

                //WetBulbTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueInputMessage + ":";
                //WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestWetBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueInputValue;
                //toolTip1.SetToolTip(TestWetBulbTemperature, MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueTooltip);

                //DryBulbTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueInputMessage + ":";
                //DryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestDryBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueInputValue;
                //toolTip1.SetToolTip(TestDryBulbTemperature, MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueTooltip);

                //FanDriverPowerLabel.Text = MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueInputMessage + ":";
                //FanDriverPowerLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestFanDriverPower.Text = MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueInputValue;
                //toolTip1.SetToolTip(TestFanDriverPower, MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueTooltip);

                //BarometricPressureLabel.Text = MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueInputMessage + ":";
                //BarometricPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestBarometricPressure.Text = MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueInputValue;
                //toolTip1.SetToolTip(TestBarometricPressure, MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueTooltip);

                //LiquidToGasRatioLabel.Text = MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueInputMessage + ":";
                //LiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
                //TestLiquidToGasRatio.Text = MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueInputValue;
                //toolTip1.SetToolTip(TestLiquidToGasRatio, MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueTooltip);

                // design data

                OwnerNameField.Text = TowerDesignDataUserControl.TowerDesignData.OwnerNameValue;
                ProjectNameField.Text = TowerDesignDataUserControl.TowerDesignData.ProjectNameValue;
                LocationField.Text = TowerDesignDataUserControl.TowerDesignData.LocationValue;
                TowerManufacturerField.Text = TowerDesignDataUserControl.TowerDesignData.TowerManufacturerValue;
                TowerTypeField.Text = TowerDesignDataUserControl.TowerDesignData.TowerTypeValue.ToString();

                DesignWaterFlowRate.Text = TowerDesignDataUserControl.TowerDesignData.WaterFlowRateDataValue.InputValue;
                DesignHotWaterTemperature.Text = TowerDesignDataUserControl.TowerDesignData.HotWaterTemperatureDataValue.InputValue;
                DesignColdWaterTemperature.Text = TowerDesignDataUserControl.TowerDesignData.ColdWaterTemperatureDataValue.InputValue;
                DesignWetBulbTemperature.Text = TowerDesignDataUserControl.TowerDesignData.WetBulbTemperatureDataValue.InputValue;
                DesignDryBulbTemperature.Text = TowerDesignDataUserControl.TowerDesignData.DryBulbTemperatureDataValue.InputValue;
                DesignFanDriverPower.Text = TowerDesignDataUserControl.TowerDesignData.FanDriverPowerDataValue.InputValue;
                DesignBarometricPressure.Text = TowerDesignDataUserControl.TowerDesignData.BarometricPressureDataValue.InputValue;
                DesignLiquidToGasRatio.Text = TowerDesignDataUserControl.TowerDesignData.LiquidToGasRatioDataValue.InputValue;

                DataFilename.Text = MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue;

                TestResultsGroupBox.Text = string.Format("Test Results ({0})", (IsInternationalSystemOfUnits_SI_) ? "SI" : "IP");
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
        }

        //private void TestWaterFlowRate_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestWaterFlowRate, "");
        //}

        //private void TestWaterFlowRate_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueUpdateValue(TestWaterFlowRate.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestWaterFlowRate.Select(0, TestWaterFlowRate.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestWaterFlowRate, errorMessage);
        //    }
        //}

        //private void TestHotWaterTemperature_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestHotWaterTemperature, "");
        //}

        //private void TestHotWaterTemperature_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueUpdateValue(TestHotWaterTemperature.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestHotWaterTemperature.Select(0, TestHotWaterTemperature.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestHotWaterTemperature, errorMessage);
        //    }
        //}

        //private void TestColdWaterTemperature_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestColdWaterTemperature, "");
        //}

        //private void TestColdWaterTemperature_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueUpdateValue(TestColdWaterTemperature.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestColdWaterTemperature.Select(0, TestColdWaterTemperature.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestColdWaterTemperature, errorMessage);
        //    }
        //}

        //private void TestWetBulbTemperature_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestWetBulbTemperature, "");
        //}

        //private void TestWetBulbTemperature_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueUpdateValue(TestWetBulbTemperature.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestWetBulbTemperature.Select(0, TestWetBulbTemperature.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestWetBulbTemperature, errorMessage);
        //    }
        //}

        //private void TestDryBulbTemperature_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestDryBulbTemperature, "");
        //}

        //private void TestDryBulbTemperature_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueUpdateValue(TestDryBulbTemperature.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestDryBulbTemperature.Select(0, TestDryBulbTemperature.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestDryBulbTemperature, errorMessage);
        //    }
        //}

        //private void TestFanDriverPower_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestFanDriverPower, "");
        //}

        //private void TestFanDriverPower_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueUpdateValue(TestFanDriverPower.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestFanDriverPower.Select(0, TestFanDriverPower.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestFanDriverPower, errorMessage);
        //    }
        //}

        //private void TestBarometricPressure_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestBarometricPressure, "");
        //}

        //private void TestBarometricPressure_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueUpdateValue(TestBarometricPressure.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestBarometricPressure.Select(0, TestBarometricPressure.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestBarometricPressure, errorMessage);
        //    }
        //}

        //private void TestLiquidToGasRatio_Validated(object sender, EventArgs e)
        //{
        //    errorProvider1.SetError(TestLiquidToGasRatio, "");
        //}

        //private void TestLiquidToGasRatio_Validating(object sender, CancelEventArgs e)
        //{
        //    string errorMessage = string.Empty;

        //    if (!MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueUpdateValue(TestLiquidToGasRatio.Text, out errorMessage))
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e.Cancel = true;
        //        TestLiquidToGasRatio.Select(0, TestLiquidToGasRatio.Text.Length);

        //        // Set the ErrorProvider error with the text to display. 
        //        this.errorProvider1.SetError(TestLiquidToGasRatio, errorMessage);
        //    }
        //}

        private void DesignDataButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            // design data

            //TowerDesignDataForm.TowerDesignDataOwnerName.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.OwnerNameInputValue;
            //PerformanceCurveProjectNameField.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.ProjectNameInputValue;
            //PerformanceCurveLocationField.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.LocationInputValue;
            //PerformanceCurveTowerManufacturerField.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.TowerManufacturerInputValue;
            //PerformanceCurveTowerTypeField.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.TowerTypeInputValue.ToString();

            //PerformanceCurveDesignWaterFlowRate.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.WaterFlowRateDataValueInputValue;
            //PerformanceCurveDesignHotWaterTemperature.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.HotWaterTemperatureDataValueInputValue;
            //PerformanceCurveDesignColdWaterTemperature.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.ColdWaterTemperatureDataValueInputValue;
            //PerformanceCurveDesignWetBulbTemperature.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.WetBulbTemperatureDataValueInputValue;
            //PerformanceCurveDesignDryBulbTemperature.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.DryBulbTemperatureDataValueInputValue;
            //PerformanceCurveDesignFanDriverPower.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.FanDriverPowerDataValueInputValue;
            //PerformanceCurveDesignBarometricPressure.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.BarometricPressureDataValueInputValue;
            //PerformanceCurveDesignLiquidToGasRatio.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.LiquidToGasRatioDataValueInputValue;


            // set data
            if (TowerDesignDataForm.ShowDialog(this) == DialogResult.OK)
            {
                if(TowerDesignDataUserControl.IsChanged)
                {
                    // enable controls
                    AddTestPointButton.Enabled = true;
                    AddTestPointName.Enabled = true;

                    // update data on this page
                    if (Setup(out errorMessage))
                    {

                    }
                }
            }
            else
            {
                // do nothing?
            }
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (MechanicalDraftPerformanceCurveViewModel.GetDataTable() != null)
            {
                DataGridView.DataSource = null;
            }

            if (MechanicalDraftPerformanceCurveViewModel.GetDataTable() != null)
            {
                // Set a DataGrid control's DataSource to the DataView.
                DataGridView.DataSource = new DataView(MechanicalDraftPerformanceCurveViewModel.GetDataTable());
            }

            //            if(MechanicalDraftPerformanceCurveViewModel.CalculatePerformanceCurve(TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel, out errorMessage))
            //            {
            //                if (MechanicalDraftPerformanceCurveViewModel.GetDataTable() != null)
            //                {
            //                    // Set a DataGrid control's DataSource to the DataView.
            ////                    MechanicalDraftPerformanceCurveGridView.DataSource = new DataView(MechanicalDraftPerformanceCurveViewModel.GetDataTable());
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(errorMessage, "Mechanical Draft Performance Curve Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
        }

        private void ViewGraph_Click(object sender, EventArgs e)
        {
        }

        private void TestSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTestPointButton_Click(object sender, EventArgs e)
        {
            string errorMessage;

            AddTabPage(AddTestPointName.Text, out errorMessage);
            AddTestPointName.Text = string.Empty;
        }

        private bool AddTabPage(string testName, out string errorMessage)
        {
            bool returnValue = true;

            try
            {
                MechanicalDraftPerformanceCurveViewModel.AddTestPoint(testName, out errorMessage);
                TabPage tabPage = new TabPage();
                tabPage.Text = testName;
                TestPointUserControl testPointUserControl = new TestPointUserControl();
                testPointUserControl.LoadData(MechanicalDraftPerformanceCurveViewModel.TestPoints[MechanicalDraftPerformanceCurveViewModel.TestPoints.Count - 1], out errorMessage);
                tabPage.Controls.Add(testPointUserControl);
                TestPointTabControl.TabPages.Add(tabPage);
                TestPointTabControl.SelectedIndex = TestPointTabControl.TabPages.Count - 1;
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }
    }
}
