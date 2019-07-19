using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    //if (!TPropPageBase::metricflag)
    //{
    //    m_dblMerkelT1		= 110;
    //	m_dblMerkelT2		= 84;
    //	m_dblMerkelLG		= 1.3;
    //    m_dblMerkelWBT		= 80;
    //    m_dblMerkelAltitude = 0;
    //    m_dblMerkelResults	= 0;
    //    m_strT1 = L_DEGF;
    //    m_strT2 = L_DEGF;
    //    m_strWBT= L_DEGF;
    //    m_strAlt= L_FEET;
    //}
    //else
    //{
    //    m_dblMerkelT1		= 43.33;
    //	m_dblMerkelT2		= 28.88;
    //	m_dblMerkelLG		= 1.3;
    //    m_dblMerkelWBT		= 26.667;
    //    m_dblMerkelAltitude	= 0;
    //    m_dblMerkelResults	= 0;
    //    m_strT1 = L_DEGC;
    //    m_strT2 = L_DEGC;
    //    m_strWBT= L_DEGC;
    //    m_strAlt= L_METERS;
    //}

    public class WaterAirFlowRateDataValue : DataValue
    {
        public const double WaterAirFlowRateDefault = 1.3; //DDV_MinMaxDouble(pDX,m_dblMerkelLG, min 0.1, max 10.0, metric min 0.1, max 10.0, decimal 2);
        public const double WaterAirFlowRateMinimum = 0.1;
        public const double WaterAirFlowRateMaximum = 10.0;

        public const double WaterAirFlowRateDefaultDemo = 1.3;
        public const double WaterAirFlowRateMinimumDemo = 0.1;
        public const double WaterAirFlowRateMaximumDemo = 10.0;

        public const double WaterAirFlowRateDefault_InternationalSystemOfUnits_IS_ = 1.3;
        public const double WaterAirFlowRateMinimum_InternationalSystemOfUnits_IS_ = 0.1;
        public const double WaterAirFlowRateMaximum_InternationalSystemOfUnits_IS_ = 10.0;

        public const double WaterAirFlowRateDefault_InternationalSystemOfUnits_IS_Demo = 1.3;
        public const double WaterAirFlowRateMinimum_InternationalSystemOfUnits_IS_Demo = 0.1;
        public const double WaterAirFlowRateMaximum_InternationalSystemOfUnits_IS_Demo = 10.0;
        public const string WaterAirFlowRateToolTipFormat = "Water Flow Rate / Air Flow Rate (L/G).\nValue should be between {0} and {1}.\n";

        public WaterAirFlowRateDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Water Flow Rate / Air Flow Rate (L/G)";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = WaterAirFlowRateDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = WaterAirFlowRateMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = WaterAirFlowRateMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = WaterAirFlowRateDefault_InternationalSystemOfUnits_IS_;
                    Minimum = WaterAirFlowRateMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = WaterAirFlowRateMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = WaterAirFlowRateDefaultDemo;
                    Minimum = WaterAirFlowRateMinimumDemo;
                    Maximum = WaterAirFlowRateMaximumDemo;
                }
                else
                {
                    Default = WaterAirFlowRateDefault;
                    Minimum = WaterAirFlowRateMinimum;
                    Maximum = WaterAirFlowRateMaximum;
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
            ToolTip = string.Format(WaterAirFlowRateToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }
}