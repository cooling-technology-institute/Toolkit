// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;

namespace ViewModels
{
    public class WaterFlowRateDataValue : DataValue
    {
        public const double WaterFlowRateDefault = 0.1;
        public const double WaterFlowRateMinimum = 0.1;
        public const double WaterFlowRateMaximum = double.MaxValue;

        public const double WaterFlowRateDefaultDemo = 0.1;
        public const double WaterFlowRateMinimumDemo = 0.1;
        public const double WaterFlowRateMaximumDemo = 57500.0;

        public const double WaterFlowRateDefault_InternationalSystemOfUnits_IS_ = 0.1;
        public const double WaterFlowRateMinimum_InternationalSystemOfUnits_IS_ = 0.1;
        public const double WaterFlowRateMaximum_InternationalSystemOfUnits_IS_ = double.MaxValue;

        public const double WaterFlowRateDefault_InternationalSystemOfUnits_IS_Demo = 0.1;
        public const double WaterFlowRateMinimum_InternationalSystemOfUnits_IS_Demo = 0.1;
        public const double WaterFlowRateMaximum_InternationalSystemOfUnits_IS_Demo = 3630.0;

        public const string WaterFlowRateToolTipFormat = "Water Flow Rate.\nValue should be between {0} and {1}.";

        public WaterFlowRateDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Water Flow Rate";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                if (IsDemo)
                {
                    Default = WaterFlowRateDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = WaterFlowRateMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = WaterFlowRateMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = WaterFlowRateDefault_InternationalSystemOfUnits_IS_;
                    Minimum = WaterFlowRateMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = WaterFlowRateMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = WaterFlowRateDefaultDemo;
                    Minimum = WaterFlowRateMinimumDemo;
                    Maximum = WaterFlowRateMaximumDemo;
                }
                else
                {
                    Default = WaterFlowRateDefault;
                    Minimum = WaterFlowRateMinimum;
                    Maximum = WaterFlowRateMaximum;
                }
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(WaterFlowRateToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);

            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                if (isInternationalSystemOfUnits_SI)
                {
                    // convert to International System Of Units IS
                    Current = UnitConverter.ConvertGallonPerMinuteToLitersPerSecond(Current);
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertLitersPerSecondToGallonPerMinute(Current);
                }
            }

            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}