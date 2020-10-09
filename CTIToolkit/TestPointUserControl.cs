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
using Models;

namespace CTIToolkit
{
    public partial class TestPointUserControl : UserControl
    {
        public MechanicalDraftPerformanceCurveViewModel MechanicalDraftPerformanceCurveViewModel { get; set; }


        public TestPointUserControl()
        {
            MechanicalDraftPerformanceCurveViewModel = new MechanicalDraftPerformanceCurveViewModel(false, false);
            InitializeComponent();
        }

        private bool Setup(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                PerformanceCurveTestWaterFlowRate.Text = MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestWaterFlowRate, MechanicalDraftPerformanceCurveViewModel.WaterFlowRateDataValueTooltip);

                PerformanceCurveTestHotWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestHotWaterTemperature, MechanicalDraftPerformanceCurveViewModel.HotWaterTemperatureDataValueTooltip);

                PerformanceCurveTestColdWaterTemperature.Text = MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestColdWaterTemperature, MechanicalDraftPerformanceCurveViewModel.ColdWaterTemperatureDataValueTooltip);

                PerformanceCurveTestWetBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestWetBulbTemperature, MechanicalDraftPerformanceCurveViewModel.WetBulbTemperatureDataValueTooltip);

                PerformanceCurveTestDryBulbTemperature.Text = MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestDryBulbTemperature, MechanicalDraftPerformanceCurveViewModel.DryBulbTemperatureDataValueTooltip);

                PerformanceCurveTestFanDriverPower.Text = MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestFanDriverPower, MechanicalDraftPerformanceCurveViewModel.FanDriverPowerDataValueTooltip);

                PerformanceCurveTestBarometricPressure.Text = MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestBarometricPressure, MechanicalDraftPerformanceCurveViewModel.BarometricPressureDataValueTooltip);

                PerformanceCurveTestLiquidToGasRatio.Text = MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueInputValue;
                toolTip1.SetToolTip(PerformanceCurveTestLiquidToGasRatio, MechanicalDraftPerformanceCurveViewModel.LiquidToGasRatioDataValueTooltip);

            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to load page. Exception: {0}", e.ToString());
                return false;
            }
            return true;
        }

        public bool LoadData(MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            if (mechanicalDraftPerformanceCurveFileData != null)
            {
                if (!MechanicalDraftPerformanceCurveViewModel.LoadData(string.Empty, mechanicalDraftPerformanceCurveFileData, out errorMessage))
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
            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
            }

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }
    }
}
