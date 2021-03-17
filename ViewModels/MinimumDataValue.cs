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
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isIS, bool doConversion = false)
        {
            Default = MinimumDefault;
            Minimum = MinimumMinimum;
            Maximum = MinimumMaximum;

            Current = Default;

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(MinimumToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isIS;
        }
    }
}