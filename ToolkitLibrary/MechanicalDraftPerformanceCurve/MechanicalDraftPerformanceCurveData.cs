using System;
using System.Data;
using System.Text;

namespace ToolkitLibrary
{
    public class MechanicalDraftPerformanceCurveData
    {
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }

		public enum TOWER_TYPE
		{
			Forced,
			Induced
		}
        public string OwnerName { set; get; }
        public string ProjectName { set; get; }
        public string Location { set; get; }
        public string TowerManufacturer { set; get; }
        public string TowerType { set; get; }

        public double ColdWaterTemperature { set; get; }
        public double HotWaterTemperature { set; get; }
        public double WetBulbTemperature { set; get; } 
        public double DryBulbTemperature { set; get; }
        public double FanDrivePower { set; get; }
        public double BarometricPressure { set; get; }
        public double LiquidToGasRatio { set; get; }
        public double WaterFlowRate { set; get; }

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS_ { get; set; }

		public List<string> MechanicalDraftPerformanceCurveFileList { get; set;}
		public MechanicalDraftPerformanceCurveInputData { get; set; }
		
        //public MechanicalDraftPerformanceCurveData(bool isInternationalSystemOfUnits_IS_, bool isElevation, bool isDemo = false)
        public MechanicalDraftPerformanceCurveData(bool isInternationalSystemOfUnits_IS_)
        {
            NameValueUnitsDataTable = new NameValueUnitsDataTable();
            HotWaterTemperature = 0.0;
            ColdWaterTemperature = 0.0;
            WaterAirRatio = 0.0;
            BarometricPressure = 0.0;

            IsDemo = false;
            IsInternationalSystemOfUnits_IS_ = isInternationalSystemOfUnits_IS_;
            IsElevation = true;
            SetUnits();
			
			MechanicalDraftPerformanceCurveFileList = new List<string>();
        }
		
		public ReadDataFile(string fileName)
		{
			// check that file exists
			// JsonSerialize from file
			// if does not serialize the try to convert old file to json
			// if converted save as jaon
			// update data and page
		}
		
		public SaveDataFile(string fileName)
		{
			// if file ext is *.bbp
			//   write as json
			//   update filename is list
			
			// else
			//   check that file exists
			//   if it does ask to overwrite ok
			//   JsonSerialize data to file
		}

        private void SetUnits()
        {
            if (IsInternationalSystemOfUnits_IS_)
            {
                Units = new UnitsSI();
            }
            else
            {
                Units = new UnitsIP();
            }
        }
		
        private void BuildFileList()
        {
			// open directory
			// foreach file with extension "*.bbp" and *.pfd.json
			//   add to list
        }

        public void SetInternationalSystemOfUnits_IS_(bool value)
        {
            IsInternationalSystemOfUnits_IS_ = value;
            SetUnits();
        }

        public void SetElevation(bool value)
        {
            IsElevation = value;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
            SetUnits();
        }
    }
}