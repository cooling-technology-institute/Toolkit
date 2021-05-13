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
    public class MerkelViewModel
    {
        private MerkelInputData MerkelInputData { get; set; }
        private MerkelOutputData MerkelOutputData { get; set; }
        private MerkelCalculationData MerkelData { get; set; }
        private MerkelDataFile MerkelDataFile { get; set; }
        private MerkelCalculationLibrary MerkelCalculationLibrary { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public string DataFileName { get; set; }
        public string ErrorMessage { get; set; }


        public MerkelViewModel(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            IsDemo = isDemo;
            ErrorMessage = string.Empty;
            DataFileName = string.Empty;

            MerkelInputData = new MerkelInputData(IsDemo, IsInternationalSystemOfUnits_SI);
            MerkelOutputData = new MerkelOutputData(IsInternationalSystemOfUnits_SI);
            MerkelDataFile = new MerkelDataFile(IsInternationalSystemOfUnits_SI);
            MerkelCalculationLibrary = new MerkelCalculationLibrary();
        }

        public void SwitchUnits(bool isIS)
        {
            IsInternationalSystemOfUnits_SI = isIS;
            MerkelInputData.ConvertValues(IsInternationalSystemOfUnits_SI);
            MerkelOutputData.SwitchUnits(IsInternationalSystemOfUnits_SI);
        }


        public bool CalculateMerkel()
        {
            ErrorMessage = string.Empty;

            try
            {
                MerkelData = new MerkelCalculationData(IsInternationalSystemOfUnits_SI);

                FillMerkelData();

                if(!MerkelCalculationLibrary.MerkelCalculation(MerkelData))
                {
                    ErrorMessage = MerkelCalculationLibrary.ErrorMessage;
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
                ErrorMessage = string.Format("Error in Merkel calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return false;
            }
        }

        public void FillMerkelData()
        {
            MerkelInputData.FillMerkelData(MerkelData);
        }

        public DataTable GetDataTable()
        {
            return MerkelOutputData.NameValueUnitsDataTable.DataTable;
        }

        public void ConvertValues(bool isIS)
        {
            IsInternationalSystemOfUnits_SI = isIS;
            MerkelInputData.ConvertValues(IsInternationalSystemOfUnits_SI);
        }

        public bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;
            ErrorMessage = string.Empty;

            try
            {
                MerkelDataFile = JsonConvert.DeserializeObject<MerkelDataFile>(File.ReadAllText(DataFileName));
            }
            catch (Exception e)
            {
                stringBuilder.AppendFormat("Failure to read file: {0}. Exception: {1}\n", Path.GetFileName(DataFileName), e.ToString());
                returnValue = false;
            }

            if (MerkelDataFile != null)
            {
                if (MerkelDataFile.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    //ToolkitMain,UpdateU
                    SwitchUnits(MerkelDataFile.IsInternationalSystemOfUnits_SI);
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
            MerkelDataFile = new MerkelDataFile(IsInternationalSystemOfUnits_SI);

            if (MerkelDataFile != null)
            {
                MerkelInputData.SetDefaults(MerkelDataFile);

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

            MerkelDataFile = new MerkelDataFile(IsInternationalSystemOfUnits_SI);

            if (MerkelDataFile != null)
            {
                if (FillFileData())
                {
                    try
                    {
                        File.WriteAllText(DataFileName, JsonConvert.SerializeObject(MerkelDataFile, Formatting.Indented));
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

            if (MerkelDataFile != null)
            {
                if (!MerkelInputData.LoadData(MerkelDataFile))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(MerkelInputData.ErrorMessage);
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

            if (!MerkelInputData.FillFileData(MerkelDataFile))
            {
                returnValue = false;
                stringBuilder.AppendLine(MerkelInputData.ErrorMessage);
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        #region DataAccess

        public DataValue HotWaterTemperatureDataValue
        {
            get
            {
                return MerkelInputData.HotWaterTemperatureDataValue;
            }
        }

        public DataValue ColdWaterTemperatureDataValue
        {
            get
            {
                return MerkelInputData.ColdWaterTemperatureDataValue;
            }
        }

        public DataValue WetBulbTemperatureDataValue
        {
            get
            {
                return MerkelInputData.WetBulbTemperatureDataValue;
            }
        }

        public DataValue LiquidToGasRatioDataValue
        {
            get
            {
                return MerkelInputData.LiquidToGasRatioDataValue;
            }
        }

        public DataValue ElevationDataValue
        {
            get
            {
                return MerkelInputData.ElevationDataValue;
            }
        }

        public DataValue BarometricPressureDataValue
        {
            get
            {
                return MerkelInputData.BarometricPressureDataValue;
            }
        }

        public bool IsElevation
        {
            get
            {
                return MerkelInputData.IsElevation;
            }
            set
            {
                MerkelInputData.IsElevation = value;
            }
        }

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(DataFileName);
            }
        }

        public void ConvertElevationToBarometricPressure()
        {
            if(IsInternationalSystemOfUnits_SI)
            {
                MerkelInputData.BarometricPressureDataValue.UpdateCurrentValue(UnitConverter.ConvertElevationInMetersToKilopascal(MerkelInputData.ElevationDataValue.Current));
            }
            else
            {
                MerkelInputData.BarometricPressureDataValue.UpdateCurrentValue(UnitConverter.CalculatePsiToInchesOfMercury(UnitConverter.ConvertElevationInFeetToBarometricPressure(MerkelInputData.ElevationDataValue.Current)));
            }
        }

        public void ConvertBarometricPressureToElevation()
        {
            if (IsInternationalSystemOfUnits_SI)
            {
                MerkelInputData.ElevationDataValue.UpdateCurrentValue(UnitConverter.ConvertKilopascalToElevationInMeters(MerkelInputData.BarometricPressureDataValue.Current));
            }
            else
            {
                MerkelInputData.ElevationDataValue.UpdateCurrentValue(UnitConverter.ConvertBarometricPressureToElevationInFeet(UnitConverter.CalculateInchesOfMercuryToPsi(MerkelInputData.BarometricPressureDataValue.Current)));
            }
        }

        #endregion DataAccess
    }
}
