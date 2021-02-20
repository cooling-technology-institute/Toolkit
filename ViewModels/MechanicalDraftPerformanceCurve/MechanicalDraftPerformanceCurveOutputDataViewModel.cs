// Copyright Cooling Technology Institute 2019-2021

using Models;

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

        public void FillTable(MechanicalDraftPerformanceCurveOutput data)
        {
            NameValueUnitsDataTable.DataTable.Clear();
            NameValueUnitsDataTable.AddRow("Adjusted Flow", data.AdjustedFlow.ToString("F1"), Units.FlowRate);
            NameValueUnitsDataTable.AddRow("Predicted Flow", data.PredictedFlow.ToString("F1"), Units.FlowRate);
            NameValueUnitsDataTable.AddRow("Tower Capability", data.TowerCapability.ToString("F2"), ConstantUnits.Percentage);
            NameValueUnitsDataTable.AddRow("Cold Water Temperature Deviation", data.ColdWaterTemperatureDeviation.ToString("1"), Units.Temperature);
        }
    }
}