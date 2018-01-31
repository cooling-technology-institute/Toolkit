using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CTIToolkit
{
    public enum CalculationType
    {
        Psychrometrics_WBT_DBT,
        Psychrometrics_DBT_RH,
        Psychrometrics_Enthalpy
    }

    public class PsychrometricsData
    {
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }

        public CalculationType CalculationType { get; set; }
        public string BarometricPressureInput { set; get; }
        public string AltitudeInput { set; get; }
        public string EnthalpyInput { set; get; }
        public string TemperatureWetBulbInput { set; get; } // TWB
        public string TemperatureDryBulbInput { set; get; } // TDB
        public string RelativeHumidityInput { set; get; }

        public double Altitude { set; get; }
        public double TemperatureWetBulb { set; get; } // TWB
        public double TemperatureDryBulb { set; get; } // TDB

        public double BarometricPressure { set; get; }
        public double HumidityRatio { set; get; }
        public double RelativeHumidity { set; get; }
        public double Enthalpy { set; get; }
        public double SpecificVolume { set; get; }
        public double Density { set; get; }
        public double DewPoint { set; get; }
        public double DegreeOfSaturation { get; set; }

        public string UnitsTemperature { set; get; }
        public string UnitsEnthalpy { set; get; }
        public string UnitsDensity { set; get; }
        public string UnitsVolume { set; get; }
        public string UnitsHumidity { set; get; }
        public string Temperature { set; get; }

        public Units Units { get; set; }
        public bool IsDemo { get; set; }
        public bool IsMetric { get; set; }
        public bool IsAltitute { get; set; }

        //public PsychrometricsData(bool isMetric, bool isAltitute, bool isDemo = false)
        public PsychrometricsData()
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            BarometricPressure = 0.0;
            HumidityRatio = 0.0;
            RelativeHumidity = 0.0;
            Enthalpy = 0.0;
            SpecificVolume = 0.0;
            Density = 0.0;
            DewPoint = 0.0;
            IsDemo = false;
            IsMetric = false;
            IsAltitute = true;
            if (IsMetric)
            {
                Units = new UnitsSI(IsDemo);
            }
            else
            {
                Units = new UnitsIP(IsDemo);
            }
        }

        public void SetMetric(bool value)
        {
            IsMetric = value;

            if (IsMetric)
            {
                Units = new UnitsSI(IsDemo);
            }
            else
            {
                Units = new UnitsIP(IsDemo);
            }
        }

        public void SetAlitute(bool value)
        {
            IsAltitute = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;

            if (IsMetric)
            {
                Units = new UnitsSI(IsDemo);
            }
            else
            {
                Units = new UnitsIP(IsDemo);
            }
        }

        public bool IsValidInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            switch (CalculationType)
            {
                case CalculationType.Psychrometrics_WBT_DBT:
                    return isValid;

                case CalculationType.Psychrometrics_DBT_RH:
                    return isValid;

                case CalculationType.Psychrometrics_Enthalpy:
                    return isValid;
            }


            return isValid;
        }

        public bool IsValidAltitudeInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            if (!string.IsNullOrEmpty(AltitudeInput))
            {
                double value;
                if (double.TryParse(AltitudeInput, out value))
                {
                    Altitude = value;
                }
                else
                {
                    message = "The Altitude input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Altitude input is not a valid number";
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidTemperatureDryBulbInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            if (!string.IsNullOrEmpty(TemperatureDryBulbInput))
            {
                double value;
                if (double.TryParse(TemperatureDryBulbInput, out value))
                {
                    if ((value < Units.MinimumTemperature) || (value > Units.MaximumTemperature))
                    {
                        message = string.Format("The Temperature Wet Bulb input must be between {0} and {1}", Units.MinimumTemperature, Units.MaximumTemperature);
                        isValid = false;
                    }
                    else
                    {
                        TemperatureDryBulb = value;
                    }
                }
                else
                {
                    message = "The Temperature Dry Bulb input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Temperature Dry Bulb input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(TemperatureWetBulbInput))
            {
                double value;
                if (double.TryParse(TemperatureWetBulbInput, out value))
                {
                    if ((value < Units.MinimumTemperature) || (value > Units.MaximumTemperature))
                    {
                        message = string.Format("The Temperature Wet Bulb input must be between {0} and {1}", Units.MinimumTemperature, Units.MaximumTemperature);
                        isValid = false;
                    }
                    else
                    {
                        TemperatureWetBulb = value;
                    }
                }
                else
                {
                    message = "The Temperature Wet Bulb input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Temperature Dry Bulb input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(RelativeHumidityInput))
            {
                double value;
                if (double.TryParse(RelativeHumidityInput, out value))
                {
                    if ((value < Units.MinimumRelativeHumitity) || (value > Units.MaximumRelativeHumitity))
                    {
                        message = string.Format("The Relative Humitity input must be between {0} and {1}", Units.MinimumRelativeHumitity, Units.MaximumRelativeHumitity);
                        isValid = false;
                    }
                    else
                    {
                        RelativeHumidity = value;
                    }
                }
                else
                {
                    message = "The Relative Humitity input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Relative Humitity input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(EnthalpyInput))
            {
                double value;
                if (double.TryParse(EnthalpyInput, out value))
                {
                    if ((value < Units.MinimumEnthalpy) || (value > Units.MaximumEnthalpy))
                    {
                        message = string.Format("The Enthalpy input must be between {0} and {1}", Units.MinimumEnthalpy, Units.MaximumEnthalpy);
                        isValid = false;
                    }
                    else
                    {
                        Enthalpy = value;
                    }
                }
                else
                {
                    message = "The Enthalpy input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Enthalpy input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(BarometricPressureInput))
            {
                double value;
                if (double.TryParse(BarometricPressureInput, out value))
                {
                    if ((value < Units.MinimumBarometricPressure) || (value > Units.MaximumBarometricPressure))
                    {
                        message = string.Format("The Barometric Pressure input must be between {0} and {1}", Units.MinimumBarometricPressure, Units.MaximumBarometricPressure);
                        isValid = false;
                    }
                    else
                    {
                        BarometricPressure = value;
                    }
                }
                else
                {
                    message = "The Barometric Pressure input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Barometric Pressure input is not a valid number";
                isValid = false;
            }

            if (isValid)
            {
                if (TemperatureDryBulb < TemperatureWetBulb)
                {
                    message = "The Temperature Dry Bulb value must be greater than the Temperature Wet Bulb value";
                    isValid = false;
                }
            }

            return isValid;
        }

        public bool IsValidTemperatureWetBulbInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            if (!string.IsNullOrEmpty(TemperatureWetBulbInput))
            {
                double value;
                if (double.TryParse(TemperatureWetBulbInput, out value))
                {
                    if ((value < Units.MinimumTemperature) || (value > Units.MaximumTemperature))
                    {
                        message = string.Format("The Temperature Wet Bulb input must be between {0} and {1}", Units.MinimumTemperature, Units.MaximumTemperature);
                        isValid = false;
                    }
                    else
                    {
                        TemperatureWetBulb = value;
                    }
                }
                else
                {
                    message = "The Temperature Wet Bulb input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Temperature Dry Bulb input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(RelativeHumidityInput))
            {
                double value;
                if (double.TryParse(RelativeHumidityInput, out value))
                {
                    if ((value < Units.MinimumRelativeHumitity) || (value > Units.MaximumRelativeHumitity))
                    {
                        message = string.Format("The Relative Humitity input must be between {0} and {1}", Units.MinimumRelativeHumitity, Units.MaximumRelativeHumitity);
                        isValid = false;
                    }
                    else
                    {
                        RelativeHumidity = value;
                    }
                }
                else
                {
                    message = "The Relative Humitity input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Relative Humitity input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(EnthalpyInput))
            {
                double value;
                if (double.TryParse(EnthalpyInput, out value))
                {
                    if ((value < Units.MinimumEnthalpy) || (value > Units.MaximumEnthalpy))
                    {
                        message = string.Format("The Enthalpy input must be between {0} and {1}", Units.MinimumEnthalpy, Units.MaximumEnthalpy);
                        isValid = false;
                    }
                    else
                    {
                        Enthalpy = value;
                    }
                }
                else
                {
                    message = "The Enthalpy input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Enthalpy input is not a valid number";
                isValid = false;
            }

            if (!string.IsNullOrEmpty(BarometricPressureInput))
            {
                double value;
                if (double.TryParse(BarometricPressureInput, out value))
                {
                    if ((value < Units.MinimumBarometricPressure) || (value > Units.MaximumBarometricPressure))
                    {
                        message = string.Format("The Barometric Pressure input must be between {0} and {1}", Units.MinimumBarometricPressure, Units.MaximumBarometricPressure);
                        isValid = false;
                    }
                    else
                    {
                        BarometricPressure = value;
                    }
                }
                else
                {
                    message = "The Barometric Pressure input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Barometric Pressure input is not a valid number";
                isValid = false;
            }

            if (isValid)
            {
                if (TemperatureDryBulb < TemperatureWetBulb)
                {
                    message = "The Temperature Dry Bulb value must be greater than the Temperature Wet Bulb value";
                    isValid = false;
                }
            }

            return isValid;
        }

        public bool IsValidRelativeHumidityInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            if (!string.IsNullOrEmpty(RelativeHumidityInput))
            {
                double value;
                if (double.TryParse(RelativeHumidityInput, out value))
                {
                    if ((value < Units.MinimumRelativeHumitity) || (value > Units.MaximumRelativeHumitity))
                    {
                        message = string.Format("The Relative Humitity input must be between {0} and {1}", Units.MinimumRelativeHumitity, Units.MaximumRelativeHumitity);
                        isValid = false;
                    }
                    else
                    {
                        RelativeHumidity = value;
                    }
                }
                else
                {
                    message = "The Relative Humitity input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Relative Humitity input is not a valid number";
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidEnthalpyInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            if (!string.IsNullOrEmpty(EnthalpyInput))
            {
                double value;
                if (double.TryParse(EnthalpyInput, out value))
                {
                    if ((value < Units.MinimumEnthalpy) || (value > Units.MaximumEnthalpy))
                    {
                        message = string.Format("The Enthalpy input must be between {0} and {1}", Units.MinimumEnthalpy, Units.MaximumEnthalpy);
                        isValid = false;
                    }
                    else
                    {
                        Enthalpy = value;
                    }
                }
                else
                {
                    message = "The Enthalpy input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Enthalpy input is not a valid number";
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidBarometricPressureInput(out string message)
        {
            bool isValid = true;
            message = string.Empty;

            if (!string.IsNullOrEmpty(BarometricPressureInput))
            {
                double value;
                if (double.TryParse(BarometricPressureInput, out value))
                {
                    if ((value < Units.MinimumBarometricPressure) || (value > Units.MaximumBarometricPressure))
                    {
                        message = string.Format("The Barometric Pressure input must be between {0} and {1}", Units.MinimumBarometricPressure, Units.MaximumBarometricPressure);
                        isValid = false;
                    }
                    else
                    {
                        BarometricPressure = value;
                    }
                }
                else
                {
                    message = "The Barometric Pressure input is not a valid number";
                    isValid = false;
                }
            }
            else
            {
                message = "The Barometric Pressure input is not a valid number";
                isValid = false;
            }

            if (isValid)
            {
                if (TemperatureDryBulb < TemperatureWetBulb)
                {
                    message = "The Temperature Dry Bulb value must be greater than the Temperature Wet Bulb value";
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}