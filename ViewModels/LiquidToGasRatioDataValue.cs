// Copyright Cooling Technology Institute 2019-2021

namespace ViewModels
{
    public class LiquidToGasRatioDataValue : DataValue
    {
        //DDV_MinMaxDouble(pDX, m_dblMerkelLG, (ip min) 0.1, (ip max) 10.0, (is min) 0.1, (is max) 10.0, (decimal) 2);
        //DDV_MinMaxDouble(pDX, m_dblLg, LiquidToGasRatio_P3_MIN_IP (0.0), LiquidToGasRatio_P3_MAX_IP (5.0), LiquidToGasRatio_P3_MIN_SI (0.0), LiquidToGasRatio_P3_MAX_SI (5.0), 2);
        // demo
        //#define LG_MIN_IP					   (0.01)//(1.0)
        //#define LG_MAX_IP					   (1.5)
        //#define LG_MIN_SI					   (0.01)//(1.0)
        //#define LG_MAX_SI					   (1.5)
        // 
        //#define LG_MIN_IP					   (0.01)
        //#define LG_MAX_IP					  (20.0)
        //#define LG_MIN_SI					   (0.01)
        //#define LG_MAX_SI					  (20.0)

        public const double LiquidToGasRatioDefault = 1.3;
        public const double LiquidToGasRatioMinimum = 0.01;
        public const double LiquidToGasRatioMaximum = 20.0;

        public const double LiquidToGasRatioDefaultDemo = 1.0;
        public const double LiquidToGasRatioMinimumDemo = 0.01;
        public const double LiquidToGasRatioMaximumDemo = 1.5;

        public const double LiquidToGasRatioDefault_InternationalSystemOfUnits_IS_ = 1.3;
        public const double LiquidToGasRatioMinimum_InternationalSystemOfUnits_IS_ = 0.01;
        public const double LiquidToGasRatioMaximum_InternationalSystemOfUnits_IS_ = 20.0;

        public const double LiquidToGasRatioDefault_InternationalSystemOfUnits_IS_Demo = 1.0;
        public const double LiquidToGasRatioMinimum_InternationalSystemOfUnits_IS_Demo = 0.01;
        public const double LiquidToGasRatioMaximum_InternationalSystemOfUnits_IS_Demo = 1.5;

        public const string LiquidToGasRatioToolTipFormat = "Liquid to Gas Ratio (L/G).\nValue should be between {0} and {1}.\n";

        public LiquidToGasRatioDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Liquid to Gas Ratio";
            Format = "F4";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                if (IsDemo)
                {
                    Default = LiquidToGasRatioDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = LiquidToGasRatioMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = LiquidToGasRatioMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = LiquidToGasRatioDefault_InternationalSystemOfUnits_IS_;
                    Minimum = LiquidToGasRatioMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = LiquidToGasRatioMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = LiquidToGasRatioDefaultDemo;
                    Minimum = LiquidToGasRatioMinimumDemo;
                    Maximum = LiquidToGasRatioMaximumDemo;
                }
                else
                {
                    Default = LiquidToGasRatioDefault;
                    Minimum = LiquidToGasRatioMinimum;
                    Maximum = LiquidToGasRatioMaximum;
                }
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(LiquidToGasRatioToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
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