// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class SlopeDataValue : DataValue
    {
        public const string SlopeToolTipFormat = "Slope Value.\nValue should be between {0} and {1}.";

        public SlopeDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Slope";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
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
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(SlopeToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
        }


        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}