// Copyright Cooling Technology Institute 2019-2021

using CalculationLibrary;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ViewModels
{
    public class MechanicalDraftPerformanceCurveViewModel
    {
        public TowerDesignData DesignData { get; set; }
        public List<TowerTestPoint> TestPoints { get; set; }
        public bool IsDesignDataValid { get; set; }

        public string DataFileName { get; set; }
        
        public MechanicalDraftPerformanceCurveFileData MechanicalDraftPerformanceCurveFileData;
        public MechanicalDraftPerformanceCurveCalculationData CalculationData { get; set; }
        public NameValueUnitsDataTable NameValueUnitsDataTable { get; set; }
        public Units Units { get; set; }

        public bool IsDemo { get; set; }
        public bool IsInternationalSystemOfUnits_SI { get; set; }
        public string ErrorMessage { get; set; }

        public MechanicalDraftPerformanceCurveViewModel(bool isDemo, bool isInternationalSystemOfUnits_SI)
        {
            IsDemo = isDemo;
            IsInternationalSystemOfUnits_SI = isInternationalSystemOfUnits_SI;
            ErrorMessage = string.Empty;
            IsDesignDataValid = false;

            DesignData = new TowerDesignData(IsDemo, IsInternationalSystemOfUnits_SI);
            TestPoints = new List<TowerTestPoint>();

            NameValueUnitsDataTable = new NameValueUnitsDataTable();

            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);
        }

        public void UpdateDemo(bool isDemo)
        {
            if (IsDemo != isDemo)
            {
                IsDemo = isDemo;
                DesignData.UpdateDemo(isDemo);
                foreach (TowerTestPoint towerTestPoint in TestPoints)
                {
                    towerTestPoint.UpdateDemo(isDemo);
                }
            }
        }

        public bool SwitchUnits(bool isIS)
        {
            bool isChange = false;

            if (IsInternationalSystemOfUnits_SI != isIS)
            {
                IsInternationalSystemOfUnits_SI = isIS;
                ConvertValues(isIS);
            }
            return isChange;
        }

        public bool ConvertValues(bool isIS)
        {
            bool isChange = false;

            isChange |= DesignData.ConvertValues(isIS);
            foreach (TowerTestPoint towerTestPoint in TestPoints)
            {
                isChange |= towerTestPoint.ConvertValues(isIS);
            }
            return isChange;
        }

        public bool OpenDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            DataFileName = fileName;
            ErrorMessage = string.Empty;

            try
            {
                MechanicalDraftPerformanceCurveFileData = JsonConvert.DeserializeObject<MechanicalDraftPerformanceCurveFileData>(File.ReadAllText(DataFileName));
            }
            catch (Exception e)
            {
                stringBuilder.AppendFormat("Failure to read file: {0}. Exception: {1}\n", Path.GetFileName(DataFileName), e.ToString());
                returnValue = false;
            }

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if(MechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI != IsInternationalSystemOfUnits_SI)
                {
                    //ToolkitMain,UpdateU
                    SwitchUnits(MechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI);
                }

                if (!LoadData())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }

            }
            else
            {
                stringBuilder.AppendLine("Unable to load file. File contains invalid data");
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool OpenNewDataFile(string fileName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            ErrorMessage = string.Empty;

            DataFileName = fileName;
            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if (!LoadData())
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    returnValue = false;
                    ErrorMessage = string.Empty;
                }
            }
            else
            {
                stringBuilder.AppendLine("Unable to create new file.");
                returnValue = false;
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        private bool SaveDataToFile()
        {
            bool returnValue = true;

            MechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(IsInternationalSystemOfUnits_SI);

            if (MechanicalDraftPerformanceCurveFileData != null)
            {
                if (FillFileData())
                {
                    try
                    {
                        File.WriteAllText(DataFileName, JsonConvert.SerializeObject(MechanicalDraftPerformanceCurveFileData, Formatting.Indented));
                    }
                    catch (Exception e)
                    {
                        ErrorMessage = string.Format("Error saving data to file. Exception: {0}", e.Message);
                    }
                }
            }
            else
            {
                ErrorMessage = "Unable to save data to file.";
                returnValue = false;
            }
            return returnValue;
        }

        public bool SaveDataFile()
        {
            return SaveDataToFile();
        }

        public bool SaveAsDataFile(string fileName)
        {
            DataFileName = fileName;
            return SaveDataToFile();
        }

        #region DataValues

        public string DataFilenameInputValue
        {
            get
            {
                return Path.GetFileName(DataFileName);
            }
        }
        
        #endregion DataValue

        public bool LoadData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if(MechanicalDraftPerformanceCurveFileData != null)
            {
                if (!DesignData.LoadData(MechanicalDraftPerformanceCurveFileData.DesignData))
                {
                    returnValue = false;
                    if (IsDemo)
                    {
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine("You are in Demo mode that limits the input value ranges. This maybe causing the file not to load properly.");
                    }
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine(DesignData.ErrorMessage);
                }
                
                TestPoints.Clear();
                foreach (TowerTestData testData in MechanicalDraftPerformanceCurveFileData.TestData)
                {
                    TowerTestPoint towerTestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI);
                    if (!towerTestPoint.LoadData(IsInternationalSystemOfUnits_SI, testData))
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(towerTestPoint.ErrorMessage);
                    }
                    TestPoints.Add(towerTestPoint);
                }

                IsDesignDataValid = DesignData.IsValid();

                if(!IsDesignDataValid)
                {
                    // set validation error to design data error message
                    stringBuilder.AppendLine();
                    stringBuilder.AppendLine(DesignData.ErrorMessage);
                }
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool FillFileData()
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            if (!DesignData.FillFileData(MechanicalDraftPerformanceCurveFileData.DesignData))
            {
                returnValue = false;
                stringBuilder.AppendLine(DesignData.ErrorMessage);
            }

            MechanicalDraftPerformanceCurveFileData.TestData.Clear();

            foreach (TowerTestPoint towerTestPoint in TestPoints)
            {
                TowerTestData towerTestData = new TowerTestData(IsInternationalSystemOfUnits_SI);
                if (!towerTestPoint.FillFileData(towerTestData))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(string.Format("Test {0}: {1}", towerTestPoint.TestName, towerTestPoint.ErrorMessage));
                }
                MechanicalDraftPerformanceCurveFileData.TestData.Add(towerTestData);
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public bool FillCalculationData(int testIndex, MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            bool returnValue = true;
            StringBuilder stringBuilder = new StringBuilder();

            calculationData.IsInternationalSystemOfUnits_SI = IsInternationalSystemOfUnits_SI;

            if (!DesignData.FillCalculationData(calculationData))
            {
                returnValue = false;
                stringBuilder.AppendLine(DesignData.ErrorMessage);
            }

            MechanicalDraftPerformanceCurveFileData.TestData.Clear();

            if(testIndex >= 0)
            {
                if (!TestPoints[testIndex].FillCalculationData(calculationData))
                {
                    returnValue = false;
                    stringBuilder.AppendLine(string.Format("Test {0}: {1}", TestPoints[testIndex].TestName, TestPoints[testIndex].ErrorMessage));
                }
            }

            if (!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }

            return returnValue;
        }

        public void FillTable()
        {
            if (IsInternationalSystemOfUnits_SI)
            {
                Units = new UnitsIS();
            }
            else
            {
                Units = new UnitsIP();
            }
            NameValueUnitsDataTable.DataTable.Clear();
            NameValueUnitsDataTable.AddRow("Adjusted Flow", CalculationData.TestOutput.AdjustedFlow.ToString("F1"), Units.FlowRate);
            NameValueUnitsDataTable.AddRow("Predicted Flow", CalculationData.TestOutput.PredictedFlow.ToString("F1") + ((CalculationData.TestOutput.Extrapolated) ? " *" : ""), Units.FlowRate);
            NameValueUnitsDataTable.AddRow("Tower Capability", CalculationData.TestOutput.TowerCapability.ToString("F1"), ConstantUnits.Percentage);
            NameValueUnitsDataTable.AddRow("Cold Water Temperature Deviation", CalculationData.TestOutput.ColdWaterTemperatureDeviation.ToString("F2"), Units.Temperature);
        }

        public bool Calculate(int testIndex)
        {
            ErrorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;

            try
            {
                if (DesignData.IsValid())
                {
                    CalculationData = new MechanicalDraftPerformanceCurveCalculationData();

                    if (FillCalculationData(testIndex, CalculationData))
                    {
                        MechanicalDraftPerformanceCurveCalculationLibrary calculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();
                        calculationLibrary.MechanicalDraftPerformanceCurveCalculation(CalculationData, true);
                        FillTable();
                        TestPoints[testIndex].LiquidToGasRatioDataValue.UpdateCurrentValue(CalculationData.TestOutput.LiquidToGasRatio);
                        calculationLibrary.GenerateGraphPoints(CalculationData);
                    }
                    else
                    {
                        returnValue = false;
                        stringBuilder.AppendLine(ErrorMessage);
                    }
                }
                else
                {
                    stringBuilder.AppendLine(DesignData.ErrorMessage);
                    returnValue = false;
                }
            }
            catch (Exception exception)
            {
                stringBuilder.AppendFormat("Error in Performance Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
            }

            if(!returnValue)
            {
                ErrorMessage = stringBuilder.ToString();
            }
            return returnValue;
        }

        //public bool CalculateViewGraphs(int testIndex)
        //{
        //    ErrorMessage = string.Empty;
        //    StringBuilder stringBuilder = new StringBuilder();
        //    bool returnValue = true;

        //    try
        //    {
        //        MechanicalDraftPerformanceCurveCalculationLibrary calculationLibrary = new MechanicalDraftPerformanceCurveCalculationLibrary();

        //        if (DesignData.IsValid())
        //        {
        //            //CalculationData = new MechanicalDraftPerformanceCurveCalculationData();

        //            //if (FillCalculationData(testIndex, CalculationData))
        //            //{
        //                //calculationLibrary.MechanicalDraftPerformanceCurveCalculation(CalculationData);
        //                calculationLibrary.GenerateGraphPoints(CalculationData);
        //                //calculationLibrary.CalculateCrossPlot2(CalculationData);
        //            //}
        //            //else
        //            //{
        //            //    returnValue = false;
        //            //    stringBuilder.AppendLine(ErrorMessage);
        //            //}
        //        }
        //        else
        //        {
        //            stringBuilder.AppendLine(DesignData.ErrorMessage);
        //            returnValue = false;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        stringBuilder.AppendFormat("Error in Performance Curve calculation. Please check your input values. Exception Message: {0}", exception.Message);
        //    }

        //    if (!returnValue)
        //    {
        //        ErrorMessage = stringBuilder.ToString();
        //    }
        //    return returnValue;
        //}

        public DataTable DataTable
        {
            get
            {
                return NameValueUnitsDataTable.DataTable;
            }
        }

        // Check design or test data, optionally prompting the user with bounds if errors are found.
        //bool ValidateData(Models.TowerSpecifications mechanicalDraftPerformanceCurveData, bool isDesignData, StringBuilder errorMessage)
        //{
            //bool isError = (isWaterFlowRateError || isHotWaterTemperatureError || isColdWaterTemperatureError || isWetBulbTemperatureError || isDryBulbTemperatureError || isFanDriverPowerError ||
            //    isBarometricPressureError || isLiquidGasRatioError);

            //// If requested, display a message box pointing out the errors and displaying
            //// the min and max values for each.
            //if (isError)
            //{
            //    string type = isDesignData ? "Design" : "Test";

            //    errorMessage.AppendFormat("Your {0} data is out of range for calculating % Capability.\n\n Please check the following {0} values:\n\n", type);
            //    int i = 1;
            //    if (isWaterFlowRateError)
            //    {
            //        errorMessage.AppendFormat("{0}. Water Flow Rate:   min = {1},   max = {2}\n", i++, minimum.WaterFlowRate, maximum.WaterFlowRate);
            //    }
            //    if (isHotWaterTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Hot Water Temperature:   min = {1},   max = {2}\n", i++, minimum.HotWaterTemperature, maximum.HotWaterTemperature);
            //    }
            //    if (isColdWaterTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Cold Water Temperature:   min = {1},   max = {2}\n", i++, minimum.ColdWaterTemperature, maximum.ColdWaterTemperature);
            //    }
            //    if (isWetBulbTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Wet Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.WetBulbTemperature, maximum.WetBulbTemperature);
            //    }
            //    if (isDryBulbTemperatureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Dry Bulb Temperature:   min = {1},   max = {2}\n", i++, minimum.DryBulbTemperature, maximum.DryBulbTemperature);
            //    }
            //    if (isFanDriverPowerError)
            //    {
            //        errorMessage.AppendFormat("{0}. Fan Driver Power:   min = {1},   max = {2}\n", i++, minimum.FanDriverPower, maximum.FanDriverPower);
            //    }
            //    if (isBarometricPressureError)
            //    {
            //        errorMessage.AppendFormat("{0}. Barometric Pressure:   min = {1},   max = {2}\n", i++, minimum.BarometricPressure, maximum.BarometricPressure);
            //    }
            //    if (isLiquidGasRatioError)
            //    {
            //        errorMessage.AppendFormat("{0}. Liquid to Gas Ratio:   min = {1},   max = {2}\n", i++, minimum.LiquidToGasRatio, maximum.LiquidToGasRatio);
            //    }
            //}
        //    return true;// !isError;
        //}

        public bool AddTestPoint(string testName)
        {
            bool returnValue = true;
            ErrorMessage = string.Empty;

            try
            {
                TowerTestPoint towerTestPoint = new TowerTestPoint(IsDemo, IsInternationalSystemOfUnits_SI)
                {
                    TestName = testName
                };
                TestPoints.Add(towerTestPoint);
            }
            catch (Exception e)
            {
                ErrorMessage = string.Format("Tower design page setup failed. Exception: {0} ", e.ToString());
                returnValue = false;
            }

            return returnValue;
        }

        #region DataAccess

        public DataValue WaterFlowRateDataValue
        {
            get
            {
                return DesignData.WaterFlowRateDataValue;
            }
        }

        public DataValue HotWaterTemperatureDataValue
        {
            get
            {
                return DesignData.HotWaterTemperatureDataValue;
            }
        }

        public DataValue ColdWaterTemperatureDataValue
        {
            get
            {
                return DesignData.ColdWaterTemperatureDataValue;
            }
        }

        public DataValue WetBulbTemperatureDataValue
        {
            get
            {
                return DesignData.WetBulbTemperatureDataValue;
            }
        }

        public DataValue DryBulbTemperatureDataValue
        {
            get
            {
                return DesignData.DryBulbTemperatureDataValue;
            }
        }

        public DataValue FanDriverPowerDataValue
        {
            get
            {
                return DesignData.FanDriverPowerDataValue;
            }
        }

        public DataValue BarometricPressureDataValue
        {
            get
            {
                return DesignData.BarometricPressureDataValue;
            }
        }

        #endregion DataAccess

    }
}
