// Copyright Cooling Technology Institute 2019-2020

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Models
{
    public class TemperatureDesignData
    {
        public double Temperature1 { set; get; }
        public double Temperature2 { set; get; }
        public double Temperature3 { set; get; }
        public double Temperature4 { set; get; }
        public double Temperature5 { set; get; }
        public double Temperature6 { set; get; }
        public int TemperatureCount { set; get; }
        public int LastValidTemperature { set; get; }
        public bool TemperatureLessThan { set; get; }

        public TemperatureDesignData()
        {
            Temperature1 = 0.0;
            Temperature2 = 0.0;
            Temperature3 = 0.0;
            Temperature4 = 0.0;
            Temperature5 = 0.0;
            Temperature6 = 0.0;

            TemperatureCount = 0;
            LastValidTemperature = 0;
            TemperatureLessThan = false;
        }

        public bool ValidateTemperatures(int count, int limit, string temperatureType, out string errorMessage)
        {
            errorMessage = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();
            bool returnValue = true;
            bool zeroDetected = false;

            TemperatureCount = 0;
            LastValidTemperature = 0;
            TemperatureLessThan = false;

            if(limit > 6)
            {
                limit = 6;
            }

            for (int i = 0; i < limit; i++)
            {
                switch (i)
                {
                    case 0:
                        returnValue &= CheckTemperature(i, Temperature1, 0.0, ref zeroDetected, stringBuilder);
                        break;
                    case 1:
                        returnValue &= CheckTemperature(i, Temperature2, Temperature1, ref zeroDetected, stringBuilder);
                        break;
                    case 2:
                        returnValue &= CheckTemperature(i, Temperature3, Temperature2, ref zeroDetected, stringBuilder);
                        break;
                    case 3:
                        returnValue &= CheckTemperature(i, Temperature4, Temperature3, ref zeroDetected, stringBuilder);
                        break;
                    case 4:
                        returnValue &= CheckTemperature(i, Temperature5, Temperature4, ref zeroDetected, stringBuilder);
                        break;
                    case 5:
                        returnValue &= CheckTemperature(i, Temperature6, Temperature5, ref zeroDetected, stringBuilder);
                        break;
                    default:
                        returnValue = false;
                        break;
                }
            }

            if (TemperatureCount < count)
            {
                stringBuilder.AppendLine(string.Format("You must specify a minimum of {0} {1} in the Tower Design Data to calculate Tower Capability.", count, temperatureType));
                returnValue = false;
            }

            errorMessage = stringBuilder.ToString();

            return returnValue;
        }

        bool CheckTemperature(int temperatureNumber, double temperature, double previousTemperature, ref bool zeroDetected, StringBuilder stringBuilder)
        {
            bool returnValue = true;

            if (temperature == 0.0)
            {
                returnValue = false;
                zeroDetected = true;
            }
            else
            {
                if (temperatureNumber == 1)
                {
                    if (previousTemperature < temperature)
                    {
                        TemperatureLessThan = true;
                    }
                }
                else if (temperatureNumber > 0)
                {
                    if (previousTemperature == temperature)
                    {
                        stringBuilder.AppendLine(string.Format("Temperature {0} is equal to Temperature {1}.", temperatureNumber, temperatureNumber + 1));
                        returnValue = false;
                    }
                    else if (TemperatureLessThan && (previousTemperature > temperature))
                    {
                        stringBuilder.AppendLine(string.Format("Temperature {0} is greater than Temperature {1}.", temperatureNumber, temperatureNumber + 1));
                        returnValue = false;
                    }
                    else if (!TemperatureLessThan && (previousTemperature < temperature))
                    {
                        stringBuilder.AppendLine(string.Format("Temperature {0} is less than Temperature {1}.", temperatureNumber, temperatureNumber + 1));
                        returnValue = false;
                    }
                }

                if (returnValue)
                {
                    LastValidTemperature = temperatureNumber + 1;

                    if (!zeroDetected)
                    {
                        TemperatureCount++;
                    }
                }
            }
            return returnValue;
        }
    }
}