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

        public PsychrometricsData(bool isMetric, bool isAltitute, bool isDemo = false)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            BarometricPressure = 0.0;
            HumidityRatio = 0.0;
            RelativeHumidity = 0.0;
            Enthalpy = 0.0;
            SpecificVolume = 0.0;
            Density = 0.0;
            DewPoint = 0.0;
            IsDemo = isDemo;
            IsMetric = isMetric;
            IsAltitute = isAltitute;
            if (IsMetric)
            {
                Units = new UnitsSI(isDemo);
            }
            else
            {
                Units = new UnitsIP(isDemo);
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

    public class PsychrometricsCalculationLibrary
    {
        public static DataTable PsychrometricsCalculation(PsychrometricsData data)
        {
            switch (data.CalculationType)
            {
                case CalculationType.Psychrometrics_WBT_DBT:
                    return Psychrometrics_WBT_DBT_Calculation(data);

                case CalculationType.Psychrometrics_DBT_RH:
                    return Psychrometrics_DBT_RH_Calculation(data);

                case CalculationType.Psychrometrics_Enthalpy:
                    return Psychrometrics_Enthalpy_Calculation(data);
            }
            return null;
        }

        public static DataTable Psychrometrics_WBT_DBT_Calculation(PsychrometricsData data)
        {
            //if (TPropPageBase::CheckData()) return;

            //double p;
            //double altitude = m_dblAltitude;
            //double TWB = m_dblPsychWBT;
            //double TDB = m_dblPsychDBT;
            //double HumidRatio;
            //double RelHumid;
            //double Enthalpy;
            //double SpVolume;
            //double Density;
            //double DEWPoint;

            try
            {
                if (data.IsMetric)
                {
                    // metric
                    //{
                    //    p = Altitude2KPA(m_dblAltitude);
                    //    CalcSIProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                    //    UnitsTemperature = pszSITemp;
                    //    UnitsEnthalpy = pszSIEnthrapy;
                    //    UnitsDensity = pszSIDensity;
                    //    UnitsVolume = pszSISPVolume;
                    //    UnitsHumidity = pszSIHumidityRatio;
                    //    if (Enthalpy > 6030) Enthalpy = -999;
                    //}

                    if (data.IsAltitute)
                    {
                        data.BarometricPressure = UnitConverter.ConvertAltitudeToKilopascal(data.Altitude);
                    }

                    CalculationLibrary.CalculatePropertiesSI(data);

                    if (data.Enthalpy > 6030)
                    {
                        data.Enthalpy = -999.0;
                    }
                }
                else
                {
                    //{
                    //    p = Altitude2PSI(m_dblAltitude);
                    //    CalcIPProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                    //    UnitsTemperature = pszIPTemp;
                    //    UnitsEnthalpy = pszIPEnthrapy;
                    //    UnitsDensity = pszIPDensity;
                    //    UnitsVolume = pszIPSPVolume;
                    //    UnitsHumidity = pszIPHumidityRatio;
                    //    if (Enthalpy > 2758) Enthalpy = -999;
                    //}


                    if (data.IsAltitute)
                    {
                        data.BarometricPressure = UnitConverter.ConvertAltitudeToPsi(data.Altitude);
                    }

                    CalculationLibrary.CalculatePropertiesIP(data);

                    if (data.Enthalpy > 2758)
                    {
                        data.Enthalpy = -999.0;
                    }

                    data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Calculation exception: {0}", e.Message));
            }

            return Psychrometrics_CheckCalculationValues(data);
        }

        public static DataTable Psychrometrics_DBT_RH_Calculation(PsychrometricsData data)
        {
            //if (!TPropPageBase::metricflag)
            //{
            //    p = Altitude2PSI(m_dblAltitude);
            //    IPWBsearch(p, TWB / 100, TDB, TWB);
            //    CalcIPProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
            //    UnitsTemperature = pszIPTemp;
            //    UnitsEnthalpy = pszIPEnthrapy;
            //    UnitsDensity = pszIPDensity;
            //    UnitsVolume = pszIPSPVolume;
            //    UnitsHumidity = pszIPHumidityRatio;
            //}
            //else
            //{
            //    p = Altitude2KPA(m_dblAltitude);
            //    SIWBsearch(p, TWB / 100, TDB, TWB);
            //    CalcSIProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
            //    UnitsTemperature = pszSITemp;
            //    UnitsEnthalpy = pszSIEnthrapy;
            //    UnitsDensity = pszSIDensity;
            //    UnitsVolume = pszSISPVolume;
            //    UnitsHumidity = pszSIHumidityRatio;
            //}

            //RelHumid = m_dblRelHumidity;

            //if ((RelHumid < 0) || (Enthalpy < 0) || (SpVolume < 0) || (HumidRatio < 0))
            //{
            //    AfxMessageBox("Thermodynamically impossible combination of RH & DBT", MB_ICONEXCLAMATION);
            //}
            //else
            //{
            //    int x = 0;
            //    if (!TPropPageBase::metricflag)
            //        strTemp.Format("%.4f", calcPressureF(p));
            //    else
            //        strTemp.Format("%.4f", p);
            //    m_wndPsychResults.AddItem(x, 0, "Barometric Pressure");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    if (!TPropPageBase::metricflag)
            //    {
            //        m_wndPsychResults.AddItem(x++, 2, L_HG);
            //    }
            //    else
            //    {
            //        m_wndPsychResults.AddItem(x++, 2, L_KPA);
            //    }

            //    strTemp.Format("%.2f", m_dblAltitude);
            //    m_wndPsychResults.AddItem(x, 0, "Altitude above MSL");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    if (!TPropPageBase::metricflag)
            //    {
            //        m_wndPsychResults.AddItem(x++, 2, L_FEET);
            //    }
            //    else
            //    {
            //        m_wndPsychResults.AddItem(x++, 2, L_METERS);
            //    }

            //    strTemp.Format("%.2f", TDB);
            //    m_wndPsychResults.AddItem(x, 0, "Dry Bulb Temperature");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsTemperature);

            //    strTemp.Format("%.2f", TWB);
            //    m_wndPsychResults.AddItem(x, 0, "Wet Bulb Temperature");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsTemperature);

            //    strTemp.Format("%.4f", Enthalpy);
            //    m_wndPsychResults.AddItem(x, 0, "Enthalpy");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsEnthalpy);

            //    strTemp.Format("%.2f", DEWPoint);
            //    m_wndPsychResults.AddItem(x, 0, "Dew Point");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsTemperature);

            //    strTemp.Format("%.2f", RelHumid);
            //    m_wndPsychResults.AddItem(x, 0, "Relative Humidity");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, pszPercent);

            //    strTemp.Format("%.5f", Density);
            //    m_wndPsychResults.AddItem(x, 0, "Density");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsDensity);

            //    strTemp.Format("%.5f", SpVolume);
            //    m_wndPsychResults.AddItem(x, 0, "Specific Volume");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsVolume);

            //    strTemp.Format("%.5f", HumidRatio);
            //    m_wndPsychResults.AddItem(x, 0, "Humidity Ratio");
            //    m_wndPsychResults.AddItem(x, 1, strTemp);
            //    m_wndPsychResults.AddItem(x++, 2, UnitsHumidity);

            //    m_wndPsychResults.SetColumnWidth(0, LVSCW_AUTOSIZE);
            //    m_wndPsychResults.SetColumnWidth(1, LVSCW_AUTOSIZE);
            //    m_wndPsychResults.SetColumnWidth(2, LVSCW_AUTOSIZE);
            //}
            try
            {
                if (data.IsMetric)
                {
                    //    p = Altitude2KPA(m_dblAltitude);
                    //    SIWBsearch(p, TWB / 100, TDB, TWB);
                    //    CalcSIProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                    //    UnitsTemperature = pszSITemp;
                    //    UnitsEnthalpy = pszSIEnthrapy;
                    //    UnitsDensity = pszSIDensity;
                    //    UnitsVolume = pszSISPVolume;
                    //    UnitsHumidity = pszSIHumidityRatio;

                    if (data.IsAltitute)
                    {
                        data.BarometricPressure = UnitConverter.ConvertAltitudeToKilopascal(data.Altitude);
                    }

                    data.TemperatureWetBulb = CalculationLibrary.CalculateTemperatureWetBulbSI(data.BarometricPressure, data.RelativeHumidity / 100, data.TemperatureDryBulb);

                    CalculationLibrary.CalculatePropertiesSI(data);
                }
                else
                {
                    //    p = Altitude2PSI(m_dblAltitude);
                    //    IPWBsearch(p, TWB / 100, TDB, TWB);
                    //    CalcIPProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                    //    UnitsTemperature = pszIPTemp;
                    //    UnitsEnthalpy = pszIPEnthrapy;
                    //    UnitsDensity = pszIPDensity;
                    //    UnitsVolume = pszIPSPVolume;
                    //    UnitsHumidity = pszIPHumidityRatio;


                    if (data.IsAltitute)
                    {
                        data.BarometricPressure = UnitConverter.ConvertAltitudeToPsi(data.Altitude);
                    }

                    data.TemperatureWetBulb = CalculationLibrary.CalculateTemperatureWetBulbIP(data.BarometricPressure, data.RelativeHumidity / 100, data.TemperatureDryBulb);
                    //data.TemperatureWetBulb = CalculationLibrary.CalculateTemperatureWetBulbIP(data);

                    CalculationLibrary.CalculatePropertiesIP(data);

                    data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Calculation exception: {0}", e.Message));
            }

            return Psychrometrics_CheckCalculationValues(data);
        }

        public static DataTable Psychrometrics_Enthalpy_Calculation(PsychrometricsData data)
        {
            data.Enthalpy = 43.46;
            data.SpecificVolume = -999;
            data.Density = -999;
            data.DewPoint = -999;
            data.TemperatureDryBulb = data.Enthalpy;
            data.TemperatureWetBulb = 80.0;

            try
            {
                if (data.IsMetric)
                {
                    //TWB = 0;
                    //p = Altitude2KPA(m_dblAltitude);
                    //void SIEnthalpysearch (int sat,
                    //                       double p,
                    //                       double RootEnthalpy,
                    //                       double&OutputEnthalpy,
                    //                       double & TWB,
                    //                       double & TDB,
                    //                       double HumidRatio,
                    //                       double RelHumid,
                    //                       double SpVolume,
                    //                       double Density,
                    //                       double DEWPoint
                    //   )
                    //SIEnthalpysearch(1, p, TDB, OutH, TWB, TDB, IPHR, IPRH, SpVolume, Density, DEWPoint);
                    //SIEnthalpysearch(1, BarometricPressure, EnthalpyIn, ref EnthalpyOut, ref TWB, ref TDB, IPHR, IPRH, SpecificVolume, Density, DewPoint);
                    //CalcSIProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                    //Enthalpy = m_dblEnthalpy;
                    //UnitsTemperature = pszSITemp;
                    //UnitsEnthalpy = pszSIEnthrapy;
                    //UnitsDensity = pszSIDensity;
                    //UnitsVolume = pszSISPVolume;
                    //UnitsHumidity = pszSIHumidityRatio;

                    if (data.IsAltitute)
                    {
                        data.BarometricPressure = UnitConverter.ConvertAltitudeToKilopascal(data.Altitude);
                    }

                    CalculationLibrary.EnthalpySI(1, data);
                    //CalculationLibrary.EnthalpySI(1, 
                    //    data.BarometricPressure, 
                    //    data.Enthalpy, 
                    //    ref dataEnthalpy, 
                    //    ref dataTemperatureWetBulb, 
                    //    ref dataTemperatureDryBulb, 
                    //    data.HumidityRatio, 
                    //    data.RelativeHumidity, 
                    //    data.SpecificVolume, 
                    //    data.Density, 
                    //    data.DewPoint);

                    CalculationLibrary.CalculatePropertiesSI(data);
                }
                else
                {
                    //p = Altitude2PSI(m_dblAltitude);
                    //void IPEnthalpysearch (int sat,
                    //                       double p,
                    //                       double RootEnthalpy,
                    //                       double&OutputEnthalpy,
                    //                       double & TWB,
                    //                       double & TDB,
                    //                       double HumidRatio,
                    //                       double RelHumid,
                    //                       double SpVolume,
                    //                       double Density,
                    //                       double DEWPoint)
                    //IPEnthalpysearch(1, p, TDB, OutH, TWB, TDB, IPHR, IPRH, SpVolume, Density, DEWPoint);
                    //CalcIPProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                    //Enthalpy = m_dblEnthalpy;
                    //UnitsTemperature = pszIPTemp;
                    //UnitsEnthalpy = pszIPEnthrapy;
                    //UnitsDensity = pszIPDensity;
                    //UnitsVolume = pszIPSPVolume;
                    //UnitsHumidity = pszIPHumidityRatio;


                    if (data.IsAltitute)
                    {
                        data.BarometricPressure = UnitConverter.ConvertAltitudeToPsi(data.Altitude);
                    }

                    CalculationLibrary.EnthalpyIP(1, data);

                    //CalculationLibrary.EnthalpyIP(1, 
                    //    data.BarometricPressure, 
                    //    data.Enthalpy, 
                    //    ref dataEnthalpy, 
                    //    ref dataTemperatureWetBulb, 
                    //    ref dataTemperatureDryBulb, 
                    //    data.HumidityRatio, 
                    //    data.RelativeHumidity, 
                    //    data.SpecificVolume, 
                    //    data.Density, 
                    //    data.DewPoint);

                    CalculationLibrary.CalculatePropertiesIP(data);

                    data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Calculation exception: {0}", e.Message));
            }

            return Psychrometrics_CheckCalculationValues(data);
        }

        public static DataTable Psychrometrics_CheckCalculationValues(PsychrometricsData data)
        {
            if ((data.RelativeHumidity < 0) || (data.Enthalpy < 0) || (data.SpecificVolume < 0) || (data.HumidityRatio < 0))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Calculation returned invalid data. Check the input values.");
                if (data.RelativeHumidity < 0)
                {
                    sb.AppendLine(string.Format("Relative Humidity is less than zero. Value: {0}", (data.RelativeHumidity * 100.00).ToString("F2")));
                }
                if (data.Enthalpy < 0)
                {
                    sb.AppendLine(string.Format("Enthalpy is less than zero. Value: {0}", data.Enthalpy.ToString("F4")));
                }
                if (data.SpecificVolume < 0)
                {
                    sb.AppendLine(string.Format("Specific Volume is less than zero. Value: {0}", data.SpecificVolume.ToString("F4")));
                }
                if (data.HumidityRatio < 0)
                {
                    sb.AppendLine(string.Format("Humidity Ratio is less than zero. Value: {0}", data.HumidityRatio.ToString("F5")));
                }
                MessageBox.Show(sb.ToString());
                return null;
            }
            else
            {
                //data.BarometricPressure = truncit(data.BarometricPressure, 5);
                data.NameValueUnitsDataTable.AddRow("Barometric Pressure", data.BarometricPressure.ToString("F4"), data.Units.BarometricPressure);
                data.NameValueUnitsDataTable.AddRow("Altitute above MSL", data.Altitude.ToString(), data.Units.Foot);
                data.NameValueUnitsDataTable.AddRow("Dry Bulb Temperature", data.TemperatureDryBulb.ToString("F2"), data.Units.Temperature);
                data.NameValueUnitsDataTable.AddRow("Wet Bulb Temperature", data.TemperatureWetBulb.ToString("F2"), data.Units.Temperature);
                data.NameValueUnitsDataTable.AddRow("Enthalpy", data.Enthalpy.ToString("F4"), data.Units.Enthalpy);
                data.NameValueUnitsDataTable.AddRow("Dew Point", data.DewPoint.ToString("F2"), data.Units.Temperature);
                data.NameValueUnitsDataTable.AddRow("Relative Humidity", (data.RelativeHumidity * 100.00).ToString("F2"), data.Units.Percent);
                data.NameValueUnitsDataTable.AddRow("Density", data.Density.ToString("F4"), data.Units.Density);
                data.NameValueUnitsDataTable.AddRow("Specific Volume", data.SpecificVolume.ToString("F4"), data.Units.SpecificVolume);
                data.NameValueUnitsDataTable.AddRow("Humidity Ratio", data.HumidityRatio.ToString("F4"), data.Units.HumidityRatio);
            }
            return data.NameValueUnitsDataTable.DataTable;
        }
    }
}