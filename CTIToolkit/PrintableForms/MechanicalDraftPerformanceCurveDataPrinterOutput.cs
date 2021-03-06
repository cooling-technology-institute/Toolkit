﻿using System.Data;
using System.Windows.Forms;
using ViewModels;

namespace CTIToolkit
{
    public partial class MechanicalDraftPerformanceCurveDataPrinterOutput : UserControl
    {
        public MechanicalDraftPerformanceCurveDataPrinterOutput(int bottomOfPage, string optionalLabel, NameValueUnitsDataTable nameValueUnitsDataTable,  MechanicalDraftPerformanceCurveViewModel viewModel)
        {
            InitializeComponent();
            
            OptionalLabelTextBox.Text = optionalLabel;

            OwnerTextBox.Text = string.Format("Owner: {0}", viewModel.DesignData.OwnerNameValue);
            ProjectTextBox.Text = string.Format("Project: {0}", viewModel.DesignData.ProjectNameValue);
            LocationTextBox.Text = string.Format("Location: {0}", viewModel.DesignData.LocationValue);
            TowerManufacturerTextBox.Text = string.Format("Manufacturer: {0}", viewModel.DesignData.TowerManufacturerValue);
            TowerTypeTextBox.Text = string.Format("Tower Type: {0}", viewModel.DesignData.TowerTypeValue.ToString());
            
            if(nameValueUnitsDataTable.DataTable != null)
            {
                InputPropertiesDataGridView.DataSource = nameValueUnitsDataTable.DataTable;
            }

            this.Height = bottomOfPage + 10;
        }

        public void AddBeta(int pageSize)
        {
            // 
            // Beta
            // 
            TextBox beta = new TextBox();
            beta.BackColor = System.Drawing.Color.White;
            beta.BorderStyle = BorderStyle.None;
            beta.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            beta.ForeColor = System.Drawing.Color.DarkRed;
            //beta.Location = new System.Drawing.Point(0, ((pageSize - Beta.Size.Height) - 20));
            beta.Name = string.Format("Beta{0}", pageSize);
            beta.ReadOnly = true;
            beta.Size = new System.Drawing.Size(462, 37);
            beta.Text = "CTI Toolkit 4.0 Beta Version";
            Controls.Add(beta);

            this.Height = pageSize;
        }

        public int AddWaterFlowRate(int pageSize, int bottom, string flowRate, DataTable dataTable)
        {
            int controlSize = (dataTable.Rows.Count * 25) + 35;

            if (bottom + controlSize >= (pageSize - 40))
            {
                bottom = pageSize + 20;
            }

            Label WaterFlowRateLabel = new Label();
            WaterFlowRateLabel.AutoSize = true;
            WaterFlowRateLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            WaterFlowRateLabel.Location = new System.Drawing.Point(10, bottom);
            WaterFlowRateLabel.Name = string.Format("WaterFlowRate{0}", bottom);
            WaterFlowRateLabel.Size = new System.Drawing.Size(113, 100);
            WaterFlowRateLabel.Text = flowRate;
            Controls.Add(WaterFlowRateLabel);

            bottom += 35;

            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridView WaterFlowRateDataView1 = new DataGridView();
            
            WaterFlowRateDataView1.AllowUserToAddRows = false;
            WaterFlowRateDataView1.AllowUserToDeleteRows = false;
            WaterFlowRateDataView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            WaterFlowRateDataView1.BackgroundColor = System.Drawing.Color.White;
            WaterFlowRateDataView1.BorderStyle = BorderStyle.None;
            WaterFlowRateDataView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            WaterFlowRateDataView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            WaterFlowRateDataView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            WaterFlowRateDataView1.DefaultCellStyle = dataGridViewCellStyle4;
            WaterFlowRateDataView1.Enabled = false;
            WaterFlowRateDataView1.Name = string.Format("WaterFlowRateDataView{0}", bottom);
            WaterFlowRateDataView1.RowHeadersVisible = false;
            WaterFlowRateDataView1.ScrollBars = ScrollBars.None;
            WaterFlowRateDataView1.Location = new System.Drawing.Point(28, bottom);
            WaterFlowRateDataView1.Size = new System.Drawing.Size(646, dataTable.Rows.Count * 30);

            WaterFlowRateDataView1.DataSource = dataTable;

            Controls.Add(WaterFlowRateDataView1);

            bottom += controlSize;

            this.Height = bottom;
            
            return bottom;
        }
    }
}
