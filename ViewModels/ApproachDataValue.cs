// Copyright Cooling Technology Institute 2019-2021

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

        public const string ApproachToolTipFormat = "Approach.\nValue should be between {0} and {1}.";

        public ApproachDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Approach";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
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

        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(ApproachToolTipFormat, Minimum, Maximum);
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
                    //Current = UnitConverter.ConvertFahrenheitToCelsius(Current);
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    //Current = UnitConverter.ConvertCelsiusToFahrenheit(Current);
                }
            }

            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}