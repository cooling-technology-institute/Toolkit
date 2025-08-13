// Copyright Cooling Technology Institute 2019-2025

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

        public MinimumDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
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
            Default = MinimumDefault;
            Minimum = MinimumMinimum;
            Maximum = MinimumMaximum;
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            UpdateCurrentValue(Current);
            ToolTip = string.Format(MinimumToolTipFormat, Minimum, Maximum);
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
                }
                else
                {
                    // convert to United States Customary Units (IP)
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}