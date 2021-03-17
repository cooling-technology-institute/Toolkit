// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class BarometricPressureDataValue : DataValue
    {
        public const double BarometricPressureDefault = 29.921;
        public const double BarometricPressureMinimum = 5.0;
        public const double BarometricPressureMaximum = 31.5;

        public const double BarometricPressureDefaultDemo = 29.921;
        public const double BarometricPressureMinimumDemo = 29.0;
        public const double BarometricPressureMaximumDemo = 30.0;

        public const double BarometricPressureDefault_InternationalSystemOfUnits_IS_ = 101.325;
        public const double BarometricPressureMinimum_InternationalSystemOfUnits_IS_ = 16.932;
        public const double BarometricPressureMaximum_InternationalSystemOfUnits_IS_ = 103.285;

        public const double BarometricPressureDefault_InternationalSystemOfUnits_IS_Demo = 29.921;
        public const double BarometricPressureMinimum_InternationalSystemOfUnits_IS_Demo = 98.0;
        public const double BarometricPressureMaximum_InternationalSystemOfUnits_IS_Demo = 102.0;

        public const string BarometricPressureToolTipFormat = "Barometric Pressure, the pressure exerted by the weight of the atmosphere.\nValue should be between {0} and {1}.";

        public BarometricPressureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Barometric Pressure";
            Format = "F3";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isIS, bool doConversion = false)
        {
            if (isIS)
            {
                if (IsDemo)
                {
                    Default = BarometricPressureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = BarometricPressureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = BarometricPressureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = BarometricPressureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = BarometricPressureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = BarometricPressureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = BarometricPressureDefaultDemo;
                    Minimum = BarometricPressureMinimumDemo;
                    Maximum = BarometricPressureMaximumDemo;
                }
                else
                {
                    Default = BarometricPressureDefault;
                    Minimum = BarometricPressureMinimum;
                    Maximum = BarometricPressureMaximum;
                }
            }

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_SI_ && !isIS)
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertCelsiusToFahrenheit(UnitConverter.ConvertKilopascalToBarometricPressure(Current));
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertFahrenheitToCelsius(UnitConverter.ConvertBarometricPressureToKilopascal(Current));
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(BarometricPressureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isIS;
        }
    }
}