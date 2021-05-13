// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.Text;

namespace ViewModels
{
    public class TowerTestPoint
    {
        public string TestName { get; set; }

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
        public string ErrorMessage { get; set; }

        private TowerTestData TowerTestData { get; set; }

        public TowerTestPoint(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            ErrorMessage = string.Empty;
            
            TestName = string.Empty;
            WaterFlowRateDataValue = new WaterFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            FanDriverPowerDataValue = new FanDriverPowerDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_SI);

            LiquidToGasRatioDataValue = new LiquidToGasRatioDataValue(IsDemo, IsInternationalSystemOfUnits_SI);
            LiquidToGasRatioDataValue.IsZeroValid = true;
            LiquidToGasRatioDataValue.UpdateCurrentValue(0.0);
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                WaterFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                FanDriverPowerDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                LiquidToGasRatioDataValue.ConvertValue(IsInternationalSystemOfUnits_SI);
                isChanged = true;
            }

            return isChanged;
        }

        public bool LoadData(bool isInternationalSystemOfUnits_SI, TowerTestData testData)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();
            ErrorMessage = string.Empty;
            bool isSI = IsInternationalSystemOfUnits_SI;

            try
            {
                if (testData != null)
                {
                    TestName = testData.TestName;
                    string label = string.Format("Test Data {0} : ", TestName);

                    ConvertValues(isInternationalSystemOfUnits_SI);

                    if (!WaterFlowRateDataValue.UpdateCurrentValue(testData.TowerSpecifications.WaterFlowRate))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + WaterFlowRateDataValue.ErrorMessage);
                    }

                    if (!HotWaterTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.HotWaterTemperature))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + HotWaterTemperatureDataValue.ErrorMessage);
                    }

                    if (!ColdWaterTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.ColdWaterTemperature))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + ColdWaterTemperatureDataValue.ErrorMessage);
                    }

                    if (!WetBulbTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.WetBulbTemperature))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + WetBulbTemperatureDataValue.ErrorMessage);
                    }

                    if (!DryBulbTemperatureDataValue.UpdateCurrentValue(testData.TowerSpecifications.DryBulbTemperature))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + DryBulbTemperatureDataValue.ErrorMessage);
                    }

                    if (!FanDriverPowerDataValue.UpdateCurrentValue(testData.TowerSpecifications.FanDriverPower))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + FanDriverPowerDataValue.ErrorMessage);
                    }

                    if (!BarometricPressureDataValue.UpdateCurrentValue(testData.TowerSpecifications.BarometricPressure))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(label + BarometricPressureDataValue.ErrorMessage);
                    }

                    ConvertValues(isSI);
                }
            }
            catch(Exception exception)
            {
                stringBuilder.AppendFormat("Failure to update page with data. Exception {0}.", exception.ToString());
                returnValue = false;
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            return returnValue;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }

        public bool FillFileData(TowerTestData towerTestData)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                towerTestData.TestName = TestName;
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
                ErrorMessage = string.Format("Failure to fill and validate Test Data '{0}'. Exception {1}.", TestName, exception.ToString());
            }

            return returnValue;
        }

        public bool FillCalculationData(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            ErrorMessage = string.Empty;
            bool returnValue = true;

            try
            {
                calculationData.TowerTestData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

                calculationData.TowerTestData.WaterFlowRate = WaterFlowRateDataValue.Current;
                calculationData.TowerTestData.HotWaterTemperature = HotWaterTemperatureDataValue.Current;
                calculationData.TowerTestData.ColdWaterTemperature = ColdWaterTemperatureDataValue.Current;
                calculationData.TowerTestData.WetBulbTemperature = WetBulbTemperatureDataValue.Current;
                calculationData.TowerTestData.DryBulbTemperature = DryBulbTemperatureDataValue.Current;
                calculationData.TowerTestData.FanDriverPower = FanDriverPowerDataValue.Current;
                calculationData.TowerTestData.BarometricPressure = BarometricPressureDataValue.Current;
                calculationData.TowerTestData.LiquidToGasRatio = LiquidToGasRatioDataValue.Current;
            }
            catch (Exception exception)
            {
                ErrorMessage = string.Format("Failure to fill and validate Test Data '{0}'. Exception {1}.", TestName, exception.ToString());
            }

            return returnValue;
        }
    }
}