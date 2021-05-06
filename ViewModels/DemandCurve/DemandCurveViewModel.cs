// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace ViewModels
{
    public class DemandCurveViewModel
    {
        private DemandCurveFileData DemandCurveFileData { get; set; }
        private DemandCurveInputData DemandCurveInputData { get; set; }
        private DemandCurveCalculationData DemandCurveCalculationData { get; set; }
        public DemandCurveCalculationLibrary DemandCurveCalculationLibrary { get; set; }
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }

        //Units Units { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public List<Approach> Approaches
        {
            get
            {
                if(DemandCurveCalculationData == null)
                {
                    return null;
                }
                else
                {
                    return DemandCurveCalculationData.Approaches;
                }
            }
            private set
            {
                
            }
        }

        public bool IsElevation 
        { 
            get 
            { 
                return DemandCurveInputData.IsElevation; 
            } 
            set 
            { 
                DemandCurveInputData.IsElevation = value; 
            } 
        }

        public bool IsCoef
        {
            get
            {
                return DemandCurveCalculationData.IsCoef;
            }
            set
            {
                DemandCurveCalculationData.IsCoef = value;
            }
        }

        public bool IsLiquidToGasRatio
        {
            get
            {
                return DemandCurveCalculationData.IsLiquidToGasRatio;
            }
            set
            {
                DemandCurveCalculationData.IsLiquidToGasRatio = value;
            }
        }

        public bool IsKaV_L
        {
            get
            {
                return DemandCurveCalculationData.IsKaV_L;
            }
            set
            {
                DemandCurveCalculationData.IsKaV_L = value;
            }
        }

        public bool IsUserApproach
        {
            get
            {
                return DemandCurveCalculationData.IsUserApproach;
            }
            set
            {
                DemandCurveCalculationData.IsUserApproach = value;
            }
        }

        public bool IsApproach
        {
            get
            {
                return DemandCurveInputData.IsApproach;
            }
            set
            {
                DemandCurveInputData.IsApproach = value;
            }
        }
        public string ErrorMessage { get; set; }
        public string DataFileName { get; set; }

        public DemandCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            IsDemo = isDemo;
            BuildFilename();

            DemandCurveInputData = new DemandCurveInputData(isDemo, isInternationalSystemOfUnits_SI);
            DemandCurveCalculationLibrary = new DemandCurveCalculationLibrary(isInternationalSystemOfUnits_SI);
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            DemandCurveCalculationData = new DemandCurveCalculationData(isInternationalSystemOfUnits_SI);
            DemandCurveFileData = new DemandCurveFileData(isInternationalSystemOfUnits_SI);
            DemandCurveInputData.SetDefaults(DemandCurveFileData);
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
                DemandCurveInputData.SetDefaults(DemandCurveFileData);

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

        private bool SaveDataToFile()
        {
            bool returnValue = true;

            if (DemandCurveFileData != null)
            {
                if (FillFileData())
                {
                    try
                    {
                        File.WriteAllText(DataFileName, JsonConvert.SerializeObject(DemandCurveFileData, Formatting.Indented));
                    }
                    catch (Exception e)
                    {
                        ErrorMessage = string.Format("Error saving data to file. Exception: {0}", e.Message);
                    }
                }
            }
            else
            {
                ErrorMessage = "Unable to save data to file.";
                returnValue = false;
            }
                return returnValue;
        }

        public bool SaveDataFile()
        {
            return SaveDataToFile();
        }

        public bool SaveAsDataFile(string fileName)
        {
            DataFileName = fileName;

            return SaveDataToFile();
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
            DemandCurveInputData.ConvertValues(IsInternationalSystemOfUnits_SI, IsElevation, IsApproach);
            DemandCurveCalculationData.ConvertValues(IsInternationalSystemOfUnits_SI);
        }

        public bool LoadData()
        {
            bool returnValue = true;

            if (DemandCurveFileData != null)
            {
                if (!DemandCurveInputData.LoadData(DemandCurveFileData))
                {
                    ErrorMessage = DemandCurveInputData.ErrorMessage;
                    returnValue = false;
                }
            }
            else
            {
                returnValue = false;
            }

            return returnValue;
        }

        public void FillSeries(Series series)
        {
            if(Approaches != null && Approaches.Count > 0)
            {
                foreach (Approach approach in Approaches)
                {
                    if (approach.Name == series.Name)
                    {
                        foreach (Point point in approach.Points)
                        {
                            series.Points.AddXY(point.X, point.Y);
                        }
                        break;
                    }
                }
            }
        }

        public double CalculateExactApproach(double lg, double kval)
        {
            try
            {
                return DemandCurveCalculationLibrary.CalculateExactApproach(DemandCurveCalculationData, lg, kval);
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Error in Demand Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return 0.0;
            }
        }

        public bool Calculate()
        {
            try
            {
                DemandCurveCalculationData.Initialize();

                if (!FillAndValidate(DemandCurveCalculationData.DemandCurveData))
                {
                    return false;
                }

                if (!DemandCurveCalculationLibrary.Calculate(DemandCurveCalculationData))
                {
                    ErrorMessage = DemandCurveCalculationLibrary.ErrorMessage;
                    return false;
                }

                // output data in DemandCurveOutputData
                NameValueUnitsDataTable.DataTable.Clear();

                NameValueUnitsDataTable.AddRow("Approach", (DemandCurveCalculationData.DemandCurveData.TargetApproach > 0.001) ?
                    DemandCurveCalculationData.DemandCurveData.TargetApproach.ToString("F3") : string.Empty, 
                    (DemandCurveCalculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.RangeK : ConstantUnits.TemperatureFahrenheit);
                NameValueUnitsDataTable.AddRow("KaV/L", 
                    (DemandCurveCalculationData.DemandCurveData.KaV_L > 0.001) ? DemandCurveCalculationData.DemandCurveData.KaV_L.ToString("F5") : string.Empty, 
                    string.Empty);

                return true;
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Error in Demand Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return false;
            }
        }

        public bool FillAndValidate(DemandCurveData demandCurveData)
        {
            return DemandCurveInputData.FillAndValidate(demandCurveData);
        }

        public bool FillFileData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (!DemandCurveInputData.FillFileData(DemandCurveFileData))
            {
                returnValue = false;
                stringBuilder.AppendLine(DemandCurveInputData.ErrorMessage);
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public DataTable GetDataTable()
        {
            if(DemandCurveCalculationData == null)
            {
                return null;
            }
            else
            {
                return DemandCurveCalculationData.DataTable;
            }
        }

        public DataTable GetOutputDataTable()
        {
            if (DemandCurveCalculationData == null)
            {
                return null;
            }
            else
            {
                return NameValueUnitsDataTable.DataTable;
            }
        }

        public void ConvertValues(bool isIS)
        {
            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                DemandCurveInputData.ConvertValues(IsInternationalSystemOfUnits_SI, IsElevation, IsApproach);
                DemandCurveCalculationData.ConvertValues(IsInternationalSystemOfUnits_SI);
            }
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

        public string UserApproachDataValueInputMessage
        {
            get
            {
                return DemandCurveInputData.UserApproachDataValue.InputMessage;
            }
        }

        public string UserApproachDataValueInputValue
        {
            get
            {
                return DemandCurveInputData.UserApproachDataValue.InputValue;
            }
        }

        public bool UserApproachDataValueUpdateValue(string value, out string errorMessage)
        {
            return DemandCurveInputData.UserApproachDataValue.UpdateValue(value, out errorMessage);
        }

        public string UserApproachDataValueTooltip
        {
            get
            {
                return DemandCurveInputData.UserApproachDataValue.ToolTip;
            }
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(DataFileName);
            }
        }
        #endregion DataValues
    }
}
