// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class TowerTestPoint
    {
        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }

        public TowerTestPoint(bool isDemo, bool isInternationalSystemOfUnits_IS_, Models.TowerSpecifications mechanicalDraftPerformanceCurveData = null)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_IS_;

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
  
            if(mechanicalDraftPerformanceCurveData != null)
            {
                WaterFlowRateDataValue.Current = mechanicalDraftPerformanceCurveData.WaterFlowRate;
                HotWaterTemperatureDataValue.Current = mechanicalDraftPerformanceCurveData.HotWaterTemperature;
                ColdWaterTemperatureDataValue.Current = mechanicalDraftPerformanceCurveData.ColdWaterTemperature;
                WetBulbTemperatureDataValue.Current = mechanicalDraftPerformanceCurveData.WetBulbTemperature;
                DryBulbTemperatureDataValue.Current = mechanicalDraftPerformanceCurveData.DryBulbTemperature;
                FanDriverPowerDataValue.Current = mechanicalDraftPerformanceCurveData.FanDriverPower;
                BarometricPressureDataValue.Current = mechanicalDraftPerformanceCurveData.BarometricPressure;
                LiquidToGasRatioDataValue.Current = mechanicalDraftPerformanceCurveData.LiquidToGasRatio;
            }
        }
/*
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
*/
        public bool LoadData(int testIndex, List<Models.TowerTestData> testData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();
            string label = "Test Data: ";

            try
            {
                if(testData != null && testData.Count > testIndex)
                {
                    if (IsInternationalSystemOfUnits_SI != testData[testIndex].TowerSpecifications.IsInternationalSystemOfUnits_SI)
                    {
                        IsInternationalSystemOfUnits_SI = testData[testIndex].TowerSpecifications.IsInternationalSystemOfUnits_SI;
                        WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                        LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI, false);
                    }

                    if (!WaterFlowRateDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.WaterFlowRate, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!HotWaterTemperatureDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.HotWaterTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.ColdWaterTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!WetBulbTemperatureDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.WetBulbTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!DryBulbTemperatureDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.DryBulbTemperature, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!FanDriverPowerDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.FanDriverPower, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!BarometricPressureDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.BarometricPressure, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    if (!LiquidToGasRatioDataValue.UpdateCurrentValue(testData[testIndex].TowerSpecifications.LiquidToGasRatio, out errorMessage))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + errorMessage);
                        errorMessage = string.Empty;
                    }

                    errorMessage = stringBuilder.ToString();
                }
            }
            catch(Exception exception)
            {
                errorMessage = string.Format("Failure to update page with data. Exception {0}.", exception.ToString());
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
                isChanged = true;
            }
            return isChanged;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }

        public bool FillAndValidate(TowerTestData towerTestData, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                towerTestData.TowerSpecifications.WaterFlowRate = WaterFlowRateDataValue.Current;
                towerTestData.TowerSpecifications.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                towerTestData.TowerSpecifications.FanDriverPower = FanDriverPowerDataValue.Current;
                towerTestData.TowerSpecifications.BarometricPressure = BarometricPressureDataValue.Current;
                towerTestData.TowerSpecifications.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failure to fill and validate Mechanical Draft Performance Curve Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}