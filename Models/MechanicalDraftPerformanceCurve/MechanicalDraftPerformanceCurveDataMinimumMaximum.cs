// Copyright Cooling Technology Institute 2019-2021

using System.Text;

namespace Models
{
    public class MechanicalDraftPerformanceCurveDataMinimumMaximum
    {
        const double WATER_FLOW_RATE_MIN_IP = 0.1;
        const double WATER_FLOW_RATE_MAX_IP = double.MaxValue;
        const double WATER_FLOW_RATE_MIN_SI = 0.1;
        const double WATER_FLOW_RATE_MAX_SI = double.MaxValue;

        const double HOT_WATER_TEMPERATURE_MIN_IP = 32.0;
        const double HOT_WATER_TEMPERATURE_MAX_IP = 212.0;
        const double HOT_WATER_TEMPERATURE_MIN_SI = 0.0;
        const double HOT_WATER_TEMPERATURE_MAX_SI = 100.0;

        const double COLD_WATER_TEMPERATURE_MIN_IP = 32.0;
        const double COLD_WATER_TEMPERATURE_MAX_IP = 212.0;
        const double COLD_WATER_TEMPERATURE_MIN_SI = 0.0;
        const double COLD_WATER_TEMPERATURE_MAX_SI = 100.0;

        const double WET_BULB_TEMPERATURE_MIN_IP = 0.0;
        const double WET_BULB_TEMPERATURE_MAX_IP = 200.0;
        const double WET_BULB_TEMPERATURE_MIN_SI = -18.0;
        const double WET_BULB_TEMPERATURE_MAX_SI = 93.0;

        const double DRY_BULB_TEMPERATURE_MIN_IP = 0.0;
        const double DRY_BULB_TEMPERATURE_MAX_IP = 200.0;
        const double DRY_BULB_TEMPERATURE_MIN_SI = -18.0;
        const double DRY_BULB_TEMPERATURE_MAX_SI = 93.0;

        const double FAN_DRIVER_POWER_MIN_IP = 0.0001;
        const double FAN_DRIVER_POWER_MAX_IP = 1000.0;
        const double FAN_DRIVER_POWER_MIN_SI = 0.0001;
        const double FAN_DRIVER_POWER_MAX_SI = 745.7;

        const double BAROMETRIC_PRESSURE_MIN_IP = 5.0;
        const double BAROMETRIC_PRESSURE_MAX_IP = 31.5;
        const double BAROMETRIC_PRESSURE_MIN_SI = 16.932;
        const double BAROMETRIC_PRESSURE_MAX_SI = 103.285;

