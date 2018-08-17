using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ToolkitLibrary
{
    public class MerkelCalculationLibrary
    {
        public static DataTable MerkelCalculation(MerkelData data)
        {
            try
            {
                if (data.IsInternationalSystemOfUnits_IS_)
                {
                    if (data.IsElevation)
                    {
                        data.BarometricPressure = UnitConverter.ConvertElevationToKilopascal(data.Elevation);
                    }
                }
                else
                {
                    if (data.IsElevation)
                    {
                        data.BarometricPressure = UnitConverter.ConvertElevationToBarometricPressure(data.Elevation);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Calculation exception: {0}", e.Message));
            }

            CalculationLibrary.CalculateMerkel(data);

            return Merkel_CheckCalculationValues(data);
        }

        public static DataTable Merkel_CheckCalculationValues(MerkelData data)
        {
            data.NameValueUnitsDataTable.DataTable.Clear();

            //data.BarometricPressure = truncit(data.BarometricPressure, 5);
            data.NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F4"), string.Empty);

            return data.NameValueUnitsDataTable.DataTable;
        }
    }
}