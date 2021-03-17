// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class RangeDataValue : DataValue
    {
        //    DDV_MinMaxDouble(pDX, m_dblCurveRange, .1, 160, .2, 88.9, 2);
        public const double RangeDefault = 10.0;
        public const double RangeMinimum = 0.1;
        public const double RangeMaximum = 160.0;

        public const double RangeDefault_InternationalSystemOfUnits_IS_ = 10.0;
        public const double RangeMinimum_InternationalSystemOfUnits_IS_ = 0.2;
        public const double RangeMaximum_InternationalSystemOfUnits_IS_ = 88.9;

        public const string RangeToolTipFormat = "Range.\nValue should be between {0} and {1}.";

        public RangeDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Range";
            Format = "F2";
            IsZeroValid = true;
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                Default = RangeDefault_InternationalSystemOfUnits_IS_;
                Minimum = RangeMinimum_InternationalSystemOfUnits_IS_;
                Maximum = RangeMaximum_InternationalSystemOfUnits_IS_;
            }
            else
            {
                Default = RangeDefault;
                Minimum = RangeMinimum;
                Maximum = RangeMaximum;
            }

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_SI_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                    InitializeValue(UnitConverter.ConvertCelsiusToFahrenheit(Current));
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    InitializeValue(Current = UnitConverter.ConvertFahrenheitToCelsius(Current));
                }
            }
            else
            {
                InitializeValue(Default);
            }
            ToolTip = string.Format(RangeToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }
    }
}