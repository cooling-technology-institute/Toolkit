using Models;
using System;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class RangedTemperatureDesignUserControl : UserControl
    {
        public TowerDesignCurveData TowerDesignCurveData { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsChanged { get; set; }
        public string ErrorMessage { get; set; }

        public RangedTemperatureDesignUserControl(bool isDemo, bool isInternationalSystemOfUnits_SI_)
        {
            InitializeComponent();

            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI_;
            IsChanged = false;
            ErrorMessage = string.Empty;

            TowerDesignCurveData = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI);
            SetDisplayedUnits();
            SetDisplayedValues();
        }

        public bool SetUnitsStandard(bool isInternationalSystemOfUnits_SI, StringBuilder stringBuilder = null)
        {
            bool returnValue = true;
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
                TowerDesignCurveData.ConvertValues(IsInternationalSystemOfUnits_SI);
                SetDisplayedUnits();
                if (!SetDisplayedValues() && stringBuilder != null)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                }
            }
            return returnValue;
        }

        private void SetDisplayedUnits()
        {
            if (IsInternationalSystemOfUnits_SI)
            {
                UnitsWetWaterTemperature1.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetWaterTemperature2.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetWaterTemperature3.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetWaterTemperature4.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetWaterTemperature5.Text = ConstantUnits.TemperatureCelsius;
                UnitsWetWaterTemperature6.Text = ConstantUnits.TemperatureCelsius;
            }
            else
            {
                UnitsWetWaterTemperature1.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetWaterTemperature2.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetWaterTemperature3.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetWaterTemperature4.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetWaterTemperature5.Text = ConstantUnits.TemperatureFahrenheit;
                UnitsWetWaterTemperature6.Text = ConstantUnits.TemperatureFahrenheit;
            }
        }

        public bool LoadData(TowerDesignCurveData towerDesignCurveData)
        {
            StringBuilder stringBuilder = new StringBuilder();
            ErrorMessage = string.Empty;

            TowerDesignCurveData = towerDesignCurveData;
            bool returnValue = SetUnitsStandard(TowerDesignCurveData.IsInternationalSystemOfUnits_SI, stringBuilder);
            
            ErrorMessage = stringBuilder.ToString();
            IsChanged = false;
            return returnValue;
        }

        public bool SetDisplayedValues()
        {
            bool returnValue = true;
            ErrorMessage = string.Empty;
            try
            {
                WetBulbTemperature1.Text = TowerDesignCurveData.WetBulbTemperatureDataValue1.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature1, TowerDesignCurveData.WetBulbTemperatureDataValue1.ToolTip);

                WetBulbTemperature2.Text = TowerDesignCurveData.WetBulbTemperatureDataValue2.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature2, TowerDesignCurveData.WetBulbTemperatureDataValue2.ToolTip);

                WetBulbTemperature3.Text = TowerDesignCurveData.WetBulbTemperatureDataValue3.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature3, TowerDesignCurveData.WetBulbTemperatureDataValue3.ToolTip);

                WetBulbTemperature4.Text = TowerDesignCurveData.WetBulbTemperatureDataValue4.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature4, TowerDesignCurveData.WetBulbTemperatureDataValue4.ToolTip);

                WetBulbTemperature5.Text = TowerDesignCurveData.WetBulbTemperatureDataValue5.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature5, TowerDesignCurveData.WetBulbTemperatureDataValue5.ToolTip);

                WetBulbTemperature6.Text = TowerDesignCurveData.WetBulbTemperatureDataValue6.InputValue;
                toolTip1.SetToolTip(WetBulbTemperature6, TowerDesignCurveData.WetBulbTemperatureDataValue6.ToolTip);

                // Range 1
                Range1ColdWaterTemperature1.Text = TowerDesignCurveData.Range1ColdWaterTemperatureDataValue1.InputValue;
                toolTip1.SetToolTip(Range1ColdWaterTemperature1, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue1.ToolTip);

                Range1ColdWaterTemperature2.Text = TowerDesignCurveData.Range1ColdWaterTemperatureDataValue2.InputValue;
                toolTip1.SetToolTip(Range1ColdWaterTemperature2, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue2.ToolTip);

                Range1ColdWaterTemperature3.Text = TowerDesignCurveData.Range1ColdWaterTemperatureDataValue3.InputValue;
                toolTip1.SetToolTip(Range1ColdWaterTemperature3, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue3.ToolTip);

                Range1ColdWaterTemperature4.Text = TowerDesignCurveData.Range1ColdWaterTemperatureDataValue4.InputValue;
                toolTip1.SetToolTip(Range1ColdWaterTemperature4, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue4.ToolTip);

                Range1ColdWaterTemperature5.Text = TowerDesignCurveData.Range1ColdWaterTemperatureDataValue5.InputValue;
                toolTip1.SetToolTip(Range1ColdWaterTemperature5, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue5.ToolTip);

                Range1ColdWaterTemperature6.Text = TowerDesignCurveData.Range1ColdWaterTemperatureDataValue6.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature6, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue6.ToolTip);

                // Range 2
                Range2ColdWaterTemperature1.Text = TowerDesignCurveData.Range2ColdWaterTemperatureDataValue1.InputValue;
                toolTip1.SetToolTip(Range2ColdWaterTemperature1, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue1.ToolTip);

                Range2ColdWaterTemperature2.Text = TowerDesignCurveData.Range2ColdWaterTemperatureDataValue2.InputValue;
                toolTip1.SetToolTip(Range2ColdWaterTemperature2, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue2.ToolTip);

                Range2ColdWaterTemperature3.Text = TowerDesignCurveData.Range2ColdWaterTemperatureDataValue3.InputValue;
                toolTip1.SetToolTip(Range2ColdWaterTemperature3, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue3.ToolTip);

                Range2ColdWaterTemperature4.Text = TowerDesignCurveData.Range2ColdWaterTemperatureDataValue4.InputValue;
                toolTip1.SetToolTip(Range2ColdWaterTemperature4, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue4.ToolTip);

                Range2ColdWaterTemperature5.Text = TowerDesignCurveData.Range2ColdWaterTemperatureDataValue5.InputValue;
                toolTip1.SetToolTip(Range2ColdWaterTemperature5, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue5.ToolTip);

                Range2ColdWaterTemperature6.Text = TowerDesignCurveData.Range2ColdWaterTemperatureDataValue6.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature6, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue6.ToolTip);

                // Range 3
                Range3ColdWaterTemperature1.Text = TowerDesignCurveData.Range3ColdWaterTemperatureDataValue1.InputValue;
                toolTip1.SetToolTip(Range3ColdWaterTemperature1, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue1.ToolTip);

                Range3ColdWaterTemperature2.Text = TowerDesignCurveData.Range3ColdWaterTemperatureDataValue2.InputValue;
                toolTip1.SetToolTip(Range3ColdWaterTemperature2, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue2.ToolTip);

                Range3ColdWaterTemperature3.Text = TowerDesignCurveData.Range3ColdWaterTemperatureDataValue3.InputValue;
                toolTip1.SetToolTip(Range3ColdWaterTemperature3, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue3.ToolTip);

                Range3ColdWaterTemperature4.Text = TowerDesignCurveData.Range3ColdWaterTemperatureDataValue4.InputValue;
                toolTip1.SetToolTip(Range3ColdWaterTemperature4, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue4.ToolTip);

                Range3ColdWaterTemperature5.Text = TowerDesignCurveData.Range3ColdWaterTemperatureDataValue5.InputValue;
                toolTip1.SetToolTip(Range3ColdWaterTemperature5, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue5.ToolTip);

                Range3ColdWaterTemperature6.Text = TowerDesignCurveData.Range3ColdWaterTemperatureDataValue6.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature6, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue6.ToolTip);

                // Range 4
                Range4ColdWaterTemperature1.Text = TowerDesignCurveData.Range4ColdWaterTemperatureDataValue1.InputValue;
                toolTip1.SetToolTip(Range4ColdWaterTemperature1, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue1.ToolTip);

                Range4ColdWaterTemperature2.Text = TowerDesignCurveData.Range4ColdWaterTemperatureDataValue2.InputValue;
                toolTip1.SetToolTip(Range4ColdWaterTemperature2, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue2.ToolTip);

                Range4ColdWaterTemperature3.Text = TowerDesignCurveData.Range4ColdWaterTemperatureDataValue3.InputValue;
                toolTip1.SetToolTip(Range4ColdWaterTemperature3, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue3.ToolTip);

                Range4ColdWaterTemperature4.Text = TowerDesignCurveData.Range4ColdWaterTemperatureDataValue4.InputValue;
                toolTip1.SetToolTip(Range4ColdWaterTemperature4, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue4.ToolTip);

                Range4ColdWaterTemperature5.Text = TowerDesignCurveData.Range4ColdWaterTemperatureDataValue5.InputValue;
                toolTip1.SetToolTip(Range4ColdWaterTemperature5, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue5.ToolTip);

                Range4ColdWaterTemperature6.Text = TowerDesignCurveData.Range4ColdWaterTemperatureDataValue6.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature6, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue6.ToolTip);

                // Range 5
                Range5ColdWaterTemperature1.Text = TowerDesignCurveData.Range5ColdWaterTemperatureDataValue1.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature1, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue1.ToolTip);

                Range5ColdWaterTemperature2.Text = TowerDesignCurveData.Range5ColdWaterTemperatureDataValue2.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature2, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue2.ToolTip);

                Range5ColdWaterTemperature3.Text = TowerDesignCurveData.Range5ColdWaterTemperatureDataValue3.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature3, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue3.ToolTip);

                Range5ColdWaterTemperature4.Text = TowerDesignCurveData.Range5ColdWaterTemperatureDataValue4.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature4, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue4.ToolTip);

                Range5ColdWaterTemperature5.Text = TowerDesignCurveData.Range5ColdWaterTemperatureDataValue5.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature5, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue5.ToolTip);

                Range5ColdWaterTemperature6.Text = TowerDesignCurveData.Range5ColdWaterTemperatureDataValue6.InputValue;
                toolTip1.SetToolTip(Range5ColdWaterTemperature6, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue6.ToolTip);
            }
            catch(Exception e)
            {
                ErrorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        //public void RangedColdWaterTemperatureVisibility(int rangeCount)
        //{
        //    Range1GroupBox.Visible = (rangeCount >= 1);
        //    Range2GroupBox.Visible = (rangeCount >= 2);
        //    Range3GroupBox.Visible = (rangeCount >= 3);
        //    Range4GroupBox.Visible = (rangeCount >= 4);
        //    Range5GroupBox.Visible = (rangeCount >= 5);
        //}

        public void RangeVisible(int rangeIndex, bool visible)
        {
            switch(rangeIndex)
            {
                case 1:
                    Range1GroupBox.Visible = visible;
                    break;
                case 2:
                    Range2GroupBox.Visible = visible;
                    break;
                case 3:
                    Range3GroupBox.Visible = visible;
                    break;
                case 4:
                    Range4GroupBox.Visible = visible;
                    break;
                case 5:
                    Range5GroupBox.Visible = visible;
                    break;
            }
        }

        public void ColdWaterTemperatureVisible(int temperatureIndex, bool visible)
        {
            switch (temperatureIndex)
            {
                case 1:
                    Range1ColdWaterTemperature1.Visible = visible;
                    Range2ColdWaterTemperature1.Visible = visible;
                    Range3ColdWaterTemperature1.Visible = visible;
                    Range4ColdWaterTemperature1.Visible = visible;
                    Range5ColdWaterTemperature1.Visible = visible;
                    break;
                case 2:
                    Range1ColdWaterTemperature2.Visible = visible;
                    Range2ColdWaterTemperature2.Visible = visible;
                    Range3ColdWaterTemperature2.Visible = visible;
                    Range4ColdWaterTemperature2.Visible = visible;
                    Range5ColdWaterTemperature2.Visible = visible;
                    break;
                case 3:
                    Range1ColdWaterTemperature3.Visible = visible;
                    Range2ColdWaterTemperature3.Visible = visible;
                    Range3ColdWaterTemperature3.Visible = visible;
                    Range4ColdWaterTemperature3.Visible = visible;
                    Range5ColdWaterTemperature3.Visible = visible;
                    break;
                case 4:
                    Range1ColdWaterTemperature4.Visible = visible;
                    Range2ColdWaterTemperature4.Visible = visible;
                    Range3ColdWaterTemperature4.Visible = visible;
                    Range4ColdWaterTemperature4.Visible = visible;
                    Range5ColdWaterTemperature4.Visible = visible;
                    break;
                case 5:
                    Range1ColdWaterTemperature5.Visible = visible;
                    Range2ColdWaterTemperature5.Visible = visible;
                    Range3ColdWaterTemperature5.Visible = visible;
                    Range4ColdWaterTemperature5.Visible = visible;
                    Range5ColdWaterTemperature5.Visible = visible;
                    break;
                case 6:
                    Range1ColdWaterTemperature6.Visible = visible;
                    Range2ColdWaterTemperature6.Visible = visible;
                    Range3ColdWaterTemperature6.Visible = visible;
                    Range4ColdWaterTemperature6.Visible = visible;
                    Range5ColdWaterTemperature6.Visible = visible;
                    break;
            }
        }

        //public void ColdWaterTemperaturesVisible()
        //{
        //    for (int i = 1; i <= 6; i++)
        //    {
        //        switch (i)
        //        {
        //            case 1:
        //                //ColdWaterTemperatureVisible(i, (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current != 0.0));
        //                break;
        //            case 2:
        //                //ColdWaterTemperatureVisible(i, (TowerDesignCurveData.WetBulbTemperatureDataValue2.Current != 0.0));
        //                break;
        //            case 3:
        //                //ColdWaterTemperatureVisible(i, (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current != 0.0));
        //                break;
        //            case 4:
        //                //ColdWaterTemperatureVisible(i, (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current != 0.0));
        //                break;
        //            case 5:
        //                //ColdWaterTemperatureVisible(i, (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current != 0.0));
        //                break;
        //            case 6:
        //                //ColdWaterTemperatureVisible(i, (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current != 0.0));
        //                break;
        //        }
        //    }
        //}

        #region DataValidation

        private void WetBulbTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature1, "");
            //ColdWaterTemperatureVisible(1, (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current != 0.0));
        }

        private void WetBulbTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WetBulbTemperature1.Text != TowerDesignCurveData.WetBulbTemperatureDataValue1.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignCurveData.WetBulbTemperatureDataValue1.UpdateValue(WetBulbTemperature1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature1.Select(0, WetBulbTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature1, TowerDesignCurveData.WetBulbTemperatureDataValue1.ErrorMessage);
            }
        }

        private void WetBulbTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature2, "");
        }

        private void WetBulbTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WetBulbTemperature2.Text != TowerDesignCurveData.WetBulbTemperatureDataValue2.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignCurveData.WetBulbTemperatureDataValue2.UpdateValue(WetBulbTemperature2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature2.Select(0, WetBulbTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature2, TowerDesignCurveData.WetBulbTemperatureDataValue2.ErrorMessage);
            }
        }

        private void WetBulbTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature3, "");
            //ColdWaterTemperatureVisible(3, (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current != 0.0));
        }

        private void WetBulbTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WetBulbTemperature3.Text != TowerDesignCurveData.WetBulbTemperatureDataValue3.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignCurveData.WetBulbTemperatureDataValue3.UpdateValue(WetBulbTemperature3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature3.Select(0, WetBulbTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature3, TowerDesignCurveData.WetBulbTemperatureDataValue3.ErrorMessage);
            }
        }

        private void WetBulbTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature4, "");
            //ColdWaterTemperatureVisible(4, (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current != 0.0));
        }

        private void WetBulbTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WetBulbTemperature4.Text != TowerDesignCurveData.WetBulbTemperatureDataValue4.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignCurveData.WetBulbTemperatureDataValue4.UpdateValue(WetBulbTemperature4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature4.Select(0, WetBulbTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature4, TowerDesignCurveData.WetBulbTemperatureDataValue4.ErrorMessage);
            }
        }

        private void WetBulbTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature5, "");
            //ColdWaterTemperatureVisible(5, (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0));
        }

        private void WetBulbTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WetBulbTemperature5.Text != TowerDesignCurveData.WetBulbTemperatureDataValue5.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignCurveData.WetBulbTemperatureDataValue5.UpdateValue(WetBulbTemperature5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature5.Select(0, WetBulbTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature5, TowerDesignCurveData.WetBulbTemperatureDataValue5.ErrorMessage);
            }
        }

        private void WetBulbTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(WetBulbTemperature6, "");
            //ColdWaterTemperatureVisible(6, (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current != 0.0));
        }

        private void WetBulbTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (WetBulbTemperature6.Text != TowerDesignCurveData.WetBulbTemperatureDataValue6.InputValue)
            {
                IsChanged = true;
            }

            if (!TowerDesignCurveData.WetBulbTemperatureDataValue6.UpdateValue(WetBulbTemperature6.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                WetBulbTemperature6.Select(0, WetBulbTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(WetBulbTemperature6, TowerDesignCurveData.WetBulbTemperatureDataValue6.ErrorMessage);
            }
        }

        private void Range1ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1ColdWaterTemperature1, "");
        }

        private void Range1ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range1ColdWaterTemperature1.Text != TowerDesignCurveData.Range1ColdWaterTemperatureDataValue1.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range1ColdWaterTemperatureDataValue1.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current == 0.0);

            if (!TowerDesignCurveData.Range1ColdWaterTemperatureDataValue1.UpdateValue(Range1ColdWaterTemperature1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1ColdWaterTemperature1.Select(0, Range1ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1ColdWaterTemperature1, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue1.ErrorMessage);
            }
        }

        private void Range1ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1ColdWaterTemperature2, "");
        }

        private void Range1ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range1ColdWaterTemperature2.Text != TowerDesignCurveData.Range1ColdWaterTemperatureDataValue2.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range1ColdWaterTemperatureDataValue2.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue2.Current == 0.0);

            if (!TowerDesignCurveData.Range1ColdWaterTemperatureDataValue2.UpdateValue(Range1ColdWaterTemperature2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1ColdWaterTemperature2.Select(0, Range1ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1ColdWaterTemperature2, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue2.ErrorMessage);
            }
        }

        private void Range1ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1ColdWaterTemperature3, "");
        }

        private void Range1ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range1ColdWaterTemperature3.Text != TowerDesignCurveData.Range1ColdWaterTemperatureDataValue3.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range1ColdWaterTemperatureDataValue3.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current == 0.0);

            if (!TowerDesignCurveData.Range1ColdWaterTemperatureDataValue3.UpdateValue(Range1ColdWaterTemperature3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1ColdWaterTemperature3.Select(0, Range1ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1ColdWaterTemperature3, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue3.ErrorMessage);
            }
        }

        private void Range1ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1ColdWaterTemperature4, "");
        }

        private void Range1ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range1ColdWaterTemperature4.Text != TowerDesignCurveData.Range1ColdWaterTemperatureDataValue4.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range1ColdWaterTemperatureDataValue4.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current == 0.0);

            if (!TowerDesignCurveData.Range1ColdWaterTemperatureDataValue4.UpdateValue(Range1ColdWaterTemperature4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1ColdWaterTemperature4.Select(0, Range1ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1ColdWaterTemperature4, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue4.ErrorMessage);
            }
        }

        private void Range1ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1ColdWaterTemperature5, "");
        }

        private void Range1ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range1ColdWaterTemperature5.Text != TowerDesignCurveData.Range1ColdWaterTemperatureDataValue5.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range1ColdWaterTemperatureDataValue5.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0);

            if (!TowerDesignCurveData.Range1ColdWaterTemperatureDataValue5.UpdateValue(Range1ColdWaterTemperature5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1ColdWaterTemperature5.Select(0, Range1ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1ColdWaterTemperature5, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue5.ErrorMessage);
            }
        }

        private void Range1ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range1ColdWaterTemperature6, "");
        }

        private void Range1ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range1ColdWaterTemperature6.Text != TowerDesignCurveData.Range1ColdWaterTemperatureDataValue6.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range1ColdWaterTemperatureDataValue6.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current == 0.0);

            if (!TowerDesignCurveData.Range1ColdWaterTemperatureDataValue6.UpdateValue(Range1ColdWaterTemperature6.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range1ColdWaterTemperature6.Select(0, Range1ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range1ColdWaterTemperature6, TowerDesignCurveData.Range1ColdWaterTemperatureDataValue6.ErrorMessage);
            }
        }

        private void Range2ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2ColdWaterTemperature1, "");
        }

        private void Range2ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range2ColdWaterTemperature1.Text != TowerDesignCurveData.Range2ColdWaterTemperatureDataValue1.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range2ColdWaterTemperatureDataValue1.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current == 0.0);

            if (!TowerDesignCurveData.Range2ColdWaterTemperatureDataValue1.UpdateValue(Range2ColdWaterTemperature1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2ColdWaterTemperature1.Select(0, Range2ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2ColdWaterTemperature1, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue1.ErrorMessage);
            }
        }

        private void Range2ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2ColdWaterTemperature2, "");
        }

        private void Range2ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range2ColdWaterTemperature2.Text != TowerDesignCurveData.Range2ColdWaterTemperatureDataValue2.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range2ColdWaterTemperatureDataValue2.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue2.Current == 0.0);

            if (!TowerDesignCurveData.Range2ColdWaterTemperatureDataValue2.UpdateValue(Range2ColdWaterTemperature2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2ColdWaterTemperature2.Select(0, Range2ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2ColdWaterTemperature2, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue2.ErrorMessage);
            }
        }

        private void Range2ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2ColdWaterTemperature3, "");
        }

        private void Range2ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range2ColdWaterTemperature3.Text != TowerDesignCurveData.Range2ColdWaterTemperatureDataValue3.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range2ColdWaterTemperatureDataValue3.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current == 0.0);

            if (!TowerDesignCurveData.Range2ColdWaterTemperatureDataValue3.UpdateValue(Range2ColdWaterTemperature3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2ColdWaterTemperature3.Select(0, Range2ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2ColdWaterTemperature3, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue3.ErrorMessage);
            }
        }

        private void Range2ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2ColdWaterTemperature4, "");
        }

        private void Range2ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range2ColdWaterTemperature4.Text != TowerDesignCurveData.Range2ColdWaterTemperatureDataValue4.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range2ColdWaterTemperatureDataValue4.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current == 0.0);

            if (!TowerDesignCurveData.Range2ColdWaterTemperatureDataValue4.UpdateValue(Range2ColdWaterTemperature4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2ColdWaterTemperature4.Select(0, Range2ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2ColdWaterTemperature4, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue4.ErrorMessage);
            }
        }

        private void Range2ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2ColdWaterTemperature5, "");
        }

        private void Range2ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range2ColdWaterTemperature5.Text != TowerDesignCurveData.Range2ColdWaterTemperatureDataValue5.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range2ColdWaterTemperatureDataValue5.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0);

            if (!TowerDesignCurveData.Range2ColdWaterTemperatureDataValue5.UpdateValue(Range2ColdWaterTemperature5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2ColdWaterTemperature5.Select(0, Range2ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2ColdWaterTemperature5, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue5.ErrorMessage);
            }
        }

        private void Range2ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range2ColdWaterTemperature6, "");
        }

        private void Range2ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range2ColdWaterTemperature6.Text != TowerDesignCurveData.Range2ColdWaterTemperatureDataValue6.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range2ColdWaterTemperatureDataValue6.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current == 0.0);

            if (!TowerDesignCurveData.Range2ColdWaterTemperatureDataValue6.UpdateValue(Range2ColdWaterTemperature6.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range2ColdWaterTemperature6.Select(0, Range2ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range2ColdWaterTemperature6, TowerDesignCurveData.Range2ColdWaterTemperatureDataValue6.ErrorMessage);
            }
        }

        private void Range3ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3ColdWaterTemperature1, "");
        }

        private void Range3ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range3ColdWaterTemperature1.Text != TowerDesignCurveData.Range3ColdWaterTemperatureDataValue1.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range3ColdWaterTemperatureDataValue1.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current == 0.0);

            if (!TowerDesignCurveData.Range3ColdWaterTemperatureDataValue1.UpdateValue(Range3ColdWaterTemperature1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3ColdWaterTemperature1.Select(0, Range3ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3ColdWaterTemperature1, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue1.ErrorMessage);
            }
        }

        private void Range3ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3ColdWaterTemperature2, "");
        }

        private void Range3ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range3ColdWaterTemperature2.Text != TowerDesignCurveData.Range3ColdWaterTemperatureDataValue2.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range3ColdWaterTemperatureDataValue2.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue2.Current == 0.0);

            if (!TowerDesignCurveData.Range3ColdWaterTemperatureDataValue2.UpdateValue(Range3ColdWaterTemperature2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3ColdWaterTemperature2.Select(0, Range3ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3ColdWaterTemperature2, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue2.ErrorMessage);
            }
        }

        private void Range3ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3ColdWaterTemperature3, "");
        }

        private void Range3ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range3ColdWaterTemperature3.Text != TowerDesignCurveData.Range3ColdWaterTemperatureDataValue3.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range3ColdWaterTemperatureDataValue3.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current == 0.0);

            if (!TowerDesignCurveData.Range3ColdWaterTemperatureDataValue3.UpdateValue(Range3ColdWaterTemperature3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3ColdWaterTemperature3.Select(0, Range3ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3ColdWaterTemperature3, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue3.ErrorMessage);
            }
        }

        private void Range3ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3ColdWaterTemperature4, "");
        }

        private void Range3ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range3ColdWaterTemperature4.Text != TowerDesignCurveData.Range3ColdWaterTemperatureDataValue4.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range3ColdWaterTemperatureDataValue4.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current == 0.0);

            if (!TowerDesignCurveData.Range3ColdWaterTemperatureDataValue4.UpdateValue(Range3ColdWaterTemperature4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3ColdWaterTemperature4.Select(0, Range3ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3ColdWaterTemperature4, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue4.ErrorMessage);
            }
        }

        private void Range3ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3ColdWaterTemperature5, "");
        }

        private void Range3ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range3ColdWaterTemperature5.Text != TowerDesignCurveData.Range3ColdWaterTemperatureDataValue5.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range3ColdWaterTemperatureDataValue5.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0);

            if (!TowerDesignCurveData.Range3ColdWaterTemperatureDataValue5.UpdateValue(Range3ColdWaterTemperature5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3ColdWaterTemperature5.Select(0, Range3ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3ColdWaterTemperature5, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue5.ErrorMessage);
            }
        }

        private void Range3ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range3ColdWaterTemperature6, "");
        }

        private void Range3ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range3ColdWaterTemperature6.Text != TowerDesignCurveData.Range3ColdWaterTemperatureDataValue6.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range3ColdWaterTemperatureDataValue6.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current == 0.0);

            if (!TowerDesignCurveData.Range3ColdWaterTemperatureDataValue6.UpdateValue(Range3ColdWaterTemperature6.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range3ColdWaterTemperature6.Select(0, Range3ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range3ColdWaterTemperature6, TowerDesignCurveData.Range3ColdWaterTemperatureDataValue6.ErrorMessage);
            }
        }

        private void Range4ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4ColdWaterTemperature1, "");
        }

        private void Range4ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range4ColdWaterTemperature1.Text != TowerDesignCurveData.Range4ColdWaterTemperatureDataValue1.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range4ColdWaterTemperatureDataValue1.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current == 0.0);

            if (!TowerDesignCurveData.Range4ColdWaterTemperatureDataValue1.UpdateValue(Range4ColdWaterTemperature1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4ColdWaterTemperature1.Select(0, Range4ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4ColdWaterTemperature1, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue1.ErrorMessage);
            }
        }

        private void Range4ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4ColdWaterTemperature2, "");
        }

        private void Range4ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range4ColdWaterTemperature2.Text != TowerDesignCurveData.Range4ColdWaterTemperatureDataValue2.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range4ColdWaterTemperatureDataValue2.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue2.Current == 0.0);

            if (!TowerDesignCurveData.Range4ColdWaterTemperatureDataValue2.UpdateValue(Range4ColdWaterTemperature2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4ColdWaterTemperature2.Select(0, Range4ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4ColdWaterTemperature2, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue2.ErrorMessage);
            }
        }

        private void Range4ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4ColdWaterTemperature3, "");
        }

        private void Range4ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range4ColdWaterTemperature3.Text != TowerDesignCurveData.Range4ColdWaterTemperatureDataValue3.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range4ColdWaterTemperatureDataValue3.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current == 0.0);

            if (!TowerDesignCurveData.Range4ColdWaterTemperatureDataValue3.UpdateValue(Range4ColdWaterTemperature3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4ColdWaterTemperature3.Select(0, Range4ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4ColdWaterTemperature3, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue3.ErrorMessage);
            }
        }

        private void Range4ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4ColdWaterTemperature4, "");
        }

        private void Range4ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range4ColdWaterTemperature4.Text != TowerDesignCurveData.Range4ColdWaterTemperatureDataValue4.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range4ColdWaterTemperatureDataValue4.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current == 0.0);

            if (!TowerDesignCurveData.Range4ColdWaterTemperatureDataValue4.UpdateValue(Range4ColdWaterTemperature4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4ColdWaterTemperature4.Select(0, Range4ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4ColdWaterTemperature4, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue4.ErrorMessage);
            }
        }

        private void Range4ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4ColdWaterTemperature5, "");
        }

        private void Range4ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range4ColdWaterTemperature5.Text != TowerDesignCurveData.Range4ColdWaterTemperatureDataValue5.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range4ColdWaterTemperatureDataValue5.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0);

            if (!TowerDesignCurveData.Range4ColdWaterTemperatureDataValue5.UpdateValue(Range4ColdWaterTemperature5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4ColdWaterTemperature5.Select(0, Range4ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4ColdWaterTemperature5, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue5.ErrorMessage);
            }
        }

        private void Range4ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range4ColdWaterTemperature6, "");
        }

        private void Range4ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range4ColdWaterTemperature6.Text != TowerDesignCurveData.Range4ColdWaterTemperatureDataValue6.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range4ColdWaterTemperatureDataValue6.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current == 0.0);

            if (!TowerDesignCurveData.Range4ColdWaterTemperatureDataValue6.UpdateValue(Range4ColdWaterTemperature6.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range4ColdWaterTemperature6.Select(0, Range4ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range4ColdWaterTemperature6, TowerDesignCurveData.Range4ColdWaterTemperatureDataValue6.ErrorMessage);
            }
        }

        private void Range5ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5ColdWaterTemperature1, "");
        }

        private void Range5ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range5ColdWaterTemperature1.Text != TowerDesignCurveData.Range5ColdWaterTemperatureDataValue1.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range5ColdWaterTemperatureDataValue1.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue1.Current == 0.0);

            if (!TowerDesignCurveData.Range5ColdWaterTemperatureDataValue1.UpdateValue(Range5ColdWaterTemperature1.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5ColdWaterTemperature1.Select(0, Range5ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5ColdWaterTemperature1, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue1.ErrorMessage);
            }
        }

        private void Range5ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5ColdWaterTemperature2, "");
        }

        private void Range5ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range5ColdWaterTemperature2.Text != TowerDesignCurveData.Range5ColdWaterTemperatureDataValue2.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range5ColdWaterTemperatureDataValue2.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue2.Current == 0.0);

            if (!TowerDesignCurveData.Range5ColdWaterTemperatureDataValue2.UpdateValue(Range5ColdWaterTemperature2.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5ColdWaterTemperature2.Select(0, Range5ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5ColdWaterTemperature2, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue2.ErrorMessage);
            }
        }

        private void Range5ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5ColdWaterTemperature3, "");
        }

        private void Range5ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range5ColdWaterTemperature3.Text != TowerDesignCurveData.Range5ColdWaterTemperatureDataValue3.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range5ColdWaterTemperatureDataValue3.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue3.Current == 0.0);

            if (!TowerDesignCurveData.Range5ColdWaterTemperatureDataValue3.UpdateValue(Range5ColdWaterTemperature3.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5ColdWaterTemperature3.Select(0, Range5ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5ColdWaterTemperature3, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue3.ErrorMessage);
            }
        }

        private void Range5ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5ColdWaterTemperature4, "");
        }

        private void Range5ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range5ColdWaterTemperature4.Text != TowerDesignCurveData.Range5ColdWaterTemperatureDataValue4.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range5ColdWaterTemperatureDataValue4.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue4.Current == 0.0);

            if (!TowerDesignCurveData.Range5ColdWaterTemperatureDataValue4.UpdateValue(Range5ColdWaterTemperature4.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5ColdWaterTemperature4.Select(0, Range5ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5ColdWaterTemperature4, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue4.ErrorMessage);
            }
        }

        private void Range5ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5ColdWaterTemperature5, "");
        }

        private void Range5ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range5ColdWaterTemperature5.Text != TowerDesignCurveData.Range5ColdWaterTemperatureDataValue5.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range5ColdWaterTemperatureDataValue5.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue5.Current == 0.0);

            if (!TowerDesignCurveData.Range5ColdWaterTemperatureDataValue5.UpdateValue(Range5ColdWaterTemperature5.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5ColdWaterTemperature5.Select(0, Range5ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5ColdWaterTemperature5, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue5.ErrorMessage);
            }
        }

        private void Range5ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(Range5ColdWaterTemperature6, "");
        }

        private void Range5ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Range5ColdWaterTemperature6.Text != TowerDesignCurveData.Range5ColdWaterTemperatureDataValue6.InputValue)
            {
                IsChanged = true;
            }

            TowerDesignCurveData.Range5ColdWaterTemperatureDataValue6.IsZeroValid = (TowerDesignCurveData.WetBulbTemperatureDataValue6.Current == 0.0);

            if (!TowerDesignCurveData.Range5ColdWaterTemperatureDataValue6.UpdateValue(Range5ColdWaterTemperature6.Text))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                Range5ColdWaterTemperature6.Select(0, Range5ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(Range5ColdWaterTemperature6, TowerDesignCurveData.Range5ColdWaterTemperatureDataValue6.ErrorMessage);
            }
        }

        #endregion DataValidation
    }
}