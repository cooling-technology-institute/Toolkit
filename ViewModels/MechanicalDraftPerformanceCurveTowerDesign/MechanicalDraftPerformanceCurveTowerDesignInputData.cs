// Copyright Cooling Technology Institute 2019-2020

using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignInputData
    {
        const int MIN_FLOW_COUNT = 3;
        const int MIN_RANGE_COUNT = 3;
        const int MIN_WET_BULB_TEMPERTURE_COUNT = 3;	// Dean's notes say 5 ....
        const string rangeOrderError = "Range are not order correctly. They must be entered in either ascending or descending order, but not mixed or the same value.";

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

        public WaterFlowRateDataValue AddWaterFlowRateDataValue { get; set; }

        public string MechanicalDraftPerformanceCurvePerformanceDesignDataFile { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_SI { get; set; }

        public MechanicalDraftPerformanceCurveDesignData MechanicalDraftPerformanceCurveDesignData { get; set; }

        public MechanicalDraftPerformanceCurveTowerDesignInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            MechanicalDraftPerformanceCurveDesignData = new MechanicalDraftPerformanceCurveDesignData();
    
            OwnerName = string.Empty;
            ProjectName = string.Empty;
            Location = string.Empty;
            TowerManufacturer = string.Empty;
            TowerType = TOWER_TYPE.Forced;

            RangeDataValue1 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue1.InitializeValue(0.0);
            RangeDataValue2 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue2.InitializeValue(0.0);
            RangeDataValue3 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue3.InitializeValue(0.0);
            RangeDataValue4 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue4.InitializeValue(0.0);
            RangeDataValue5 = new RangeDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            RangeDataValue5.InitializeValue(0.0);

            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            AddWaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            
            RangedTemperatureDesignInputData = new List<RangedTemperatureDesignInputData>();
        }

        public bool LoadData(MechanicalDraftPerformanceCurveDesignData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                OwnerName = MechanicalDraftPerformanceCurveDesignData.OwnerName;
                ProjectName = MechanicalDraftPerformanceCurveDesignData.ProjectName;
                Location = MechanicalDraftPerformanceCurveDesignData.Location;
                TowerManufacturer = MechanicalDraftPerformanceCurveDesignData.TowerManufacturer;
                TowerType = MechanicalDraftPerformanceCurveDesignData.TowerType;

                MechanicalDraftPerformanceCurveDesignData = data;

                RangedTemperatureDesignInputData.Clear();
                foreach (RangedTemperaturesDesignData rangedTemperaturesDesignData in MechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData)
                {
                    RangedTemperatureDesignInputData rangedTemperatureDesignInputData = new RangedTemperatureDesignInputData(IsDemo, IsInternationalSystemOfUnits_SI);
                    rangedTemperatureDesignInputData.LoadData(rangedTemperaturesDesignData, out errorMessage);
                    RangedTemperatureDesignInputData.Add(rangedTemperatureDesignInputData);
                }

                if (!RangeDataValue1.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range1, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue2.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range2, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue3.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range3, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (RangeDataValue4.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range4, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!RangeDataValue5.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.Range5, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }


                if (!WaterFlowRateDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.WaterFlowRate, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!HotWaterTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.HotWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.ColdWaterTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!WetBulbTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.WetBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!DryBulbTemperatureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.DryBulbTemperature, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!FanDriverPowerDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.FanDriverPower, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!BarometricPressureDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.BarometricPressure, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }

                if (!LiquidToGasRatioDataValue.UpdateCurrentValue(MechanicalDraftPerformanceCurveDesignData.LiquidToGasRatio, out errorMessage))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                }
            }
            catch (Exception e)
            {
                errorMessage = string.Format("Failure to Mechanical Draft Performance Curve Design Data. Exception: {0}", e.ToString());
                returnValue = false;
            }
            return returnValue;
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

        public bool FillAndValidate(MechanicalDraftPerformanceCurveDesignData mechanicalDraftPerformanceCurveDesignData, out string errorMessage)
        {
            errorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            try
            {
                mechanicalDraftPerformanceCurveDesignData.WaterFlowRate = WaterFlowRateDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.OwnerName = OwnerName;
                mechanicalDraftPerformanceCurveDesignData.ProjectName = ProjectName;
                mechanicalDraftPerformanceCurveDesignData.Location = Location;
                mechanicalDraftPerformanceCurveDesignData.TowerManufacturer = TowerManufacturer;
                mechanicalDraftPerformanceCurveDesignData.TowerType = TowerType;

                mechanicalDraftPerformanceCurveDesignData.Range1 = RangeDataValue1.Current;
                mechanicalDraftPerformanceCurveDesignData.Range2 = RangeDataValue2.Current;
                mechanicalDraftPerformanceCurveDesignData.Range3 = RangeDataValue3.Current;
                mechanicalDraftPerformanceCurveDesignData.Range4 = RangeDataValue4.Current;
                mechanicalDraftPerformanceCurveDesignData.Range5 = RangeDataValue5.Current;

                if(!mechanicalDraftPerformanceCurveDesignData.ValidateRanges(MIN_RANGE_COUNT, out errorMessage))
                {
                    stringBuilder.AppendLine(errorMessage);
                    errorMessage = string.Empty;
                    returnValue = false;
                }

                mechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData.Clear();
                foreach (RangedTemperaturesDesignData rangedTemperaturesDesignData in MechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData)
                {
                    if (!rangedTemperaturesDesignData.ValidateWetBulbTemperature(MIN_WET_BULB_TEMPERTURE_COUNT, out errorMessage))
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                    if (!rangedTemperaturesDesignData.ValidateColdWaterTemperaturesRange1(MIN_WET_BULB_TEMPERTURE_COUNT, out errorMessage))
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                    if (!rangedTemperaturesDesignData.ValidateColdWaterTemperaturesRange2(MIN_WET_BULB_TEMPERTURE_COUNT, out errorMessage))
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                    if (!rangedTemperaturesDesignData.ValidateColdWaterTemperaturesRange3(MIN_WET_BULB_TEMPERTURE_COUNT, out errorMessage))
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                    if (!rangedTemperaturesDesignData.ValidateColdWaterTemperaturesRange4(MIN_WET_BULB_TEMPERTURE_COUNT, out errorMessage))
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                    if (!rangedTemperaturesDesignData.ValidateColdWaterTemperaturesRange5(MIN_WET_BULB_TEMPERTURE_COUNT, out errorMessage))
                    {
                        stringBuilder.AppendLine(errorMessage);
                        errorMessage = string.Empty;
                        returnValue = false;
                    }
                    mechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData.Add(rangedTemperaturesDesignData);
                }

                if (mechanicalDraftPerformanceCurveDesignData.RangedTemperaturesDesignData.Count < MIN_FLOW_COUNT)
                {
                    stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} flows in the Tower Design Data to calculate Tower Capability.", MIN_FLOW_COUNT));
                    returnValue = false;
                }

                mechanicalDraftPerformanceCurveDesignData.WaterFlowRate = WaterFlowRateDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.FanDriverPower = FanDriverPowerDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.BarometricPressure = BarometricPressureDataValue.Current;
                mechanicalDraftPerformanceCurveDesignData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Failed to fill and validate Mechanical Draft Performance Curve Design Data. Exception {0}.", exception.ToString());
            }
            return returnValue;
        }
    }
}
