using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public abstract class DataValue
    {
        public double Default { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double Current { get; set; }
        public bool IsValid { get; set; }
        public string InputMessage { get; set; }
        public string InputValue { get; set; }
        public string Format { get; set; }
        public string ToolTipFormat { get; set; }
        public string ToolTip { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }
        public bool IsDemo { get; set; }

        public DataValue()
        {
            Default = 0.0;
            Minimum = 0.0;
            Maximum = 0.0;
            Current = 0.0;
            IsValid = false;
            IsDemo = true;
            IsInternationalSystemOfUnits_IS_ = false;
            InputMessage = string.Empty;
            InputValue = string.Empty;
            Format = string.Empty;
            ToolTipFormat = string.Empty;
            ToolTip = string.Empty;
        }

        public abstract void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false);

        public bool UpdateValue(string input, out string message)
        {
            InputValue = input;
            return IsValidValue(out message);
        }

        private bool IsValidValue(out string message)
        {
            message = string.Empty;
            double value = Current;

            if (!string.IsNullOrEmpty(InputValue))
            {
                if (double.TryParse(InputValue, out value))
                {
                    if ((value < Minimum) || (value > Maximum))
                    {
                        value = Current;
                        message = string.Format("The {0} input must be between {1} and {2}", InputMessage, Minimum, Maximum);
                        IsValid = false;
                    }
                    else
                    {
                        Current = value;
                        IsValid = true;
                    }
                }
                else
                {
                    message = string.Format("The {0} input is not a valid number", InputMessage);
                    IsValid = false;
                }
            }
            else
            {
                message = string.Format("The {0} input is not a valid number", InputMessage);
                IsValid = false;
            }

            return IsValid;
        }
    }

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

        public EnthalpyDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Enthalpy";
            Format = "F4";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
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

            if(doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
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
            ToolTip = string.Format(EnthalpyToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }

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

    public class BarometricPressureDataValue : DataValue
    {
        public const double BarometricPressureDefault = 29.921;
        public const double BarometricPressureMinimum = 5.0;
        public const double BarometricPressureMaximum = 31.5;

        public const double BarometricPressureDefaultDemo = 29.921;
        public const double BarometricPressureMinimumDemo = 29.0;
        public const double BarometricPressureMaximumDemo = 30.0;

        public const double BarometricPressureDefault_InternationalSystemOfUnits_IS_ = 29.921;
        public const double BarometricPressureMinimum_InternationalSystemOfUnits_IS_ = 16.932;
        public const double BarometricPressureMaximum_InternationalSystemOfUnits_IS_ = 103.285;

        public const double BarometricPressureDefault_InternationalSystemOfUnits_IS_Demo = 29.921;
        public const double BarometricPressureMinimum_InternationalSystemOfUnits_IS_Demo = 98.0;
        public const double BarometricPressureMaximum_InternationalSystemOfUnits_IS_Demo = 102.0;

        public const string BarometricPressureToolTipFormat = "Barometric Pressure, the pressure exerted by the weight of the atmosphere.\nValue should be between {0} and {1}.";

        public BarometricPressureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Barometric Pressure";
            Format = "F3";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = BarometricPressureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = BarometricPressureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = BarometricPressureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = BarometricPressureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = BarometricPressureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = BarometricPressureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = BarometricPressureMinimumDemo;
                    Minimum = BarometricPressureMaximumDemo;
                    Maximum = BarometricPressureDefaultDemo;
                }
                else
                {
                    Default = BarometricPressureDefault;
                    Minimum = BarometricPressureMinimum;
                    Maximum = BarometricPressureMaximum;
                }
            }

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertBarometricPressureToKilopascal(Current);
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertKilopascalToBarometricPressure(Current);
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(BarometricPressureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }

    public class WetBlubTemperatureDataValue : DataValue
    {
        public const double WetBulbTemperatureDefault = 90.0;
        public const double WetBulbTemperatureMinimum = 0.0;
        public const double WetBulbTemperatureMaximum = 200.0;

        public const double WetBulbTemperatureDefaultDemo = 90.0;
        public const double WetBulbTemperatureMinimumDemo = 75.0;
        public const double WetBulbTemperatureMaximumDemo = 80.0;

        public const double WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_ = 26.67;
        public const double WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_ = -18.0;
        public const double WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 26.67;
        public const double WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;

        public const string WetBulbTemperatureToolTipFormat = "Wet Bulb Temperature (WBT).\nValue should be between {0} and {1}.\nValue should be less than the Dry Bulb Temperature.";

        public WetBlubTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Wet Bulb Temperature";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = WetBulbTemperatureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = WetBulbTemperatureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = WetBulbTemperatureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = WetBulbTemperatureDefaultDemo;
                    Minimum = WetBulbTemperatureMinimumDemo;
                    Maximum = WetBulbTemperatureMaximumDemo;
                }
                else
                {
                    Default = WetBulbTemperatureDefault;
                    Minimum = WetBulbTemperatureMinimum;
                    Maximum = WetBulbTemperatureMaximum;
                }
            }

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertCelsiusToFahrenheit(Current);
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertFahrenheitToCelsius(Current);
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(WetBulbTemperatureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }

    public class DryBlubTemperatureDataValue : DataValue
    {
        public const double DryBulbTemperatureDefault = 100.0;
        public const double DryBulbTemperatureMinimum = 0.0;
        public const double DryBulbTemperatureMaximum = 200.0;

        public const double DryBulbTemperatureDefaultDemo = 100.0;
        public const double DryBulbTemperatureMinimumDemo = 75.0;
        public const double DryBulbTemperatureMaximumDemo = 80.0;

        public const double DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_ = 26.67;
        public const double DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_ = -18.0;
        public const double DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_ = 93.0;

        public const double DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo = 26.67;
        public const double DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo = 24.0;
        public const double DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo = 27.0;
        public const string DryBulbTemperatureToolTipFormat = "Dry Bulb Temperature (DBT).\nValue should be between {0} and {1}.\nValue should be less than the Wet Bulb Temperature.";

        public DryBlubTemperatureDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Dry Bulb Temperature";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            if (isInternationalSystemOfUnits_IS_)
            {
                if (IsDemo)
                {
                    Default = DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_Demo;
                    Minimum = DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_Demo;
                    Maximum = DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_Demo;
                }
                else
                {
                    Default = DryBulbTemperatureDefault_InternationalSystemOfUnits_IS_;
                    Minimum = DryBulbTemperatureMinimum_InternationalSystemOfUnits_IS_;
                    Maximum = DryBulbTemperatureMaximum_InternationalSystemOfUnits_IS_;
                }
            }
            else
            {
                if (IsDemo)
                {
                    Default = DryBulbTemperatureDefaultDemo;
                    Minimum = DryBulbTemperatureMinimumDemo;
                    Maximum = DryBulbTemperatureMaximumDemo;
                }
                else
                {
                    Default = DryBulbTemperatureDefault;
                    Minimum = DryBulbTemperatureMinimum;
                    Maximum = DryBulbTemperatureMaximum;
                }
            }

            if (doConversion)
            {
                if (IsInternationalSystemOfUnits_IS_ && !isInternationalSystemOfUnits_IS_)
                {
                    // convert to United States Customary Units (IP)
                    Current = UnitConverter.ConvertCelsiusToFahrenheit(Current);
                }
                else
                {
                    // convert to InternationalSystemOfUnits_IS
                    Current = UnitConverter.ConvertFahrenheitToCelsius(Current);
                }
            }
            else
            {
                Current = Default;
            }

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(DryBulbTemperatureToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }

    public class RelativeHumitityDataValue : DataValue
    {
        public const double RelativeHumidityMinimum = 0.0;
        public const double RelativeHumidityMaximum = 100.0;
        public const double RelativeHumidityDefault = 42.38;
        public const string RelativeHumidityToolTipFormat = "Relative Humidity, the amount of water vapor present in air expressed as a percentage of the amount needed for saturation at the same temperature.\nValue should be between {0} and {1}.";

        public RelativeHumitityDataValue(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            InputMessage = "Relative Humidity";
            Format = "F2";
            ConvertValue(isInternationalSystemOfUnits_IS_);
        }

        public override void ConvertValue(bool isInternationalSystemOfUnits_IS_, bool doConversion = false)
        {
            Default = RelativeHumidityMinimum;
            Minimum = RelativeHumidityMinimum;
            Maximum = RelativeHumidityMaximum;

            Current = Default;

            InputValue = Current.ToString(Format);
            ToolTip = string.Format(RelativeHumidityToolTipFormat, Minimum, Maximum);

            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
        }
    }

    public class PsychrometricsInputData
    {
        public CalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }
        public bool IsElevation { get; set; }

        public EnthalpyDataValue EnthalpyDataValue { get; set; }
        public ElevationDataValue ElevationDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public RelativeHumitityDataValue RelativeHumitityDataValue { get; set; }
        public WetBlubTemperatureDataValue WetBlubTemperatureDataValue { get; set; }
        public DryBlubTemperatureDataValue DryBlubTemperatureDataValue { get; set; }

        public PsychrometricsInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS_ = IsInternationalSystemOfUnits_IS_;
            IsElevation = true;
            CalculationType = CalculationType.Psychrometrics_WBT_DBT;
            EnthalpyDataValue = new EnthalpyDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            ElevationDataValue = new ElevationDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            RelativeHumitityDataValue = new RelativeHumitityDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            WetBlubTemperatureDataValue = new WetBlubTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
            DryBlubTemperatureDataValue = new DryBlubTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS_);
        }

        public bool ConvertValues(bool isInternationalSystemOfUnits_IS_)
        {
            if(IsInternationalSystemOfUnits_IS_ != isInternationalSystemOfUnits_IS_)
            {
                IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
                EnthalpyDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                ElevationDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                WetBlubTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                DryBlubTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS_);
                return true;
            }
            return false;
        }

        public void SetElevation(bool value)
        {
            IsElevation = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }
    }
}