// Copyright Cooling Technology Institute 2019-2020

using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveInputData
    {
        private MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }

        public string MechanicalDraftPerformanceCurveDataFile { get; set; }

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveData Data
        {
            get
            {
                return MechanicalDraftPerformanceCurveData;
            }
        }

        public MechanicalDraftPerformanceCurveInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;
            
            MechanicalDraftPerformanceCurveData = new MechanicalDraftPerformanceCurveData(IsInternationalSystemOfUnits_SI);

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            
            MechanicalDraftPerformanceCurveDataFile = GetFilename();
        }

        public string GetFilename()
        {
            string mechanicalDraftPerformanceCurveDataFile = string.Empty;
            int fileCount = 0;
            do
            {
                if (fileCount == 0)
                {
                    mechanicalDraftPerformanceCurveDataFile = Path.Combine(Application.UserAppDataPath, "MechanicalDraftPerformanceData.json");
                }
                else
                {
                    mechanicalDraftPerformanceCurveDataFile = Path.Combine(Application.UserAppDataPath, string.Format("MechanicalDraftPerformanceData({0}).json", fileCount));
                }
                fileCount++;
            } while (File.Exists(mechanicalDraftPerformanceCurveDataFile));

            return mechanicalDraftPerformanceCurveDataFile;
        }

        public bool OpenDataFile(string fileName, out string errorMessage, MechanicalDraftPerformanceCurveTowerDesignInputData mechanicalDraftPerformanceCurveTowerDesignInputData)
        {
            try
            {
                MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData; 

                try
                {
                    mechanicalDraftPerformanceCurveData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveData>(File.ReadAllText(fileName));
                }
                catch(Exception e)
                {
                    errorMessage = string.Format("Failure to read file: {0}. Exception: {1}", Path.GetFileName(fileName), e.ToString());
                    return false;
                }

                MechanicalDraftPerformanceCurveDataFile = fileName;
                MechanicalDraftPerformanceCurveData = mechanicalDraftPerformanceCurveData;

                bool returnValue = LoadData(fileName, MechanicalDraftPerformanceCurveData, out errorMessage);
                if(mechanicalDraftPerformanceCurveTowerDesignInputData != null)
                {
                    returnValue = mechanicalDraftPerformanceCurveTowerDesignInputData.LoadData(MechanicalDraftPerformanceCurveData.DesignData, out errorMessage);
                }
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Failure to Mechanica lDraft Performance Curve Data from file: {0}. Exception: {1}", Path.GetFileName(fileName), e.ToString());
                return false;
            }
            return true;
        }

        public bool SaveDataFile(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                File.WriteAllText(MechanicalDraftPerformanceCurveDataFile, JsonConvert.SerializeObject(MechanicalDraftPerformanceCurveData));
            }
            catch(Exception e)
            {
                errorMessage = string.Format("Failed to write Mechanical Draft Performance Curve Data to file {0}. Exception {1}", Path.GetFileName(MechanicalDraftPerformanceCurveDataFile), e.ToString());
                return false;
            }
            return true;
        }

        public bool SaveAsDataFile(string fileName, out string errorMessage)
        {
            try
            {
                MechanicalDraftPerformanceCurveDataFile = fileName;
                return SaveDataFile(out errorMessage);
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failed to write Mechanical Draft Performance Curve Data to file {0}. Exception {1}", Path.GetFileName(MechanicalDraftPerformanceCurveDataFile), e.ToString());
                return false;
            }
        }

        public bool LoadData(string fileName, MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                MechanicalDraftPerformanceCurveDataFile = fileName;

                if (!WaterFlowRateDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.WaterFlowRate, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.HotWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.ColdWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.WetBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.DryBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!FanDriverPowerDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.FanDriverPower, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.BarometricPressure, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.TestData.LiquidToGasRatio, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                errorMessage = stringBuilder.ToString();
            }
            catch(Exception exception)
            {
                errorMessage = string.Format("Failure to Mechanical Draft Performance Curve Test Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true); 
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                //MechanicalDraftPerformanceCurveDesignInputData.ConvertValue(IsInternationalSystemOfUnits_SI, true);
                isChanged = true;
            }
            return isChanged;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }

        public bool FillAndValidate(ref MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                mechanicalDraftPerformanceCurveData.TestData.WaterFlowRate = WaterFlowRateDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.FanDriverPower = FanDriverPowerDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.BarometricPressure = BarometricPressureDataValue.Current;
                mechanicalDraftPerformanceCurveData.TestData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Test Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}