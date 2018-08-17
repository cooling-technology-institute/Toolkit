using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
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

        public ElevationDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Elevation";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_, false);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
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

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertMetersToFeet(Current);
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertFeetToMeters(Current);
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(ElevationToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }
}