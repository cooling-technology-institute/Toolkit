// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
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

                OwnerName.Text = TowerDesignData.OwnerNameValue;
                ProjectName.Text = TowerDesignData.ProjectNameValue;
                TowerLocation.Text = TowerDesignData.LocationValue;
                TowerManufacturer.Text = TowerDesignData.TowerManufacturerValue;

                if (TowerDesignData.TowerTypeValue == TOWER_TYPE.Induced)
                {
                    TowerTypeInduced.Checked = true;
                }
                else
                {
                    TowerTypeForced.Checked = true;
                }

                WaterFlowRateLabel.Text = TowerDesignData.WaterFlowRateDataValue.InputMessage + ":";
                WaterFlowRateLabel.TextAlign = ContentAlignment.MiddleRight;
                WaterFlowRate.Text = TowerDesignData.WaterFlowRateDataValue.InputValue;
                toolTip1.SetToolTip(WaterFlowRate, TowerDesignData.WaterFlowRateDataValue.ToolTip);
                
                HotWaterTemperatureLabel.Text = TowerDesignData.HotWaterTemperatureDataValue.InputMessage + ":";
                HotWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                HotWaterTemperature.Text = TowerDesignData.HotWaterTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(HotWaterTemperature, TowerDesignData.HotWaterTemperatureDataValue.ToolTip);

                ColdWaterTemperatureLabel.Text = TowerDesignData.ColdWaterTemperatureDataValue.InputMessage + ":";
                ColdWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                ColdWaterTemperature.Text = TowerDesignData.ColdWaterTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(ColdWaterTemperature, TowerDesignData.ColdWaterTemperatureDataValue.ToolTip);

                WetBulbTemperatureLabel.Text = TowerDesignData.WetBulbTemperatureDataValue.InputMessage + ":";
                WetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                WetBulbTemperature.Text = TowerDesignData.WetBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature, TowerDesignData.WetBulbTemperatureDataValue.ToolTip);

                DryBulbTemperatureLabel.Text = TowerDesignData.DryBulbTemperatureDataValue.InputMessage + ":";
                DryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                DryBulbTemperature.Text = TowerDesignData.DryBulbTemperatureDataValue.InputValue;
                toolTip1.SetToolTip(DryBulbTemperature, TowerDesignData.DryBulbTemperatureDataValue.ToolTip);

                FanDriverPowerLabel.Text = TowerDesignData.FanDriverPowerDataValue.InputMessage + ":";
                FanDriverPowerLabel.TextAlign = ContentAlignment.MiddleRight;
                FanDriverPower.Text = TowerDesignData.FanDriverPowerDataValue.InputValue;
                toolTip1.SetToolTip(FanDriverPower, TowerDesignData.FanDriverPowerDataValue.ToolTip);

                BarometricPressureLabel.Text = TowerDesignData.BarometricPressureDataValue.InputMessage + ":";
                BarometricPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                BarometricPressure.Text = TowerDesignData.BarometricPressureDataValue.InputValue;
                toolTip1.SetToolTip(BarometricPressure, TowerDesignData.BarometricPressureDataValue.ToolTip);

                LiquidToGasRatioLabel.Text = TowerDesignData.LiquidToGasRatioDataValue.InputMessage + ":";
                LiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
                LiquidToGasRatio.Text = TowerDesignData.LiquidToGasRatioDataValue.InputValue;
                toolTip1.SetToolTip(LiquidToGasRatio, TowerDesignData.LiquidToGasRatioDataValue.ToolTip);

                Range1.Text = TowerDesignData.Range1Value.InputValue;
                toolTip1.SetToolTip(Range1, TowerDesignData.Range1Value.ToolTip);

                Range2.Text = TowerDesignData.Range2Value.InputValue;
                toolTip1.SetToolTip(Range2, TowerDesignData.Range2Value.ToolTip);

                Range3.Text = TowerDesignData.Range3Value.InputValue;
                toolTip1.SetToolTip(Range3, TowerDesignData.Range3Value.ToolTip);

                Range4.Text = TowerDesignData.Range4Value.InputValue;
                toolTip1.SetToolTip(Range4, TowerDesignData.Range4Value.ToolTip);

                Range5.Text = TowerDesignData.Range5Value.InputValue;
                toolTip1.SetToolTip(Range5, TowerDesignData.Range5Value.ToolTip);

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
                RangedTemperatureDesignUserControlTabPage tabPage = new RangedTemperatureDesignUserControlTabPage(new RangedTemperatureDesignUserControl(IsDemo, IsInternationalSystemOfUnits_SI));
                tabPage.UserControl.Dock = DockStyle.Fill;
                tabPage.UserControl.RangeVisible(1, (TowerDesignData.Range1Value.Current != 0.0));
                tabPage.UserControl.RangeVisible(2, (TowerDesignData.Range2Value.Current != 0.0));
                tabPage.UserControl.RangeVisible(3, (TowerDesignData.Range3Value.Current != 0.0));
                tabPage.UserControl.RangeVisible(4, (TowerDesignData.Range4Value.Current != 0.0));
                tabPage.UserControl.RangeVisible(5, (TowerDesignData.Range5Value.Current != 0.0));
                //tabPage.UserControl.ColdWaterTemperaturesVisible();
                tabPage.UserControl.TowerDesignCurveData = towerDesignCurveData;
                tabPage.Text = towerDesignCurveData.WaterFlowRateDataValue.InputValue;
                if (!tabPage.UserControl.Setup(out errorMessage))
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

        private void WaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WaterFlowRate, "");
        }

        private void WaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (WaterFlowRate.Text != TowerDesignData.WaterFlowRateDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.WaterFlowRateDataValue.UpdateValue(WaterFlowRate.Text, out errorMessage))
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

        private void HotWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if(HotWaterTemperature.Text != TowerDesignData.HotWaterTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.HotWaterTemperatureDataValue.UpdateValue(HotWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                HotWaterTemperature.Select(0, HotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(HotWaterTemperature, errorMessage);
            }
            else if(TowerDesignData.HotWaterTemperatureDataValue.Current <= TowerDesignData.ColdWaterTemperatureDataValue.Current)
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

        private void ColdWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (ColdWaterTemperature.Text != TowerDesignData.ColdWaterTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.ColdWaterTemperatureDataValue.UpdateValue(ColdWaterTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature.Select(0, ColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature, errorMessage);
            }
            else if (TowerDesignData.ColdWaterTemperatureDataValue.Current >= TowerDesignData.HotWaterTemperatureDataValue.Current)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature.Select(0, HotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature, "Cold Water Temperature must be less than the Hot Water Temperature.");
            }
        }

        private void WetBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature, "");
        }

        private void WetBulbTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (WetBulbTemperature.Text != TowerDesignData.WetBulbTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.WetBulbTemperatureDataValue.UpdateValue(WetBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature.Select(0, WetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature, errorMessage);
            }
            else if (TowerDesignData.WetBulbTemperatureDataValue.Current >= TowerDesignData.DryBulbTemperatureDataValue.Current)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature.Select(0, WetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature, "Wet Bulb Temperature must be less than the Dry Bulb Temperature.");
            }
            //"Dry bulb must be greater than Wet bulb temperature."
        }

        private void DryBulbTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(DryBulbTemperature, "");
        }

        private void DryBulbTemperature_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (DryBulbTemperature.Text != TowerDesignData.DryBulbTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.DryBulbTemperatureDataValue.UpdateValue(DryBulbTemperature.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature.Select(0, DryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature, errorMessage);
            }
            else if (TowerDesignData.DryBulbTemperatureDataValue.Current <= TowerDesignData.WetBulbTemperatureDataValue.Current)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature.Select(0, DryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature, "Dry Bulb Temperature must be greater than the Wet Bulb Temperature.");
            }
        }

        private void FanDriverPower_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(FanDriverPower, "");
        }

        private void FanDriverPower_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (FanDriverPower.Text != TowerDesignData.FanDriverPowerDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.FanDriverPowerDataValue.UpdateValue(FanDriverPower.Text, out errorMessage))
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

        private void BarometricPressure_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (BarometricPressure.Text != TowerDesignData.BarometricPressureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.BarometricPressureDataValue.UpdateValue(BarometricPressure.Text, out errorMessage))
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

        private void LiquidToGasRatio_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (LiquidToGasRatio.Text != TowerDesignData.LiquidToGasRatioDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.LiquidToGasRatioDataValue.UpdateValue(LiquidToGasRatio.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidToGasRatio.Select(0, LiquidToGasRatio.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidToGasRatio, errorMessage);
            }
        }

        private void Range1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1, "");

            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                tabPage.UserControl.RangeVisible(1, (TowerDesignData.Range1Value.Current != 0.0));
            }
        }

        private void Range1_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (Range1.Text != TowerDesignData.Range1Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range1Value.UpdateValue(Range1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1.Select(0, Range1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1, errorMessage);
            }
            else if (!TowerDesignData.CheckRangeOrder())
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1.Select(0, Range1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1, "This range is out of order, it must be ascending or descending");
            }
            else
            {

            }
        }

        private void Range2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2, "");
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                tabPage.UserControl.RangeVisible(2, (TowerDesignData.Range2Value.Current != 0.0));
            }
        }

        private void Range2_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (Range2.Text != TowerDesignData.Range2Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range2Value.UpdateValue(Range2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2.Select(0, Range2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2, errorMessage);
            }
            else if (!TowerDesignData.CheckRangeOrder())
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2.Select(0, Range2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2, "This range is out of order, it must be ascending or descending");
            }
            else
            {

            }
        }

        private void Range3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3, "");
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                tabPage.UserControl.RangeVisible(3, (TowerDesignData.Range3Value.Current != 0.0));
            }
        }

        private void Range3_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (Range3.Text != TowerDesignData.Range3Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range3Value.UpdateValue(Range3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3.Select(0, Range3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3, errorMessage);
            }
            else if (!TowerDesignData.CheckRangeOrder())
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3.Select(0, Range3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3, "This range is out of order, it must be ascending or descending");
            }
        }

        private void Range4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4, "");
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                tabPage.UserControl.RangeVisible(4, (TowerDesignData.Range4Value.Current != 0.0));
            }
        }

        private void Range4_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (Range4.Text != TowerDesignData.Range4Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range4Value.UpdateValue(Range4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4.Select(0, Range4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4, errorMessage);
            }
            else if (!TowerDesignData.CheckRangeOrder())
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4.Select(0, Range4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4, "This range is out of order, it must be ascending or descending");
            }
        }

        private void Range5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5, "");
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                tabPage.UserControl.RangeVisible(5, (TowerDesignData.Range5Value.Current != 0.0));
            }
        }

        private void Range5_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (Range5.Text != TowerDesignData.Range5Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range5Value.UpdateValue(Range5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5.Select(0, Range5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5, errorMessage);
            }
            else if (!TowerDesignData.CheckRangeOrder())
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5.Select(0, Range5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5, "This range is out of order, it must be ascending or descending");
            }
        }

        private void AddNewWaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(AddNewWaterFlowRate, "");
        }

        private void AddNewWaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!TowerDesignData.AddWaterFlowRateDataValue.UpdateValue(AddNewWaterFlowRate.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                AddNewWaterFlowRate.Select(0, AddNewWaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(AddNewWaterFlowRate, errorMessage);
            }
        }

        #endregion Validating

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // save data to file?

            // you could create your own class here and pass the object to your main form if you wanted
            FormClosingEventArgs eventArgs = new FormClosingEventArgs(CloseReason.UserClosing, false);

            // tell host form to close itself
            CloseFormEvent(this, eventArgs);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // you could create your own class here and pass the object to your main form if you wanted
            FormClosingEventArgs eventArgs = new FormClosingEventArgs(CloseReason.None, false);

            // tell host form to close itself
            CloseFormEvent(this, eventArgs);
        }

        private void AddWaterFlowRate()
        {
            string errorMessage = string.Empty;

            IsChanged = true;

            TowerDesignCurveData towerDesignCurveData = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI);
            RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();
            WaterFlowRateDataValue waterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            if (waterFlowRateDataValue.UpdateValue(AddNewWaterFlowRate.Text, out errorMessage))
            {
                rangedTemperaturesDesignData.WaterFlowRate = waterFlowRateDataValue.Current;

                if (!towerDesignCurveData.LoadData(rangedTemperaturesDesignData, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    //RangedTemperatureDesignViewModels.Add(rangedTemperatureDesignViewModel);
                    AddTabPage(towerDesignCurveData, out errorMessage);
                    TowerDesignDataTabControl.SelectedIndex = TowerDesignDataTabControl.TabPages.Count - 1;
                }
            }
        }

        private void AddWaterFlowRateButton_Click(object sender, EventArgs e)
        {
            AddWaterFlowRate();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }

        private void TowerDesignDataCancelButton_Click(object sender, EventArgs e)
        {
            if(IsChanged)
            {
                // Are you sure?
                var result = MessageBox.Show("Are you sure you want to discard your changes?", "Cancel Updates",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

                // If the yes button was pressed ...
                if (result == DialogResult.Yes)
                {
                    // you could create your own class here and pass the object to your main form if you wanted
                    FormClosingEventArgs eventArgs = new FormClosingEventArgs(CloseReason.UserClosing, false);

                    // tell host form to close itself
                    CloseFormEvent(this, eventArgs);
                }
            }
        }

        private void TowerDesignDataTabPage_DoubleClick(object sender, EventArgs e)
        {

        }

        private void TypeInduced_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void TypeForced_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void TowerDesignDataTabControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // find tab then display menu next to tab
                // iterate through all the tab pages
                for (int i = 0; i < TowerDesignDataTabControl.TabCount; i++)
                {
                    // get their rectangle area and check if it contains the mouse cursor
                    Rectangle r = TowerDesignDataTabControl.GetTabRect(i);

                    if (r.Contains(e.Location))
                    {
                        ContextMenu contextMenu = new ContextMenu();
                        contextMenu.MenuItems.Add(new CustomMenuItem("Update", new System.EventHandler(this.WaterFlowRateUpdate_Click), i));
                        contextMenu.MenuItems.Add("-");
                        if(i != 0)
                        {
                            contextMenu.MenuItems.Add(new CustomMenuItem("< Move Left", new System.EventHandler(this.WaterFlowRateMoveLeft_Click), i));
                        }
                        if (i != TowerDesignDataTabControl.TabCount - 1)
                        {
                            contextMenu.MenuItems.Add(new CustomMenuItem("> Move Right", new System.EventHandler(this.WaterFlowRateMoveRight_Click), i));
                        }
                        contextMenu.MenuItems.Add("-");
                        contextMenu.MenuItems.Add(new CustomMenuItem("Delete", new System.EventHandler(this.WaterFlowRateDelete_Click), i));


                        // show the context menu here
                        contextMenu.Show(this.TowerDesignDataTabControl, e.Location);
                    }
                }
            }
            else
            {

            }
        }

        private void WaterFlowRateUpdate_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            string text = TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex].Text;

            MessageBox.Show(text);
            //UpdateWaterFlowRate();
        }

        private void WaterFlowRateMoveLeft_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TabPage tabPage = TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex];
            TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex] = TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex - 1];
            TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex - 1] = tabPage;
            TowerDesignDataTabControl.SelectedIndex = customMenuItem.TabIndex - 1;
        }

        private void WaterFlowRateMoveRight_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TabPage tabPage = TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex + 1];
            TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex + 1] = TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex];
            TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex] = tabPage;
            TowerDesignDataTabControl.SelectedIndex = customMenuItem.TabIndex + 1;
        }

        private void WaterFlowRateDelete_Click(object sender, EventArgs e)
        {
            CustomMenuItem customMenuItem = sender as CustomMenuItem;
            TowerDesignDataTabControl.TabPages.Remove(TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex]);
        }
    }
}
