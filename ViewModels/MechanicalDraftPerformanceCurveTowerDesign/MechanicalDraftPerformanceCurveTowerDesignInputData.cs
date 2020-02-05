// Copyright Cooling Technology Institute 2019-2020

using Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignInputData
    {
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public TOWER_TYPE TowerType { set; get; }

        public RangeDataValue RangeDataValue1 { get; set; }
        public RangeDataValue RangeDataValue2 { get; set; }
        public RangeDataValue RangeDataValue3 { get; set; }
        public RangeDataValue RangeDataValue4 { get; set; }
        public RangeDataValue RangeDataValue5 { get; set; }

        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public FanDriverPowerDataValue FanDriverPowerDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioDataValue LiquidToGasRatioDataValue { get; set; }
        public List<RangedTemperatureDesignInputData> RangedTemperatureDesignInputData { get; set; }

        public string MechanicalDraftPerformanceCurvePerformanceDesignDataFile { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public MechanicalDraftPerformanceCurveDesignData MechanicalDraftPerformanceCurveDesignData { get; set; }

        public MechanicalDraftPerformanceCurveTowerDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            MechanicalDraftPerformanceCurveDesignData = new MechanicalDraftPerformanceCurveDesignData();
    
            OwnerName = string.Empty;
            ProjectName = string.Empty;
            Location = string.Empty;
            TowerManufacturer = string.Empty;
            TowerType = TOWER_TYPE.Forced;

            RangeDataValue1 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue2 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue3 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue4 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            RangeDataValue5 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            RangedTemperatureDesignInputData = new List<RangedTemperatureDesignInputData>();
        }

        public bool LoadData(MechanicalDraftPerformanceCurveDesignData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            MechanicalDraftPerformanceCurveDesignData = data;

            OwnerName = MechanicalDraftPerformanceCurveDesignData.OwnerName;
            ProjectName = MechanicalDraftPerformanceCurveDesignData.ProjectName;
            Location = MechanicalDraftPerformanceCurveDesignData.Location;
            TowerManufacturer = MechanicalDraftPerformanceCurveDesignData.TowerManufacturer;
            TowerType = MechanicalDraftPerformanceCurveDesignData.TowerType;

            RangedTemperatureDesignInputData.Clear();
            foreach (RangedTemperaturesDesignData rangedTemperaturesDesignData in MechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData)
            {
                RangedTemperatureDesignInputData rangedTemperatureDesignInputData = new RangedTemperatureDesignInputData(IsDemo, IsInternationalSystemOfUnits_IS);
                rangedTemperatureDesignInputData.LoadData(rangedTemperaturesDesignData, out errorMessage);
                RangedTemperatureDesignInputData.Add(rangedTemperatureDesignInputData);
            }

            RangeDataValue1.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range1, out errorMessage);
            RangeDataValue2.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range2, out errorMessage);
            RangeDataValue3.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range3, out errorMessage);
            RangeDataValue4.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range4, out errorMessage);
            RangeDataValue5.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range5, out errorMessage);

            WaterFlowRateDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.WaterFlowRate, out errorMessage);
            HotWaterTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.HotWaterTemperature, out errorMessage);
            ColdWaterTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.ColdWaterTemperature, out errorMessage);
            WetBulbTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.WetBulbTemperature, out errorMessage);
            DryBulbTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.DryBulbTemperature, out errorMessage);
            FanDriverPowerDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.FanDriverPower, out errorMessage);
            BarometricPressureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.BarometricPressure, out errorMessage);
            LiquidToGasRatioDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.LiquidToGasRatio, out errorMessage);

            return true;
        }

        public void ReadAllText(string filename)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(MechanicalDraftPerformanceCurveDesignData));
        }

        public void WriteAllText(string filename)
        {
            // fill data

            File.WriteAllText(filename, JsonConvert.SerializeObject(MechanicalDraftPerformanceCurveDesignData, Formatting.Indented));
        }
    }
}
