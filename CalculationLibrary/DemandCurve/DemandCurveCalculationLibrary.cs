// Copyright Cooling Technology Institute 2019-2021

using Models;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace CalculationLibrary
{
    public class DemandCurveCalculationLibrary : CalculationLibrary
    {
        private const double liquidToGasRatio_MIN = 0.1;
        private const double liquidToGasRatio_MAX = 5.0;

        public readonly int[] InitialApproachXValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        private double CalculatedLiquidToGasRatio { get; set; }
        private double CalculatedLiquidToGasRatio_MIN { get; set; }
        private MerkelCalculationData MerkelCalculationData { get; set; }

        public DemandCurveCalculationLibrary(bool isInternationalSystemOfUnits_IS)
        {
            MerkelCalculationData = new MerkelCalculationData(isInternationalSystemOfUnits_IS);
        }

        public bool Calculate(DemandCurveCalculationData data)
        {
            ErrorMessage = string.Empty;

            data.DemandCurveData.TargetApproach = 0;

            CalculatedLiquidToGasRatio_MIN = 999.0;

            InitializeApproachList(data);

            CalculateApproach(data);
            CalculateApproaches(data);
            GenerateCharacterticsLine(data);
            GenerateLGLine(data);
            GenerateKaVLLine(data);
            GenerateTargetApproach(data);
            GenerateUserApproach(data);

            return true;
        }

        void InitializeApproachList(DemandCurveCalculationData data)
        {
            MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(data);

            foreach (double approachValue in InitialApproachXValues)
            {
                Approach approach = new Approach(approachValue);
                MerkelCalculationData.Approach = approachValue;

                if (CalculateMerkel(MerkelCalculationData))
                {
                    approach.InRange = (MerkelCalculationData.KaV_L > 0.1) && (MerkelCalculationData.KaV_L < 5.0);
                    approach.OutOfRange = !approach.InRange;
                    data.Approaches.Add(approach);
                }
            }
        }

        private void MerkelConvertValues(DemandCurveCalculationData data)
        {
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
            MerkelCalculationData.IsElevation = data.DemandCurveData.IsElevation;
            MerkelCalculationData.WetBulbTemperature = data.DemandCurveData.WetBulbTemperature;
            MerkelCalculationData.Elevation = data.DemandCurveData.Elevation;
            MerkelCalculationData.WetBulbTemperature = data.DemandCurveData.WetBulbTemperature;
            MerkelCalculationData.PressurePSI = data.DemandCurveData.BarometricPressure;
            ConvertMerkelValues(MerkelCalculationData);

            MerkelCalculationData.Range = data.DemandCurveData.Range;
            if (data.IsInternationalSystemOfUnits_SI)
            {
                MerkelCalculationData.Range *= 1.8;
            }
            MerkelCalculationData.LiquidToGasRatio = 0.1;
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = false;
        }

        void CalculateApproach(DemandCurveCalculationData data)
        {
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
            MerkelConvertValues(data);
            MerkelCalculationData.LiquidToGasRatio = data.DemandCurveData.LiquidToGasRatio;

            if ((data.DemandCurveData.LiquidToGasRatio >= 0.1) && (data.DemandCurveData.LiquidToGasRatio <= 5.0))
            {
                if (data.DemandCurveData.CurveC1 != 0.0 && data.DemandCurveData.CurveC2 != 0.0)
                {
                    data.DemandCurveData.KaV_L = Math.Round((data.DemandCurveData.CurveC1 * Math.Pow(data.DemandCurveData.LiquidToGasRatio, data.DemandCurveData.CurveC2)), 5, MidpointRounding.ToEven);
                    MerkelCalculationData.KaV_L = data.DemandCurveData.KaV_L;
                    data.DemandCurveData.TargetApproach = GetExactApproach(MerkelCalculationData);

                    if ((data.DemandCurveData.KaV_L < .01) || (data.DemandCurveData.KaV_L > 5.0))
                    {
                        data.DemandCurveData.KaV_L = 0.0;
                        data.DemandCurveData.TargetApproach = 0;
                    }

                    if (data.DemandCurveData.TargetApproach >= 100)
                    {
                        data.DemandCurveData.TargetApproach = 0;
                    }

                    if (data.IsInternationalSystemOfUnits_SI)
                    {
                        data.DemandCurveData.TargetApproach *= 5.0 / 9.0;
                    }
                }
            }
        }

        public double CalculateExactApproach(DemandCurveCalculationData data, double lg, double kval)
        {
            MerkelCalculationData.IsInternationalSystemOfUnits_SI = data.IsInternationalSystemOfUnits_SI;
            MerkelConvertValues(data);
            MerkelCalculationData.LiquidToGasRatio = lg;
            MerkelCalculationData.KaV_L = kval;
            return GetExactApproach(MerkelCalculationData);
        }

        void CalculateApproaches(DemandCurveCalculationData data)
        {
            MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
            MerkelConvertValues(data);

            if (data.Approaches.Count > 0)
            {
                for (double liquidToGasRatio = liquidToGasRatio_MIN; liquidToGasRatio < liquidToGasRatio_MAX; liquidToGasRatio += .05)
                {
                    foreach (Approach approach in data.Approaches)
                    {
                        approach.OutOfRange = GenerateApproach(approach, data, liquidToGasRatio);
                    }
                }
            }
        }

        void GenerateUserApproach(DemandCurveCalculationData data)
        {
            if (data.DemandCurveData.UserApproach != 0)
            {
                Approach approach = new Approach("User");
                approach.Value = data.DemandCurveData.UserApproach;

                MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
                MerkelConvertValues(data);

                for (double liquidToGasRatio = liquidToGasRatio_MIN; liquidToGasRatio < liquidToGasRatio_MAX; liquidToGasRatio += .05)
                {
                    GenerateApproach(approach, data, liquidToGasRatio);
                }

                data.Approaches.Add(approach);
            }
        }

        void GenerateTargetApproach(DemandCurveCalculationData data)
        {
            if (data.DemandCurveData.TargetApproach != 0)
            {
                Approach approach = new Approach("Target");
                approach.Value = data.DemandCurveData.TargetApproach;

                MerkelCalculationData.Initialize(data.IsInternationalSystemOfUnits_SI);
                MerkelConvertValues(data);

                for (double liquidToGasRatio = liquidToGasRatio_MIN; liquidToGasRatio < liquidToGasRatio_MAX; liquidToGasRatio += .05)
                {
                    GenerateApproach(approach, data, liquidToGasRatio);
                }

                data.Approaches.Add(approach);
            }
        }


        void GenerateCharacterticsLine(DemandCurveCalculationData data)
        {
            //---------------------------------------------------------------------
            // Draw Fill Line
            //---------------------------------------------------------------------
            if ((data.DemandCurveData.CurveC1 != 0) && (data.DemandCurveData.CurveC2 != 0))
            {
                Approach approach = new Approach("C");

                for (double lg = data.DemandCurveData.CurveMinimum; lg <= data.DemandCurveData.CurveMaximum; lg += .05)
                {
                    if ((lg >= data.DemandCurveData.CurveMinimum) && (lg <= data.DemandCurveData.CurveMaximum))
                    {
                        double k = data.DemandCurveData.CurveC1 * Math.Pow(lg, data.DemandCurveData.CurveC2);

                        if ((k >= CalculatedLiquidToGasRatio_MIN) && (k <= liquidToGasRatio_MAX))
                        {
                            approach.Points.Add(new Point(lg, k));
                            data.IsCoef = true;
                        }
                    }
                }

                data.Approaches.Add(approach);
            }
        }

        void GenerateLGLine(DemandCurveCalculationData data)
        {
            //---------------------------------------------------------------------
            // Draw L/G line
            //---------------------------------------------------------------------
            if ((data.DemandCurveData.LiquidToGasRatio > liquidToGasRatio_MIN) && (data.DemandCurveData.LiquidToGasRatio <= liquidToGasRatio_MAX))
            {
                Approach approach = new Approach("L/G");
                approach.Points.Add(new Point(data.DemandCurveData.LiquidToGasRatio, CalculatedLiquidToGasRatio_MIN));
                approach.Points.Add(new Point(data.DemandCurveData.LiquidToGasRatio, liquidToGasRatio_MAX));
                data.Approaches.Add(approach);
                data.IsLiquidToGasRatio = true;
            }
        }

        void GenerateKaVLLine(DemandCurveCalculationData data)
        {
            //---------------------------------------------------------------------
            // Draw KaV/L line
            //---------------------------------------------------------------------
            if ((data.DemandCurveData.KaV_L > 0.1) && (data.DemandCurveData.KaV_L <= liquidToGasRatio_MAX))
            {
                Approach approach = new Approach("KaV/L");
                approach.Points.Add(new Point(liquidToGasRatio_MIN, data.DemandCurveData.KaV_L));
                approach.Points.Add(new Point(liquidToGasRatio_MAX, data.DemandCurveData.KaV_L));
                data.Approaches.Add(approach);
                data.IsKaV_L = true;
            }
        }

        private bool GenerateApproach(Approach approach, DemandCurveCalculationData data, double liquidToGasRatio)
        {
            const double kavl_MIN = 0.01;
            const double kavl_MAX = 5.0;

            if (approach.InRange && !approach.OutOfRange)
            {
                MerkelCalculationData.LiquidToGasRatio = liquidToGasRatio;
                MerkelCalculationData.Approach = approach.Value;

                if (data.IsInternationalSystemOfUnits_SI)
                {
                    MerkelCalculationData.Approach *= 1.8;
                }

                if (CalculateMerkel(MerkelCalculationData))
                {
                    // ddp
                    if ((MerkelCalculationData.KaV_L < kavl_MIN) || (MerkelCalculationData.KaV_L >= kavl_MAX))
                    {
                        double dInterp;
                        for (dInterp = liquidToGasRatio; ((MerkelCalculationData.KaV_L < kavl_MIN) || (MerkelCalculationData.KaV_L >= kavl_MAX)) && (dInterp > .1); dInterp -= 0.0002)
                        {
                            MerkelCalculationData.Approach = approach.Value;
                            if (data.IsInternationalSystemOfUnits_SI)
                            {
                                MerkelCalculationData.Approach *= 1.8;
                            }
                            MerkelCalculationData.LiquidToGasRatio = dInterp;
                            if (!CalculateMerkel(MerkelCalculationData))
                            {
                                break;
                            }
                        }
                        CalculatedLiquidToGasRatio = dInterp;
                        approach.OutOfRange = true;  //DDP This is the last point
                    }
                    else
                    {
                        CalculatedLiquidToGasRatio = liquidToGasRatio;
                    }

                    if ((CalculatedLiquidToGasRatio_MIN > MerkelCalculationData.KaV_L) && (MerkelCalculationData.KaV_L > .1))
                    {
                        CalculatedLiquidToGasRatio_MIN = MerkelCalculationData.KaV_L;
                    }

                    if ((MerkelCalculationData.KaV_L <= 10.0) && (MerkelCalculationData.KaV_L >= .1))
                    {
                        approach.Points.Add(new Point(CalculatedLiquidToGasRatio, MerkelCalculationData.KaV_L));
                    }
                }
            }
            return approach.OutOfRange;
        }

        public double GetExactApproach(MerkelCalculationData MerkelCalculationData)
        {
            double approach;
            double delta = 1.0;

            double givenKaV_L = MerkelCalculationData.KaV_L;

            if (givenKaV_L == 0)
            {
                MerkelCalculationData.Approach = 0;
                return 0;
            }

            //---------------------------------------------------------------------
            // Find approach within .001
            //---------------------------------------------------------------------
            for (approach = 0.0; approach < 100.0; approach += delta)
            {
                MerkelCalculationData.Approach = approach;

                CalculateMerkel(MerkelCalculationData);
                if (delta > 0.9)
                {
                    if (MerkelCalculationData.KaV_L < givenKaV_L)
                    {
                        delta = -0.001;
                    }
                    //else
                    //{
                    //    break; // calculation error?
                    //}
                }
                else
                {
                    if (MerkelCalculationData.KaV_L >= givenKaV_L)
                    {
                        approach = Math.Round(approach, 3, MidpointRounding.ToEven);
                        break;
                    }
                }
            }
            return approach;
        }
    }
}