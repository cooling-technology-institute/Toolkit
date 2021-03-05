using Models;
using System;
using System.Text;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class RangedTemperatureDesignUserControl : UserControl
    {
        public TowerDesignCurveData RangedTemperatureDesignViewModel { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }

        public RangedTemperatureDesignUserControl(bool isDemo, bool isInternationalSystemOfUnits_SI_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_SI_;

            InitializeComponent();

            RangedTemperatureDesignViewModel = new TowerDesignCurveData(IsDemo, IsInternationalSystemOfUnits_SI_);

            string errorMessage = string.Empty;
            
            Setup(out errorMessage);
        }

        public bool LoadData(bool isInternationalSystemOfUnits_SI_, RangedTemperaturesDesignData rangedTemperaturesDesignData, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
               
            if(!RangedTemperatureDesignViewModel.LoadData(isInternationalSystemOfUnits_SI_, rangedTemperaturesDesignData, out errorMessage))
            {
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
                returnValue = false;
            }
            if (!Setup(out errorMessage))
            {
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
                returnValue = false;
            }
            return returnValue;
        }

        public bool Setup(out string errorMessage)
        {
            bool returnValue = true;
            errorMessage = string.Empty;
            try
            {
                TowerDesignDataWetBulbTemperature1.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature1, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1Tooltip);

                TowerDesignDataWetBulbTemperature2.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature2, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue2Tooltip);

                TowerDesignDataWetBulbTemperature3.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature3, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue3Tooltip);

                TowerDesignDataWetBulbTemperature4.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature4, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue4Tooltip);

                TowerDesignDataWetBulbTemperature5.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature5, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue5Tooltip);

                TowerDesignDataWetBulbTemperature6.Text = RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature6, RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue6Tooltip);

                // Range 1
                TowerDesignDataRange1ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange1ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange1ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange1ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange1ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange1ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue6Tooltip);

                // Range 2
                TowerDesignDataRange2ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange2ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange2ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange2ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange2ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange2ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue6Tooltip);

                // Range 3
                TowerDesignDataRange3ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange3ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange3ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange3ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange3ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange3ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue6Tooltip);

                // Range 4
                TowerDesignDataRange4ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange4ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange4ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange4ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange4ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange4ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue6Tooltip);

                // Range 5
                TowerDesignDataRange5ColdWaterTemperature1.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature1, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1Tooltip);

                TowerDesignDataRange5ColdWaterTemperature2.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature2, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue2Tooltip);

                TowerDesignDataRange5ColdWaterTemperature3.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature3, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue3Tooltip);

                TowerDesignDataRange5ColdWaterTemperature4.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature4, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue4Tooltip);

                TowerDesignDataRange5ColdWaterTemperature5.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature5, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue5Tooltip);

                TowerDesignDataRange5ColdWaterTemperature6.Text = RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue6InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5ColdWaterTemperature6, RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue6Tooltip);
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        public void RangedColdWaterTemperatureVisibility(int rangeCount)
        {
            TowerDesignDataRange1GroupBox.Visible = (rangeCount >= 1);
            TowerDesignDataRange2GroupBox.Visible = (rangeCount >= 2);
            TowerDesignDataRange3GroupBox.Visible = (rangeCount >= 3);
            TowerDesignDataRange4GroupBox.Visible = (rangeCount >= 4);
            TowerDesignDataRange5GroupBox.Visible = (rangeCount >= 5);
        }

        public void RangedColdWaterTemperatureEnable(int webBulbTemperatureCount)
        {
            TowerDesignDataRange1ColdWaterTemperature1.Visible = (webBulbTemperatureCount >= 1);
            TowerDesignDataRange1ColdWaterTemperature2.Visible = (webBulbTemperatureCount >= 2);
            TowerDesignDataRange1ColdWaterTemperature3.Visible = (webBulbTemperatureCount >= 3);
            TowerDesignDataRange1ColdWaterTemperature4.Visible = (webBulbTemperatureCount >= 4);
            TowerDesignDataRange1ColdWaterTemperature5.Visible = (webBulbTemperatureCount >= 5);
            TowerDesignDataRange1ColdWaterTemperature6.Visible = (webBulbTemperatureCount >= 6);

            TowerDesignDataRange2ColdWaterTemperature1.Visible = (webBulbTemperatureCount >= 1);
            TowerDesignDataRange2ColdWaterTemperature2.Visible = (webBulbTemperatureCount >= 2);
            TowerDesignDataRange2ColdWaterTemperature3.Visible = (webBulbTemperatureCount >= 3);
            TowerDesignDataRange2ColdWaterTemperature4.Visible = (webBulbTemperatureCount >= 4);
            TowerDesignDataRange2ColdWaterTemperature5.Visible = (webBulbTemperatureCount >= 5);
            TowerDesignDataRange2ColdWaterTemperature6.Visible = (webBulbTemperatureCount >= 6);

            TowerDesignDataRange3ColdWaterTemperature1.Visible = (webBulbTemperatureCount >= 1);
            TowerDesignDataRange3ColdWaterTemperature2.Visible = (webBulbTemperatureCount >= 2);
            TowerDesignDataRange3ColdWaterTemperature3.Visible = (webBulbTemperatureCount >= 3);
            TowerDesignDataRange3ColdWaterTemperature4.Visible = (webBulbTemperatureCount >= 4);
            TowerDesignDataRange3ColdWaterTemperature5.Visible = (webBulbTemperatureCount >= 5);
            TowerDesignDataRange3ColdWaterTemperature6.Visible = (webBulbTemperatureCount >= 6);

            TowerDesignDataRange4ColdWaterTemperature1.Visible = (webBulbTemperatureCount >= 1);
            TowerDesignDataRange4ColdWaterTemperature2.Visible = (webBulbTemperatureCount >= 2);
            TowerDesignDataRange4ColdWaterTemperature3.Visible = (webBulbTemperatureCount >= 3);
            TowerDesignDataRange4ColdWaterTemperature4.Visible = (webBulbTemperatureCount >= 4);
            TowerDesignDataRange4ColdWaterTemperature5.Visible = (webBulbTemperatureCount >= 5);
            TowerDesignDataRange4ColdWaterTemperature6.Visible = (webBulbTemperatureCount >= 6);

            TowerDesignDataRange5ColdWaterTemperature1.Visible = (webBulbTemperatureCount >= 1);
            TowerDesignDataRange5ColdWaterTemperature2.Visible = (webBulbTemperatureCount >= 2);
            TowerDesignDataRange5ColdWaterTemperature3.Visible = (webBulbTemperatureCount >= 3);
            TowerDesignDataRange5ColdWaterTemperature4.Visible = (webBulbTemperatureCount >= 4);
            TowerDesignDataRange5ColdWaterTemperature5.Visible = (webBulbTemperatureCount >= 5);
            TowerDesignDataRange5ColdWaterTemperature6.Visible = (webBulbTemperatureCount >= 6);
        }

        #region DataValidation

        private void TowerDesignDataWetBulbTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature1, "");
        }

        private void TowerDesignDataWetBulbTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1UpdateValue(TowerDesignDataWetBulbTemperature1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature1.Select(0, TowerDesignDataWetBulbTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature1, errorMessage);
            }
        }

        private void TowerDesignDataWetBulbTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature2, "");
        }

        private void TowerDesignDataWetBulbTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1UpdateValue(TowerDesignDataWetBulbTemperature2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature2.Select(0, TowerDesignDataWetBulbTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature2, errorMessage);
            }
        }

        private void TowerDesignDataWetBulbTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature3, "");
        }

        private void TowerDesignDataWetBulbTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1UpdateValue(TowerDesignDataWetBulbTemperature3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature3.Select(0, TowerDesignDataWetBulbTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature3, errorMessage);
            }
        }

        private void TowerDesignDataWetBulbTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature4, "");
        }

        private void TowerDesignDataWetBulbTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1UpdateValue(TowerDesignDataWetBulbTemperature4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature4.Select(0, TowerDesignDataWetBulbTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature4, errorMessage);
            }
        }

        private void TowerDesignDataWetBulbTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature5, "");
        }

        private void TowerDesignDataWetBulbTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1UpdateValue(TowerDesignDataWetBulbTemperature5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature5.Select(0, TowerDesignDataWetBulbTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature5, errorMessage);
            }
        }

        private void TowerDesignDataWetBulbTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWetBulbTemperature6, "");
        }

        private void TowerDesignDataWetBulbTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.WetBulbTemperatureDataValue1UpdateValue(TowerDesignDataWetBulbTemperature6.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataWetBulbTemperature6.Select(0, TowerDesignDataWetBulbTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataWetBulbTemperature6, errorMessage);
            }
        }

        private void TowerDesignDataRange1ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature1, "");
        }

        private void TowerDesignDataRange1ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange1ColdWaterTemperature1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1ColdWaterTemperature1.Select(0, TowerDesignDataRange1ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature1, errorMessage);
            }
        }

        private void TowerDesignDataRange1ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature2, "");
        }

        private void TowerDesignDataRange1ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange1ColdWaterTemperature2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1ColdWaterTemperature2.Select(0, TowerDesignDataRange1ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature2, errorMessage);
            }
        }

        private void TowerDesignDataRange1ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature3, "");
        }

        private void TowerDesignDataRange1ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange1ColdWaterTemperature3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1ColdWaterTemperature3.Select(0, TowerDesignDataRange1ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature3, errorMessage);
            }
        }

        private void TowerDesignDataRange1ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature4, "");
        }

        private void TowerDesignDataRange1ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange1ColdWaterTemperature4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1ColdWaterTemperature4.Select(0, TowerDesignDataRange1ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature4, errorMessage);
            }
        }

        private void TowerDesignDataRange1ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature5, "");
        }

        private void TowerDesignDataRange1ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange1ColdWaterTemperature5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1ColdWaterTemperature5.Select(0, TowerDesignDataRange1ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature5, errorMessage);
            }
        }

        private void TowerDesignDataRange1ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature6, "");
        }

        private void TowerDesignDataRange1ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range1ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange1ColdWaterTemperature6.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange1ColdWaterTemperature6.Select(0, TowerDesignDataRange1ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange1ColdWaterTemperature6, errorMessage);
            }
        }

        private void TowerDesignDataRange2ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature1, "");
        }

        private void TowerDesignDataRange2ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange2ColdWaterTemperature1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2ColdWaterTemperature1.Select(0, TowerDesignDataRange2ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature1, errorMessage);
            }
        }

        private void TowerDesignDataRange2ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature2, "");
        }

        private void TowerDesignDataRange2ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange2ColdWaterTemperature2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2ColdWaterTemperature2.Select(0, TowerDesignDataRange2ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature2, errorMessage);
            }
        }

        private void TowerDesignDataRange2ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature3, "");
        }

        private void TowerDesignDataRange2ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange2ColdWaterTemperature3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2ColdWaterTemperature3.Select(0, TowerDesignDataRange2ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature3, errorMessage);
            }
        }

        private void TowerDesignDataRange2ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature4, "");
        }

        private void TowerDesignDataRange2ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange2ColdWaterTemperature4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2ColdWaterTemperature4.Select(0, TowerDesignDataRange2ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature4, errorMessage);
            }
        }

        private void TowerDesignDataRange2ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature5, "");
        }

        private void TowerDesignDataRange2ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange2ColdWaterTemperature5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2ColdWaterTemperature5.Select(0, TowerDesignDataRange2ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature5, errorMessage);
            }
        }

        private void TowerDesignDataRange2ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature6, "");
        }

        private void TowerDesignDataRange2ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range2ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange2ColdWaterTemperature6.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange2ColdWaterTemperature6.Select(0, TowerDesignDataRange2ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange2ColdWaterTemperature6, errorMessage);
            }
        }

        private void TowerDesignDataRange3ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature1, "");
        }

        private void TowerDesignDataRange3ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange3ColdWaterTemperature1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3ColdWaterTemperature1.Select(0, TowerDesignDataRange3ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature1, errorMessage);
            }
        }

        private void TowerDesignDataRange3ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature2, "");
        }

        private void TowerDesignDataRange3ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange3ColdWaterTemperature2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3ColdWaterTemperature2.Select(0, TowerDesignDataRange3ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature2, errorMessage);
            }
        }

        private void TowerDesignDataRange3ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature3, "");
        }

        private void TowerDesignDataRange3ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange3ColdWaterTemperature3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3ColdWaterTemperature3.Select(0, TowerDesignDataRange3ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature3, errorMessage);
            }
        }

        private void TowerDesignDataRange3ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature4, "");
        }

        private void TowerDesignDataRange3ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange3ColdWaterTemperature4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3ColdWaterTemperature4.Select(0, TowerDesignDataRange3ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature4, errorMessage);
            }
        }

        private void TowerDesignDataRange3ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature5, "");
        }

        private void TowerDesignDataRange3ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange3ColdWaterTemperature5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3ColdWaterTemperature5.Select(0, TowerDesignDataRange3ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature5, errorMessage);
            }
        }

        private void TowerDesignDataRange3ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature6, "");
        }

        private void TowerDesignDataRange3ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range3ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange3ColdWaterTemperature6.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange3ColdWaterTemperature6.Select(0, TowerDesignDataRange3ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange3ColdWaterTemperature6, errorMessage);
            }
        }

        private void TowerDesignDataRange4ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature1, "");
        }

        private void TowerDesignDataRange4ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange4ColdWaterTemperature1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4ColdWaterTemperature1.Select(0, TowerDesignDataRange4ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature1, errorMessage);
            }
        }

        private void TowerDesignDataRange4ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature2, "");
        }

        private void TowerDesignDataRange4ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange4ColdWaterTemperature2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4ColdWaterTemperature2.Select(0, TowerDesignDataRange4ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature2, errorMessage);
            }
        }

        private void TowerDesignDataRange4ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature3, "");
        }

        private void TowerDesignDataRange4ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange4ColdWaterTemperature3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4ColdWaterTemperature3.Select(0, TowerDesignDataRange4ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature3, errorMessage);
            }
        }

        private void TowerDesignDataRange4ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature4, "");
        }

        private void TowerDesignDataRange4ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange4ColdWaterTemperature4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4ColdWaterTemperature4.Select(0, TowerDesignDataRange4ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature4, errorMessage);
            }
        }

        private void TowerDesignDataRange4ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature5, "");
        }

        private void TowerDesignDataRange4ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange4ColdWaterTemperature5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4ColdWaterTemperature5.Select(0, TowerDesignDataRange4ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature5, errorMessage);
            }
        }

        private void TowerDesignDataRange4ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature6, "");
        }

        private void TowerDesignDataRange4ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range4ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange4ColdWaterTemperature6.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange4ColdWaterTemperature6.Select(0, TowerDesignDataRange4ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange4ColdWaterTemperature6, errorMessage);
            }
        }

        private void TowerDesignDataRange5ColdWaterTemperature1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature1, "");
        }

        private void TowerDesignDataRange5ColdWaterTemperature1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange5ColdWaterTemperature1.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5ColdWaterTemperature1.Select(0, TowerDesignDataRange5ColdWaterTemperature1.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature1, errorMessage);
            }
        }

        private void TowerDesignDataRange5ColdWaterTemperature2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature2, "");
        }

        private void TowerDesignDataRange5ColdWaterTemperature2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange5ColdWaterTemperature2.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5ColdWaterTemperature2.Select(0, TowerDesignDataRange5ColdWaterTemperature2.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature2, errorMessage);
            }
        }

        private void TowerDesignDataRange5ColdWaterTemperature3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature3, "");
        }

        private void TowerDesignDataRange5ColdWaterTemperature3_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange5ColdWaterTemperature3.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5ColdWaterTemperature3.Select(0, TowerDesignDataRange5ColdWaterTemperature3.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature3, errorMessage);
            }
        }

        private void TowerDesignDataRange5ColdWaterTemperature4_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature4, "");
        }

        private void TowerDesignDataRange5ColdWaterTemperature4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange5ColdWaterTemperature4.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5ColdWaterTemperature4.Select(0, TowerDesignDataRange5ColdWaterTemperature4.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature4, errorMessage);
            }
        }

        private void TowerDesignDataRange5ColdWaterTemperature5_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature5, "");
        }

        private void TowerDesignDataRange5ColdWaterTemperature5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange5ColdWaterTemperature5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5ColdWaterTemperature5.Select(0, TowerDesignDataRange5ColdWaterTemperature5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature5, errorMessage);
            }
        }

        private void TowerDesignDataRange5ColdWaterTemperature6_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature6, "");
        }

        private void TowerDesignDataRange5ColdWaterTemperature6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!RangedTemperatureDesignViewModel.Range5ColdWaterTemperatureDataValue1UpdateValue(TowerDesignDataRange5ColdWaterTemperature6.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5ColdWaterTemperature6.Select(0, TowerDesignDataRange5ColdWaterTemperature6.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5ColdWaterTemperature6, errorMessage);
            }
        }

        #endregion DataValidation

        private void TowerDesignDataUpdateWaterFlowRateButton_Click(object sender, EventArgs e)
        {

        }
        //public bool WaterFlowRateDataValue_UpdateValue(string value, out string errorMessage)
        //{
        //    RangedTemperatureDesignViewModel.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        //}

        private void TowerDesignDataUpdateWaterFlowRate_Vaildating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            //if (!WaterFlowRateDataValue_UpdateValue(TowerDesignDataUpdateWaterFlowRate.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataUpdateWaterFlowRate.Select(0, TowerDesignDataUpdateWaterFlowRate.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataUpdateWaterFlowRate, errorMessage);
            }
        }

        private void TowerDesignDataUpdateWaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataUpdateWaterFlowRate, "");
        }
    }
}