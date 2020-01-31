// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class LiquidToGasRatioDataValue : DataValue
    {
        //DDV_MinMaxDouble(pDX, m_dblMerkelLG, (ip min) 0.1, (ip max) 10.0, (is min) 0.1, (is max) 10.0, (decimal) 2);
        public const double LiquidToGasRatioDefault = 1.0; //DDV_MinMaxDouble(pDX, m_dblLg, LiquidToGasRatio_P3_MIN_IP (0.0), LiquidToGasRatio_P3_MAX_IP (5.0), LiquidToGasRatio_P3_MIN_SI (0.0), LiquidToGasRatio_P3_MAX_SI (5.0), 2);
        public const double LiquidToGasRatioMinimum = 0.0;
        public const double LiquidToGasRatioMaximum = 5.0;

        public const double LiquidToGasRatioDefaultDemo = 1.0;
        public const double LiquidToGasRatioMinimumDemo = 1.0;
        public const double LiquidToGasRatioMaximumDemo = 5.0;

        public const double LiquidToGasRatioDefault_InternationalSystemOfUnits_IS_ = 1.0;
        public const double LiquidToGasRatioMinimum_InternationalSystemOfUnits_IS_ = 1.0;
        public const double LiquidToGasRatioMaximum_InternationalSystemOfUnits_IS_ = 5.0;

        public const double LiquidToGasRatioDefault_InternationalSystemOfUnits_IS_Demo = 1.0;
        public const double LiquidToGasRatioMinimum_InternationalSystemOfUnits_IS_Demo = 1.0;
        public const double LiquidToGasRatioMaximum_InternationalSystemOfUnits_IS_Demo = 5.0;

        public const string LiquidToGasRatioToolTipFormat = "Liquid to Gas Ratio (L/G).\nValue should be between {0} and {1}.\n";

        public LiquidToGasRatioDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Liquid to Gas Ratio";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
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

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
                {
                }
                else
                {
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(LiquidToGasRatioToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }
}