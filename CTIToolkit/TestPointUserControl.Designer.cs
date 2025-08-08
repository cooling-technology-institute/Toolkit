namespace CTIToolkit
{
    partial class TestPointUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LiquidToGasRatio = new System.Windows.Forms.TextBox();
            this.WaterFlowRate = new System.Windows.Forms.TextBox();
            this.HotWaterTemperature = new System.Windows.Forms.TextBox();
            this.ColdWaterTemperature = new System.Windows.Forms.TextBox();
            this.WetBulbTemperature = new System.Windows.Forms.TextBox();
            this.DryBulbTemperature = new System.Windows.Forms.TextBox();
            this.BarometricPressure = new System.Windows.Forms.TextBox();
            this.FanDriverPower = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // LiquidToGasRatio
            // 
            this.LiquidToGasRatio.Enabled = false;
            this.LiquidToGasRatio.Location = new System.Drawing.Point(13, 201);
            this.LiquidToGasRatio.Name = "LiquidToGasRatio";
            this.LiquidToGasRatio.Size = new System.Drawing.Size(70, 20);
            this.LiquidToGasRatio.TabIndex = 7;
            // 
            // WaterFlowRate
            // 
            this.WaterFlowRate.Location = new System.Drawing.Point(13, 19);
            this.WaterFlowRate.Name = "WaterFlowRate";
            this.WaterFlowRate.Size = new System.Drawing.Size(70, 20);
            this.WaterFlowRate.TabIndex = 0;
            this.WaterFlowRate.Validating += new System.ComponentModel.CancelEventHandler(this.WaterFlowRate_Validating);
            this.WaterFlowRate.Validated += new System.EventHandler(this.WaterFlowRate_Validated);
            // 
            // HotWaterTemperature
            // 
            this.HotWaterTemperature.Location = new System.Drawing.Point(13, 45);
            this.HotWaterTemperature.Name = "HotWaterTemperature";
            this.HotWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.HotWaterTemperature.TabIndex = 1;
            this.HotWaterTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.HotWaterTemperature_Validating);
            this.HotWaterTemperature.Validated += new System.EventHandler(this.HotWaterTemperature_Validated);
            // 
            // ColdWaterTemperature
            // 
            this.ColdWaterTemperature.Location = new System.Drawing.Point(13, 71);
            this.ColdWaterTemperature.Name = "ColdWaterTemperature";
            this.ColdWaterTemperature.Size = new System.Drawing.Size(70, 20);
            this.ColdWaterTemperature.TabIndex = 2;
            this.ColdWaterTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.ColdWaterTemperature_Validating);
            this.ColdWaterTemperature.Validated += new System.EventHandler(this.ColdWaterTemperature_Validated);
            // 
            // WetBulbTemperature
            // 
            this.WetBulbTemperature.Location = new System.Drawing.Point(13, 97);
            this.WetBulbTemperature.Name = "WetBulbTemperature";
            this.WetBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.WetBulbTemperature.TabIndex = 3;
            this.WetBulbTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.WetBulbTemperature_Validating);
            this.WetBulbTemperature.Validated += new System.EventHandler(this.WetBulbTemperature_Validated);
            // 
            // DryBulbTemperature
            // 
            this.DryBulbTemperature.Location = new System.Drawing.Point(13, 123);
            this.DryBulbTemperature.Name = "DryBulbTemperature";
            this.DryBulbTemperature.Size = new System.Drawing.Size(70, 20);
            this.DryBulbTemperature.TabIndex = 4;
            this.DryBulbTemperature.Validating += new System.ComponentModel.CancelEventHandler(this.DryBulbTemperature_Validating);
            this.DryBulbTemperature.Validated += new System.EventHandler(this.DryBulbTemperature_Validated);
            // 
            // BarometricPressure
            // 
            this.BarometricPressure.Location = new System.Drawing.Point(13, 175);
            this.BarometricPressure.Name = "BarometricPressure";
            this.BarometricPressure.Size = new System.Drawing.Size(70, 20);
            this.BarometricPressure.TabIndex = 6;
            this.BarometricPressure.Validating += new System.ComponentModel.CancelEventHandler(this.BarometricPressure_Validating);
            this.BarometricPressure.Validated += new System.EventHandler(this.BarometricPressure_Validated);
            // 
            // FanDriverPower
            // 
            this.FanDriverPower.Location = new System.Drawing.Point(13, 149);
            this.FanDriverPower.Name = "FanDriverPower";
            this.FanDriverPower.Size = new System.Drawing.Size(70, 20);
            this.FanDriverPower.TabIndex = 5;
            this.FanDriverPower.Validating += new System.ComponentModel.CancelEventHandler(this.FanDriverPower_Validating);
            this.FanDriverPower.Validated += new System.EventHandler(this.FanDriverPower_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TestPointUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LiquidToGasRatio);
            this.Controls.Add(this.WaterFlowRate);
            this.Controls.Add(this.HotWaterTemperature);
            this.Controls.Add(this.FanDriverPower);
            this.Controls.Add(this.ColdWaterTemperature);
            this.Controls.Add(this.BarometricPressure);
            this.Controls.Add(this.WetBulbTemperature);
            this.Controls.Add(this.DryBulbTemperature);
            this.Name = "TestPointUserControl";
            this.Size = new System.Drawing.Size(125, 230);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LiquidToGasRatio;
        private System.Windows.Forms.TextBox WaterFlowRate;
        private System.Windows.Forms.TextBox HotWaterTemperature;
        private System.Windows.Forms.TextBox ColdWaterTemperature;
        private System.Windows.Forms.TextBox WetBulbTemperature;
        private System.Windows.Forms.TextBox DryBulbTemperature;
        private System.Windows.Forms.TextBox BarometricPressure;
        private System.Windows.Forms.TextBox FanDriverPower;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
