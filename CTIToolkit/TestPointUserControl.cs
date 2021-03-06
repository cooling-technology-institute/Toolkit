﻿using System;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class TestPointUserControl : UserControl
    {
        public TowerTestPoint TowerTestPoint { get; set; }
        public string ErrorMessage { get; set; }

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

        private void NotifyParentDataHasChanged()
        {
            try
            {
                MechanicalDraftPerformanceCurveTabPage parentTab = this.Parent.Parent.Parent.Parent as MechanicalDraftPerformanceCurveTabPage;
                if (parentTab != null)
                {
                    parentTab.ValueHasChanged();
                }
            }
            catch
            { }
        }

        private void WaterFlowRate_Validated(object sender, EventArgs e)
        {
            NotifyParentDataHasChanged();
            errorProvider1.SetError(WaterFlowRate, "");
        }

        private void WaterFlowRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.WaterFlowRateDataValue.UpdateValue(WaterFlowRate.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WaterFlowRate.Select(0, WaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WaterFlowRate, TowerTestPoint.WaterFlowRateDataValue.ErrorMessage);
            }
        }

        private void HotWaterTemperature_Validated(object sender, EventArgs e)
        {
            NotifyParentDataHasChanged();
            errorProvider1.SetError(HotWaterTemperature, "");
        }

        private void HotWaterTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.HotWaterTemperatureDataValue.UpdateValue(HotWaterTemperature.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                HotWaterTemperature.Select(0, HotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(HotWaterTemperature, TowerTestPoint.HotWaterTemperatureDataValue.ErrorMessage);
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
            NotifyParentDataHasChanged();
            errorProvider1.SetError(ColdWaterTemperature, "");
        }

        private void ColdWaterTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.ColdWaterTemperatureDataValue.UpdateValue(ColdWaterTemperature.Text ))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature.Select(0, ColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature, TowerTestPoint.ColdWaterTemperatureDataValue.ErrorMessage);
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
            NotifyParentDataHasChanged();
            errorProvider1.SetError(WetBulbTemperature, "");
        }

        private void WetBulbTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.WetBulbTemperatureDataValue.UpdateValue(WetBulbTemperature.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature.Select(0, WetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature, TowerTestPoint.WetBulbTemperatureDataValue.ErrorMessage);
            }
        }

        private void DryBulbTemperature_Validated(object sender, EventArgs e)
        {
            NotifyParentDataHasChanged();
            errorProvider1.SetError(DryBulbTemperature, "");
        }

        private void DryBulbTemperature_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.DryBulbTemperatureDataValue.UpdateValue(DryBulbTemperature.Text ))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature.Select(0, DryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature, TowerTestPoint.DryBulbTemperatureDataValue.ErrorMessage);
            }
        }

        private void FanDriverPower_Validated(object sender, EventArgs e)
        {
            NotifyParentDataHasChanged();
            errorProvider1.SetError(FanDriverPower, "");
        }

        private void FanDriverPower_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.FanDriverPowerDataValue.UpdateValue(FanDriverPower.Text ))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                FanDriverPower.Select(0, FanDriverPower.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(FanDriverPower, TowerTestPoint.FanDriverPowerDataValue.ErrorMessage);
            }
        }

        private void BarometricPressure_Validated(object sender, EventArgs e)
        {
            NotifyParentDataHasChanged();
            errorProvider1.SetError(BarometricPressure, "");
        }

        private void BarometricPressure_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.BarometricPressureDataValue.UpdateValue(BarometricPressure.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                BarometricPressure.Select(0, BarometricPressure.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(BarometricPressure, TowerTestPoint.BarometricPressureDataValue.ErrorMessage);
            }
        }

        private void LiquidToGasRatio_Validated(object sender, EventArgs e)
        {
            NotifyParentDataHasChanged();
            errorProvider1.SetError(LiquidToGasRatio, "");
        }

        private void LiquidToGasRatio_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!TowerTestPoint.LiquidToGasRatioDataValue.UpdateValue(LiquidToGasRatio.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidToGasRatio.Select(0, LiquidToGasRatio.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidToGasRatio, TowerTestPoint.LiquidToGasRatioDataValue.ErrorMessage);
            }
        }
    }
}
