// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;

namespace ViewModels
{
    public class DryBulbTemperatureDataValue : DataValue
    {
        public const double DryBulbTemperatureDefault = 100.0;
        public const double DryBulbTemperatureMinimum = 0.0;
        public const double DryBulbTemperatureMaximum = 200.0;

        public const double DryBulbTemperatureDefaultDemo = 77.0;
        public const double DryBulbTemperatureMinimumDemo = 75.0;
        public const double DryBulbTemperatureMaximumDemo = 80.0;

        public const double DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_ = 26.67;
        public const double DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_ = -18.0;
        public const double DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 26.67;
        public const double DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;
        public const string DryBulbTemperatureToolTipFormat = "Dry Bulb Temperature (DBT).\nValue should be between {0} and {1}.\nValue should be greater than the Wet Bulb Temperature.";

        public DryBulbTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Dry Bulb Temperature";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = DryBulbTemperatureDefaultDemo;
                    Minimum = DryBulbTemperatureMinimumDemo;
                    Maximum = DryBulbTemperatureMaximumDemo;
                }
                else
                {
                    Default = DryBulbTemperatureDefault;
                    Minimum = DryBulbTemperatureMinimum;
                    Maximum = DryBulbTemperatureMaximum;
                }
            }

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_SI_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertCelsiusToFahrenheit(Current);
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertFahrenheitToCelsius(Current);
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(DryBulbTemperatureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }
    }
}