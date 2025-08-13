// Copyright Cooling Technology Institute 2019-2025

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

        public MaximumDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Minimum";
            Format = "F1";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            Default = MaximumDefault;
            Minimum = MaximumMinimum;
            Maximum = MaximumMaximum;
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            UpdateCurrentValue(Current);
            ToolTip = string.Format(MaximumToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}