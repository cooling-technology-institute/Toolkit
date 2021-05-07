// Copyright Cooling Technology Institute 2019-2021

using System.Data;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class DemandCurvePrinterOutput : UserControl
    {
        public DemandCurvePrinterOutput(int bottomOfPage, string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable, DemandCurveViewModel demandCurveViewModel)
        {
            InitializeComponent();

            OptionalLabelTextBox.Text = optionalLabel;

            ThermalDesignConditionsDataGridView.DataSource = new DataView(nameValueUnitsDataTable.DataTable);

            //DataGridView.DataSource = new DataView(dataTable);

            if (demandCurveViewModel.GetDataTable() != null)
            {
                Chart.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                Chart.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                Chart.ChartAreas[0].AxisX.MajorGrid.Interval = 0.25D;
                //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1.0;
                //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.IntervalOffset = 1.0;
                //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.Interval = 0.75D;
                //DemandCurveChart.ChartAreas[0].AxisX.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                Chart.ChartAreas[0].AxisX.Maximum = 5D;
                Chart.ChartAreas[0].AxisX.Minimum = 0.1D;
                Chart.ChartAreas[0].AxisX.MinorTickMark.Enabled = true;
                Chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = true;
                Chart.ChartAreas[0].AxisX.MinorTickMark.Interval = 0.75D;
                Chart.ChartAreas[0].AxisX.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                Chart.ChartAreas[0].AxisX.Title = "L/G";
                Chart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);

                Chart.ChartAreas[0].AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
                Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.25;
                Chart.ChartAreas[0].AxisY.MajorGrid.Interval = 0.75D;
                Chart.ChartAreas[0].AxisY.MajorTickMark.Interval = 0.5D;
                Chart.ChartAreas[0].AxisY.Maximum = 10D;
                Chart.ChartAreas[0].AxisY.Minimum = 0.1D;
                Chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
                Chart.ChartAreas[0].AxisY.MinorTickMark.Interval = 0.75D;
                Chart.ChartAreas[0].AxisY.MinorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
                Chart.ChartAreas[0].AxisY.Title = "KaV/L";
                Chart.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

                Chart.ChartAreas[0].AxisX.Minimum = 0.1;
                Chart.ChartAreas[0].AxisX.IsLogarithmic = true;
                Chart.ChartAreas[0].AxisX.Maximum = 5;

                Chart.ChartAreas[0].AxisY.Title = "KaV/L";
                Chart.ChartAreas[0].AxisY.Minimum = 0.1;
                Chart.ChartAreas[0].AxisY.IsLogarithmic = true;

                Chart.Legends[0].Title = "Approach";

                Chart.ChartAreas[0].CursorX.AutoScroll = true;
                Chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                Chart.ChartAreas[0].CursorY.AutoScroll = true;
                Chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

                //for (int i = 0; i < demandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues.Length; i++)
                //{
                //    if (demandCurveViewModel.DemandCurveCalculationLibrary.ApproachInRange[i])
                //    {
                //        Series series = new Series()
                //        {
                //            ChartArea = "ChartArea1",
                //            ChartType = SeriesChartType.Line,
                //            //series.Color = System.Drawing.Color.Yellow,
                //            Name = string.Format("{0}", demandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]),
                //            XValueMember = string.Format("L/G-{0}", demandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]),
                //            YValueMembers = string.Format("kaVL-{0}", demandCurveViewModel.DemandCurveCalculationLibrary.InitialApproachXValues[i]),
                //        };
                //        DemandCurveChart.Series.Add(series);
                //    }
                //}
                ////                    if (Display_Charactertics)
                if (true)
                {
                    //Series series = new Series();
                    //series.ChartArea = "ChartArea1";
                    //series.ChartType = SeriesChartType.Line;
                    //series.Color = Color.Yellow;
                    //series.Name = "Charactertics";
                    //series.XValueMember = "L/G-Charactertics";
                    //series.YValueMembers = "kaVL-Charactertics";
                    //DemandCurveChart.Series.Add(series);
                }


                Chart.DataSource = demandCurveViewModel.GetDataTable();
                //BindingSource SBind = new BindingSource()
                //{
                //    DataSource = dataTable
                //};

                Chart.DataBind();
            }

            this.Height = bottomOfPage + 10;
        }
    }
}
