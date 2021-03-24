// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class MaximumDataValue : DataValue
    {
        public const double MaximumDefault = 2.5;
        public const double MaximumMinimum = 0.1;
        public const double MaximumMaximum = 20.0;

        public const string MaximumToolTipFormat = "Maximum Value.\nValue should be between {0} and {1}.";

        public MaximumDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
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
            Default = MaximumDefault;
            Minimum = MaximumMinimum;
            Maximum = MaximumMaximum;
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_IS_)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(MaximumToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }
    }
}