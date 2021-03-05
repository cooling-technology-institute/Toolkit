// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class TowerDesignDataUserControl : UserControl
    {
        public event FormClosingEventHandler CloseFormEvent;

        public TowerDesignData TowerDesignData { get; set; }

        public bool IsChanged { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerDesignDataUserControl(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            InitializeComponent();

            TowerDesignData = new TowerDesignData(IsDemo, IsInternationalSystemOfUnits_SI);

            string errorMessage;
            Setup(out errorMessage);
        }

        public bool LoadData(TowerDesignData data, out string errorMessage)
        {
            TowerDesignData = data;
            bool returnValue = true;
            errorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            //string label = "Design Data: ";

            IsChanged = false;

            //IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;

            //if (!TowerDesignData.LoadData(data, out errorMessage))
            //{
            //    returnValue = false;
            //    stringBuilder.AppendLine(label + errorMessage);
            //    errorMessage = string.Empty;
            //}

            if (!Setup(out errorMessage))
            {
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
                returnValue = false;
            }

            return returnValue;
        }

        private bool Setup(out string errorMessage)
        {
            bool returnValue = true;
            errorMessage = string.Empty;

            try
            {
                IsChanged = false;

                TowerDesignDataOwnerName.Text = TowerDesignData.OwnerNameValue;
                TowerDesignDataProjectName.Text = TowerDesignData.ProjectNameValue;
                TowerDesignDataLocation.Text = TowerDesignData.LocationValue;
                TowerDesignDataTowerManufacturer.Text = TowerDesignData.TowerManufacturerValue;

                if (TowerDesignData.TowerTypeValue == TOWER_TYPE.Induced)
                {
                    TowerDesignDataTowerTypeInducedRadio.Checked = true;
                }
                else
                {
                    TowerDesignDataTowerTypeForcedRadio.Checked = true;
                }

                TowerDesignDataWaterFlowRateLabel.Text = TowerDesignData.WaterFlowRateDataValue.InputMessage + ":";
                TowerDesignDataWaterFlowRateLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataWaterFlowRate.Text = TowerDesignData.WaterFlowRateDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataWaterFlowRate, TowerDesignData.WaterFlowRateDataValue.ToolTip);
                
                TowerDesignDataHotWaterTemperatureLabel.Text = TowerDesignData.HotWaterTemperatureDataValue.InputMessage + ":";
                TowerDesignDataHotWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataHotWaterTemperature.Text = TowerDesignData.HotWaterTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataHotWaterTemperature, TowerDesignData.HotWaterTemperatureDataValue.ToolTip);

                TowerDesignDataColdWaterTemperatureLabel.Text = TowerDesignData.ColdWaterTemperatureDataValue.InputMessage + ":";
                TowerDesignDataColdWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataColdWaterTemperature.Text = TowerDesignData.ColdWaterTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataColdWaterTemperature, TowerDesignData.ColdWaterTemperatureDataValue.ToolTip);

                TowerDesignDataWetBulbTemperatureLabel.Text = TowerDesignData.WetBulbTemperatureDataValue.InputMessage + ":";
                TowerDesignDataWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataWetBulbTemperature.Text = TowerDesignData.WetBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature, TowerDesignData.WetBulbTemperatureDataValue.ToolTip);

                TowerDesignDataDryBulbTemperatureLabel.Text = TowerDesignData.DryBulbTemperatureDataValue.InputMessage + ":";
                TowerDesignDataDryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataDryBulbTemperature.Text = TowerDesignData.DryBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataDryBulbTemperature, TowerDesignData.DryBulbTemperatureDataValue.ToolTip);

                TowerDesignDataFanDriverPowerLabel.Text = TowerDesignData.FanDriverPowerDataValue.InputMessage + ":";
                TowerDesignDataFanDriverPowerLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataFanDriverPower.Text = TowerDesignData.FanDriverPowerDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataFanDriverPower, TowerDesignData.FanDriverPowerDataValue.ToolTip);

                TowerDesignDataBarometricPressureLabel.Text = TowerDesignData.BarometricPressureDataValue.InputMessage + ":";
                TowerDesignDataBarometricPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataBarometricPressure.Text = TowerDesignData.BarometricPressureDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataBarometricPressure, TowerDesignData.BarometricPressureDataValue.ToolTip);

                TowerDesignDataLiquidToGasRatioLabel.Text = TowerDesignData.LiquidToGasRatioDataValue.InputMessage + ":";
                TowerDesignDataLiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataLiquidToGasRatio.Text = TowerDesignData.LiquidToGasRatioDataValue.InputValue;
                toolTip1.SetToolTip(TowerDesignDataLiquidToGasRatio, TowerDesignData.LiquidToGasRatioDataValue.ToolTip);

                TowerDesignDataRange1.Text = TowerDesignData.Range1Value.InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1, TowerDesignData.Range1Value.ToolTip);

                TowerDesignDataRange2.Text = TowerDesignData.Range2Value.InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2, TowerDesignData.Range2Value.ToolTip);

                TowerDesignDataRange3.Text = TowerDesignData.Range3Value.InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3, TowerDesignData.Range3Value.ToolTip);

                TowerDesignDataRange4.Text = TowerDesignData.Range4Value.InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4, TowerDesignData.Range4Value.ToolTip);

                TowerDesignDataRange5.Text = TowerDesignData.Range5Value.InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5, TowerDesignData.Range5Value.ToolTip);

                // build tab pages
                TowerDesignDataTabControl.TabPages.Clear();
                if(TowerDesignData.TowerDesignCurveData != null)
                {
                    foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignData.TowerDesignCurveData)
                    {
                        AddTabPage(towerDesignCurveData, out errorMessage);
                    }
                }

                TowerDesignDataGroupBox.Text = string.Format("Tower Design Specifications ({0})", (IsInternationalSystemOfUnits_SI) ? "SI" : "IP");
                TowerDesignDataCurveDataGroupBox.Text = string.Format("Tower Design Curve Data ({0})", (IsInternationalSystemOfUnits_SI) ? "SI" : "IP");

                // verify values and set error provider
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        private bool AddTabPage(TowerDesignCurveData towerDesignCurveData, out string errorMessage)
        {
            bool returnValue = true;

            try
            {
                TabPage tabPage = new TabPage();

                RangedTemperatureDesignUserControl towerDesignCurveDataUserControl = new RangedTemperatureDesignUserControl(IsDemo, IsInternationalSystemOfUnits_SI);
                towerDesignCurveDataUserControl.Dock = DockStyle.Fill;
                towerDesignCurveDataUserControl.RangedColdWaterTemperatureVisibility(TowerDesignData.CountRanges());
                towerDesignCurveDataUserControl.RangedColdWaterTemperatureEnable(towerDesignCurveData.CountWetBulbTemperatures());
                towerDesignCurveDataUserControl.RangedTemperatureDesignViewModel = towerDesignCurveData;
                tabPage.Text = towerDesignCurveData.WaterFlowRateDataValueInputValue;
                tabPage.Controls.Add(towerDesignCurveDataUserControl);
                if (!towerDesignCurveDataUserControl.Setup(out errorMessage))
                {

                }

                TowerDesignDataTabControl.TabPages.Add(tabPage);
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        #region Validating

        private void TowerDesignDataWaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWaterFlowRate, "");
        }

        private void TowerDesignDataWaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.WaterFlowRateDataValue.UpdateValue(TowerDesignDataWaterFlowRate.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWaterFlowRate.Select(0, TowerDesignDataWaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWaterFlowRate, errorMessage);
            }
        }

        private void TowerDesignDataHotWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataHotWaterTemperature, "");
        }

        private void TowerDesignDataHotWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.HotWaterTemperatureDataValue.UpdateValue(TowerDesignDataHotWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataHotWaterTemperature.Select(0, TowerDesignDataHotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataHotWaterTemperature, errorMessage);
            }
        }

        private void TowerDesignDataColdWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataColdWaterTemperature, "");
        }

        private void TowerDesignDataColdWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.ColdWaterTemperatureDataValue.UpdateValue(TowerDesignDataColdWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataColdWaterTemperature.Select(0, TowerDesignDataColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataColdWaterTemperature, errorMessage);
            }
        }

        private void TowerDesignDataWetBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature, "");
        }

        private void TowerDesignDataWetBulbTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.WetBulbTemperatureDataValue.UpdateValue(TowerDesignDataWetBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature.Select(0, TowerDesignDataWetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature, errorMessage);
            }
        }

        private void TowerDesignDataDryBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataDryBulbTemperature, "");
        }

        private void TowerDesignDataDryBulbTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.DryBulbTemperatureDataValue.UpdateValue(TowerDesignDataDryBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataDryBulbTemperature.Select(0, TowerDesignDataDryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataDryBulbTemperature, errorMessage);
            }
        }

        private void TowerDesignDataFanDriverPower_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataFanDriverPower, "");
        }

        private void TowerDesignDataFanDriverPower_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.FanDriverPowerDataValue.UpdateValue(TowerDesignDataFanDriverPower.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataFanDriverPower.Select(0, TowerDesignDataFanDriverPower.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataFanDriverPower, errorMessage);
            }
        }

        private void TowerDesignDataBarometricPressure_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataBarometricPressure, "");
        }

        private void TowerDesignDataBarometricPressure_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.BarometricPressureDataValue.UpdateValue(TowerDesignDataBarometricPressure.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataBarometricPressure.Select(0, TowerDesignDataBarometricPressure.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataBarometricPressure, errorMessage);
            }
        }

        private void TowerDesignDataLiquidToGasRatio_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataLiquidToGasRatio, "");
        }

        private void TowerDesignDataLiquidToGasRatio_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.LiquidToGasRatioDataValue.UpdateValue(TowerDesignDataLiquidToGasRatio.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataLiquidToGasRatio.Select(0, TowerDesignDataLiquidToGasRatio.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataLiquidToGasRatio, errorMessage);
            }
        }

        private void TowerDesignDataRange1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1, "");
        }

        private void TowerDesignDataRange1_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.Range1Value.UpdateValue(TowerDesignDataRange1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1.Select(0, TowerDesignDataRange1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1, errorMessage);
            }
        }

        private void TowerDesignDataRange2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2, "");
        }

        private void TowerDesignDataRange2_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.Range2Value.UpdateValue(TowerDesignDataRange2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2.Select(0, TowerDesignDataRange2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2, errorMessage);
            }
        }

        private void TowerDesignDataRange3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3, "");
        }

        private void TowerDesignDataRange3_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.Range3Value.UpdateValue(TowerDesignDataRange3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3.Select(0, TowerDesignDataRange5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3, errorMessage);
            }
        }

        private void TowerDesignDataRange4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4, "");
        }

        private void TowerDesignDataRange4_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.Range4Value.UpdateValue(TowerDesignDataRange4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4.Select(0, TowerDesignDataRange5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4, errorMessage);
            }
        }

        private void TowerDesignDataRange5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5, "");
        }

        private void TowerDesignDataRange5_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.Range5Value.UpdateValue(TowerDesignDataRange5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5.Select(0, TowerDesignDataRange5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5, errorMessage);
            }
        }

        private void TowerDesignDataAddWaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataAddWaterFlowRate, "");
        }

        private void TowerDesignDataAddWaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.AddWaterFlowRateDataValue.UpdateValue(TowerDesignDataAddWaterFlowRate.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataAddWaterFlowRate.Select(0, TowerDesignDataAddWaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataAddWaterFlowRate, errorMessage);
            }
        }

        #endregion Validating

        private void TowerDesignCurveDataSaveButton_Click(object sender, EventArgs e)
        {
            // save data to file?

            // you could create your own class here and pass the object to your main form if you wanted
            FormClosingEventArgs eventArgs = new FormClosingEventArgs(CloseReason.UserClosing, false);

            // tell host form to close itself
            CloseFormEvent(this, eventArgs);
        }

        private void TowerDesignCurveDataCancelButton_Click(object sender, EventArgs e)
        {
            // you could create your own class here and pass the object to your main form if you wanted
            FormClosingEventArgs eventArgs = new FormClosingEventArgs(CloseReason.None, false);

            // tell host form to close itself
            CloseFormEvent(this, eventArgs);
        }

        private void AddWaterFlowRate()
        {
            string errorMessage = string.Empty;
            object sender = new object();
            CancelEventArgs e = new CancelEventArgs()
            {
                Cancel = false
            };
            TowerDesignDataAddWaterFlowRate_Validating(sender, e);
            if(!e.Cancel)
            {
                TowerDesignCurveData rangedTemperatureDesignViewModel = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI);
                RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();
                WaterFlowRateDataValue waterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
                if (waterFlowRateDataValue.UpdateValue(TowerDesignDataAddWaterFlowRate.Text, out errorMessage))
                {
                    rangedTemperaturesDesignData.WaterFlowRate = waterFlowRateDataValue.Current;

                    if (!rangedTemperatureDesignViewModel.LoadData(IsInternationalSystemOfUnits_SI, rangedTemperaturesDesignData, out errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }
                    else
                    {
                        //RangedTemperatureDesignViewModels.Add(rangedTemperatureDesignViewModel);
                        AddTabPage(rangedTemperatureDesignViewModel, out errorMessage);
                        TowerDesignDataTabControl.SelectedIndex = TowerDesignDataTabControl.TabPages.Count;
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private void TowerDesignDataAddWaterFlowRateButton_Click(object sender, EventArgs e)
        {
            AddWaterFlowRate();
        }

        private void TowerDesignDataOkButton_Click(object sender, EventArgs e)
        {

        }

        private void TowerDesignDataCancelButton_Click(object sender, EventArgs e)
        {

        }

        private void TowerDesignDataTabPage_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
