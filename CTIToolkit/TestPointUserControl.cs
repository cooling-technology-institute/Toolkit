using System;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class TestPointUserControl : UserControl
    {
        public TowerTestPoint TowerTestPoint { get; set; }
        public string ErrorMessage { get; set; }

        //public bool IsDemo { get; set; }
        //public bool IsInternationalSystemOfUnits_SI { get; set; }

        public TestPointUserControl()
        {
            InitializeComponent();
            ErrorMessage = string.Empty;
        }

        public bool SetDisplayedValues()
        {
            ErrorMessage = string.Empty;
            
            try
            {
                WaterFlowRate.Text = TowerTestPoint.WaterFlowRateDataValue.InputValue;
                toolTip1.SetToolTip(WaterFlowRate, TowerTestPoint.WaterFlowRateDataValue.ToolTip);

                HotWaterTemperature.Text = TowerTestPoint.HotWaterTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(HotWaterTemperature, TowerTestPoint.HotWaterTemperatureDataValue.ToolTip);

                ColdWaterTemperature.Text = TowerTestPoint.ColdWaterTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(ColdWaterTemperature, TowerTestPoint.ColdWaterTemperatureDataValue.ToolTip);

                WetBulbTemperature.Text = TowerTestPoint.WetBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature, TowerTestPoint.WetBulbTemperatureDataValue.ToolTip);

                DryBulbTemperature.Text = TowerTestPoint.DryBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(DryBulbTemperature, TowerTestPoint.DryBulbTemperatureDataValue.ToolTip);

                FanDriverPower.Text = TowerTestPoint.FanDriverPowerDataValue.InputValue;
                toolTip1.SetToolTip(FanDriverPower, TowerTestPoint.FanDriverPowerDataValue.ToolTip);

                BarometricPressure.Text = TowerTestPoint.BarometricPressureDataValue.InputValue;
                toolTip1.SetToolTip(BarometricPressure, TowerTestPoint.BarometricPressureDataValue.ToolTip);

                LiquidToGasRatio.Text = TowerTestPoint.LiquidToGasRatioDataValue.InputValue;
                toolTip1.SetToolTip(LiquidToGasRatio, TowerTestPoint.LiquidToGasRatioDataValue.ToolTip);
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
        }

        public bool LoadData(TowerTestPoint towerTestPoint)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            TowerTestPoint = towerTestPoint;

            if (TowerTestPoint != null)
            {
                 if (!SetDisplayedValues())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data.");
            }

            ErrorMessage = stringBuilder.ToString();

            return returnValue;
        }

        private void WaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WaterFlowRate, "");
        }

        private void WaterFlowRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.WaterFlowRateDataValue.UpdateValue(WaterFlowRate.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WaterFlowRate.Select(0, WaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WaterFlowRate, errorMessage);
            }
        }

        private void HotWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(HotWaterTemperature, "");
        }

        private void HotWaterTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.HotWaterTemperatureDataValue.UpdateValue(HotWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                HotWaterTemperature.Select(0, HotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(HotWaterTemperature, errorMessage);
            }
            else if(TowerTestPoint.HotWaterTemperatureDataValue.Current <= TowerTestPoint.ColdWaterTemperatureDataValue.Current) 
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                HotWaterTemperature.Select(0, HotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(HotWaterTemperature, "Hot Water Temperature must be greater than the Cold Water Temperature.");
            }
        }

        private void ColdWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(ColdWaterTemperature, "");
        }

        private void ColdWaterTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.ColdWaterTemperatureDataValue.UpdateValue(ColdWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature.Select(0, ColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature, errorMessage);
            }
            else if (TowerTestPoint.ColdWaterTemperatureDataValue.Current >= TowerTestPoint.HotWaterTemperatureDataValue.Current)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature.Select(0, ColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature, "Cold Water Temperature must be less than the Hot Water Temperature.");
            }
        }

        private void WetBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature, "");
        }

        private void WetBulbTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.WetBulbTemperatureDataValue.UpdateValue(WetBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature.Select(0, WetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature, errorMessage);
            }
        }

        private void DryBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DryBulbTemperature, "");
        }

        private void DryBulbTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.DryBulbTemperatureDataValue.UpdateValue(DryBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature.Select(0, DryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature, errorMessage);
            }
        }

        private void FanDriverPower_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(FanDriverPower, "");
        }

        private void FanDriverPower_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.FanDriverPowerDataValue.UpdateValue(FanDriverPower.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                FanDriverPower.Select(0, FanDriverPower.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(FanDriverPower, errorMessage);
            }
        }

        private void BarometricPressure_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(BarometricPressure, "");
        }

        private void BarometricPressure_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.BarometricPressureDataValue.UpdateValue(BarometricPressure.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                BarometricPressure.Select(0, BarometricPressure.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(BarometricPressure, errorMessage);
            }
        }

        private void LiquidToGasRatio_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LiquidToGasRatio, "");
        }

        private void LiquidToGasRatio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerTestPoint.LiquidToGasRatioDataValue.UpdateValue(LiquidToGasRatio.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidToGasRatio.Select(0, LiquidToGasRatio.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidToGasRatio, errorMessage);
            }
        }
    }
}
