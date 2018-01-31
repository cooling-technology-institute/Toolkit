using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CTIToolkit
{
    public class DefaultValues
    {
        //#define WBT_MIN_IP					   (0.0)
        //#define WBT_MAX_IP					 (200.0)
        //#define WBT_MIN_SI					 (-18.0)
        //#define WBT_MAX_SI					  (93.0)
        //#define DBT_MIN_IP					   (0.0)
        //#define DBT_MAX_IP					 (200.0)
        //#define DBT_MIN_SI				 	 (-18.0)
        //#define DBT_MAX_SI					  (93.0)
        //    if (!TPropPageBase::metricflag)
        //    {
        //        m_strPsychWBTUnits = _T(L_DEGF);
        //        m_strPsychDBTUnits = _T(L_DEGF);
        //#ifndef _DEMO_VERSION
        //        m_dblPsychDBT      = 100.;
        //        m_dblPsychWBT      = 80.;
        //#else
        //        m_dblPsychDBT      = DBT_MAX_IP;
        //        m_dblPsychWBT      = WBT_MAX_IP;
        //#endif
        //        m_dblAltitude      = 0;
        //        m_dblRelHumidity   = 42.38;
        //        m_dblEnthalpy      = 43.46;
        //    }
        //    else
        //    {
        //        m_strPsychWBTUnits = _T(L_DEGC);
        //    m_strPsychDBTUnits = _T(L_DEGC);
        //# ifndef _DEMO_VERSION
        //    m_dblPsychDBT      = 37.78;
        //        m_dblPsychWBT      = 26.67;
        //#else
        //        m_dblPsychDBT      = DBT_MAX_SI;
        //        m_dblPsychWBT      = WBT_MAX_SI;
        //#endif
        //        m_dblAltitude      = 0;
        //        m_dblRelHumidity   = 42.38;
        //        m_dblEnthalpy      = 83.32;
        //    }

        public double MinimumTemperature = 0.0;
        public double MaximumTemperature = 200.0;

        public const double BulbTemperatureMinimum = 0.0;
        public const double BulbTemperatureMaximum = 200.0;

        public const double BulbTemperatureMinimumMetric = -18.0;
        public const double BulbTemperatureMaximumMetric = 93.0;

        public const double BulbTemperatureMinimumDemo = 80.0;
        public const double BulbTemperatureMaximumDemo = 100.0;

        public const double BulbTemperatureMinimumMetricDemo = 26.67;
        public const double BulbTemperatureMaximumMetricDemo = 37.78;

        public const double WetBulbTemperatureDefault = 80.0;
        public const double WetBulbTemperatureDefaultDemo = 100.0;
        public const double DryBulbTemperatureDefault = 80.0;
        public const double DryBulbTemperatureDefaultDemo = 100.0;

        public const double WetBulbTemperatureDefaultMetric = 26.67;
        public const double WetBulbTemperatureDefaultMetricDemo = 26.67;
        public const double DryBulbTemperatureDefaultMetric = 37.78;
        public const double DryBulbTemperatureDefaultMetricDemo = 37.78;

        public const double AltitudeMinimum = -1000.00;
        public const double AltitudeMaximum = 40000.00;
        public const double AltitudeMinimumMetric = -300.00;
        public const double AltitudeMaximumMetric = 12200.00;
        public const double AltitudeDefault = 0.0;
        public const double AltitudeDefaultMetric = 0.0;

        public const double RelativeHumidityMinimum = 0.0;
        public const double RelativeHumidityMaximum = 100.0;
        public const double RelativeHumidityDefault = 42.38;
        public const double RelativeHumidityDefaultMetric = 42.38;
        public const double RelativeHumidityMinimumMetric = 0.0;
        public const double RelativeHumidityMaximumMetric = 100.0;

        public const double EnthalpyMinimum = 0.0;
        public const double EnthalpyMaximum = 2758;
        public const double EnthalpyDefault = 43.46;
        public const double EnthalpyDefaultMetric = 83.32;

        public const double BarometricPressureMinimum = 5.0;
        public const double BarometricPressureMaximum = 31.5;
        public const double BarometricPressureMinimumMetric = 16.932;
        public const double BarometricPressureMaximumMetric = 103.285;
        public const double BarometricPressureDefault = 43.46;
        public const double BarometricPressureDefaultMetric = 43.46;
    }

    public class DataValue
    {
        public double Default { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public double Current { get; set; }
        public bool IsValid { get; set; }
        public string InputMessage { get; set; }
        public string InputValue { get; set; }
        public string Format { get; set; }

        public DataValue(double defaultValue, double minimum, double maximum, string inputMessage, string format = "F2")
        {
            Default = defaultValue;
            Minimum = minimum;
            Maximum = maximum;
            Current = defaultValue;
            InputMessage = inputMessage;
            Format = format;
            InputValue = defaultValue.ToString(Format);
        }

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

    public class PsychrometricsInputData
    {
        public CalculationType CalculationType { get; set; }
        public bool IsDemo { get; set; }
        public bool IsMetric { get; set; }
        public bool IsAltitute { get; set; }

        public DataValue EnthalpyDataValue { get; set; }
        public DataValue AltitudeDataValue { get; set; }
        public DataValue BarometricPressureDataValue { get; set; }
        public DataValue RelativeHumitityDataValue { get; set; }
        public DataValue WetBlubTemperatureDataValue { get; set; }
        public DataValue DryBlubTemperatureDataValue { get; set; }

        public PsychrometricsInputData()
        {
            IsDemo = false;
            IsMetric = false;
            IsAltitute = true;
            CalculationType = CalculationType.Psychrometrics_WBT_DBT;
            SetValues();
        }

        public void SetMetric(bool value)
        {
            IsMetric = value;
            SetValues();
        }

        public void SetAltitute(bool value)
        {
            IsAltitute = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
            SetValues();
        }

        private void SetValues()
        {
            if (IsMetric)
            {
                if (IsDemo)
                {
                    WetBlubTemperatureDataValue = new DataValue(DefaultValues.WetBulbTemperatureDefaultMetricDemo, DefaultValues.BulbTemperatureMinimumDemo, DefaultValues.BulbTemperatureMaximumDemo, "Wet Bulb Temperature");
                    DryBlubTemperatureDataValue = new DataValue(DefaultValues.DryBulbTemperatureDefaultMetricDemo, DefaultValues.BulbTemperatureMinimumMetricDemo, DefaultValues.BulbTemperatureMaximumMetricDemo, "Dry Bulb Temperature");
                }
                else
                {
                    WetBlubTemperatureDataValue = new DataValue(DefaultValues.WetBulbTemperatureDefaultMetric, DefaultValues.BulbTemperatureMinimumMetric, DefaultValues.BulbTemperatureMaximumMetric, "Wet Bulb Temperature");
                    DryBlubTemperatureDataValue = new DataValue(DefaultValues.DryBulbTemperatureDefaultMetric, DefaultValues.BulbTemperatureMinimumMetric, DefaultValues.BulbTemperatureMaximumMetric, "Dry Bulb Temperature");
                }

                EnthalpyDataValue = new DataValue(DefaultValues.EnthalpyDefaultMetric, DefaultValues.EnthalpyMinimum, DefaultValues.EnthalpyMaximum, "Enthalpy");
                AltitudeDataValue = new DataValue(DefaultValues.AltitudeDefaultMetric, DefaultValues.AltitudeMinimumMetric, DefaultValues.AltitudeMaximumMetric, "Altitude");
                BarometricPressureDataValue = new DataValue(DefaultValues.BarometricPressureDefaultMetric, DefaultValues.BarometricPressureMinimumMetric, DefaultValues.BarometricPressureMaximumMetric, "Barometric Pressure");
                RelativeHumitityDataValue = new DataValue(DefaultValues.RelativeHumidityDefaultMetric, DefaultValues.RelativeHumidityMinimumMetric, DefaultValues.RelativeHumidityMaximumMetric, "Relative Humidity");
            }
            else
            {
                if (IsDemo)
                {
                    WetBlubTemperatureDataValue = new DataValue(DefaultValues.WetBulbTemperatureDefaultDemo, DefaultValues.BulbTemperatureMinimumDemo, DefaultValues.BulbTemperatureMaximumDemo, "Wet Bulb Temperature");
                    DryBlubTemperatureDataValue = new DataValue(DefaultValues.DryBulbTemperatureDefaultDemo, DefaultValues.BulbTemperatureMinimumDemo, DefaultValues.BulbTemperatureMaximumDemo, "Dry Bulb Temperature");
                }
                else
                {
                    WetBlubTemperatureDataValue = new DataValue(DefaultValues.WetBulbTemperatureDefault, DefaultValues.BulbTemperatureMinimum, DefaultValues.BulbTemperatureMaximum, "Wet Bulb Temperature");
                    DryBlubTemperatureDataValue = new DataValue(DefaultValues.DryBulbTemperatureDefault, DefaultValues.BulbTemperatureMinimum, DefaultValues.BulbTemperatureMaximum, "Dry Bulb Temperature");
                }

                EnthalpyDataValue = new DataValue(DefaultValues.EnthalpyDefault, DefaultValues.EnthalpyMinimum, DefaultValues.EnthalpyMaximum, "Enthalpy");
                AltitudeDataValue = new DataValue(DefaultValues.AltitudeDefault, DefaultValues.AltitudeMinimum, DefaultValues.AltitudeMaximum, "Altitude");
                BarometricPressureDataValue = new DataValue(DefaultValues.BarometricPressureDefault, DefaultValues.BarometricPressureMinimum, DefaultValues.BarometricPressureMaximum, "Barometric Pressure");
                RelativeHumitityDataValue = new DataValue(DefaultValues.RelativeHumidityDefault, DefaultValues.RelativeHumidityMinimum, DefaultValues.RelativeHumidityMaximum, "Relative Humidity");
            }
        }
   }
}