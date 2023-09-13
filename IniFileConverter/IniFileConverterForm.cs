// Copyright Cooling Technology Institute 2019-2021

using IniParser;
using IniParser.Model;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace IniFileConverter
{
    public partial class IniFileConverterForm : Form
    {
        string InputFolder { get; set; }
        string OutputFolder { get; set; }
        List<PathLabel> SearchPaths { get; set; }

        public IniFileConverterForm()
        {
            InitializeComponent();
            
            SearchPaths = new List<PathLabel>();
            String sPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            String sUserName = Environment.UserName;
            string[] sPathLines = sPath.Split(new string[] { sUserName }, StringSplitOptions.RemoveEmptyEntries);

            // search for old version installed
            //C:\Users\renee\AppData\Local\VirtualStore\Program Files (x86)\Cooling Technology Institute\CTI Toolkit 3.2
            string path = Path.Combine(sPathLines[0], Environment.UserName, "AppData", "Local", "VirtualStore", "Program Files (x86)", "Cooling Technology Institute", "CTI Toolkit 3.2");
            //string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Cooling Technology Institute", "CTI Toolkit 3.2");
            if(Directory.Exists(path))
            {
                PathLabel pathLabel = new PathLabel()
                {
                    path = path,
                    label = "..\\Program Files (x86)\\Cooling Technology Institute\\CTI Toolkit 3.2"
                };
                SearchPaths.Add(pathLabel);
                InputDirectoryComboBox.Items.Add(pathLabel.label);
            }
            else // windows 7
            {

            }

            //C:\Users\renee\AppData\Local\VirtualStore\Program Files (x86)\Thuridion\CTI Toolkit 3.1
            //path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Thuridion", "CTI Toolkit 3.1");
            path = Path.Combine(sPathLines[0], Environment.UserName, "AppData", "Local", "VirtualStore", "Program Files (x86)", "Thuridion", "CTI Toolkit 3.1");
            if (Directory.Exists(path))
            {
                PathLabel pathLabel = new PathLabel()
                {
                    path = path,
                    label = "..\\Program Files (x86)\\Thuridion\\CTI Toolkit 3.1"
                };
                SearchPaths.Add(pathLabel);
                InputDirectoryComboBox.Items.Add(pathLabel.label);
            }
            else // windows 7
            {

            }

            path = Path.Combine(sPathLines[0], Environment.UserName, "AppData", "Local", "VirtualStore", "Program Files (x86)", "Thuridion", "CTI Toolkit 3.0");
            //path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Thuridion", "CTI Toolkit 3.0");
            if (Directory.Exists(path))
            {
                PathLabel pathLabel = new PathLabel()
                {
                    path = path,
                    label = "..\\Program Files (x86)\\Thuridion\\CTI Toolkit 3.0"
                };
                SearchPaths.Add(pathLabel);
                InputDirectoryComboBox.Items.Add(pathLabel.label);
            }
            else // windows 7
            {

            }

            if (InputDirectoryComboBox.Items.Count > 0)
            {
                InputDirectoryComboBox.SelectedIndex = 0;
            }
            OutputDirectory.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Cooling Technology Institute", "CTI Toolkit 4.0");
            InputFolder = InputDirectoryComboBox.Text;
            OutputFolder = OutputDirectory.Text;
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            OutputTextBox.ResetText();
            foreach (PathLabel pathLabel in SearchPaths)
            {
                if (pathLabel.label == InputFolder)
                {
                    InputFolder = pathLabel.path;
                    break;
                }
            }
            ProcessMechanicalDraftPerformanceCurveFiles();
            ProcessDemandCurveFiles();
        }

        private void ProcessMechanicalDraftPerformanceCurveFiles()
        {
            string[] fileEntries = Directory.GetFiles(InputFolder, "*.bbp");

            foreach (string fileName in fileEntries)
            {
                if((Path.GetFileNameWithoutExtension(fileName) != "Appendix C") && (Path.GetFileNameWithoutExtension(fileName) != "Appendix D"))
                {
                    var parser = new FileIniDataParser();
                    parser.Parser.Configuration.CaseInsensitive = true;
                    parser.Parser.Configuration.SkipInvalidLines = true;

                    OutputTextBox.AppendText(string.Format("Processing file: {0}", Path.GetFileName(fileName)) + Environment.NewLine);
                    IniData data = null;

                    try
                    {
                        data = parser.ReadFile(fileName);
                    }
                    catch(Exception exception)
                    {
                        string message = exception.Message;
                        if(message.Contains("while parsing line number 0 with value '' - IniParser version: 2.5.2.0"))
                        {
                            message = message.Replace("while parsing line number 0 with value '' - IniParser version: 2.5.2.0", "");
                        }
                        if (message.Contains(" - IniParser version: 2.5.2.0"))
                        {
                            message = message.Replace(" - IniParser version: 2.5.2.0", "");
                        }
                        
                        OutputTextBox.AppendText(string.Format("Error: {0}", message) + Environment.NewLine);
                    }

                    if (data != null)
                    {
                        try
                        {
                            
                            string units = GetIniString(data, "Tower Design Point", "Units");
                            MechanicalDraftPerformanceCurveFileData mechanicalDraftPerformanceCurveFileData = new MechanicalDraftPerformanceCurveFileData(units == "SI");

                            //[Tower Info]
                            //Owner=New Era Power Company
                            //ProjectName=Big Megawatt Station
                            //Location=Off the Highway
                            //Manufacturer=Cooling Technology Institute
                            //ManufacturerData=0
                            //InducedFlow=1
                            mechanicalDraftPerformanceCurveFileData.DesignData.OwnerName = GetIniString(data, "Tower Info", "Owner");
                            mechanicalDraftPerformanceCurveFileData.DesignData.ProjectName = GetIniString(data, "Tower Info", "ProjectName");
                            mechanicalDraftPerformanceCurveFileData.DesignData.Location = GetIniString(data, "Tower Info", "Location");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerManufacturer = GetIniString(data, "Tower Info", "Manufacturer");
                            if (GetInt(data, "Tower Info", "InducedFlow") == 1)
                            {
                                mechanicalDraftPerformanceCurveFileData.DesignData.TowerType = TOWER_TYPE.Induced;
                            }
                            else
                            {
                                mechanicalDraftPerformanceCurveFileData.DesignData.TowerType = TOWER_TYPE.Forced;
                            }
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.IsInternationalSystemOfUnits_SI = mechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI;

                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.WaterFlowRate = GetDouble(data, "Tower Design Point", "WaterFlowRate");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.HotWaterTemperature = GetDouble(data, "Tower Design Point", "HWT");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.ColdWaterTemperature = GetDouble(data, "Tower Design Point", "CWT");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.WetBulbTemperature = GetDouble(data, "Tower Design Point", "WBT");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.DryBulbTemperature = GetDouble(data, "Tower Design Point", "DBT");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.FanDriverPower = GetDouble(data, "Tower Design Point", "FanDriverPower");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.BarometricPressure = GetDouble(data, "Tower Design Point", "BarometricPressure");
                            mechanicalDraftPerformanceCurveFileData.DesignData.TowerSpecifications.LiquidToGasRatio = GetDouble(data, "Tower Design Point", "LG");

                            int numberOfRanges = GetInt(data, "Curve Data", "NumRanges");
                            for (int i = 0; i < numberOfRanges; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        mechanicalDraftPerformanceCurveFileData.DesignData.Range1 = GetDouble(data, "Curve Data", "Range1");
                                        break;
                                    case 1:
                                        mechanicalDraftPerformanceCurveFileData.DesignData.Range2 = GetDouble(data, "Curve Data", "Range2");
                                        break;
                                    case 2:
                                        mechanicalDraftPerformanceCurveFileData.DesignData.Range3 = GetDouble(data, "Curve Data", "Range3");
                                        break;
                                    case 3:
                                        mechanicalDraftPerformanceCurveFileData.DesignData.Range4 = GetDouble(data, "Curve Data", "Range4");
                                        break;
                                    case 4:
                                        mechanicalDraftPerformanceCurveFileData.DesignData.Range5 = GetDouble(data, "Curve Data", "Range5");
                                        break;
                                }
                            }

                            int numberOfFlows = GetInt(data, "Curve Data", "NumFlows");
                            for (int flowNumber = 0; flowNumber < numberOfFlows; flowNumber++)
                            {
                                string flowName = string.Format("Flow{0}", flowNumber + 1);

                                RangedTemperaturesDesignData rangedTemperaturesDesignData = new RangedTemperaturesDesignData();

                                rangedTemperaturesDesignData.WaterFlowRate = GetDouble(data, flowName, "FlowRate");

                                string wetblubtemperatures = GetIniString(data, flowName, "WBTs");

                                string[] temperaturesStrings = wetblubtemperatures.Split(',');
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

                                    string[] coldTemperaturesStrings = GetIniString(data, flowName, temperatureString).Split(',');

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
                                mechanicalDraftPerformanceCurveFileData.DesignData.RangedTemperaturesDesignData.Add(rangedTemperaturesDesignData);
                            }

                            int numberOfTests = GetInt(data, "Tests", "NumTests");
                            for (int testNumber = 0; testNumber < numberOfTests; testNumber++)
                            {
                                string testName = string.Format("TestPoint{0}", testNumber + 1);
                                TowerTestData towerTestData = new TowerTestData(mechanicalDraftPerformanceCurveFileData.IsInternationalSystemOfUnits_SI);
                                towerTestData.TestName = GetIniString(data, testName, "Date");
                                towerTestData.TowerSpecifications.WaterFlowRate = GetDouble(data, testName, "WaterFlowRate");
                                towerTestData.TowerSpecifications.HotWaterTemperature = GetDouble(data, testName, "HWT");
                                towerTestData.TowerSpecifications.ColdWaterTemperature = GetDouble(data, testName, "CWT");
                                towerTestData.TowerSpecifications.WetBulbTemperature = GetDouble(data, testName, "WBT");
                                towerTestData.TowerSpecifications.DryBulbTemperature = GetDouble(data, testName, "DBT");
                                towerTestData.TowerSpecifications.FanDriverPower = GetDouble(data, testName, "FanDriverPower");
                                towerTestData.TowerSpecifications.BarometricPressure = GetDouble(data, testName, "BarometricPressure");
                                mechanicalDraftPerformanceCurveFileData.TestData.Add(towerTestData);
                            }

                            string convertedFileName = Path.Combine(OutputFolder, Path.GetFileNameWithoutExtension(fileName) + ".mdpc");
                            int index = 1;
                            while (File.Exists(convertedFileName))
                            {
                                convertedFileName = Path.Combine(OutputFolder, Path.GetFileNameWithoutExtension(fileName) + string.Format("({0})", index++) + ".mdpc");
                            }
                            File.WriteAllText(convertedFileName, JsonConvert.SerializeObject(mechanicalDraftPerformanceCurveFileData, Formatting.Indented));

                            OutputTextBox.AppendText(string.Format("Saved as {0}", Path.GetFileName(convertedFileName) + Environment.NewLine));
                        }
                        catch (Exception exception)
                        {
                            OutputTextBox.AppendText(string.Format("Error process file: {0}", exception.ToString() + Environment.NewLine));
                        }
                    }
                    OutputTextBox.AppendText(Environment.NewLine);
                }
            }
        }

        private string GetIniString(IniData data, string section, string key)
        {
            string returnValue = string.Empty;

            try
            {
                returnValue = data[section][key];
                if (returnValue == null)
                {
                    OutputTextBox.AppendText(string.Format("Error: Section='{0}' Key='{1}' was not found", section, key) + Environment.NewLine);
                    returnValue = string.Empty;
                }
            }
            catch
            {
                OutputTextBox.AppendText(string.Format("Error: Section='{0}' Key='{1}' was not found", section, key) + Environment.NewLine);
            }

            return returnValue;
        }

        private int GetInt(IniData data, string section, string key)
        {
            int returnValue = 0;
            string value = string.Empty;

            try
            {
                value = GetIniString(data, section, key);
                if(!string.IsNullOrEmpty(value))
                {
                    returnValue = int.Parse(value);
                }
            }
            catch
            {
                OutputTextBox.AppendText(string.Format("Error: Section='{0}' Key='{1}' is not a valid integer, Value '{2}'", section, key, value) + Environment.NewLine);
            }

            return returnValue;
        }

        private double GetDouble(IniData data, string section, string key)
        {
            double returnValue = 0;
            string value = string.Empty;

            try
            {
                value = GetIniString(data, section, key);
                if (!string.IsNullOrEmpty(value))
                {
                    returnValue = double.Parse(value);
                }
            }
            catch
            {
                OutputTextBox.AppendText(string.Format("Error: Section='{0}' Key='{1}' is not a valid floating point, Value '{2}'", section, key, value) + Environment.NewLine);
            }

            return returnValue;
        }


        private void ProcessDemandCurveFiles()
        {
            string[] fileEntries = Directory.GetFiles(InputFolder, "*.bbd");

            foreach (string fileName in fileEntries)
            {
                var parser = new FileIniDataParser();
                parser.Parser.Configuration.CaseInsensitive = true;
                parser.Parser.Configuration.SkipInvalidLines = true;

                OutputTextBox.AppendText(string.Format("Processing file: {0}", Path.GetFileName(fileName)) + Environment.NewLine);

                IniData data = null;
                try
                {
                    data = parser.ReadFile(fileName);
                }
                catch (Exception exception)
                {
                    OutputTextBox.AppendText(string.Format("Error: {0}", exception.Message) + Environment.NewLine);
                }

                if (data != null)
                {
                    try
                    {
                        string unitsWBT = GetIniString(data, "Demand Curve Data", "WBTUnits");

                        DemandCurveFileData demandCurveFileData = new DemandCurveFileData(unitsWBT == "°C");

                        demandCurveFileData.CurveC1 = GetDouble(data, "Demand Curve Data", "CurveC1");
                        demandCurveFileData.CurveC2 = GetDouble(data, "Demand Curve Data", "CurveC2");
                        demandCurveFileData.Elevation = GetDouble(data, "Demand Curve Data", "Altitude");
                        demandCurveFileData.WetBulbTemperature = GetDouble(data, "Demand Curve Data", "CurveWBT");
                        demandCurveFileData.Range = GetDouble(data, "Demand Curve Data", "CurveRange");
                        demandCurveFileData.LiquidToGasRatio = GetDouble(data, "Demand Curve Data", "Lg");
                        demandCurveFileData.CurveMaximum = GetDouble(data, "Demand Curve Data", "CurveMax");
                        demandCurveFileData.CurveMinimum = GetDouble(data, "Demand Curve Data", "CurveMin");

                        string convertedFileName = Path.Combine(OutputFolder, Path.GetFileNameWithoutExtension(fileName) + ".dc");
                        int index = 1;
                        while (File.Exists(convertedFileName))
                        {
                            convertedFileName = Path.Combine(OutputFolder, Path.GetFileNameWithoutExtension(fileName) + string.Format("({0})", index++) + ".dc");
                        }
                        File.WriteAllText(convertedFileName, JsonConvert.SerializeObject(demandCurveFileData, Formatting.Indented));

                        OutputTextBox.AppendText(string.Format("Saved as: {0}", Path.GetFileName(convertedFileName) + Environment.NewLine));
                    }
                    catch (Exception exception)
                    {
                        OutputTextBox.AppendText(string.Format("Error: {0}", exception.ToString() + Environment.NewLine));
                    }
                }

                OutputTextBox.AppendText(Environment.NewLine);
            }
        }

        private void SelectInput_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(InputDirectoryComboBox, "");

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InputFolder = folderBrowserDialog.SelectedPath;
                InputDirectoryComboBox.Items.Add(InputFolder);
                InputDirectoryComboBox.SelectedIndex = InputDirectoryComboBox.Items.Count - 1;

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
                    OutputDirectory.Select(0, OutputDirectory.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(OutputDirectory, "Invalid directory");
                }
            }
        }

        private void InputDirectory_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(InputDirectoryComboBox, "");
        }

        private void InputDirectory_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(InputDirectoryComboBox.Text))
            {
                if (!Directory.Exists(InputDirectoryComboBox.Text))
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    InputDirectoryComboBox.Select(0, InputDirectoryComboBox.Text.Length);

                    // Set the ErrorProvider error with the text to display. 
                    this.errorProvider1.SetError(InputDirectoryComboBox, "Invalid directory");
                }
            }
        }

        private void OutputDirectory_TextChanged(object sender, EventArgs e)
        {
            OutputFolder = OutputDirectory.Text;

        }

        private void InputDirectory_TextChanged(object sender, EventArgs e)
        {
            InputFolder = InputDirectoryComboBox.Text;
        }

        private void InputDirectoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputFolder = InputDirectoryComboBox.Text;
        }
    }
}
