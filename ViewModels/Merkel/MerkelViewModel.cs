// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;
using Models;
using System;
using System.Data;

namespace ViewModels
{
    public class MerkelViewModel
    {
        private MerkelInputData MerkelInputData { get; set; }
        private MerkelOutputData MerkelOutputData { get; set; }
        private MerkelData MerkelData { get; set; }
        private MerkelCalculationLibrary MerkelCalculationLibrary { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS { get; set; }
        public bool IsElevation { get; set; }

        public string HotWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MerkelInputData.HotWaterTemperatureDataValue.InputMessage;
            }
        }

        public string HotWaterTemperatureDataValueInputValue
        {
            get
            {
                return MerkelInputData.HotWaterTemperatureDataValue.InputValue;
            }
        }

        public bool HotWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MerkelInputData.HotWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string HotWaterTemperatureDataValueTooltip
        {
            get
            {
                return MerkelInputData.HotWaterTemperatureDataValue.ToolTip;
            }
        }

        public string ColdWaterTemperatureDataValueInputMessage
        {
            get
            {
                return MerkelInputData.ColdWaterTemperatureDataValue.InputMessage;
            }
        }

        public string ColdWaterTemperatureDataValueInputValue
        {
            get
            {
                return MerkelInputData.ColdWaterTemperatureDataValue.InputValue;
            }
        }

        public string ColdWaterTemperatureDataValueTooltip
        {
            get
            {
                return MerkelInputData.ColdWaterTemperatureDataValue.ToolTip;
            }
        }

        public bool ColdWaterTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MerkelInputData.ColdWaterTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MerkelInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return MerkelInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return MerkelInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MerkelInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string LiquidtoGasRatioDataValueInputMessage
        {
            get
            {
                return MerkelInputData.LiquidToGasRatioDataValue .InputMessage;
            }
        }

        public string LiquidtoGasRatioDataValueInputValue
        {
            get
            {
                return MerkelInputData.LiquidToGasRatioDataValue .InputValue;
            }
        }

        public string LiquidtoGasRatioDataValueTooltip
        {
            get
            {
                return MerkelInputData.LiquidToGasRatioDataValue .ToolTip;
            }
        }

        public bool LiquidtoGasRatioDataValueUpdateValue(string value, out string errorMessage)
        {
            return MerkelInputData.LiquidToGasRatioDataValue .UpdateValue(value, out errorMessage);
        }

        public string ElevationDataValueInputMessage
        {
            get
            {
                return MerkelInputData.ElevationDataValue.InputMessage;
            }
        }

        public string ElevationDataValueInputValue
        {
            get
            {
                return MerkelInputData.ElevationDataValue.InputValue;
            }
        }

        public string ElevationDataValueTooltip
        {
            get
            {
                return MerkelInputData.ElevationDataValue.ToolTip;
            }
        }

        public bool ElevationDataValueUpdateValue(string value, out string errorMessage)
        {
            return MerkelInputData.ElevationDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return MerkelInputData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return MerkelInputData.BarometricPressureDataValue.InputValue;
            }
        }

        public string BarometricPressureDataValueTooltip
        {
            get
            {
                return MerkelInputData.BarometricPressureDataValue.ToolTip;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MerkelInputData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public MerkelViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            MerkelInputData = new MerkelInputData(isDemo, isInternationalSystemOfUnits_IS_);
            MerkelOutputData = new MerkelOutputData(isInternationalSystemOfUnits_IS_);
            IsInternationalSystemOfUnits_IS = isInternationalSystemOfUnits_IS_;
            MerkelCalculationLibrary = new MerkelCalculationLibrary();
        }

        public bool CalculateMerkel(bool isElevation, out string errorMessage)
        {
            try
            {
                MerkelData = new MerkelData();

                if (!FillMerkelData(isElevation, out errorMessage))
                {
                    return false;
                }

                if(!MerkelCalculationLibrary.MerkelCalculation(MerkelData, out errorMessage))
                {
                    return false;
                }

                // output data in MerkelOutputData
                MerkelOutputData.NameValueUnitsDataTable.DataTable.Clear();

                //data.BarometricPressure = truncit(data.BarometricPressure, 5);
                MerkelOutputData.NameValueUnitsDataTable.AddRow("KaV/L", MerkelData.KaV_L.ToString("F5"), string.Empty);

                return true;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Merkel calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return false;
            }
        }

        public bool FillMerkelData(bool isElevation, out string message)
        {
            return MerkelInputData.FillMerkelData(MerkelData, isElevation, out message);
        }

        public DataTable GetDataTable()
        {
            return MerkelOutputData.NameValueUnitsDataTable.DataTable;
        }

        public bool ConvertValues(bool isIS, bool isElevation)
        {
            if ((IsInternationalSystemOfUnits_IS != isIS) || (IsElevation != isElevation))
            { 
                IsInternationalSystemOfUnits_IS = isIS;
                IsElevation = isElevation;
                return MerkelInputData.ConvertValues(IsInternationalSystemOfUnits_IS, IsElevation);
            }
            return false;
        }
    }
}
