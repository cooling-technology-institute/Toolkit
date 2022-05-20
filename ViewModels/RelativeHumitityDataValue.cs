// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class RelativeHumidityDataValue : DataValue
    {
        public const double RelativeHumidityMinimum = 0.0;
        public const double RelativeHumidityMaximum = 100.0;
        public const double RelativeHumidityDefault = 42.38;
        public const string RelativeHumidityToolTipFormat = "Relative Humidity, the amount of water vapor present in air expressed as a percentage of the amount needed for saturation at the same temperature.\nValue should be between {0} and {1}.";

        public RelativeHumidityDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Relative Humidity";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            Default = RelativeHumidityDefault;
            Minimum = RelativeHumidityMinimum;
            Maximum = RelativeHumidityMaximum;
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(RelativeHumidityToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            Units = ConstantUnits.Percentage;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                if (isInternationalSystemOfUnits_SI)
                {
                }
                else
                {
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}