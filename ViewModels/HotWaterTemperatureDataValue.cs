// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class HotWaterTemperatureDataValue : DataValue
    {
        public const double HotWaterTemperatureDefault = 110.0; //     DDV_MinMaxDouble(pDX,m_dblMerkelT1, min 32, max 200, metric min 0, metric max 93, decimalplaces 2);
        public const double HotWaterTemperatureMinimum = 32.0;
        public const double HotWaterTemperatureMaximum = 200.0;

        public const double HotWaterTemperatureDefaultDemo = 100.0;
        public const double HotWaterTemperatureMinimumDemo = 75.0;
        public const double HotWaterTemperatureMaximumDemo = 80.0;

        public const double HotWaterTemperatureDefault_InternationalSystemOfUnits_IS_ = 43.33;
        public const double HotWaterTemperatureMinimum_InternationalSystemOfUnits_IS_ = 0.0;
        public const double HotWaterTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double HotWaterTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 37.78;
        public const double HotWaterTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double HotWaterTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;
        public const string HotWaterTemperatureToolTipFormat = "Hot Water Temperature (HWT).\nValue should be between {0} and {1}.\nValue should be greater than the Cold Water Temperature.";

        public HotWaterTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Hot Water Temperature";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = HotWaterTemperatureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = HotWaterTemperatureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = HotWaterTemperatureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = HotWaterTemperatureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = HotWaterTemperatureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = HotWaterTemperatureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = HotWaterTemperatureDefaultDemo;
                    Minimum = HotWaterTemperatureMinimumDemo;
                    Maximum = HotWaterTemperatureMaximumDemo;
                }
                else
                {
                    Default = HotWaterTemperatureDefault;
                    Minimum = HotWaterTemperatureMinimum;
                    Maximum = HotWaterTemperatureMaximum;
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
            ToolTip = string.Format(HotWaterTemperatureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }
    }
}