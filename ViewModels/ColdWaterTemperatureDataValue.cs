// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class ColdWaterTemperatureDataValue : DataValue
    {
        public const double ColdWaterTemperatureDefault = 84.0; //DDV_MinMaxDouble(pDX,m_dblMerkelT2, min 32, max 200, metric min 0, max 93, decimals 2);
        public const double ColdWaterTemperatureMinimum = 32.0;
        public const double ColdWaterTemperatureMaximum = 200.0;

        public const double ColdWaterTemperatureDefaultDemo = 80.0;
        public const double ColdWaterTemperatureMinimumDemo = 75.0;
        public const double ColdWaterTemperatureMaximumDemo = 80.0;

        public const double ColdWaterTemperatureDefault_InternationalSystemOfUnits_IS_ = 28.89;
        public const double ColdWaterTemperatureMinimum_InternationalSystemOfUnits_IS_ = 0.0;
        public const double ColdWaterTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double ColdWaterTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 26.67;
        public const double ColdWaterTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double ColdWaterTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;
        public const string ColdWaterTemperatureToolTipFormat = "Cold Water Temperature (CWT).\nValue should be between {0} and {1}.\nValue should be less than the Hot Water Temperature.";

        public ColdWaterTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Cold Water Temperature";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_IS_);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_IS_)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = ColdWaterTemperatureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = ColdWaterTemperatureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = ColdWaterTemperatureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = ColdWaterTemperatureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = ColdWaterTemperatureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = ColdWaterTemperatureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = ColdWaterTemperatureDefaultDemo;
                    Minimum = ColdWaterTemperatureMinimumDemo;
                    Maximum = ColdWaterTemperatureMaximumDemo;
                }
                else
                {
                    Default = ColdWaterTemperatureDefault;
                    Minimum = ColdWaterTemperatureMinimum;
                    Maximum = ColdWaterTemperatureMaximum;
                }
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_IS_)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(ColdWaterTemperatureToolTipFormat, Minimum, Maximum);
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
                    Current = UnitConverter.ConvertFahrenheitToCelsius(Current);
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertCelsiusToFahrenheit(Current);
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_IS_);
        }
    }
}