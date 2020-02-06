// Copyright Cooling Technology Institute 2019-2020

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

        public MechanicalDraftPerformanceCurveTowerDesignViewModel MechanicalDraftPerformanceCurveTowerDesignViewModel { get; set; }
        public List<RangedTemperatureDesignViewModel> RangedTemperatureDesignViewModels { get; set; }

        public bool IsChanged { get; set; }
        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerDesignDataUserControl(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            InitializeComponent();

            MechanicalDraftPerformanceCurveTowerDesignViewModel = new MechanicalDraftPerformanceCurveTowerDesignViewModel(IsDemo, IsInternationalSystemOfUnits_SI);

            RangedTemperatureDesignViewModels = new List<RangedTemperatureDesignViewModel>();

            string errorMessage;
            Setup(out errorMessage);
        }

        public bool LoadData(MechanicalDraftPerformanceCurveDesignData mechanicalDraftPerformanceCurveDesignData, out string errorMessage)
        {
            bool returnValue = true;
            errorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.LoadData(mechanicalDraftPerformanceCurveDesignData, out errorMessage))
            {
                returnValue = false;
                stringBuilder.AppendLine(errorMessage);
                errorMessage = string.Empty;
            }
            
            RangedTemperatureDesignViewModels.Clear();
            foreach (RangedTemperaturesDesignData rangedTemperaturesDesignData in mechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData)
            {
                RangedTemperatureDesignViewModel rangedTemperatureDesignViewModel = new RangedTemperatureDesignViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
                if (!rangedTemperatureDesignViewModel.LoadData(rangedTemperaturesDesignData, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }
                RangedTemperatureDesignViewModels.Add(rangedTemperatureDesignViewModel);
            }

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

                TowerDesignDataOwnerName.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.OwnerNameInputValue;
                TowerDesignDataProjectName.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.ProjectNameInputValue;
                TowerDesignDataLocation.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.LocationInputValue;
                TowerDesignDataTowerManufacturer.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.TowerManufacturerInputValue;

                if (MechanicalDraftPerformanceCurveTowerDesignViewModel.TowerTypeInputValue == TOWER_TYPE.Induced)
                {
                    TowerDesignDataTowerTypeInducedRadio.Checked = true;
                }
                else
                {
                    TowerDesignDataTowerTypeForcedRadio.Checked = true;
                }

                TowerDesignDataWaterFlowRateLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.WaterFlowRateDataValueInputMessage + ":";
                TowerDesignDataWaterFlowRateLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataWaterFlowRate.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.WaterFlowRateDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataWaterFlowRate, MechanicalDraftPerformanceCurveTowerDesignViewModel.WaterFlowRateDataValueTooltip);

                TowerDesignDataHotWaterTemperatureLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.HotWaterTemperatureDataValueInputMessage + ":";
                TowerDesignDataHotWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataHotWaterTemperature.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.HotWaterTemperatureDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataHotWaterTemperature, MechanicalDraftPerformanceCurveTowerDesignViewModel.HotWaterTemperatureDataValueTooltip);

                TowerDesignDataColdWaterTemperatureLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.ColdWaterTemperatureDataValueInputMessage + ":";
                TowerDesignDataColdWaterTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataColdWaterTemperature.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.ColdWaterTemperatureDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataColdWaterTemperature, MechanicalDraftPerformanceCurveTowerDesignViewModel.ColdWaterTemperatureDataValueTooltip);

                TowerDesignDataWetBulbTemperatureLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.WetBulbTemperatureDataValueInputMessage + ":";
                TowerDesignDataWetBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataWetBulbTemperature.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.WetBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataWetBulbTemperature, MechanicalDraftPerformanceCurveTowerDesignViewModel.WetBulbTemperatureDataValueTooltip);

                TowerDesignDataDryBulbTemperatureLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.DryBulbTemperatureDataValueInputMessage + ":";
                TowerDesignDataDryBulbTemperatureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataDryBulbTemperature.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.DryBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataDryBulbTemperature, MechanicalDraftPerformanceCurveTowerDesignViewModel.DryBulbTemperatureDataValueTooltip);

                TowerDesignDataFanDriverPowerLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.FanDriverPowerDataValueInputMessage + ":";
                TowerDesignDataFanDriverPowerLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataFanDriverPower.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.FanDriverPowerDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataFanDriverPower, MechanicalDraftPerformanceCurveTowerDesignViewModel.FanDriverPowerDataValueTooltip);

                TowerDesignDataBarometricPressureLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.BarometricPressureDataValueInputMessage + ":";
                TowerDesignDataBarometricPressureLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataBarometricPressure.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.BarometricPressureDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataBarometricPressure, MechanicalDraftPerformanceCurveTowerDesignViewModel.BarometricPressureDataValueTooltip);

                TowerDesignDataLiquidToGasRatioLabel.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.LiquidToGasRatioDataValueInputMessage + ":";
                TowerDesignDataLiquidToGasRatioLabel.TextAlign = ContentAlignment.MiddleRight;
                TowerDesignDataLiquidToGasRatio.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.LiquidToGasRatioDataValueInputValue;
                toolTip1.SetToolTip(TowerDesignDataLiquidToGasRatio, MechanicalDraftPerformanceCurveTowerDesignViewModel.LiquidToGasRatioDataValueTooltip);

                TowerDesignDataRange1.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue1InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange1, MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue1Tooltip);

                TowerDesignDataRange2.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue2InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange2, MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue2Tooltip);

                TowerDesignDataRange3.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue3InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange3, MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue3Tooltip);

                TowerDesignDataRange4.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue4InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange4, MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue4Tooltip);

                TowerDesignDataRange5.Text = MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue5InputValue;
                toolTip1.SetToolTip(TowerDesignDataRange5, MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue5Tooltip);

                // build tab pages
                TowerDesignDataCurveDataTabControl.TabPages.Clear();
                foreach (RangedTemperatureDesignViewModel rangedTemperatureDesignViewModel in RangedTemperatureDesignViewModels)
                {
                    AddTabPage(rangedTemperatureDesignViewModel);
                }

                if (IsInternationalSystemOfUnits_SI)
                {
                    TowerDesignDataGroupBox.Text = "Tower Design Specifications (IP)";
                }
                else
                {
                    TowerDesignDataGroupBox.Text = "Tower Design Specifications (SI)";
                }
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        private void AddTabPage(RangedTemperatureDesignViewModel rangedTemperatureDesignViewModel)
        {
            TabPage tabPage = new TabPage();

            RangedTemperatureDesignUserControl towerDesignCurveDataUserControl = new RangedTemperatureDesignUserControl(IsDemo, IsInternationalSystemOfUnits_SI);
            towerDesignCurveDataUserControl.RangedTemperatureDesignViewModel = rangedTemperatureDesignViewModel;
            tabPage.Text = rangedTemperatureDesignViewModel.WaterFlowRateDataValueInputValue;
            tabPage.Controls.Add(towerDesignCurveDataUserControl);

            TowerDesignDataCurveDataTabControl.TabPages.Add(tabPage);
        }

        #region Validating

        private void TowerDesignDataWaterFlowRate_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(TowerDesignDataWaterFlowRate, "");
        }

        private void TowerDesignDataWaterFlowRate_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.WaterFlowRateDataValueUpdateValue(TowerDesignDataWaterFlowRate.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.HotWaterTemperatureDataValueUpdateValue(TowerDesignDataHotWaterTemperature.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.ColdWaterTemperatureDataValueUpdateValue(TowerDesignDataColdWaterTemperature.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.WetBulbTemperatureDataValueUpdateValue(TowerDesignDataWetBulbTemperature.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.DryBulbTemperatureDataValueUpdateValue(TowerDesignDataDryBulbTemperature.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.FanDriverPowerDataValueUpdateValue(TowerDesignDataFanDriverPower.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.BarometricPressureDataValueUpdateValue(TowerDesignDataBarometricPressure.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.LiquidToGasRatioDataValueUpdateValue(TowerDesignDataLiquidToGasRatio.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue1UpdateValue(TowerDesignDataRange1.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue2UpdateValue(TowerDesignDataRange2.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue3UpdateValue(TowerDesignDataRange3.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue4UpdateValue(TowerDesignDataRange4.Text, out errorMessage))
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

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.RangeDataValue5UpdateValue(TowerDesignDataRange5.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                TowerDesignDataRange5.Select(0, TowerDesignDataRange5.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(TowerDesignDataRange5, errorMessage);
            }
        }

        private void WaterFlowRateValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(AddWaterFlowRateValue, "");
        }

        private void WaterFlowRateValue_Validating(object sender, CancelEventArgs e)
        {
            string errorMessage = string.Empty;

            if (!MechanicalDraftPerformanceCurveTowerDesignViewModel.AddWaterFlowRateDataValueUpdateValue(AddWaterFlowRateValue.Text, out errorMessage))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                AddWaterFlowRateValue.Select(0, AddWaterFlowRateValue.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(AddWaterFlowRateValue, errorMessage);
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

            RangedTemperatureDesignViewModel rangedTemperatureDesignViewModel = new RangedTemperatureDesignViewModel(IsDemo, IsInternationalSystemOfUnits_SI);
            RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();
            WaterFlowRateDataValue waterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            if (waterFlowRateDataValue.UpdateValue(AddWaterFlowRateValue.Text, out errorMessage))
            {
                rangedTemperaturesDesignData.WaterFlowRate = waterFlowRateDataValue.Current;

                if (!rangedTemperatureDesignViewModel.LoadData(rangedTemperaturesDesignData, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    RangedTemperatureDesignViewModels.Add(rangedTemperatureDesignViewModel);
                    AddTabPage(rangedTemperatureDesignViewModel);
                    TowerDesignDataCurveDataTabControl.SelectedIndex = TowerDesignDataCurveDataTabControl.TabPages.Count;
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void AddFlowRateButton_Click(object sender, EventArgs e)
        {
            AddWaterFlowRate();
        }
    }
}
