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
    public partial class MechanicalDraftPerformanceCurveTabPage : CalculatePrintUserControl
    {
        private MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }

        private TowerDesignDataForm TowerDesignDataForm { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public MechanicalDraftPerformanceCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI_);

            TowerDesignDataForm = new TowerDesignDataForm(IsDemo, IsInternationalSystemOfUnits_SI_);

            TestPointTabControl.TabPages.Clear();

            string errorMessage = string.Empty;
            LoadTestPoints(out errorMessage);

            if (Setup(out errorMessage))
            {
            }
        }

        public void SetUnitsStandard(ApplicationSettings applicationSettings)
        {
            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);
            SwitchUnits();
            TowerDesignDataForm.SetUnitsStandard(applicationSettings);
        }

        private void SwitchUnits()
        {
            MechanicalDraftPerformanceCurveViewModel.ConvertValues(IsInternationalSystemOfUnits_SI_);

            if (IsInternationalSystemOfUnits_SI_)
            {
                UnitsWaterFlowRate.Text = ConstantUnits.LitersPerSecond;
                UnitsHotWaterTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsColdWaterTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetBulbTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsDryBulbTemperature.Text = ConstantUnits.TemperatureCelsius;
                UnitsFanDriverPower.Text = ConstantUnits.Kilowatt;
                UnitsBarometricPressure.Text = ConstantUnits.BarometricPressureKiloPascal;
            }
            else
            {
                UnitsWaterFlowRate.Text = ConstantUnits.GallonsPerMinute;
                UnitsHotWaterTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsColdWaterTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetBulbTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsDryBulbTemperature.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsFanDriverPower.Text = ConstantUnits.BrakeHorsepower;
                UnitsBarometricPressure.Text = ConstantUnits.BarometricPressureInchOfMercury;
            }
        }

        public bool OpenDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if(MechanicalDraftPerformanceCurveViewModel.OpenDataFile(fileName, out errorMessage))
            {
                if (!TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData, out errorMessage))
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
                    CalculateButton.Enabled = true;
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

        public bool OpenNewDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (MechanicalDraftPerformanceCurveViewModel.OpenNewDataFile(fileName, out errorMessage))
            {
                if (!TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData, out errorMessage))
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
                    CalculateButton.Enabled = true;
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
                // design data
                OwnerNameField.Text = TowerDesignDataForm.TowerDesignData.OwnerNameValue;
                ProjectNameField.Text = TowerDesignDataForm.TowerDesignData.ProjectNameValue;
                LocationField.Text = TowerDesignDataForm.TowerDesignData.LocationValue;
                TowerManufacturerField.Text = TowerDesignDataForm.TowerDesignData.TowerManufacturerValue;
                TowerTypeField.Text = TowerDesignDataForm.TowerDesignData.TowerTypeValue.ToString();

                DesignWaterFlowRate.Text = TowerDesignDataForm.TowerDesignData.WaterFlowRateDataValue.InputValue;
                DesignHotWaterTemperature.Text = TowerDesignDataForm.TowerDesignData.HotWaterTemperatureDataValue.InputValue;
                DesignColdWaterTemperature.Text = TowerDesignDataForm.TowerDesignData.ColdWaterTemperatureDataValue.InputValue;
                DesignWetBulbTemperature.Text = TowerDesignDataForm.TowerDesignData.WetBulbTemperatureDataValue.InputValue;
                DesignDryBulbTemperature.Text = TowerDesignDataForm.TowerDesignData.DryBulbTemperatureDataValue.InputValue;
                DesignFanDriverPower.Text = TowerDesignDataForm.TowerDesignData.FanDriverPowerDataValue.InputValue;
                DesignBarometricPressure.Text = TowerDesignDataForm.TowerDesignData.BarometricPressureDataValue.InputValue;
                DesignLiquidToGasRatio.Text = TowerDesignDataForm.TowerDesignData.LiquidToGasRatioDataValue.InputValue;

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

            // set data
            if (TowerDesignDataForm.ShowDialog(this) == DialogResult.OK)
            {
                if(TowerDesignDataForm.HasDataChanged)
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
                TowerDesignDataForm.LoadData(MechanicalDraftPerformanceCurveViewModel.DesignData, out errorMessage);
            }
        }

        public override void Calculate()
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

        public override void Print()
        {
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Calculate();
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
