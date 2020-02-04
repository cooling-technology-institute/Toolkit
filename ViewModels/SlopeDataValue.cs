// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class SlopeDataValue : DataValue
    {
        public const string SlopeToolTipFormat = "Slope Value.\nValue should be between {0} and {1}.";

        public SlopeDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Slope";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isIS, bool doConversion = false)
        {
            if (IsDemo)
            {
                Default = -0.75;
            }
            else
            {
                Default = 0;
            }

            Minimum = -2;
            Maximum = 0;

            Current = Default;

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(SlopeToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isIS;
        }
    }
}