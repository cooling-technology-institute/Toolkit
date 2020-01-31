// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;

namespace ViewModels
{
    public class ApproachDataValue : DataValue
    {
        //    DDV_MinMaxDouble(pDX, m_dblCurveApproach, .1, 160, .2, 88.9, 2);
        public const double ApproachDefault = 10.0;
        public const double ApproachMinimum = 0.1;
        public const double ApproachMaximum = 160.0;

        public const double ApproachDefault_InternationalSystemOfUnits_IS_ = 10.0;
        public const double ApproachMinimum_InternationalSystemOfUnits_IS_ = 0.2;
        public const double ApproachMaximum_InternationalSystemOfUnits_IS_ = 88.9;

        public const string ApproachToolTipFormat = "Approach.";

        public ApproachDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Approach";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                Default = ApproachDefault_InternationalSystemOfUnits_IS_;
                Minimum = ApproachMinimum_InternationalSystemOfUnits_IS_;
                Maximum = ApproachMaximum_InternationalSystemOfUnits_IS_;
            }
            else
            {
                Default = ApproachDefault;
                Minimum = ApproachMinimum;
                Maximum = ApproachMaximum;
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
            ToolTip = string.Format(ApproachToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }
}