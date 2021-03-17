// Copyright Cooling Technology Institute 2019-2021

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

        public WaterFlowRateDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Water Flow Rate";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
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

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_SI_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(WaterFlowRateToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
        }
    }
}