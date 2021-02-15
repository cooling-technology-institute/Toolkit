// Copyright Cooling Technology Institute 2019-2020

using Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveInputData
    {
        private MechanicalDraftPerformanceCurveFileData MechanicalDraftPerformanceCurveFileData { get; set; }

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

        public MechanicalDraftPerformanceCurveFileData Data
        {
            get
            {
                return MechanicalDraftPerformanceCurveFileData;
            }
        }

        public MechanicalDraftPerformanceCurveInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

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
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "CTI Toolkit");
            int fileCount = 0;

            do
            {
                if (fileCount == 0)
                {
                    mechanicalDraftPerformanceCurveDataFile = Path.Combine(path, "MechanicalDraftPerformanceData.json");
                }
                else
                {
                    mechanicalDraftPerformanceCurveDataFile = Path.Combine(path, string.Format("MechanicalDraftPerformanceData({0}).json", fileCount));
                }

                fileCount++;

            } while (File.Exists(mechanicalDraftPerformanceCurveDataFile));

            return mechanicalDraftPerformanceCurveDataFile;
        }

        public bool SaveDataFile(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                File.WriteAllText(MechanicalDraftPerformanceCurveDataFile, JsonConvert.SerializeObject(MechanicalDraftPerformanceCurveFileData));
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

        public bool LoadData(string fileName, MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();
            string label = "Test Data: ";

            try
            {
                MechanicalDraftPerformanceCurveDataFile = fileName;
                if(IsInternationalSystemOfUnits_SI != mechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI)
                {
                    IsInternationalSystemOfUnits_SI = mechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI;
                    WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                }

                if (!WaterFlowRateDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.WaterFlowRate, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.HotWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.ColdWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.WetBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.DryBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!FanDriverPowerDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.FanDriverPower, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.BarometricPressure, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveFileData.TestData.LiquidToGasRatio, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(label + errorMessage);
                    errorMessage = string.Empty;
                }

                errorMessage = stringBuilder.ToString();
            }
            catch(Exception exception)
            {
                errorMessage = string.Format("Failure to update page with test data. Exception {0}.", exception.ToString());
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

        public bool FillAndValidate(MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                mechanicalDraftPerformanceCurveFileData.TestData.WaterFlowRate = WaterFlowRateDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.FanDriverPower = FanDriverPowerDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.BarometricPressure = BarometricPressureDataValue.Current;
                mechanicalDraftPerformanceCurveFileData.TestData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Test Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}