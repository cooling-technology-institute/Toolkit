// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class UserApproachDataValue : DataValue
    {
        public const double UserApproachDefault = 10.0;
        public const double UserApproachMinimum = 0.1;
        public const double UserApproachMaximum = 100.0;

        public const double UserApproachDefault_InternationalSystemOfUnits_IS_ = 10.0;
        public const double UserApproachMinimum_InternationalSystemOfUnits_IS_ = 0.1;
        public const double UserApproachMaximum_InternationalSystemOfUnits_IS_ = 100.0;

        public const string UserApproachToolTipFormat = "Value should be between {0} and {1}.";

        public UserApproachDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "User Approach";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
            IsZeroValid = true;
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                Default = UserApproachDefault_InternationalSystemOfUnits_IS_;
                Minimum = UserApproachMinimum_InternationalSystemOfUnits_IS_;
                Maximum = UserApproachMaximum_InternationalSystemOfUnits_IS_;
            }
            else
            {
                Default = UserApproachDefault;
                Minimum = UserApproachMinimum;
                Maximum = UserApproachMaximum;
            }

        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(UserApproachToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            if (IsInternationalSystemOfUnits_SI)
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
                    Current /= 1.8;
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current *= 1.8;
                }
            }

            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}