using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ToolkitLibrary
{
    public class DemandCurveCalculationLibrary
    {
        public static DataTable DemandCurveCalculation(DemandCurveData data)
        {
            try
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
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Calculation exception: {0}", e.Message));
            }

            //double WBT = m_dblDemandCurveWBT;
            //double LG = m_dblDemandCurveLG;
            //double dblrange = m_dblDemandCurveT1 - m_dblDemandCurveT2;
            //double approach = m_dblDemandCurveT2 - m_dblDemandCurveWBT;
            //double altitude = m_dblDemandCurveAltitude;
            //double T1 = m_dblDemandCurveT1;
            //double T2 = m_dblDemandCurveT2;


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

            CalculationLibrary.CalculateDemandCurve(data);

            return DemandCurve_CheckCalculationValues(data);
        }

        public static DataTable DemandCurve_CheckCalculationValues(DemandCurveData data)
        {
            data.NameValueUnitsDataTable.DataTable.Clear();

            //data.BarometricPressure = truncit(data.BarometricPressure, 5);
            data.NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F5"), string.Empty);

            return data.NameValueUnitsDataTable.DataTable;
        }
    }
}