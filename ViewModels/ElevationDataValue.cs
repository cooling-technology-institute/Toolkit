// Copyright Cooling Technology Institute 2019-2025

using CalculationLibrary;

namespace ViewModels
{
    public class ElevationDataValue : DataValue
    {
        public const double ElevationMinimum = -1000.00;
        public const double ElevationMaximum = 40000.00;
        public const double ElevationMinimumInternationalSystemOfUnits_IS_ = -300.00;
        public const double ElevationMaximumInternationalSystemOfUnits_IS_ = 12200.00;
        public const double ElevationDefault = 0.0;
        public const double ElevationDefaultInternationalSystemOfUnits_IS_ = 0.0;
        public const string ElevationToolTipFormat = "Elevation above sea level.\nValue should be between {0} and {1}.";

        public ElevationDataValue(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            InputMessage = "Elevation";
            Format = "F4";
            SetDefaultMinMax(isInternationalSystemOfUnits_SI);
            Current = Default;
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }

        public override void SetDefaultMinMax(bool isInternationalSystemOfUnits_SI)
        {
            if (isInternationalSystemOfUnits_SI)
            {
                Default = ElevationDefault;
                Minimum = ElevationMinimumInternationalSystemOfUnits_IS_;
                Maximum = ElevationMaximumInternationalSystemOfUnits_IS_;
            }
            else
            {
                Default = ElevationDefault;
                Minimum = ElevationMinimum;
                Maximum = ElevationMaximum;
            }

        }

        public void SetInputAndTooltip(bool isInternationalSystemOfUnits_SI)
        {
            UpdateCurrentValue(Current);
            ToolTip = string.Format(ElevationToolTipFormat, Minimum, Maximum);
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            if (IsInternationalSystemOfUnits_SI)
            {
                Units = ConstantUnits.Meter;
            }
            else
            {
                Units = ConstantUnits.Foot;
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
                    Current = UnitConverter.ConvertFeetToMeters(Current);
                }
                else
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertMetersToFeet(Current);
                }
            }
            SetInputAndTooltip(isInternationalSystemOfUnits_SI);
        }
    }
}