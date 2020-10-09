// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveViewModel
    {
        public MechanicalDraftPerformanceCurveInputData MechanicalDraftPerformanceCurveInputData { get; set; }
        public MechanicalDraftPerformanceCurveOutputData MechanicalDraftPerformanceCurveOutputData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            MechanicalDraftPerformanceCurveInputData = new MechanicalDraftPerformanceCurveInputData(IsDemo, IsInternationalSystemOfUnits_SI);
            MechanicalDraftPerformanceCurveOutputData = new MechanicalDraftPerformanceCurveOutputData(IsInternationalSystemOfUnits_SI);
        }

        #region DataValues

        public string WaterFlowRateDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.InputMessage;
            }
        }

        public string WaterFlowRateDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.InputValue;
            }
        }

        public bool WaterFlowRateDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.UpdateValue(value, out errorMessage);
        }

        public string WaterFlowRateDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WaterFlowRateDataValue.ToolTip;
            }
        }


        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public string DryBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string FanDriverPowerDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.InputMessage;
            }
        }

        public string FanDriverPowerDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.InputValue;
            }
        }

        public string FanDriverPowerDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.ToolTip;
            }
        }

        public bool FanDriverPowerDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.FanDriverPowerDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(MechanicalDraftPerformanceCurveInputData.MechanicalDraftPerformanceCurveDataFile);
            }
        }
        
        #endregion DataValue

        public bool LoadData(string fileName, MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.LoadData(fileName, mechanicalDraftPerformanceCurveFileData, out errorMessage);
        }

        public bool SaveDataFile(out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.SaveDataFile(out errorMessage);
        }

        public bool SaveAsDataFile(string fileName, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveInputData.SaveAsDataFile(fileName, out errorMessage);
        }

        public bool FillAndValidate(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            return returnValue;
        }

        public bool CalculatePerformanceCurve(MechanicalDraftPerformanceCurveTowerDesignViewModel mechanicalDraftPerformanceCurveTowerDesignViewModel, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            try
            {
                MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

                // validate test data
                if (!mechanicalDraftPerformanceCurveTowerDesignViewModel.FillAndValidate(mechanicalDraftPerformanceCurveFileData.DesignData, out errorMessage))
                {

                }

                if (!MechanicalDraftPerformanceCurveInputData.FillAndValidate(mechanicalDraftPerformanceCurveFileData, out errorMessage))
                {

                }


                MechanicalDraftPerformanceCurveCalculationLibrary mechanicalDraftPerformanceCurveCalculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

                mechanicalDraftPerformanceCurveCalculationLibrary.MechanicalDraftPerformanceCurveCalculation(mechanicalDraftPerformanceCurveFileData, MechanicalDraftPerformanceCurveOutputData.MechanicalDraftPerformanceCurveOutput);
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Performance Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
            }
            return returnValue;
        }

        public DataTable GetDataTable()
        {
            return MechanicalDraftPerformanceCurveOutputData.NameValueUnitsDataTable.DataTable;
        }
    }
}
