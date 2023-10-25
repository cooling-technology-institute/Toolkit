
namespace GenerateSerialNumber
{
    partial class GenerateSerialNumberForm
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
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label first_NameLabel;
            System.Windows.Forms.Label last_NameLabel;
            System.Windows.Forms.Label companyLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateSerialNumberForm));
            this.generatedSerialNumber = new System.Windows.Forms.TextBox();
            this.generateSerialNumber = new System.Windows.Forms.Button();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.first_NameTextBox = new System.Windows.Forms.TextBox();
            this.last_NameTextBox = new System.Windows.Forms.TextBox();
            this.companyTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.serialNumberLabel = new System.Windows.Forms.Label();
            this.toolkit_4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolkitSerialNumbersDataSet = new GenerateSerialNumber.ToolkitSerialNumbersDataSet();
            this.toolkit_4TableAdapter = new GenerateSerialNumber.ToolkitSerialNumbersDataSetTableAdapters.Toolkit_4TableAdapter();
            this.tableAdapterManager = new GenerateSerialNumber.ToolkitSerialNumbersDataSetTableAdapters.TableAdapterManager();
            emailLabel = new System.Windows.Forms.Label();
            first_NameLabel = new System.Windows.Forms.Label();
            last_NameLabel = new System.Windows.Forms.Label();
            companyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolkit_4BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolkitSerialNumbersDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(25, 28);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(35, 13);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "Email:";
            // 
            // first_NameLabel
            // 
            first_NameLabel.AutoSize = true;
            first_NameLabel.Location = new System.Drawing.Point(25, 64);
            first_NameLabel.Name = "first_NameLabel";
            first_NameLabel.Size = new System.Drawing.Size(60, 13);
            first_NameLabel.TabIndex = 6;
            first_NameLabel.Text = "First Name:";
            // 
            // last_NameLabel
            // 
            last_NameLabel.AutoSize = true;
            last_NameLabel.Location = new System.Drawing.Point(24, 100);
            last_NameLabel.Name = "last_NameLabel";
            last_NameLabel.Size = new System.Drawing.Size(61, 13);
            last_NameLabel.TabIndex = 8;
            last_NameLabel.Text = "Last Name:";
            // 
            // companyLabel
            // 
            companyLabel.AutoSize = true;
            companyLabel.Location = new System.Drawing.Point(24, 136);
            companyLabel.Name = "companyLabel";
            companyLabel.Size = new System.Drawing.Size(54, 13);
            companyLabel.TabIndex = 10;
            companyLabel.Text = "Company:";
            // 
            // generatedSerialNumber
            // 
            this.generatedSerialNumber.Location = new System.Drawing.Point(108, 217);
            this.generatedSerialNumber.Name = "generatedSerialNumber";
            this.generatedSerialNumber.ReadOnly = true;
            this.generatedSerialNumber.Size = new System.Drawing.Size(151, 20);
            this.generatedSerialNumber.TabIndex = 0;
            this.generatedSerialNumber.TabStop = false;
            // 
            // generateSerialNumber
            // 
            this.generateSerialNumber.Location = new System.Drawing.Point(27, 176);
            this.generateSerialNumber.Name = "generateSerialNumber";
            this.generateSerialNumber.Size = new System.Drawing.Size(149, 23);
            this.generateSerialNumber.TabIndex = 5;
            this.generateSerialNumber.Text = "Generate Serial Number";
            this.generateSerialNumber.UseVisualStyleBackColor = true;
            this.generateSerialNumber.Click += new System.EventHandler(this.generateSerialNumber_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.toolkit_4BindingSource, "Email", true));
            this.emailTextBox.Location = new System.Drawing.Point(91, 25);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(304, 20);
            this.emailTextBox.TabIndex = 1;
            this.emailTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.emailTextBox_Validating);
            this.emailTextBox.Validated += new System.EventHandler(this.emailTextBox_Validated);
            // 
            // first_NameTextBox
            // 
            this.first_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.toolkit_4BindingSource, "First Name", true));
            this.first_NameTextBox.Location = new System.Drawing.Point(91, 61);
            this.first_NameTextBox.Name = "first_NameTextBox";
            this.first_NameTextBox.Size = new System.Drawing.Size(273, 20);
            this.first_NameTextBox.TabIndex = 2;
            this.first_NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.first_NameTextBox_Validating);
            this.first_NameTextBox.Validated += new System.EventHandler(this.first_NameTextBox_Validated);
            // 
            // last_NameTextBox
            // 
            this.last_NameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.toolkit_4BindingSource, "Last Name", true));
            this.last_NameTextBox.Location = new System.Drawing.Point(91, 97);
            this.last_NameTextBox.Name = "last_NameTextBox";
            this.last_NameTextBox.Size = new System.Drawing.Size(273, 20);
            this.last_NameTextBox.TabIndex = 3;
            this.last_NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.last_NameTextBox_Validating);
            this.last_NameTextBox.Validated += new System.EventHandler(this.last_NameTextBox_Validated);
            // 
            // companyTextBox
            // 
            this.companyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.toolkit_4BindingSource, "Company", true));
            this.companyTextBox.Location = new System.Drawing.Point(91, 133);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.Size = new System.Drawing.Size(273, 20);
            this.companyTextBox.TabIndex = 4;
            this.companyTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.companyTextBox_Validating);
            this.companyTextBox.Validated += new System.EventHandler(this.companyTextBox_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // serialNumberLabel
            // 
            this.serialNumberLabel.AutoSize = true;
            this.serialNumberLabel.Location = new System.Drawing.Point(24, 220);
            this.serialNumberLabel.Name = "serialNumberLabel";
            this.serialNumberLabel.Size = new System.Drawing.Size(76, 13);
            this.serialNumberLabel.TabIndex = 12;
            this.serialNumberLabel.Text = "Serial Number:";
            // 
            // toolkit_4BindingSource
            // 
            this.toolkit_4BindingSource.DataMember = "Toolkit 4";
            this.toolkit_4BindingSource.DataSource = this.toolkitSerialNumbersDataSet;
            // 
            // toolkitSerialNumbersDataSet
            // 
            this.toolkitSerialNumbersDataSet.DataSetName = "ToolkitSerialNumbersDataSet";
            this.toolkitSerialNumbersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolkit_4TableAdapter
            // 
            this.toolkit_4TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Toolkit_4TableAdapter = this.toolkit_4TableAdapter;
            this.tableAdapterManager.UpdateOrder = GenerateSerialNumber.ToolkitSerialNumbersDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // GenerateSerialNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(449, 258);
            this.Controls.Add(this.serialNumberLabel);
            this.Controls.Add(companyLabel);
            this.Controls.Add(this.companyTextBox);
            this.Controls.Add(last_NameLabel);
            this.Controls.Add(this.last_NameTextBox);
            this.Controls.Add(first_NameLabel);
            this.Controls.Add(this.first_NameTextBox);
            this.Controls.Add(emailLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.generateSerialNumber);
            this.Controls.Add(this.generatedSerialNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GenerateSerialNumberForm";
            this.Text = "Generate Serial Number";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolkit_4BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolkitSerialNumbersDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolkitSerialNumbersDataSet toolkitSerialNumbersDataSet;
        private System.Windows.Forms.BindingSource toolkit_4BindingSource;
        private ToolkitSerialNumbersDataSetTableAdapters.Toolkit_4TableAdapter toolkit_4TableAdapter;
        private ToolkitSerialNumbersDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox generatedSerialNumber;
        private System.Windows.Forms.Button generateSerialNumber;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox first_NameTextBox;
        private System.Windows.Forms.TextBox last_NameTextBox;
        private System.Windows.Forms.TextBox companyTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label serialNumberLabel;
    }
}

