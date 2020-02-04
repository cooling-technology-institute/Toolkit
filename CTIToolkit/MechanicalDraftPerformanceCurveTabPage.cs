using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurveTabPage : UserControl
    {
        private MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }
        private MechanicalDraftPerformanceCurveTowerDesignViewModel MechanicalDraftPerformanceCurveTowerDesignViewModel { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS_ { get; set; }

        public MechanicalDraftPerformanceCurveTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_IS_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(IsDemo, IsInternationalSystemOfUnits_IS_);
            MechanicalDraftPerformanceCurveTowerDesignViewModel = new MechanicalDraftPerformanceCurveTowerDesignViewModel(IsDemo, IsInternationalSystemOfUnits_IS_);
            
            Setup();
        }

        private void Setup()
        {
            PerformanceCurveWaterFlowRateLabel.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputMessage + ":";
            PerformanceCurveWaterFlowRateLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestWaterFlowRate.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestWaterFlowRate, MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueTooltip);

            PerformanceCurveHotWaterTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueInputMessage + ":";
            PerformanceCurveHotWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestHotWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestHotWaterTemperature, MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueTooltip);

            PerformanceCurveColdWaterTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueInputMessage + ":";
            PerformanceCurveColdWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestColdWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestColdWaterTemperature, MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueTooltip);

            PerformanceCurveWetBulbTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueInputMessage + ":";
            PerformanceCurveWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestWetBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestWetBulbTemperature, MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueTooltip);

            PerformanceCurveDryBulbTemperatureLabel.Text = MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueInputMessage + ":";
            PerformanceCurveDryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestDryBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestDryBulbTemperature, MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueTooltip);

            PerformanceCurveFanDriverPowerLabel.Text = MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueInputMessage + ":";
            PerformanceCurveFanDriverPowerLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestFanDriverPower.Text = MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestFanDriverPower, MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueTooltip);

            PerformanceCurveBarometricPressureLabel.Text = MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueInputMessage + ":";
            PerformanceCurveBarometricPressureLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestBarometricPressure.Text = MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestBarometricPressure, MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueTooltip);

            PerformanceCurveLiquidToGasRatioLabel.Text = MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueInputMessage + ":";
            PerformanceCurveLiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
            PerformanceCurveTestLiquidToGasRatio.Text = MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueInputValue;
            toolTip1.SetToolTip(PerformanceCurveTestLiquidToGasRatio, MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueTooltip);

            PerformanceCurveOwnerNameField.Text = "";
            PerformanceCurveProjectNameField.Text = "";
            PerformanceCurveLocationField.Text = "";
            PerformanceCurveTowerManufacturerField.Text = "";
            PerformanceCurveTowerTypeField.Text = "";
        }

        private void PerformanceCurveTestWaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestWaterFlowRate, "");
        }

        private void PerformanceCurveTestWaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueUpdateValue(PerformanceCurveTestWaterFlowRate.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestWaterFlowRate.Select(0, PerformanceCurveTestWaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestWaterFlowRate, errorMessage);
            }
        }

        private void PerformanceCurveTestHotWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestHotWaterTemperature, "");
        }

        private void PerformanceCurveTestHotWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueUpdateValue(PerformanceCurveTestHotWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestHotWaterTemperature.Select(0, PerformanceCurveTestHotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestHotWaterTemperature, errorMessage);
            }
        }

        private void PerformanceCurveTestColdWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestColdWaterTemperature, "");
        }

        private void PerformanceCurveTestColdWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueUpdateValue(PerformanceCurveTestColdWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestColdWaterTemperature.Select(0, PerformanceCurveTestColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestColdWaterTemperature, errorMessage);
            }
        }

        private void PerformanceCurveTestWetBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestWetBulbTemperature, "");
        }

        private void PerformanceCurveTestWetBulbTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueUpdateValue(PerformanceCurveTestWetBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestWetBulbTemperature.Select(0, PerformanceCurveTestWetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestWetBulbTemperature, errorMessage);
            }
        }

        private void PerformanceCurveTestDryBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestDryBulbTemperature, "");
        }

        private void PerformanceCurveTestDryBulbTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueUpdateValue(PerformanceCurveTestDryBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestDryBulbTemperature.Select(0, PerformanceCurveTestDryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestDryBulbTemperature, errorMessage);
            }
        }

        private void PerformanceCurveTestFanDriverPower_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestFanDriverPower, "");
        }

        private void PerformanceCurveTestFanDriverPower_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueUpdateValue(PerformanceCurveTestFanDriverPower.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestFanDriverPower.Select(0, PerformanceCurveTestFanDriverPower.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestFanDriverPower, errorMessage);
            }
        }

        private void PerformanceCurveTestBarometricPressure_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestBarometricPressure, "");
        }

        private void PerformanceCurveTestBarometricPressure_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueUpdateValue(PerformanceCurveTestBarometricPressure.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestBarometricPressure.Select(0, PerformanceCurveTestBarometricPressure.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestBarometricPressure, errorMessage);
            }
        }

        private void PerformanceCurveTestLiquidToGasRatio_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(PerformanceCurveTestLiquidToGasRatio, "");
        }

        private void PerformanceCurveTestLiquidToGasRatio_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueUpdateValue(PerformanceCurveTestLiquidToGasRatio.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                PerformanceCurveTestLiquidToGasRatio.Select(0, PerformanceCurveTestLiquidToGasRatio.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(PerformanceCurveTestLiquidToGasRatio, errorMessage);
            }
        }

        private void PerformanceCurveDesignDataButton_Click(object sender, EventArgs e)
        {
            var control = new TowerDesignDataUserControl();
            //PsychrometricsUserControl = new PsychrometricsTabPage(ApplicationSettings);
            //PsychrometricsUserControl.Dock = DockStyle.Top;
            //TabPage psychrometricsTabPage = new TabPage("Psychrometrics");
            //psychrometricsTabPage.Controls.Add(PsychrometricsUserControl);
            //tabControl1.TabPages.Add(psychrometricsTabPage);

            //splitContainer1.Panel2.Controls.Add(control);

            //Disable your other controls here


            if (await control.ShowModalAsync() == DialogResult.OK) //Execution will pause here until the user closes the "dialog" (task completes), just like a modal dialog.
            {
                // save data
            }
        }
    }
}
