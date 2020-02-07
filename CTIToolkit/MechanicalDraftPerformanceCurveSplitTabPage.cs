using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurveSplitTabPage: UserControl
    {
        private MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }

        private TowerDesignDataUserControl TowerDesignDataUserControl { get; set; }

        private TowerDesignDataForm TowerDesignDataForm { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public MechanicalDraftPerformanceCurveSplitTabPage(ApplicationSettings applicationSettings)
        {
            InitializeComponent();

            IsInternationalSystemOfUnits_SI_ = (applicationSettings.UnitsSelection == UnitsSelection.International_System_Of_Units_SI);

            PerformanceCurveDesignDataButton_Click(null, null);

            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(IsDemo, IsInternationalSystemOfUnits_SI_);

            TowerDesignDataForm = new TowerDesignDataForm();
            TowerDesignDataUserControl = new TowerDesignDataUserControl(IsDemo, IsInternationalSystemOfUnits_SI_);
            TowerDesignDataForm.Controls.Add(TowerDesignDataUserControl);
            TowerDesignDataForm.AddControlEvents();

            string errorMessage = string.Empty;
            if (Setup(out errorMessage))
            {

            }
        }

        public bool OpenDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.OpenDataFile(fileName, out errorMessage, TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel))
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

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        public bool SaveDataFile(out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.SaveDataFile(out errorMessage))
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

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        public bool SaveAsDataFile(string fileName, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.SaveAsDataFile(fileName, out errorMessage))
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

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        private bool Setup(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
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

                // design data

                //PerformanceCurveOwnerNameField.Text = TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel.OwnerNameInputValue;
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

                DataFilename.Text = MechanicalDraftPerformanceCurveViewModel.DataFilenameInputValue;
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
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
            if(splitContainer1.Panel2Collapsed) // unlock
            {
                TowerDesignDataOwnerName.Enabled = true;
                TowerDesignDataProjectName.Enabled = true;
                TowerDesignDataLocation.Enabled = true;
                TowerDesignDataTowerManufacturer.Enabled = true;
                TowerDesignDataTowerTypeInducedRadio.Enabled = true;
                TowerDesignDataTowerTypeForcedRadio.Enabled = true;

                TowerDesignDataWaterFlowRate.Enabled = true;
                TowerDesignDataHotWaterTemperature.Enabled = true;
                TowerDesignDataColdWaterTemperature.Enabled = true;
                TowerDesignDataWetBulbTemperature.Enabled = true;
                TowerDesignDataDryBulbTemperature.Enabled = true;
                TowerDesignDataFanDriverPower.Enabled = true;
                TowerDesignDataBarometricPressure.Enabled = true;
                TowerDesignDataLiquidToGasRatio.Enabled = true;

                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel2.Show();
                PerformanceCurveDesignDataButton.Text = "Lock Design Data";
                if(ParentForm != null)
                {
                    ParentForm.Size = new Size(1908, 894);
                }
            }
            else // lock
            {
                TowerDesignDataOwnerName.Enabled = false;
                TowerDesignDataProjectName.Enabled = false;
                TowerDesignDataLocation.Enabled = false;
                TowerDesignDataTowerManufacturer.Enabled = false;
                TowerDesignDataTowerTypeInducedRadio.Enabled = false;
                TowerDesignDataTowerTypeForcedRadio.Enabled = false;

                TowerDesignDataWaterFlowRate.Enabled = false;
                TowerDesignDataHotWaterTemperature.Enabled = false;
                TowerDesignDataColdWaterTemperature.Enabled = false;
                TowerDesignDataWetBulbTemperature.Enabled = false;
                TowerDesignDataDryBulbTemperature.Enabled = false;
                TowerDesignDataFanDriverPower.Enabled = false;
                TowerDesignDataBarometricPressure.Enabled = false;
                TowerDesignDataLiquidToGasRatio.Enabled = false;

                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel2.Hide();
                PerformanceCurveDesignDataButton.Text = "Unlock Design Data";
                if (ParentForm != null)
                {
                    ParentForm.Size = new Size(933, 894);
                }
            }
        }

        private void PerformanceCurveCalculate_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveViewModel.CalculatePerformanceCurve(TowerDesignDataUserControl.MechanicalDraftPerformanceCurveTowerDesignViewModel, out errorMessage))
            {
                MessageBox.Show(errorMessage, "Mechanical Draft Performance Curve Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PerformanceCurveViewGraph_Click(object sender, EventArgs e)
        {
        }
    }
}
