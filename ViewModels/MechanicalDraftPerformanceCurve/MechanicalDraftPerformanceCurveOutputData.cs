// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.IO;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveOutputData
    {
        NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        Units Units { get; set; }

        public MechanicalDraftPerformanceCurveOutputData(bool isInternationalSystemOfUnits_IS_)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            if (isInternationalSystemOfUnits_IS_)
            {
                Units = new UnitsIS();
            }
            else
            {
                Units = new UnitsIP();
            }
        }

        public void FillTable(MechanicalDraftPerformanceCurveOutputData data)
        {
            NameValueUnitsDataTable.DataTable.Clear();

            //NameValueUnitsDataTable.AddRow("KaV/L", data.KaV_L.ToString("F5"), string.Empty);
        }
    }
}