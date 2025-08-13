// Copyright Cooling Technology Institute 2019-2025

using CalculationLibrary;

namespace ViewModels
{
    public class RangeDataValue : DataValue
    {
        //    DDV_MinMaxDouble(pDX, m_dblCurveRange, .1, 160, .2, 88.9, 2);
        public const double RangeDefault = 10.0;
        public const double RangeMinimum = 0.1;
        public const double RangeMaximum = 160.0;

        public const double RangeDefault_InternationalSystemOfUnits_IS_ = 5.56;
        public const double RangeMinimum_InternationalSystemOfUnits_IS_ = 0.2;
        public const double RangeMaximum_InternationalSystemOfUnits_IS_ = 88.9;

        public const string RangeToolTipFormat = "Range.\nValue should be between {0} and {1}.";

        public RangeDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Range";
            Format = "F2";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                Default = RangeDefault_InternationalSystemOfUnits_IS_;
                Minimum = RangeMinimum_InternationalSystemOfUnits_IS_;
                Maximum = RangeMaximum_InternationalSystemOfUnits_IS_;
            }
            else
            {
                Default = RangeDefault;
                Minimum = RangeMinimum;
                Maximum = RangeMaximum;
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            UpdateCurrentValue(Current);
            ToolTip = string.Format(RangeToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            if (IsInternationalSystemOfUnits_SI)
            {
                Units = ConstantUnits.RangeK;
            }
            else
            {
                Units = ConstantUnits.TemperatureFahrenheit;
            }
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);

            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                if (isInternationalSystemOfUnits_SI)
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current /= 1.8;
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current *= 1.8;
                }
            }

            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}