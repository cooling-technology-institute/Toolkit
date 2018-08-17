using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class WetBlubTemperatureDataValue : DataValue
    {
        public const double WetBulbTemperatureDefault = 80.0;
        public const double WetBulbTemperatureMinimum = 0.0;
        public const double WetBulbTemperatureMaximum = 200.0;

        public const double WetBulbTemperatureDefaultDemo = 80.0;
        public const double WetBulbTemperatureMinimumDemo = 75.0;
        public const double WetBulbTemperatureMaximumDemo = 80.0;

        public const double WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_ = 26.67;
        public const double WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_ = -18.0;
        public const double WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 26.67;
        public const double WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;

        public const string WetBulbTemperatureToolTipFormat = "Wet Bulb Temperature (WBT).\nValue should be between {0} and {1}.\nValue should be less than the Dry Bulb Temperature.";

        public WetBlubTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Wet Bulb Temperature";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
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

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
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
            ToolTip = string.Format(WetBulbTemperatureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }
}