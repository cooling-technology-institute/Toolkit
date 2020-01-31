// Copyright Cooling Technology Institute 2019-2020

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveTowerDesignViewModel
    {
        public MechanicalDraftPerformanceCurveTowerDesignInputData MechanicalDraftPerformanceCurveTowerDesignInputData { get; set; }

        private bool IsDemo { get; set; }
        private bool IsInternationalSystemOfUnits_IS { get; set; }

        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueTooltip
        {
            get
            {
                return MechanicalDraftPerformanceCurveTowerDesignInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public MechanicalDraftPerformanceCurveTowerDesignViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = IsInternationalSystemOfUnits_IS;

            MechanicalDraftPerformanceCurveTowerDesignInputData = new MechanicalDraftPerformanceCurveTowerDesignInputData(IsDemo, IsInternationalSystemOfUnits_IS);
        }
    }
}
