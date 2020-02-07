// Copyright Cooling Technology Institute 2019-2020

using IniParser;
using IniParser.Model;
using Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace IniFileConverter
{
    public partial class IniFileConverterForm : Form
    {
        string InputFolder { get; set; }
        string OutputFolder { get; set; }

        public IniFileConverterForm()
        {
            InitializeComponent();

            InputFolder = string.Empty;
            OutputFolder = string.Empty;
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            try
            {
                string[] fileEntries = Directory.GetFiles(InputFolder, "*.bbp");

                foreach (string fileName in fileEntries)
                {
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(fileName);

                    MechanicalDraftPerformanceCurveData mechanicalDraftPerformanceCurveData = new MechanicalDraftPerformanceCurveData((data["Tower Design Point"]["Units"] == "SI"));

                    //[Tower Info]
                    //Owner=New Era Power Company
                    //ProjectName=Big Megawatt Station
                    //Location=Off the Highway
                    //Manufacturer=Cooling Technology Institute
                    //ManufacturerData=0
                    //InducedFlow=1
                    mechanicalDraftPerformanceCurveData.DesignData.OwnerName = data["Tower Info"]["Owner"];
                    mechanicalDraftPerformanceCurveData.DesignData.ProjectName = data["Tower Info"]["ProjectName"];
                    mechanicalDraftPerformanceCurveData.DesignData.Location = data["Tower Info"]["Location"];
                    mechanicalDraftPerformanceCurveData.DesignData.TowerManufacturer = data["Tower Info"]["Manufacturer"];
                    if (int.Parse(data["Tower Info"]["InducedFlow"]) == 1)
                    {
                        mechanicalDraftPerformanceCurveData.DesignData.TowerType = TOWER_TYPE.Induced;
                    }
                    else
                    {
                        mechanicalDraftPerformanceCurveData.DesignData.TowerType = TOWER_TYPE.Forced;
                    }

                    mechanicalDraftPerformanceCurveData.DesignData.WaterFlowRate = double.Parse(data["Tower Design Point"]["WaterFlowRate"]);
                    mechanicalDraftPerformanceCurveData.DesignData.HotWaterTemperature = double.Parse(data["Tower Design Point"]["HWT"]);
                    mechanicalDraftPerformanceCurveData.DesignData.ColdWaterTemperature = double.Parse(data["Tower Design Point"]["CWT"]);
                    mechanicalDraftPerformanceCurveData.DesignData.WetBulbTemperature = double.Parse(data["Tower Design Point"]["WBT"]);
                    mechanicalDraftPerformanceCurveData.DesignData.DryBulbTemperature = double.Parse(data["Tower Design Point"]["DBT"]);
                    mechanicalDraftPerformanceCurveData.DesignData.FanDriverPower = double.Parse(data["Tower Design Point"]["FanDriverPower"]);
                    mechanicalDraftPerformanceCurveData.DesignData.BarometricPressure = double.Parse(data["Tower Design Point"]["BarometricPressure"]);
                    mechanicalDraftPerformanceCurveData.DesignData.LiquidToGasRatio = double.Parse(data["Tower Design Point"]["LG"]);

                    int numberOfRanges = int.Parse(data["Curve Data"]["NumRanges"]);
                    for(int i = 0; i < numberOfRanges; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                mechanicalDraftPerformanceCurveData.DesignData.Range1 = double.Parse(data["Curve Data"]["Range1"]);
                                break;
                            case 1:
                                mechanicalDraftPerformanceCurveData.DesignData.Range2 = double.Parse(data["Curve Data"]["Range2"]);
                                break;
                            case 2:
                                mechanicalDraftPerformanceCurveData.DesignData.Range3 = double.Parse(data["Curve Data"]["Range3"]);
                                break;
                            case 3:
                                mechanicalDraftPerformanceCurveData.DesignData.Range4 = double.Parse(data["Curve Data"]["Range4"]);
                                break;
                            case 4:
                                mechanicalDraftPerformanceCurveData.DesignData.Range5 = double.Parse(data["Curve Data"]["Range5"]);
                                break;
                        }
                    }

                    int numberOfFlows = int.Parse(data["Curve Data"]["NumFlows"]);
                    for (int flowNumber = 0; flowNumber < numberOfFlows; flowNumber++)
                    {
                        string flowName = string.Format("Flow{0}", flowNumber+1);
                        
                        RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();

                        rangedTemperaturesDesignData.WaterFlowRate = double.Parse(data[flowName]["FlowRate"]);

                        string[] temperaturesStrings = data[flowName]["WBTs"].Split(',');
                        int wetBlubNumber = 0;
                        foreach (string temperatureString in temperaturesStrings)
                        {
                            double temperature = double.Parse(temperatureString);
                            switch (wetBlubNumber)
                            {
                                case 0:
                                    rangedTemperaturesDesignData.WetBulbTemperatures.Temperature1 = temperature;
                                    break;
                                case 1:
                                    rangedTemperaturesDesignData.WetBulbTemperatures.Temperature2 = temperature;
                                    break;
                                case 2:
                                    rangedTemperaturesDesignData.WetBulbTemperatures.Temperature3 = temperature;
                                    break;
                                case 3:
                                    rangedTemperaturesDesignData.WetBulbTemperatures.Temperature4 = temperature;
                                    break;
                                case 4:
                                    rangedTemperaturesDesignData.WetBulbTemperatures.Temperature5 = temperature;
                                    break;
                                case 5:
                                    rangedTemperaturesDesignData.WetBulbTemperatures.Temperature6 = temperature;
                                    break;
                            }

                            string[] coldTemperaturesStrings = data[flowName][temperatureString].Split(',');

                            int coldRange = 0;
                            foreach (string coldTemperatureString in coldTemperaturesStrings)
                            {
                                double coldTemperature = double.Parse(coldTemperatureString);
                                switch (coldRange)
                                {
                                    case 0:
                                        switch (wetBlubNumber)
                                        {
                                            case 0:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature1 = coldTemperature;
                                                break;
                                            case 1:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature2 = coldTemperature;
                                                break;
                                            case 2:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature3 = coldTemperature;
                                                break;
                                            case 3:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature4 = coldTemperature;
                                                break;
                                            case 4:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature5 = coldTemperature;
                                                break;
                                            case 5:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange1.Temperature6 = coldTemperature;
                                                break;
                                        }
                                        break;
                                    case 1:
                                        switch (wetBlubNumber)
                                        {
                                            case 0:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature1 = coldTemperature;
                                                break;
                                            case 1:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature2 = coldTemperature;
                                                break;
                                            case 2:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature3 = coldTemperature;
                                                break;
                                            case 3:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature4 = coldTemperature;
                                                break;
                                            case 4:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature5 = coldTemperature;
                                                break;
                                            case 5:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange2.Temperature6 = coldTemperature;
                                                break;
                                        }
                                        break;
                                    case 2:
                                        switch (wetBlubNumber)
                                        {
                                            case 0:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature1 = coldTemperature;
                                                break;
                                            case 1:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature2 = coldTemperature;
                                                break;
                                            case 2:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature3 = coldTemperature;
                                                break;
                                            case 3:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature4 = coldTemperature;
                                                break;
                                            case 4:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature5 = coldTemperature;
                                                break;
                                            case 5:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange3.Temperature6 = coldTemperature;
                                                break;
                                        }
                                        break;
                                    case 3:
                                        switch (wetBlubNumber)
                                        {
                                            case 0:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature1 = coldTemperature;
                                                break;
                                            case 1:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature2 = coldTemperature;
                                                break;
                                            case 2:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature3 = coldTemperature;
                                                break;
                                            case 3:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature4 = coldTemperature;
                                                break;
                                            case 4:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature5 = coldTemperature;
                                                break;
                                            case 5:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange4.Temperature6 = coldTemperature;
                                                break;
                                        }
                                        break;
                                    case 4:
                                        switch (wetBlubNumber)
                                        {
                                            case 0:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature1 = coldTemperature;
                                                break;
                                            case 1:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature2 = coldTemperature;
                                                break;
                                            case 2:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature3 = coldTemperature;
                                                break;
                                            case 3:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature4 = coldTemperature;
                                                break;
                                            case 4:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature5 = coldTemperature;
                                                break;
                                            case 5:
                                                rangedTemperaturesDesignData.ColdWaterTemperaturesRange5.Temperature6 = coldTemperature;
                                                break;
                                        }
                                        break;
                                }
                                coldRange++;
                            }
                            wetBlubNumber++;
                        }
                        mechanicalDraftPerformanceCurveData.DesignData.RangedTemperaturesDesignData.Add(rangedTemperaturesDesignData);
                    }

                    int numberOfTests = int.Parse(data["Tests"]["NumTests"]);
                    for(int testNumber = 0; testNumber < numberOfTests; testNumber++)
                    {
                        string testName = string.Format("TestPoint{0}", testNumber+1);
                        if (data[testName]["Date"].Contains("Test Data"))
                        {
                            mechanicalDraftPerformanceCurveData.TestData.WaterFlowRate = double.Parse(data[testName]["WaterFlowRate"]);
                            mechanicalDraftPerformanceCurveData.TestData.HotWaterTemperature = double.Parse(data[testName]["HWT"]);
                            mechanicalDraftPerformanceCurveData.TestData.ColdWaterTemperature = double.Parse(data[testName]["CWT"]);
                            mechanicalDraftPerformanceCurveData.TestData.WetBulbTemperature = double.Parse(data[testName]["WBT"]);
                            mechanicalDraftPerformanceCurveData.TestData.DryBulbTemperature = double.Parse(data[testName]["DBT"]);
                            mechanicalDraftPerformanceCurveData.TestData.FanDriverPower = double.Parse(data[testName]["FanDriverPower"]);
                            mechanicalDraftPerformanceCurveData.TestData.BarometricPressure = double.Parse(data[testName]["BarometricPressure"]);
                        }
                    }

                    string convertedFileName = Path.Combine(OutputFolder, Path.GetFileNameWithoutExtension(fileName) + ".json");
                    File.WriteAllText(convertedFileName, JsonConvert.SerializeObject(mechanicalDraftPerformanceCurveData, Formatting.Indented));

                    ConvertListBox.Items.Add(string.Format("Converted file: {0} saved as {1}", fileName, convertedFileName));
            }
            }
            catch (Exception exception)
            {
                ConvertListBox.Items.Add(string.Format("Error process file: {0}", exception.ToString()));
            }
        }

        private void SelectInput_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(InputDirectory, "");

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InputFolder = folderBrowserDialog.SelectedPath;
                InputDirectory.Text = InputFolder;
            }
        }

        private void SelectOutput_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(OutputDirectory, "");

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                OutputFolder = folderBrowserDialog.SelectedPath;
                OutputDirectory.Text = OutputFolder;
            }
        }

        private void OutputDirectory_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(OutputDirectory, "");
        }

        private void OutputDirectory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(OutputDirectory.Text))
            {
                if (!Directory.Exists(OutputDirectory.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    InputDirectory.Select(0, OutputDirectory.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(OutputDirectory, "Invalid directory");
                }
            }
        }

        private void InputDirectory_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(InputDirectory, "");
        }

        private void InputDirectory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(InputDirectory.Text))
            {
                if (!Directory.Exists(InputDirectory.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    InputDirectory.Select(0, InputDirectory.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(InputDirectory, "Invalid directory");
                }
            }
        }
    }
}
