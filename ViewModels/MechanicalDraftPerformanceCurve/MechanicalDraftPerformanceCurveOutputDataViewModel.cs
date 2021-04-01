// Copyright Cooling Technology Institute 2019-2021

using Models;
using System.Data;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveOutputDataViewModel
    {
        public MechanicalDraftPerformanceCurveOutput MechanicalDraftPerformanceCurveOutput { get; set; }
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        public Units Units { get; set; }

        public MechanicalDraftPerformanceCurveOutputDataViewModel(bool isInternationalSystemOfUnits_IS_)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();

            MechanicalDraftPerformanceCurveOutput = new MechanicalDraftPerformanceCurveOutput();

            if (isInternationalSystemOfUnits_IS_)
            {
                Units = new UnitsIS();
            }
            else
            {
                Units = new UnitsIP();
            }
        }

        public void FillTable()
        {
            NameValueUnitsDataTable.DataTable.Clear();
            NameValueUnitsDataTable.AddRow("Adjusted Flow", MechanicalDraftPerformanceCurveOutput.AdjustedFlow.ToString("F1"), Units.FlowRate);
            NameValueUnitsDataTable.AddRow("Predicted Flow", MechanicalDraftPerformanceCurveOutput.PredictedFlow.ToString("F1"), Units.FlowRate);
            NameValueUnitsDataTable.AddRow("Tower Capability", MechanicalDraftPerformanceCurveOutput.TowerCapability.ToString("F2"), ConstantUnits.Percentage);
            NameValueUnitsDataTable.AddRow("Cold Water Temperature Deviation", MechanicalDraftPerformanceCurveOutput.ColdWaterTemperatureDeviation.ToString("F1"), Units.Temperature);
        }

        public DataTable GetDataTable()
        {
            return NameValueUnitsDataTable.DataTable;
        }
    }
}