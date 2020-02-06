// Copyright Cooling Technology Institute 2019-2020

using Models;
using System.Text;

namespace CalculationLibrary
{
    public class PsychrometricsCalculationLibrary
    {
        public bool PsychrometricsCalculation(PsychrometricsData data, out string errorMessage)
        {
            switch (data.CalculationType)
            {
                case PsychrometricsCalculationType.Psychrometrics_WetBulbTemperature_DryBulbTemperature:
                    return Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(data, out errorMessage);

                case PsychrometricsCalculationType.Psychrometrics_DryBulbTemperature_RelativeHumidity:
                    return Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation(data, out errorMessage);

                case PsychrometricsCalculationType.Psychrometrics_Enthalpy:
                    return Psychrometrics_Enthalpy_Calculation(data, out errorMessage);

                default:
                    errorMessage = "Calculation Type is invalid";
                    return false;
            }
        }

        public bool Psychrometrics_WetBulbTemperature_DryBulbTemperature_Calculation(PsychrometricsData data, out string errorMessage)
        {
            //if (TPropPageBase::CheckData()) return;

            //double p;
            //double altitude = m_dblElevation;
            //double TWB = m_dblPsychWBT;
            //double TDB = m_dblPsychDBT;
            //double HumidRatio;
            //double RelHumid;
            //double Enthalpy;
            //double SpVolume;
            //double Density;
            //double DEWPoint;

            if (data.IsInternationalSystemOfUnits_SI_)
            {
                // metric
                //{
                //    p = Elevation2KPA(m_dblElevation);
                //    CalcSIProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                //    UnitsTemperature = pszSITemp;
                //    UnitsEnthalpy = pszSIEnthrapy;
                //    UnitsDensity = pszSIDensity;
                //    UnitsVolume = pszSISPVolume;
                //    UnitsHumidity = pszSIHumidityRatio;
                //    if (Enthalpy > 6030) Enthalpy = -999;
                //}

                if (data.IsElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInMetersToKilopascal(data.Elevation);
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
                //    p = Elevation2PSI(m_dblElevation);
                //    CalcIPProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                //    UnitsTemperature = pszIPTemp;
                //    UnitsEnthalpy = pszIPEnthrapy;
                //    UnitsDensity = pszIPDensity;
                //    UnitsVolume = pszIPSPVolume;
                //    UnitsHumidity = pszIPHumidityRatio;
                //    if (Enthalpy > 2758) Enthalpy = -999;
                //}


                if (data.IsElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInFeetToBarometricPressure(data.Elevation);
                }

                CalculationLibrary.CalculatePropertiesIP(data);

                if (data.Enthalpy > 2758)
                {
                    data.Enthalpy = -999.0;
                }

                data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
            }

            return Psychrometrics_CheckCalculationValues(data, out errorMessage);
        }

        public bool Psychrometrics_DryBulbTemperature_RelativeHumidity_Calculation(PsychrometricsData data, out string errorMessage)
        {
            if (data.IsInternationalSystemOfUnits_SI_)
            {
                //    p = Elevation2KPA(m_dblElevation);
                //    SIWBsearch(p, TWB / 100, TDB, TWB);
                //    CalcSIProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                //    UnitsTemperature = pszSITemp;
                //    UnitsEnthalpy = pszSIEnthrapy;
                //    UnitsDensity = pszSIDensity;
                //    UnitsVolume = pszSISPVolume;
                //    UnitsHumidity = pszSIHumidityRatio;

                if (data.IsElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInMetersToKilopascal(data.Elevation);
                }

                data.WetBulbTemperature = CalculationLibrary.CalculateTemperatureWetBulbSI(data.BarometricPressure, data.RelativeHumidity / 100, data.DryBulbTemperature);

                CalculationLibrary.CalculatePropertiesSI(data);
            }
            else
            {
                //    p = Elevation2PSI(m_dblElevation);
                //    IPWBsearch(p, TWB / 100, TDB, TWB);
                //    CalcIPProperties(p, TWB, TDB, HumidRatio, RelHumid, Enthalpy, SpVolume, Density, DEWPoint);
                //    UnitsTemperature = pszIPTemp;
                //    UnitsEnthalpy = pszIPEnthrapy;
                //    UnitsDensity = pszIPDensity;
                //    UnitsVolume = pszIPSPVolume;
                //    UnitsHumidity = pszIPHumidityRatio;


                if (data.IsElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInFeetToBarometricPressure(data.Elevation);
                }

                data.WetBulbTemperature = CalculationLibrary.CalculateTemperatureWetBulbIP(data.BarometricPressure, data.RelativeHumidity / 100, data.DryBulbTemperature);
                //data.TemperatureWetBulb = CalculationLibrary.CalculateTemperatureWetBulbIP(data);

                CalculationLibrary.CalculatePropertiesIP(data);

                data.BarometricPressure = UnitConverter.CalculatePressureFahrenheit(data.BarometricPressure);
            }

            return Psychrometrics_CheckCalculationValues(data, out errorMessage);
        }

        public bool Psychrometrics_Enthalpy_Calculation(PsychrometricsData data, out string errorMessage)
        {
            data.SpecificVolume = -999;
            data.Density = -999;
            data.DewPoint = -999;
            data.DryBulbTemperature = data.Enthalpy;

            if (data.IsInternationalSystemOfUnits_SI_)
            {
                //TWB = 0;
                //p = Elevation2KPA(m_dblElevation);
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

                if (data.IsElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInMetersToKilopascal(data.Elevation);
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
                //p = Elevation2PSI(m_dblElevation);
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


                if (data.IsElevation)
                {
                    data.BarometricPressure = UnitConverter.ConvertElevationInFeetToBarometricPressure(data.Elevation);
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

            return Psychrometrics_CheckCalculationValues(data, out errorMessage);
        }

        public bool Psychrometrics_CheckCalculationValues(PsychrometricsData data, out string errorMessage)
        {
            errorMessage = string.Empty;

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
                errorMessage = sb.ToString();
            }
            return string.IsNullOrEmpty(errorMessage);
        }
    }
}