        const double LIQUID_GAS_RATIO_MIN_IP = 0.01;
        const double LIQUID_GAS_RATIO_MAX_IP = 20.0;
        const double LIQUID_GAS_RATIO_MIN_SI = 0.01;
        const double LIQUID_GAS_RATIO_MAX_SI = 20.0;

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MinIP = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = false,
            WaterFlowRate = WATER_FLOW_RATE_MIN_IP,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MIN_IP,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MIN_IP,
            WetBulbTemperature = WET_BULB_TEMPERATURE_MIN_IP,
            DryBulbTemperature = DRY_BULB_TEMPERATURE_MIN_IP,
            FanDriverPower = FAN_DRIVER_POWER_MIN_IP,
            BarometricPressure = BAROMETRIC_PRESSURE_MIN_IP,
            LiquidToGasRatio = LIQUID_GAS_RATIO_MIN_IP,
        };

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MaxIP = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = false,
            WaterFlowRate = WATER_FLOW_RATE_MAX_IP,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MAX_IP,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MAX_IP,
            WetBulbTemperature = WET_BULB_TEMPERATURE_MAX_IP,
            DryBulbTemperature = DRY_BULB_TEMPERATURE_MAX_IP,
            FanDriverPower = FAN_DRIVER_POWER_MAX_IP,
            BarometricPressure = BAROMETRIC_PRESSURE_MAX_IP,
            LiquidToGasRatio = LIQUID_GAS_RATIO_MAX_IP,
        };

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MinSI = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = true,
            WaterFlowRate = WATER_FLOW_RATE_MIN_SI,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MIN_SI,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MIN_SI,
            WetBulbTemperature = WET_BULB_TEMPERATURE_MIN_SI,
            DryBulbTemperature = DRY_BULB_TEMPERATURE_MIN_SI,
            FanDriverPower = FAN_DRIVER_POWER_MIN_SI,
            BarometricPressure = BAROMETRIC_PRESSURE_MIN_SI,
            LiquidToGasRatio = LIQUID_GAS_RATIO_MIN_SI,
        };

        MechanicalDraftPerformanceCurveData MechanicalDraftPerformanceCurveData_MaxSI = new MechanicalDraftPerformanceCurveData()
        {
            IsInternationalSystemOfUnits_SI = true,
            WaterFlowRate = WATER_FLOW_RATE_MAX_SI,
            HotWaterTemperature = HOT_WATER_TEMPERATURE_MAX_SI,
            ColdWaterTemperature = COLD_WATER_TEMPERATURE_MAX_SI,
            WetBulbTemperature = WET_BULB_TEMPERATURE_MAX_SI,
            DryBulbTemperature = DRY_BULB_TEMPERATURE_MAX_SI,
            FanDriverPower = FAN_DRIVER_POWER_MAX_SI,
            BarometricPressure = BAROMETRIC_PRESSURE_MAX_SI,
            LiquidToGasRatio = LIQUID_GAS_RATIO_MAX_SI,
        };

        public bool isWaterFlowRateError = false;
        public bool isHotWaterTemperatureError = false;
        public bool isColdWaterTemperatureError = false;
        public bool isWetBulbTemperatureError = false;
        public bool isDryBulbTemperatureError = false;
        public bool isFanDriverPowerError = false;
        public bool isBarometricPressureError = false;
        public bool isLiquidGasRatioError = false;

        // Check design or test data, optionally prompting the user with bounds if errors are found.
        public bool ValidateDataWithinRange(MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData, bool isDesignData, StringBuilder errorMessage)
        {
            isWaterFlowRateError = false;
            isHotWaterTemperatureError = false;
            isColdWaterTemperatureError = false;
            isWetBulbTemperatureError = false;
            isDryBulbTemperatureError = false;
            isFanDriverPowerError = false;
            isBarometricPressureError = false;
            isLiquidGasRatioError = false;

            MechanicalDraftPerformanceCurveData minimum = new MechanicalDraftPerformanceCurveData();
            MechanicalDraftPerformanceCurveData maximum = new MechanicalDraftPerformanceCurveData();

            if (mechanicalDraftPerformanceCurveData.IsInternationalSystemOfUnits_SI)
            {
                minimum = MechanicalDraftPerformanceCurveData_MinSI;
                maximum = MechanicalDraftPerformanceCurveData_MaxSI;
            }
            else
            {
                minimum = MechanicalDraftPerformanceCurveData_MinIP;
                maximum = MechanicalDraftPerformanceCurveData_MaxIP;
            }

            // Check each value against min and max bounds
            isWaterFlowRateError = ((mechanicalDraftPerformanceCurveData.WaterFlowRate < minimum.WaterFlowRate) || (mechanicalDraftPerformanceCurveData.WaterFlowRate > maximum.WaterFlowRate));

            isHotWaterTemperatureError = ((mechanicalDraftPerformanceCurveData.HotWaterTemperature < minimum.HotWaterTemperature)
                                   || (mechanicalDraftPerformanceCurveData.HotWaterTemperature > maximum.HotWaterTemperature)
                                   || (mechanicalDraftPerformanceCurveData.HotWaterTemperature <= mechanicalDraftPerformanceCurveData.ColdWaterTemperature));

            isColdWaterTemperatureError = ((mechanicalDraftPerformanceCurveData.ColdWaterTemperature < minimum.ColdWaterTemperature)
                                    || (mechanicalDraftPerformanceCurveData.ColdWaterTemperature > maximum.ColdWaterTemperature));

            isWetBulbTemperatureError = ((mechanicalDraftPerformanceCurveData.WetBulbTemperature < minimum.WetBulbTemperature)
                                  || (mechanicalDraftPerformanceCurveData.WetBulbTemperature > maximum.WetBulbTemperature));

            isDryBulbTemperatureError = ((mechanicalDraftPerformanceCurveData.DryBulbTemperature < minimum.DryBulbTemperature)
                                  || (mechanicalDraftPerformanceCurveData.DryBulbTemperature > maximum.DryBulbTemperature)
                                  || (mechanicalDraftPerformanceCurveData.DryBulbTemperature < mechanicalDraftPerformanceCurveData.WetBulbTemperature));

            isFanDriverPowerError = ((mechanicalDraftPerformanceCurveData.FanDriverPower < minimum.FanDriverPower)
                              || (mechanicalDraftPerformanceCurveData.FanDriverPower > maximum.FanDriverPower));

            isBarometricPressureError = ((mechanicalDraftPerformanceCurveData.BarometricPressure < minimum.BarometricPressure)
                                  || (mechanicalDraftPerformanceCurveData.BarometricPressure > maximum.BarometricPressure));

            if (isDesignData)
                isLiquidGasRatioError = ((mechanicalDraftPerformanceCurveData.LiquidToGasRatio < minimum.LiquidToGasRatio) || (mechanicalDraftPerformanceCurveData.LiquidToGasRatio > maximum.LiquidToGasRatio));
            else
                isLiquidGasRatioError = false;

            bool isError = (isWaterFlowRateError || isHotWaterTemperatureError || isColdWaterTemperatureError || isWetBulbTemperatureError || isDryBulbTemperatureError || isFanDriverPowerError ||
                isBarometricPressureError || isLiquidGasRatioError);

            // If requested, display a message box pointing out the errors and displaying
            // the min and max values for each.
            if (isError)
            {
                string type = isDesignData ? "Design" : "Test";

                errorMessage.AppendFormat("Your {0} data is out of range for calculating % Capability.\n\n Please check the following {0} values:\n\n", type);
                int i = 1;
                if (isWaterFlowRateError)
                {
                    errorMessage.AppendFormat("{0}. Water Flow Rate:   min = {1},   max = {2}\n", i++, minimum.WaterFlowRate, maximum.WaterFlowRate);
                }
                if (isHotWaterTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Hot Water Temperature:   min = {1},   max = {2}\n", i++, minimum.HotWaterTemperature, maximum.HotWaterTemperature);
                }
                if (isColdWaterTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Cold Water Temperature:   min = {1},   max = {2}\n", i++, minimum.ColdWaterTemperature, maximum.ColdWaterTemperature);
                }
                if (isWetBulbTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Wet Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.WetBulbTemperature, maximum.WetBulbTemperature);
                }
                if (isDryBulbTemperatureError)
                {
                    errorMessage.AppendFormat("{0}. Dry Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.DryBulbTemperature, maximum.DryBulbTemperature);
                }
                if (isFanDriverPowerError)
                {
                    errorMessage.AppendFormat("{0}. Fan Driver Power:   min = {1},   max = {2}\n", i++, minimum.FanDriverPower, maximum.FanDriverPower);
                }
                if (isBarometricPressureError)
                {
                    errorMessage.AppendFormat("{0}. Barometric Pressure:   min = {1},   max = {2}\n", i++, minimum.BarometricPressure, maximum.BarometricPressure);
                }
                if (isLiquidGasRatioError)
                {
                    errorMessage.AppendFormat("{0}. Liquid to Gas Ratio:   min = {1},   max = {2}\n", i++, minimum.LiquidToGasRatio, maximum.LiquidToGasRatio);
                }
            }
            return !isError;
        }
    }
}