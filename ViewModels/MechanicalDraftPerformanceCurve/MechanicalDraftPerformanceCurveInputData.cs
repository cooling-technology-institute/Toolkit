// Copyright Cooling Technology Institute 2019-2020

using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public bool IsInternationalSystemOfUnits_IS { get; set; }

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
            IsInternationalSystemOfUnits_IS = isInternationalSystemOfUnits_IS_;
            
            MechanicalDraftPerformanceCurveData = new MechanicalDraftPerformanceCurveData(IsInternationalSystemOfUnits_IS);

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            int fileCount = 0;
            do
            {
                if (fileCount == 0)
                {
                    MechanicalDraftPerformanceCurveDataFile = Path.Combine(Application.UserAppDataPath, "MechanicalDraftPerformanceData.json");
                }
                else
                {
                    MechanicalDraftPerformanceCurveDataFile = Path.Combine(Application.UserAppDataPath, string.Format("MechanicalDraftPerformanceData({0}).json", fileCount));
                }
                fileCount++;
            } while (File.Exists(MechanicalDraftPerformanceCurveDataFile));
        }

        public void OpenDataFile(string fileName)
        {
            try
            {
                MechanicalDraftPerformanceCurveDataFile = fileName;

                MechanicalDraftPerformanceCurveData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveData>(File.ReadAllText(MechanicalDraftPerformanceCurveDataFile));

                string errorMessage;
                LoadData(MechanicalDraftPerformanceCurveData, out errorMessage);
            }
            catch
            {

            }
        }

        public void SaveDataFile()
        {
            try
            {
                File.WriteAllText(MechanicalDraftPerformanceCurveDataFile, JsonConvert.SerializeObject(MechanicalDraftPerformanceCurveData));
            }
            catch
            {

            }
        }

        public void SaveAsDataFile(string fileName)
        {
            try
            {
                MechanicalDraftPerformanceCurveDataFile = fileName;
                SaveDataFile();
            }
            catch
            {

            }
        }

        public void LoadData(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                WaterFlowRateDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.WaterFlowRate, out errorMessage);
                HotWaterTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.HotWaterTemperature, out errorMessage);
                ColdWaterTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.ColdWaterTemperature, out errorMessage);
                WetBulbTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.WetBulbTemperature, out errorMessage);
                DryBulbTemperatureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.DryBulbTemperature, out errorMessage);
                FanDriverPowerDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.FanDriverPower, out errorMessage);
                BarometricPressureDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.BarometricPressure, out errorMessage);
                LiquidToGasRatioDataValue.UpdateCurrentValue(mechanicalDraftPerformanceCurveData.MechanicalDraftPerformanceCurveTestData.LiquidToGasRatio, out errorMessage);
            }
            catch
            {

            }
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_IS != isIS)
            {
                IsInternationalSystemOfUnits_IS = isIS;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true); 
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                //MechanicalDraftPerformanceCurveDesignInputData.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                isChanged = true;
            }
            return isChanged;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }
    }
}