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
    public class PsychrometricsViewModel
    {
        private PsychrometricsInputData PsychrometricsInputData { get; set; }
        private PsychrometricsOutputData PsychrometricsOutputData { get; set; }
        private PsychrometricsData PsychrometricsData { get; set; }
        private PsychrometricsCalculationLibrary PsychrometricsCalculationLibrary { get; set; }
        private PsychrometricsDataFile PsychrometricsDataFile { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        private bool IsDemo { get; set; }
        public string DataFileName { get; set; }
        public string ErrorMessage { get; set; }

        public PsychrometricsViewModel(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            IsDemo = isDemo;
            ErrorMessage = string.Empty;
            DataFileName = string.Empty;

            PsychrometricsInputData = new PsychrometricsInputData(IsDemo, IsInternationalSystemOfUnits_SI);
            PsychrometricsOutputData = new PsychrometricsOutputData(IsInternationalSystemOfUnits_SI);
            PsychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            PsychrometricsData = new PsychrometricsData();
        }

        public void SwitchUnits(bool isIS)
        {
            IsInternationalSystemOfUnits_SI = isIS;
            PsychrometricsInputData.ConvertValues(IsInternationalSystemOfUnits_SI);
            PsychrometricsOutputData.SwitchUnits(IsInternationalSystemOfUnits_SI);
        }

        public bool CalculatePsychrometrics(out string errorMessage)
        {
            try
            {
                if (!FillAndValidate(out errorMessage))
                {
                    return false;
                }

                if (!PsychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsInputData.CalculationType, PsychrometricsData, out errorMessage))
                {
                    return false;
                }

                PsychrometricsOutputData.FillDataTable(PsychrometricsData);

                return true;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Psychrometrics calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return false;
            }
        }

        public bool FillAndValidate( out string errorMessage)
        {
            return PsychrometricsInputData.FillAndValidate(PsychrometricsData, out errorMessage);
        }

        public DataTable GetDataTable()
        {
            return PsychrometricsOutputData.NameValueUnitsDataTable.DataTable;
        }

        public bool UpdateCalculationType(PsychrometricsCalculationType psychrometricsCalculationType)
        {
            ErrorMessage = string.Empty;

            switch (psychrometricsCalculationType)
            {
                case PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity:
                case PsychrometricsCalculationType.Enthalpy:
                case PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature:
                    PsychrometricsInputData.CalculationType = psychrometricsCalculationType;
                    break;

                default:
                    ErrorMessage = "Invalid psychrometrics calculation type.";
                    return false;
            }

            return true;
        }

        public PsychrometricsCalculationType CalculationType()
        {
            return PsychrometricsInputData.CalculationType;
        }

        public bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;
            ErrorMessage = string.Empty;

            try
            {
                PsychrometricsDataFile = JsonConvert.DeserializeObject<PsychrometricsDataFile>(File.ReadAllText(DataFileName));
            }
            catch (Exception e)
            {
                stringBuilder.AppendFormat("Failure to read file: {0}. Exception: {1}\n", Path.GetFileName(DataFileName), e.ToString());
                returnValue = false;
            }

            if (PsychrometricsDataFile != null)
            {
                if (PsychrometricsDataFile.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    //ToolkitMain,UpdateU
                    SwitchUnits(PsychrometricsDataFile.IsInternationalSystemOfUnits_SI);
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
            PsychrometricsDataFile = new PsychrometricsDataFile(IsInternationalSystemOfUnits_SI);

            if (PsychrometricsDataFile != null)
            {
                PsychrometricsInputData.SetDefaults(PsychrometricsDataFile);

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

            PsychrometricsDataFile = new PsychrometricsDataFile(IsInternationalSystemOfUnits_SI);

            if (PsychrometricsDataFile != null)
            {
                if (FillFileData())
                {
                    try
                    {
                        File.WriteAllText(DataFileName, JsonConvert.SerializeObject(PsychrometricsDataFile, Formatting.Indented));
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

        public bool LoadData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (PsychrometricsDataFile != null)
            {
                if(!PsychrometricsInputData.LoadData(PsychrometricsDataFile))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(PsychrometricsInputData.ErrorMessage);
                }
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            return returnValue;
        }

        public bool FillFileData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (!PsychrometricsInputData.FillFileData(PsychrometricsDataFile))
            {
                returnValue = false;
                stringBuilder.AppendLine(PsychrometricsInputData.ErrorMessage);
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        #region DataAccess

        public DataValue EnthalpyDataValue
        {
            get
            {
                return PsychrometricsInputData.EnthalpyDataValue;
            }
        }

        public DataValue ElevationDataValue
        {
            get
            {
                return PsychrometricsInputData.ElevationDataValue;
            }
        }

        public DataValue BarometricPressureDataValue
        {
            get
            {
                return PsychrometricsInputData.BarometricPressureDataValue;
            }
        }

        public DataValue RelativeHumidityDataValue
        {
            get
            {
                return PsychrometricsInputData.RelativeHumidityDataValue;
            }
        }

        public DataValue WetBulbTemperatureDataValue
        {
            get
            {
                return PsychrometricsInputData.WetBulbTemperatureDataValue;
            }
        }

        public DataValue DryBulbTemperatureDataValue
        {
            get
            {
                return PsychrometricsInputData.DryBulbTemperatureDataValue;
            }
        }

        public DataValue BarometericPressureDataValue
        {
            get
            {
                return PsychrometricsInputData.BarometricPressureDataValue;
            }
        }

        public void UpdateIsElevationValue(bool value)
        {
            PsychrometricsInputData.IsElevation = value;
        }

        public bool IsElevation()
        {
            return PsychrometricsInputData.IsElevation;
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(DataFileName);
            }
        }
        #endregion DataAccess
    }
}
