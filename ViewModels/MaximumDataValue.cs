﻿// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class MaximumDataValue : DataValue
    {
        public MaximumDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Minimum";
            Format = "F1";
            ToolTipFormat = "Maximum Value.\nValue should be between {0} and {1}.";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isIS, bool doConversion = false)
        {
            Default = 0.5;
            Minimum = 0.1;
            Maximum = 5.0;

            Current = Default;

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(ToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isIS;
        }
    }
}