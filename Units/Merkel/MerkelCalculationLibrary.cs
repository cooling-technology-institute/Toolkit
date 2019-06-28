using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class MerkelCalculationLibrary
    {
        public static DataTable MerkelCalculation(MerkelData data)
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

            //double WBT = m_dblMerkelWBT;
            //double LG = m_dblMerkelLG;
            //double dblrange = m_dblMerkelT1 - m_dblMerkelT2;
            //double approach = m_dblMerkelT2 - m_dblMerkelWBT;
            //double altitude = m_dblMerkelAltitude;
            //double T1 = m_dblMerkelT1;
            //double T2 = m_dblMerkelT2;


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

            CalculationLibrary.CalculateMerkel(data);

            return Merkel_CheckCalculationValues(data);
        }

        public static DataTable Merkel_CheckCalculationValues(MerkelData data)
        {
            data.NameValueUnitsDataTable.DataTable.Clear();

            //data.BarometricPressure = truncit(data.BarometricPressure, 5);
            data.NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F5"), string.Empty);

            return data.NameValueUnitsDataTable.DataTable;
        }
    }
}