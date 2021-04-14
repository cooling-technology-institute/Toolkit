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

        public const double RangeDefault_InternationalSystemOfUnits_IS_ = 5.56;
        public const double RangeMinimum_InternationalSystemOfUnits_IS_ = 0.2;
        public const double RangeMaximum_InternationalSystemOfUnits_IS_ = 88.9;

        public const string RangeToolTipFormat = "Range.\nValue should be between {0} and {1}.";

        public RangeDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Range";
            Format = "F2";
            IsZeroValid = true;
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_IS_)
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
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_IS_)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(RangeToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);

            if (IsInternationalSystemOfUnits_SI_ != isInternationalSystemOfUnits_IS_)
            {
                if (isInternationalSystemOfUnits_IS_)
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

            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }
    }
}