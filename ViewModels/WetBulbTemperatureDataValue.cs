// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class WetBulbTemperatureDataValue : DataValue
    {
        public const double WetBulbTemperatureDefault = 80.0;
        public const double WetBulbTemperatureMinimum = 0.0;
        public const double WetBulbTemperatureMaximum = 200.0;

        public const double WetBulbTemperatureDefaultDemo = 76.0;
        public const double WetBulbTemperatureMinimumDemo = 75.0;
        public const double WetBulbTemperatureMaximumDemo = 80.0;

        public const double WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_ = 26.67;
        public const double WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_ = -18.0;
        public const double WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 26.67;
        public const double WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;

        public const string WetBulbTemperatureToolTipFormat = "Wet Bulb Temperature (WBT).\nValue should be between {0} and {1}.\nValue should be less than the Dry Bulb Temperature.";

        public WetBulbTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Wet Bulb Temperature";
            Format = "F3";
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
                    Default = WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = WetBulbTemperatureDefaultDemo;
                    Minimum = WetBulbTemperatureMinimumDemo;
                    Maximum = WetBulbTemperatureMaximumDemo;
                }
                else
                {
                    Default = WetBulbTemperatureDefault;
                    Minimum = WetBulbTemperatureMinimum;
                    Maximum = WetBulbTemperatureMaximum;
                }
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(WetBulbTemperatureToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            if(IsInternationalSystemOfUnits_SI)
            {
                Units = ConstantUnits.TemperatureCelsius;
            }
            else
            {
                Units = ConstantUnits.TemperatureFahrenheit;
            }
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                if (isInternationalSystemOfUnits_SI)
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertFahrenheitToCelsius(Current);
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertCelsiusToFahrenheit(Current);
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}