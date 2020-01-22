using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ToolkitLibrary
{
    public class MechanicalDraftPerformanceCurveInputData
    {
        public string OwnerName { private set; get; }
        public string ProjectName { private set; get; }
        public string Location { private set; get; }
        public string TowerManufacturer { private set; get; }
        public TOWER_TYPE TowerType { private set; get; }

        public ColdWaterTemperatureDataValue ColdWaterTemperatureDataValue { get; set; }
        public HotWaterTemperatureDataValue HotWaterTemperatureDataValue { get; set; }
        public WetBulbTemperatureDataValue WetBulbTemperatureDataValue { get; set; }
        public DryBulbTemperatureDataValue DryBulbTemperatureDataValue { get; set; }
        public BarometricPressureDataValue BarometricPressureDataValue { get; set; }
        public LiquidToGasRatioRateDataValue LiquidToGasRatioRateDataValue { get; set; }
        public WaterAirFlowRateDataValue WaterAirFlowRateDataValue { get; set; }

        public List<string> MechanicalDraftPerformanceCurveFileList { get; set; }

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_IS { get; set; }


        public MechanicalDraftPerformanceCurveInputData(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_IS = isInternationalSystemOfUnits_IS_;

            ColdWaterTemperatureDataValue = new ColdWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            HotWaterTemperatureDataValue = new HotWaterTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WetBulbTemperatureDataValue = new WetBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            DryBulbTemperatureDataValue = new DryBulbTemperatureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            BarometricPressureDataValue = new BarometricPressureDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            LiquidToGasRatioRateDataValue = new LiquidToGasRatioRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);
            WaterAirFlowRateDataValue = new WaterAirFlowRateDataValue(IsDemo, IsInternationalSystemOfUnits_IS);

            BuildFileList();
        }

        public void ReadDataFile(string fileName)
        {
            // check that file exists
            // JsonSerialize from file
            // if does not serialize the try to convert old file to json
            // if converted save as jaon
            // update data and page
        }

        public void SaveDataFile(string fileName)
        {
            // if file ext is *.bbp
            //   write as json
            //   update filename is list

            // else
            //   check that file exists
            //   if it does ask to overwrite ok
            //   JsonSerialize data to file
        }

        private void BuildFileList()
        {
            MechanicalDraftPerformanceCurveFileList = new List<string>();

            // open directory
            string applicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string[] files = Directory.GetFiles(applicationData, "*.bbp;*.pfd.json");
            if(files != null)
            {
                // foreach file with extension "*.bbp" and *.pfd.json
                foreach (string file in files)
                {
                    //   add to list
                    MechanicalDraftPerformanceCurveFileList.Add(file);
                }
            }
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChanged = false;

            if (IsInternationalSystemOfUnits_IS != isIS)
            {
                IsInternationalSystemOfUnits_IS = isIS;
                ColdWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                HotWaterTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                WetBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                DryBulbTemperatureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                WaterAirFlowRateDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                BarometricPressureDataValue.ConvertValue(IsInternationalSystemOfUnits_IS, true);
                isChanged = true;
            }
            return isChanged;
        }

        public void SetDemo(bool value)
        {
            IsDemo = value;
        }
    }
}