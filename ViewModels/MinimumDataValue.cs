// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class MinimumDataValue : DataValue
    {
        public const double MinimumDefault = 0.5;
        public const double MinimumMinimum = 0.1;
        public const double MinimumMaximum = 5.0;

        public const string MinimumToolTipFormat = "Minimum Value.\nValue should be between {0} and {1}.";

        public MinimumDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Minimum";
            Format = "F1";
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_IS_)
        {
            Default = MinimumDefault;
            Minimum = MinimumMinimum;
            Maximum = MinimumMaximum;
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_IS_)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(MinimumToolTipFormat, Minimum, Maximum);
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
                }
                else
                {
                    // convert to United States Customary Units (IP)
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }
    }
}