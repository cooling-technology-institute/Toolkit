using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignCurveInputData
    {
        public WaterFlowRateDataValue WaterFlowRateDataValue { get; set; }
        public List<WetBulbTemperatureDataValue> WetBulbTemperatureDataValues { get; set; }
        public List<MechanicalDraftPerformanceCurveTowerDesignFlowRateInputData> FlowRateInputData { get; set; }
    }
}
