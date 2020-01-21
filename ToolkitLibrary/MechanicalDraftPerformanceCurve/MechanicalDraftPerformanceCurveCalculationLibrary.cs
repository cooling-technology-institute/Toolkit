using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class MechanicalDraftPerformanceCurveCalculationLibrary
    {
        public static DataTable MechanicalDraftPerformanceCurveCalculation(MechanicalDraftPerformanceCurveData data)
        {
            if (data.IsInternationalSystemOfUnits_IS_)
            {
                //    WBT = fnCelcToFar(WBT);
                //    T1 = fnCelcToFar(T1);
                //    T2 = fnCelcToFar(T2);
                data.WetBulbTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.WetBulbTemperature);
                data.ColdWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.ColdWaterTemperature);
                data.HotWaterTemperature = UnitConverter.ConvertCelsiusToFahrenheit(data.HotWaterTemperature);

                if (!data.IsElevation)
                {
                    data.Elevation = UnitConverter.ConvertMetersToFeet(UnitConverter.ConvertKilopascalToElevationInMeters(data.BarometricPressure));
                }
            }
            else
            {
                if (!data.IsElevation)
                {
                    data.Elevation = UnitConverter.ConvertBarometricPressureToElevationInFeet(UnitConverter.CalculatePressureCelcius(data.BarometricPressure));
                }
            }

            //double WBT = m_dblMechanicalDraftPerformanceCurveWBT;
            //double LG = m_dblMechanicalDraftPerformanceCurveLG;
            //double dblrange = m_dblMechanicalDraftPerformanceCurveT1 - m_dblMechanicalDraftPerformanceCurveT2;
            //double approach = m_dblMechanicalDraftPerformanceCurveT2 - m_dblMechanicalDraftPerformanceCurveWBT;
            //double altitude = m_dblMechanicalDraftPerformanceCurveAltitude;
            //double T1 = m_dblMechanicalDraftPerformanceCurveT1;
            //double T2 = m_dblMechanicalDraftPerformanceCurveT2;


            //if (TPropPageBase::metricflag)
            //{
            //    WBT = fnCelcToFar(WBT);
            //    T1 = fnCelcToFar(T1);
            //    T2 = fnCelcToFar(T2);
            //    dblrange = T1 - T2;
            //    approach = T2 - WBT;
            //    altitude = fnMetersToFeet(altitude);
            //}

            data.Range = data.HotWaterTemperature - data.ColdWaterTemperature;
            data.Approach = data.ColdWaterTemperature - data.WetBulbTemperature;

            CalculationLibrary.CalculateMechanicalDraftPerformanceCurve(data);

            return MechanicalDraftPerformanceCurve_CheckCalculationValues(data);
        }

        public static DataTable MechanicalDraftPerformanceCurve_CheckCalculationValues(MechanicalDraftPerformanceCurveData data)
        {
            data.NameValueUnitsDataTable.DataTable.Clear();

            //data.BarometricPressure = truncit(data.BarometricPressure, 5);
            data.NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F5"), string.Empty);

            return data.NameValueUnitsDataTable.DataTable;
        }
    }
}