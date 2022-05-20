// Copyright Cooling Technology Institute 2019-2021

using System;
using System.Data;
using System.Text;

namespace ViewModels
{
    public class EnthalpyDataValue : DataValue
    {
        //DDV_MinMaxDouble(pDX, m_dblEnthalpy,0,2758,0,6030,4);
        public const double EnthalpyMinimum = 0.0;
        public const double EnthalpyMaximum = 2758;
        public const double EnthalpyDefault = 43.46;
        public const double EnthalpyDefault_InternationalSystemOfUnits_IS_ = 83.32;
        public const double EnthalpyMinimum_InternationalSystemOfUnits_IS_ = 0.0;
        public const double EnthalpyMaximum_InternationalSystemOfUnits_IS_ = 6030;
        public const string EnthalpyToolTipFormat = "Enthalpy, a thermodynamic quantity equivalent to the total heat content of a system.\nValue should be between {0} and {1}.";

        public EnthalpyDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Enthalpy";
            Format = "F4";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                Default = EnthalpyDefault_InternationalSystemOfUnits_IS_;
                Minimum = EnthalpyMinimum_InternationalSystemOfUnits_IS_;
                Maximum = EnthalpyMaximum_InternationalSystemOfUnits_IS_;
            }
            else
            {
                Default = EnthalpyDefault;
                Minimum = EnthalpyMinimum;
                Maximum = EnthalpyMaximum;
            }
        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            InputValue = Current.ToString(Format);
            ToolTip = string.Format(EnthalpyToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            if (IsInternationalSystemOfUnits_SI)
            {
                Units = ConstantUnits.KilojoulesPerKilogram;
            }
            else
            {
                Units = ConstantUnits.BtuPerPound;
            }
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_SI)
        {
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);

            if (IsInternationalSystemOfUnits_SI != isInternationalSystemOfUnits_SI)
            {
                if (isInternationalSystemOfUnits_SI)
                {
                    // convert to United States Customary Units (IP)
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}