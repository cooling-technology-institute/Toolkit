using Models;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ViewModels;

namespace CTIToolkit
{
    public partial class ViewGraphsForm : Form
    {
        public ViewGraphsForm(MechanicalDraftPerformanceCurveCalculationData calculationData)
        {
            InitializeComponent();

            TabControl.TabPages.Clear();
            foreach(WaterFlowRate waterFlowRate in calculationData.WaterFlowRates)
            {
                AddTabPage(calculationData, waterFlowRate);
            }
        }

        private void AddTabPage(MechanicalDraftPerformanceCurveCalculationData calculationData, WaterFlowRate waterFlowRate)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = string.Format("Flow = {0}", waterFlowRate.FlowRate.ToString("F2"));
            Chart chart = new Chart();

            chart.Titles.Add(string.Format("Flow = {0} {1}", waterFlowRate.FlowRate.ToString("F2"), (calculationData.IsInternationalSystemOfUnits_SI) ? ConstantUnits.LitersPerSecond : ConstantUnits.GallonsPerMinute));
            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add(new ChartArea());

            chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisX.Minimum = calculationData.FindMinimumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Maximum = calculationData.FindMaximumWetBulbTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisX.Title = "Wet Bulb Temperature";
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;
            chart.ChartAreas[0].AxisY.Minimum = calculationData.FindMinimumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Maximum = calculationData.FindMaximumColdWaterTempurature(waterFlowRate);
            chart.ChartAreas[0].AxisY.Title = "Cold Water Temperature";
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            for (int i = 0; i < waterFlowRate.WetBulbTemperatures[0].ColdWaterTemperatures.Count; i++)
            {
                Series series = new Series();
                series.ChartArea = "ChartArea1";
                series.ChartType = SeriesChartType.Line;
                //series.Color = System.Drawing.Color.Green;
                foreach (WetBulbTemperature wetBulbTemperature in waterFlowRate.WetBulbTemperatures)
                {
                    series.Points.AddXY(wetBulbTemperature.Temperature, wetBulbTemperature.ColdWaterTemperatures[i]);
                }
                chart.Series.Add(series);
            }

            //
            // Iterate through with 50 increments
            //
            double increment = (waterFlowRate.WetBulbTemperatures[waterFlowRate.WetBulbTemperatures.Count - 1].Temperature - waterFlowRate.WetBulbTemperatures[0].Temperature) / 50.0;
            //for (double dblWBTIndex = m_designData.m_fnGetWBT(iFlowIndex, 0, m_bIPUnits); dblWBTIndex <= m_designData.m_fnGetWBT(iFlowIndex, m_designData.m_fnGetWBTCnt(iFlowIndex) - 1, m_bIPUnits); dblWBTIndex += dblIncrement)
            //{
            //    TestX = dblWBTIndex;
            //    CalcPerfData(iCnt, X, Y, TestX, YFIT, Y2);
            //    m_wndGraph.GetSeries(iRangeIndex).AddXY(TestX, YFIT, NULL, DATACOLOR);
            //}

            //Series series = new Series();
            //series.ChartArea = "ChartArea1";
            //series.ChartType = SeriesChartType.Line;
            //series.Color = System.Drawing.Color.Green;
            //foreach (double temperature in wetBulbTemperature.ColdWaterTemperatures)
            //{
            //    series.Points.AddXY(temperature, wetBulbTemperature.Temperature);
            //    //series.Color = System.Drawing.Color.Yellow;
            //    //    series.Name = string.Format("{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]);
            //    //    series.XValueMember = string.Format("L/G-{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]);
            //    //    series.YValueMembers = string.Format("kaVL-{0}", DemandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]);
            //    //    DemandCurveChart.Series.Add(series);
            //    //}
            //}
            //chart.Series.Add(series);

            //m_wndGraph.GetAxis().GetLeft().SetMinMax(
            //    m_designData.m_fnGetCWT(iFlowIndex, 0, 0, m_bIPUnits), 
            //    m_designData.m_fnGetCWT(iFlowIndex, m_designData.m_fnGetWBTCnt(iFlowIndex) - 1, 
            //    m_designData.m_fnGetRangeCnt() - 1, 
            //    m_bIPUnits));
            //m_wndGraph.GetAxis().GetRight().SetMinMax(
            //    m_designData.m_fnGetCWT(iFlowIndex, 0, 0, m_bIPUnits), 
            //    m_designData.m_fnGetCWT(iFlowIndex, 
            //    m_designData.m_fnGetWBTCnt(iFlowIndex) - 1, 
            //    m_designData.m_fnGetRangeCnt() - 1, m_bIPUnits));
            //m_wndGraph.GetAxis().GetTop().SetMinMax(
            //    m_designData.m_fnGetWBT(iFlowIndex, 0, m_bIPUnits), 
            //    m_designData.m_fnGetWBT(iFlowIndex, 
            //    m_designData.m_fnGetWBTCnt(iFlowIndex) - 1, 
            //    m_bIPUnits));
            //m_wndGraph.GetAxis().GetBottom().SetMinMax(
            //    m_designData.m_fnGetWBT(iFlowIndex, 0, m_bIPUnits), 
            //    m_designData.m_fnGetWBT(iFlowIndex, 
            //    m_designData.m_fnGetWBTCnt(iFlowIndex) - 1, 
            //    m_bIPUnits));
            chart.Invalidate();
            tabPage.Controls.Add(chart);
            TabControl.TabPages.Add(tabPage);
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {

        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {

        }
    }
}
