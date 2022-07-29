// Copyright Cooling Technology Institute 2019-2022

using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class TowerDesignDataForm : Form
    {
        public TowerDesignData TowerDesignData { get; set; }
        public string ErrorMessage { get; set; }

        private bool IsChanged { get; set; }

        public bool HasDataChanged
        {
            get
            {
                return IsChanged || HasTabPageChanged();
            }
            //set 
            //{ 
            //    IsChanged = value;
            //}
        }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerDesignDataForm(bool isDemo, bool isInternationalSystemOfUnits_IS_, TowerDesignData towerDesignData)
        {
            InitializeComponent();

            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            ErrorMessage = string.Empty;
            IsChanged = false;

            TowerDesignData = towerDesignData;
            SetDisplayedUnits();
            SetDisplayedValues();
        }

        public void SetUnitsStandard(bool isInternationalSystemOfUnits_SI)
        {
            if(IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                TowerDesignData.ConvertValues(IsInternationalSystemOfUnits_SI);
                foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
                {
                    tabPage.SetUnitsStandard(IsInternationalSystemOfUnits_SI);
                }
                SetDisplayedValues();
                SetDisplayedUnits();
            }
        }

        private void SetDisplayedUnits()
        {
            WaterFlowRateUnits.Text = TowerDesignData.WaterFlowRateDataValue.Units;
            HotWaterTemperatureUnits.Text = TowerDesignData.HotWaterTemperatureDataValue.Units;
            ColdWaterTemperatureUnits.Text = TowerDesignData.ColdWaterTemperatureDataValue.Units;
            WetBulbTemperatureUnits.Text = TowerDesignData.WetBulbTemperatureDataValue.Units;
            DryBulbTemperatureUnits.Text = TowerDesignData.DryBulbTemperatureDataValue.Units;
            FanDriverPowerUnits.Text = TowerDesignData.FanDriverPowerDataValue.Units;
            BarometricPressureUnits.Text = TowerDesignData.BarometricPressureDataValue.Units;
        }

        protected void CloseFormCallback(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            if(!e.Cancel)
            {
                this.Close();
            }
        }

        //public void AddControlEvents()
        //{
        //    foreach(Control control in Controls)
        //    {
        //        if(control is TowerDesignDataUserControl)
        //        {
        //            ((TowerDesignDataUserControl)control).CloseFormEvent += new FormClosingEventHandler(CloseformCallback);
        //        }
        //    }
        //}

        public void FillNameValueUnitsDataTable(NameValueUnitsDataTable nameValueUnitsDataTable)
        {
            nameValueUnitsDataTable.AddRow(TowerDesignData.WaterFlowRateDataValue.InputMessage, TowerDesignData.WaterFlowRateDataValue.InputValue, WaterFlowRateUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.HotWaterTemperatureDataValue.InputMessage, TowerDesignData.HotWaterTemperatureDataValue.InputValue, HotWaterTemperatureUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.ColdWaterTemperatureDataValue.InputMessage, TowerDesignData.ColdWaterTemperatureDataValue.InputValue, ColdWaterTemperatureUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.WetBulbTemperatureDataValue.InputMessage, TowerDesignData.WetBulbTemperatureDataValue.InputValue, WetBulbTemperatureUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.DryBulbTemperatureDataValue.InputMessage, TowerDesignData.DryBulbTemperatureDataValue.InputValue, DryBulbTemperatureUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.FanDriverPowerDataValue.InputMessage, TowerDesignData.FanDriverPowerDataValue.InputValue, FanDriverPowerUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.BarometricPressureDataValue.InputMessage, TowerDesignData.BarometricPressureDataValue.InputValue, BarometricPressureUnits.Text);
            nameValueUnitsDataTable.AddRow(TowerDesignData.LiquidToGasRatioDataValue.InputMessage, TowerDesignData.LiquidToGasRatioDataValue.InputValue, string.Empty);
        }

        public bool LoadData(TowerDesignData data)
        {
            TowerDesignData = data;
            bool returnValue = true;
            IsChanged = false;

            if (!SetDisplayedValues())
            {
                returnValue = false;
            }

            return returnValue;
        }

        public void SaveDesignData(TowerDesignData data)
        {
            data = TowerDesignData;
            //data.Range1Value = TowerDesignData.Range1Value;

            if(data.TowerDesignCurveData == null)
            {
                data.TowerDesignCurveData = new List<TowerDesignCurveData>();
            }

            data.TowerDesignCurveData.Clear();
            
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                data.TowerDesignCurveData.Add(tabPage.UserControl.TowerDesignCurveData);
            }

            IsChanged = false;
        }

        private bool SetDisplayedValues()
        {
            bool returnValue = true;
            ErrorMessage = string.Empty;

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
                if (TowerDesignData.TowerDesignCurveData != null)
                {
                    foreach (TowerDesignCurveData towerDesignCurveData in TowerDesignData.TowerDesignCurveData)
                    {
                        AddTabPage(towerDesignCurveData);
                    }
                }

                TowerDesignDataGroupBox.Text = string.Format("Tower Design Specifications ({0})", (IsInternationalSystemOfUnits_SI) ? "SI" : "IP");
                TowerDesignDataCurveDataGroupBox.Text = string.Format("Tower Design Curve Data ({0})", (IsInternationalSystemOfUnits_SI) ? "SI" : "IP");

                // verify values and set error provider
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        private bool AddTabPage(TowerDesignCurveData towerDesignCurveData)
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
                tabPage.UserControl.LoadData(towerDesignCurveData);
                tabPage.Text = tabPage.UserControl.TowerDesignCurveData.WaterFlowRateDataValue.InputValue;
                if (!tabPage.UserControl.SetDisplayedValues())
                {

                }
                TowerDesignDataTabControl.TabPages.Add(tabPage);
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
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
            if (WaterFlowRate.Text != TowerDesignData.WaterFlowRateDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.WaterFlowRateDataValue.UpdateValue(WaterFlowRate.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WaterFlowRate.Select(0, WaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WaterFlowRate, TowerDesignData.WaterFlowRateDataValue.ErrorMessage);
            }
        }

        private void HotWaterTemperature_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(HotWaterTemperature, "");
        }

        private void HotWaterTemperature_Validating(object sender, CancelEventArgs e)
        {
            if (HotWaterTemperature.Text != TowerDesignData.HotWaterTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.HotWaterTemperatureDataValue.UpdateValue(HotWaterTemperature.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                HotWaterTemperature.Select(0, HotWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(HotWaterTemperature, TowerDesignData.HotWaterTemperatureDataValue.ErrorMessage);
            }
            else if (TowerDesignData.HotWaterTemperatureDataValue.Current <= TowerDesignData.ColdWaterTemperatureDataValue.Current)
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
            if (ColdWaterTemperature.Text != TowerDesignData.ColdWaterTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.ColdWaterTemperatureDataValue.UpdateValue(ColdWaterTemperature.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                ColdWaterTemperature.Select(0, ColdWaterTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(ColdWaterTemperature, TowerDesignData.ColdWaterTemperatureDataValue.ErrorMessage);
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
            if (WetBulbTemperature.Text != TowerDesignData.WetBulbTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.WetBulbTemperatureDataValue.UpdateValue(WetBulbTemperature.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature.Select(0, WetBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature, TowerDesignData.WetBulbTemperatureDataValue.ErrorMessage);
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
            if (DryBulbTemperature.Text != TowerDesignData.DryBulbTemperatureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.DryBulbTemperatureDataValue.UpdateValue(DryBulbTemperature.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                DryBulbTemperature.Select(0, DryBulbTemperature.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(DryBulbTemperature, TowerDesignData.DryBulbTemperatureDataValue.ErrorMessage);
            }
            else if (TowerDesignData.WetBulbTemperatureDataValue.Current >= TowerDesignData.DryBulbTemperatureDataValue.Current)
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
            if (FanDriverPower.Text != TowerDesignData.FanDriverPowerDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.FanDriverPowerDataValue.UpdateValue(FanDriverPower.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                FanDriverPower.Select(0, FanDriverPower.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(FanDriverPower, TowerDesignData.FanDriverPowerDataValue.ErrorMessage);
            }
        }

        private void BarometricPressure_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(BarometricPressure, "");
        }

        private void BarometricPressure_Validating(object sender, CancelEventArgs e)
        {
            if (BarometricPressure.Text != TowerDesignData.BarometricPressureDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.BarometricPressureDataValue.UpdateValue(BarometricPressure.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                BarometricPressure.Select(0, BarometricPressure.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(BarometricPressure, TowerDesignData.BarometricPressureDataValue.ErrorMessage);
            }
        }

        private void LiquidToGasRatio_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LiquidToGasRatio, "");
        }

        private void LiquidToGasRatio_Validating(object sender, CancelEventArgs e)
        {
            if (LiquidToGasRatio.Text != TowerDesignData.LiquidToGasRatioDataValue.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.LiquidToGasRatioDataValue.UpdateValue(LiquidToGasRatio.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                LiquidToGasRatio.Select(0, LiquidToGasRatio.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(LiquidToGasRatio, TowerDesignData.LiquidToGasRatioDataValue.ErrorMessage);
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
            if (Range1.Text != TowerDesignData.Range1Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range1Value.UpdateValue(Range1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1.Select(0, Range1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1, TowerDesignData.Range1Value.ErrorMessage);
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
            if (Range2.Text != TowerDesignData.Range2Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range2Value.UpdateValue(Range2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2.Select(0, Range2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2, TowerDesignData.Range2Value.ErrorMessage);
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
            if (Range3.Text != TowerDesignData.Range3Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range3Value.UpdateValue(Range3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3.Select(0, Range3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3, TowerDesignData.Range3Value.ErrorMessage);
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
            if (Range4.Text != TowerDesignData.Range4Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range4Value.UpdateValue(Range4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4.Select(0, Range4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4, TowerDesignData.Range4Value.ErrorMessage);
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
            if (Range5.Text != TowerDesignData.Range5Value.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignData.Range5Value.UpdateValue(Range5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5.Select(0, Range5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5, TowerDesignData.Range5Value.ErrorMessage);
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
            if (!TowerDesignData.AddWaterFlowRateDataValue.UpdateValue(AddNewWaterFlowRate.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                AddNewWaterFlowRate.Select(0, AddNewWaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(AddNewWaterFlowRate, TowerDesignData.AddWaterFlowRateDataValue.ErrorMessage);
            }
        }

        #endregion Validating

        private void AddWaterFlowRate()
        {
            IsChanged = true;
            ErrorMessage = string.Empty;

            TowerDesignCurveData towerDesignCurveData = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI);
            RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();
            WaterFlowRateDataValue waterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            
            if (waterFlowRateDataValue.UpdateValue(AddNewWaterFlowRate.Text))
            {
                rangedTemperaturesDesignData.WaterFlowRate = waterFlowRateDataValue.Current;

                if (!towerDesignCurveData.LoadData(rangedTemperaturesDesignData))
                {
                    MessageBox.Show(towerDesignCurveData.ErrorMessage);
                }
                else
                {
                    //RangedTemperatureDesignViewModels.Add(rangedTemperatureDesignViewModel);
                    if(AddTabPage(towerDesignCurveData))
                    {
                        TowerDesignDataTabControl.SelectedIndex = TowerDesignDataTabControl.TabPages.Count - 1;
                    }
                }
            }
            else
            {
                ErrorMessage = waterFlowRateDataValue.ErrorMessage;
            }
        }

        private void AddWaterFlowRateButton_Click(object sender, EventArgs e)
        {
            AddWaterFlowRate();
        }

        public bool HasTabPageChanged()
        {
            bool isChanged = false;
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                if (tabPage.UserControl.IsChanged)
                {
                    isChanged = true;
                    break;
                }
            }
            return isChanged;
        }

        public void ClearIsChanged()
        {
            IsChanged = false;
            foreach (RangedTemperatureDesignUserControlTabPage tabPage in TowerDesignDataTabControl.TabPages)
            {
                tabPage.UserControl.IsChanged = false;
            }
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            bool isChanged = false;

            isChanged |= HasDataChanged;

            if (this.DialogResult == DialogResult.Cancel)
            {
                if (isChanged)
                {
                    // Are you sure?
                    var result = MessageBox.Show("Are you sure you want to discard your changes?", "Cancel Updates",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question);

                    // If the yes button was pressed ...
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        ClearIsChanged();
                    }
                }
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TowerDesignDataTabPage_DoubleClick(object sender, EventArgs e)
        {

        }

        private void TypeInduced_CheckedChanged(object sender, EventArgs e)
        {
            if (TowerTypeInduced.Checked)
            {
                if(TowerDesignData.TowerTypeValue != TOWER_TYPE.Induced)
                {
                    IsChanged = true;
                    TowerDesignData.TowerTypeValue = TOWER_TYPE.Induced;
                }
            }
        }

        private void TypeForced_CheckedChanged(object sender, EventArgs e)
        {
            if (TowerTypeForced.Checked)
            {
                if (TowerDesignData.TowerTypeValue != TOWER_TYPE.Forced)
                {
                    IsChanged = true;
                    TowerDesignData.TowerTypeValue = TOWER_TYPE.Forced;
                }
            }
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
                        if (i != 0)
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
            RangedTemperatureDesignUserControl rangedTemperatureDesignUserControl = TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex].Controls[0] as RangedTemperatureDesignUserControl;

            if(rangedTemperatureDesignUserControl != null)
            {
                UpdateWaterFlowRateForm updateWaterFlowRateForm = new UpdateWaterFlowRateForm(IsDemo, IsInternationalSystemOfUnits_SI, rangedTemperatureDesignUserControl.TowerDesignCurveData.WaterFlowRateDataValue.Current);

                if (updateWaterFlowRateForm.ShowDialog(this) == DialogResult.OK)
                {
                    rangedTemperatureDesignUserControl.TowerDesignCurveData.WaterFlowRateDataValue.UpdateCurrentValue(updateWaterFlowRateForm.WaterFlowRateDataValue.Current);
                    TowerDesignDataTabControl.TabPages[customMenuItem.TabIndex].Text = updateWaterFlowRateForm.WaterFlowRateDataValue.InputValue;
                    IsChanged = true;
                }

                updateWaterFlowRateForm.Dispose();
            }
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

        private void OwnerName_TextChanged(object sender, EventArgs e)
        {
            if(TowerDesignData.OwnerNameValue != OwnerName.Text)
            {
                IsChanged = true;
                TowerDesignData.OwnerNameValue = OwnerName.Text;
            }
        }

        private void ProjectName_TextChanged(object sender, EventArgs e)
        {
            if (TowerDesignData.ProjectNameValue != ProjectName.Text)
            {
                IsChanged = true;
                TowerDesignData.ProjectNameValue = ProjectName.Text;
            }
        }

        private void TowerLocation_TextChanged(object sender, EventArgs e)
        {
            if (TowerDesignData.LocationValue != TowerLocation.Text)
            {
                IsChanged = true;
                TowerDesignData.LocationValue = TowerLocation.Text;
            }
        }

        private void TowerManufacturer_TextChanged(object sender, EventArgs e)
        {
            if (TowerDesignData.TowerManufacturerValue != TowerManufacturer.Text)
            {
                IsChanged = true;
                TowerDesignData.TowerManufacturerValue = TowerManufacturer.Text;
            }
        }
    }
}
