// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;
using System;
using System.Data;

namespace ViewModels
{
    public class DemandCurveViewModel
    {
        private DemandCurveInputData DemandCurveInputData { get; set; }
        private DemandCurveOutputData DemandCurveOutputData { get; set; }
        private DemandCurveData DemandCurveData { get; set; }
        public DemandCurveCalculationLibrary DemandCurveCalculationLibrary { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }

        public DemandCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            DemandCurveInputData = new DemandCurveInputData(isDemo, isInternationalSystemOfUnits_IS_);
            DemandCurveOutputData = new DemandCurveOutputData(isInternationalSystemOfUnits_IS_);
            DemandCurveData = new DemandCurveData(isInternationalSystemOfUnits_IS_);
            DemandCurveCalculationLibrary = new DemandCurveCalculationLibrary();
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            IsDemo = isDemo;
        }

        #region DataValues
        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public string RangeDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.RangeDataValue.InputMessage;
            }
        }

        public string RangeDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.RangeDataValue.InputValue;
            }
        }

        public bool RangeDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.RangeDataValue.UpdateValue(value, out errorMessage);
        }

        public string RangeDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.RangeDataValue.ToolTip;
            }
        }

        public string ElevationDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.ElevationDataValue.InputMessage;
            }
        }

        public string ElevationDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.ElevationDataValue.InputValue;
            }
        }

        public bool ElevationDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.ElevationDataValue.UpdateValue(value, out errorMessage);
        }

        public string ElevationDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.ElevationDataValue.ToolTip;
            }
        }

        public string LiquidToGasRatioDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.LiquidToGasRatioDataValue.InputMessage;
            }
        }

        public string LiquidToGasRatioDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.LiquidToGasRatioDataValue.InputValue;
            }
        }

        public bool LiquidToGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.LiquidToGasRatioDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidToGasRatioDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.LiquidToGasRatioDataValue.ToolTip;
            }
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.BarometricPressureDataValue.InputValue;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.BarometricPressureDataValue.ToolTip;
            }
        }

        public string C1DataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.C1DataValue.InputMessage;
            }
        }

        public string C1DataValueInputValue
        {
            get
            {
                return DemandCurveInputData.C1DataValue.InputValue;
            }
        }

        public bool C1DataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.C1DataValue.UpdateValue(value, out errorMessage);
        }

        public string C1DataValueTooltip
        {
            get
            {
                return DemandCurveInputData.C1DataValue.ToolTip;
            }
        }

        public string SlopeDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.SlopeDataValue.InputMessage;
            }
        }

        public string SlopeDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.SlopeDataValue.InputValue;
            }
        }

        public bool SlopeDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.SlopeDataValue.UpdateValue(value, out errorMessage);
        }

        public string SlopeDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.SlopeDataValue.ToolTip;
            }
        }

        public string MinimumDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.MinimumDataValue.InputMessage;
            }
        }

        public string MinimumDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.MinimumDataValue.InputValue;
            }
        }

        public bool MinimumDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.MinimumDataValue.UpdateValue(value, out errorMessage);
        }

        public string MinimumDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.MinimumDataValue.ToolTip;
            }
        }

        public string MaximumDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.MaximumDataValue.InputMessage;
            }
        }

        public string MaximumDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.MaximumDataValue.InputValue;
            }
        }

        public bool MaximumDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.MaximumDataValue.UpdateValue(value, out errorMessage);
        }

        public string MaximumDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.MaximumDataValue.ToolTip;
            }
        }
        #endregion DataValues


        public bool CalculateDemandCurve(bool isElevation, bool showUserApproach, out string errorMessage)
        {
            try
            {
                DemandCurveData = new DemandCurveData(IsInternationalSystemOfUnits_SI);

                if (!FillAndValidate(isElevation, showUserApproach, out errorMessage))
                {
                    return false;
                }

                if (!DemandCurveCalculationLibrary.DemandCurveCalculation(isElevation, showUserApproach, DemandCurveData, out errorMessage))
                {
                    return false;
                }

                // output data in DemandCurveOutputData
                DemandCurveOutputData.NameValueUnitsDataTable.DataTable.Clear();

                //data.BarometricPressure = truncit(data.BarometricPressure, 5);
                DemandCurveOutputData.NameValueUnitsDataTable.AddRow("KaV/L", DemandCurveData.KaV_L.ToString("F5"), string.Empty);

                return true;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Demand Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return false;
            }
        }

        public bool FillAndValidate(bool isElevation, bool showUserApproach, out string errorMessage)
        {
            return DemandCurveInputData.FillAndValidate(DemandCurveData, isElevation, showUserApproach, out errorMessage);
        }

        public DataTable GetDataTable()
        {
            return DemandCurveData.DataTable;
        }

        public bool ConvertValues(bool isIS, bool isElevation, out string errorMessage)
        {
            errorMessage = string.Empty;

            if ((IsInternationalSystemOfUnits_SI != isIS) || (IsElevation != isElevation))
            {
                IsInternationalSystemOfUnits_SI = isIS;
                IsElevation = isElevation;
                return DemandCurveInputData.ConvertValues(IsInternationalSystemOfUnits_SI, IsElevation, out errorMessage);
            }
            return false;
        }
    }
}
