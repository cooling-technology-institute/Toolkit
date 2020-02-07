// Copyright Cooling Technology Institute 2019-2020

using CalculationLibrary;
using Models;
using System;
using System.Data;

namespace ViewModels
{
    public class PsychrometricsViewModel
    {
        private PsychrometricsInputData PsychrometricsInputData { get; set; }
        private PsychrometricsOutputData PsychrometricsOutputData { get; set; }
        private PsychrometricsData PsychrometricsData { get; set; }
        private PsychrometricsCalculationLibrary PsychrometricsCalculationLibrary { get; set; }
        private bool IsInternationalSystemOfUnits_SI_ { get; set; }
        private bool IsDemo { get; set; }
        public bool IsElevation { get; set; }

        public string EnthalpyDataValueInputMessage
        {
            get
            {
                return PsychrometricsInputData.EnthalpyDataValue.InputMessage;
            }
        }

        public string EnthalpyDataValueInputValue
        {
            get
            {
                return PsychrometricsInputData.EnthalpyDataValue.InputValue;
            }
        }

        public bool EnthalpyDataValueUpdateValue(string value, out string errorMessage)
        {
            return PsychrometricsInputData.EnthalpyDataValue.UpdateValue(value, out errorMessage);
        }

        public string EnthalpyDataValueToolTip
        {
            get
            {
                return PsychrometricsInputData.EnthalpyDataValue.ToolTip;
            }
        }

        public string ElevationDataValueInputMessage
        {
            get
            {
                return PsychrometricsInputData.ElevationDataValue.InputMessage;
            }
        }

        public string ElevationDataValueInputValue
        {
            get
            {
                return PsychrometricsInputData.ElevationDataValue.InputValue;
            }
        }

        public bool ElevationDataValueUpdateValue(string value, out string errorMessage)
        {
            return PsychrometricsInputData.ElevationDataValue.UpdateValue(value, out errorMessage);
        }

        public string ElevationDataValueToolTip
        {
            get
            {
                return PsychrometricsInputData.ElevationDataValue.ToolTip;
            }
        }

        public string BarometricPressureDataValueInputMessage
        {
            get
            {
                return PsychrometricsInputData.BarometricPressureDataValue.InputMessage;
            }
        }

        public string BarometricPressureDataValueInputValue
        {
            get
            {
                return PsychrometricsInputData.BarometricPressureDataValue.InputValue;
            }
        }

        public bool BarometricPressureDataValueUpdateValue(string value, out string errorMessage)
        {
            return PsychrometricsInputData.BarometricPressureDataValue.UpdateValue(value, out errorMessage);
        }

        public string BarometricPressureDataValueToolTip
        {
            get
            {
                return PsychrometricsInputData.BarometricPressureDataValue.ToolTip;
            }
        }

        public string RelativeHumidityDataValueInputMessage
        {
            get
            {
                return PsychrometricsInputData.RelativeHumidityDataValue.InputMessage;
            }
        }

        public string RelativeHumidityDataValueInputValue
        {
            get
            {
                return PsychrometricsInputData.RelativeHumidityDataValue.InputValue;
            }
        }

        public bool RelativeHumidityDataValueUpdateValue(string value, out string errorMessage)
        {
            return PsychrometricsInputData.RelativeHumidityDataValue.UpdateValue(value, out errorMessage);
        }

        public string RelativeHumidityDataValueToolTip
        {
            get
            {
                return PsychrometricsInputData.RelativeHumidityDataValue.ToolTip;
            }
        }
        public string WetBulbTemperatureDataValueInputMessage
        {
            get
            {
                return PsychrometricsInputData.WetBulbTemperatureDataValue.InputMessage;
            }
        }

        public string WetBulbTemperatureDataValueInputValue
        {
            get
            {
                return PsychrometricsInputData.WetBulbTemperatureDataValue.InputValue;
            }
        }

        public bool WetBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return PsychrometricsInputData.WetBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string WetBulbTemperatureDataValueToolTip
        {
            get
            {
                return PsychrometricsInputData.WetBulbTemperatureDataValue.ToolTip;
            }
        }

        public string DryBulbTemperatureDataValueInputMessage
        {
            get
            {
                return PsychrometricsInputData.DryBulbTemperatureDataValue.InputMessage;
            }
        }

        public string DryBulbTemperatureDataValueInputValue
        {
            get
            {
                return PsychrometricsInputData.DryBulbTemperatureDataValue.InputValue;
            }
        }

        public bool DryBulbTemperatureDataValueUpdateValue(string value, out string errorMessage)
        {
            return PsychrometricsInputData.DryBulbTemperatureDataValue.UpdateValue(value, out errorMessage);
        }

        public string DryBulbTemperatureDataValueToolTip
        {
            get
            {
                return PsychrometricsInputData.DryBulbTemperatureDataValue.ToolTip;
            }
        }


        public PsychrometricsViewModel(bool isDemo, bool isInternationalSystemOfUnits_IS_)
        {
            IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
            IsDemo = isDemo;
            PsychrometricsInputData = new PsychrometricsInputData(IsDemo, IsInternationalSystemOfUnits_SI_);
            PsychrometricsOutputData = new PsychrometricsOutputData(IsInternationalSystemOfUnits_SI_);
            PsychrometricsCalculationLibrary = new PsychrometricsCalculationLibrary();
            PsychrometricsData = new PsychrometricsData();
        }

        public bool ConvertValues(bool isInternationalSystemOfUnits_IS_)
        {
            if(IsInternationalSystemOfUnits_SI_ != isInternationalSystemOfUnits_IS_)
            {
                IsInternationalSystemOfUnits_SI_ = isInternationalSystemOfUnits_IS_;
                return PsychrometricsInputData.ConvertValues(IsInternationalSystemOfUnits_SI_);
            }
            return false;
        }

        public bool CalculatePsychrometrics(bool isElevation, out string errorMessage)
        {
            try
            {
                if (!FillPsychrometricsData(isElevation, out errorMessage))
                {
                    return false;
                }

                if (!PsychrometricsCalculationLibrary.PsychrometricsCalculation(PsychrometricsInputData.CalculationType, PsychrometricsInputData.IsElevation, PsychrometricsData, out errorMessage))
                {
                    return false;
                }

                PsychrometricsOutputData.FillDataTable(PsychrometricsData);

                return true;
            }
            catch (Exception exception)
            {
                errorMessage = string.Format("Error in Psychrometrics calculation. Please check your input values. Exception Message: {0}", exception.Message);
                return false;
            }
        }

        public bool FillPsychrometricsData(bool isElevation, out string errorMessage)
        {
            return PsychrometricsInputData.FillPsychrometricsData(PsychrometricsData, isElevation, out errorMessage);
        }

        public DataTable GetDataTable()
        {
            return PsychrometricsOutputData.NameValueUnitsDataTable.DataTable;
        }

        public bool UpdateCalculationType(PsychrometricsCalculationType psychrometricsCalculationType, out string errorMessage)
        {
            errorMessage = string.Empty;

            switch (psychrometricsCalculationType)
            {
                case PsychrometricsCalculationType.DryBulbTemperature_RelativeHumidity:
                case PsychrometricsCalculationType.Enthalpy:
                case PsychrometricsCalculationType.WetBulbTemperature_DryBulbTemperature:
                    PsychrometricsInputData.CalculationType = psychrometricsCalculationType;
                    break;

                default:
                    errorMessage = "Invalid psychrometrics calculation type";
                    return false;
            }

            return true;
        }
    }
}
