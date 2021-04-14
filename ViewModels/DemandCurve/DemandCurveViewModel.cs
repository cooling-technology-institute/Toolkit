// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class DemandCurveViewModel
    {
        private DemandCurveFileData DemandCurveFileData { get; set; }
        private DemandCurveInputData DemandCurveInputData { get; set; }
        private DemandCurveOutputData DemandCurveOutputData { get; set; }
        private DemandCurveCalculationData DemandCurveCalculationData { get; set; }
        public DemandCurveCalculationLibrary DemandCurveCalculationLibrary { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public bool IsElevation { get; set; }
        public string ErrorMessage { get; set; }
        public string DataFileName { get; set; }

        public DemandCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            DemandCurveInputData = new DemandCurveInputData(isDemo, isInternationalSystemOfUnits_IS_);
            DemandCurveOutputData = new DemandCurveOutputData(isInternationalSystemOfUnits_IS_);
            DemandCurveCalculationLibrary = new DemandCurveCalculationLibrary();
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            IsDemo = isDemo;
        }

        public void BuildFilename()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
            int i = 1;

            do
            {
                DataFileName = Path.Combine(path, string.Format("DemandCurve{0}.dc", i++));
                if (File.Exists(DataFileName))
                {
                    DataFileName = string.Empty;
                }

            } while (string.IsNullOrEmpty(DataFileName));
        }

        public bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;
            ErrorMessage = string.Empty;

            try
            {
                DemandCurveFileData = JsonConvert.DeserializeObject<DemandCurveFileData>(File.ReadAllText(DataFileName));
            }
            catch (Exception e)
            {
                stringBuilder.AppendFormat("Failure to read file: {0}. Exception: {1}\n", Path.GetFileName(DataFileName), e.ToString());
                returnValue = false;
            }

            if (DemandCurveFileData != null)
            {
                if (DemandCurveFileData.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    //ToolkitMain,UpdateU
                    SwitchUnits(DemandCurveFileData.IsInternationalSystemOfUnits_SI);
                }

                if (!LoadData())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }

            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool OpenNewDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            DataFileName = fileName;
            DemandCurveFileData = new DemandCurveFileData(IsInternationalSystemOfUnits_SI);

            if (DemandCurveFileData != null)
            {
                if (!LoadData())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to create new file.");
                returnValue = false;
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool SwitchUnits(bool isIS)
        {
            bool isChange = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                ConvertValues();
            }
            return isChange;
        }

        public void ConvertValues()
        {
            WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
            Range1Value.ConvertValue(IsInternationalSystemOfUnits_SI);
            Range2Value.ConvertValue(IsInternationalSystemOfUnits_SI);
            Range3Value.ConvertValue(IsInternationalSystemOfUnits_SI);
            Range4Value.ConvertValue(IsInternationalSystemOfUnits_SI);
            Range5Value.ConvertValue(IsInternationalSystemOfUnits_SI);
        }

        public bool CalculateDemandCurve(bool isElevation, bool showUserApproach, out string errorMessage)
        {
            try
            {
                DemandCurveCalculationData = new DemandCurveCalculationData(IsInternationalSystemOfUnits_SI);

                if (!FillAndValidate(isElevation, showUserApproach, out errorMessage))
                {
                    return false;
                }

                if (!DemandCurveCalculationLibrary.DemandCurveCalculation(isElevation, showUserApproach, DemandCurveCalculationData, out errorMessage))
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
            return DemandCurveInputData.FillAndValidate(DemandCurveData, out errorMessage);
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


        public bool ConvertValues(bool isIS, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                return DemandCurveInputData.ConvertValues(IsInternationalSystemOfUnits_SI, IsElevation, out errorMessage);
            }
            return false;
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
    }
}
