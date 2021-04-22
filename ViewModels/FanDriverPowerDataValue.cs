// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class FanDriverPowerDataValue : DataValue
    {
        //#define FAN_DRIVER_POWER_MIN_IP		   (0.0001)
        //#define FAN_DRIVER_POWER_MAX_IP		(1000.0)
        public const double FanDriverPowerDefault = 0.01;
        public const double FanDriverPowerMinimum = 0.0001;
        public const double FanDriverPowerMaximum = 1000.0;

        public const double FanDriverPowerDefaultDemo = 0.01;
        public const double FanDriverPowerMinimumDemo = 0.0001;
        public const double FanDriverPowerMaximumDemo = 1000.0;

        //#define FAN_DRIVER_POWER_MIN_SI		   (0.0001)  
        //#define FAN_DRIVER_POWER_MAX_SI		 (745.7)
        public const double FanDriverPowerDefault_InternationalSystemOfUnits_IS_ = 0.0;
        public const double FanDriverPowerMinimum_InternationalSystemOfUnits_IS_ = 0.0001;
        public const double FanDriverPowerMaximum_InternationalSystemOfUnits_IS_ = 745.7;

        public const double FanDriverPowerDefault_InternationalSystemOfUnits_IS_Demo = 0.0;
        public const double FanDriverPowerMinimum_InternationalSystemOfUnits_IS_Demo = 0.0001;
        public const double FanDriverPowerMaximum_InternationalSystemOfUnits_IS_Demo = 745.7;
        public const string FanDriverPowerToolTipFormat = "Fan Driver Power.\nValue should be between {0} and {1}.";

        public FanDriverPowerDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Fan Driver Power";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                if (IsDemo)
                {
                    Default = FanDriverPowerDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = FanDriverPowerMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = FanDriverPowerMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = FanDriverPowerDefault_InternationalSystemOfUnits_IS_;
                    Minimum = FanDriverPowerMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = FanDriverPowerMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = FanDriverPowerDefaultDemo;
                    Minimum = FanDriverPowerMinimumDemo;
                    Maximum = FanDriverPowerMaximumDemo;
                }
                else
                {
                    Default = FanDriverPowerDefault;
                    Minimum = FanDriverPowerMinimum;
                    Maximum = FanDriverPowerMaximum;
                }
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(FanDriverPowerToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                if (isInternationalSystemOfUnits_SI)
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertBrakeHorsepowerToKilowatts(Current);
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertKilowattsToBrakeHorsepower(Current);
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}