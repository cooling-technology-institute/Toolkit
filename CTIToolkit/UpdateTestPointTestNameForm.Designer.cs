
namespace CTIToolkit
{
    partial class UpdateTestPointTestNameForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.TestNameTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(265, 8);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // TestNameTextBox
            // 
            this.TestNameTextBox.Location = new System.Drawing.Point(12, 10);
            this.TestNameTextBox.Name = "TestNameTextBox";
            this.TestNameTextBox.Size = new System.Drawing.Size(229, 20);
            this.TestNameTextBox.TabIndex = 1;
            this.TestNameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.TestNameTextBox_Validating);
            this.TestNameTextBox.Validated += new System.EventHandler(this.TestNameTextBox_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UpdateTestPointTestNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 39);
            this.Controls.Add(this.TestNameTextBox);
            this.Controls.Add(this.UpdateButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateTestPointTestNameForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Test Point Name";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.TextBox TestNameTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}