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

        public RelativeHumidityDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Relative Humidity";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_IS_)
        {
            Default = RelativeHumidityDefault;
            Minimum = RelativeHumidityMinimum;
            Maximum = RelativeHumidityMaximum;
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_IS_)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(RelativeHumidityToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            if (IsInternationalSystemOfUnits_SI_ != isInternationalSystemOfUnits_IS_)
            {
                if (isInternationalSystemOfUnits_IS_)
                {
                }
                else
                {
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }
    }
}