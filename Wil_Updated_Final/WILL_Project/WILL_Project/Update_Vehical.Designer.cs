namespace WILL_Project
{
    partial class Update_Vehical
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.vehicalIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicalMakeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicalModelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicalYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vINNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engineSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPlateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataBaseDataSet5 = new WILL_Project.DataBaseDataSet5();
            this.tb_Model = new System.Windows.Forms.TextBox();
            this.tb_Year = new System.Windows.Forms.TextBox();
            this.tb_VIN = new System.Windows.Forms.TextBox();
            this.tb_EngineSize = new System.Windows.Forms.TextBox();
            this.tb_NP = new System.Windows.Forms.TextBox();
            this.tb_Capacity = new System.Windows.Forms.TextBox();
            this.tb_Make = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.vehicalTableAdapter = new WILL_Project.DataBaseDataSet5TableAdapters.VehicalTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet5)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vehicalIDDataGridViewTextBoxColumn,
            this.vehicalMakeDataGridViewTextBoxColumn,
            this.vehicalModelDataGridViewTextBoxColumn,
            this.vehicalYearDataGridViewTextBoxColumn,
            this.vINNumberDataGridViewTextBoxColumn,
            this.engineSizeDataGridViewTextBoxColumn,
            this.numberPlateDataGridViewTextBoxColumn,
            this.capacityDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.vehicalBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(35, 87);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 358);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // vehicalIDDataGridViewTextBoxColumn
            // 
            this.vehicalIDDataGridViewTextBoxColumn.DataPropertyName = "VehicalID";
            this.vehicalIDDataGridViewTextBoxColumn.HeaderText = "VehicalID";
            this.vehicalIDDataGridViewTextBoxColumn.Name = "vehicalIDDataGridViewTextBoxColumn";
            this.vehicalIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.vehicalIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // vehicalMakeDataGridViewTextBoxColumn
            // 
            this.vehicalMakeDataGridViewTextBoxColumn.DataPropertyName = "Vehical_Make";
            this.vehicalMakeDataGridViewTextBoxColumn.HeaderText = "Make";
            this.vehicalMakeDataGridViewTextBoxColumn.Name = "vehicalMakeDataGridViewTextBoxColumn";
            this.vehicalMakeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicalModelDataGridViewTextBoxColumn
            // 
            this.vehicalModelDataGridViewTextBoxColumn.DataPropertyName = "Vehical_Model";
            this.vehicalModelDataGridViewTextBoxColumn.HeaderText = "Model";
            this.vehicalModelDataGridViewTextBoxColumn.Name = "vehicalModelDataGridViewTextBoxColumn";
            this.vehicalModelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicalYearDataGridViewTextBoxColumn
            // 
            this.vehicalYearDataGridViewTextBoxColumn.DataPropertyName = "Vehical_Year";
            this.vehicalYearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.vehicalYearDataGridViewTextBoxColumn.Name = "vehicalYearDataGridViewTextBoxColumn";
            this.vehicalYearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vINNumberDataGridViewTextBoxColumn
            // 
            this.vINNumberDataGridViewTextBoxColumn.DataPropertyName = "VIN_Number";
            this.vINNumberDataGridViewTextBoxColumn.HeaderText = "VIN Number";
            this.vINNumberDataGridViewTextBoxColumn.Name = "vINNumberDataGridViewTextBoxColumn";
            this.vINNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // engineSizeDataGridViewTextBoxColumn
            // 
            this.engineSizeDataGridViewTextBoxColumn.DataPropertyName = "Engine_Size";
            this.engineSizeDataGridViewTextBoxColumn.HeaderText = "Engine Size";
            this.engineSizeDataGridViewTextBoxColumn.Name = "engineSizeDataGridViewTextBoxColumn";
            this.engineSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberPlateDataGridViewTextBoxColumn
            // 
            this.numberPlateDataGridViewTextBoxColumn.DataPropertyName = "Number_Plate";
            this.numberPlateDataGridViewTextBoxColumn.HeaderText = "Number Plate";
            this.numberPlateDataGridViewTextBoxColumn.Name = "numberPlateDataGridViewTextBoxColumn";
            this.numberPlateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // capacityDataGridViewTextBoxColumn
            // 
            this.capacityDataGridViewTextBoxColumn.DataPropertyName = "Capacity";
            this.capacityDataGridViewTextBoxColumn.HeaderText = "Capacity";
            this.capacityDataGridViewTextBoxColumn.Name = "capacityDataGridViewTextBoxColumn";
            this.capacityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Visible = false;
            // 
            // vehicalBindingSource
            // 
            this.vehicalBindingSource.DataMember = "Vehical";
            this.vehicalBindingSource.DataSource = this.dataBaseDataSet5;
            // 
            // dataBaseDataSet5
            // 
            this.dataBaseDataSet5.DataSetName = "DataBaseDataSet5";
            this.dataBaseDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_Model
            // 
            this.tb_Model.Location = new System.Drawing.Point(276, 544);
            this.tb_Model.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Model.Name = "tb_Model";
            this.tb_Model.Size = new System.Drawing.Size(233, 22);
            this.tb_Model.TabIndex = 17;
            this.tb_Model.TextChanged += new System.EventHandler(this.Tb_Model_TextChanged);
            // 
            // tb_Year
            // 
            this.tb_Year.Location = new System.Drawing.Point(276, 576);
            this.tb_Year.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Year.Name = "tb_Year";
            this.tb_Year.Size = new System.Drawing.Size(233, 22);
            this.tb_Year.TabIndex = 16;
            this.tb_Year.TextChanged += new System.EventHandler(this.Tb_Year_TextChanged);
            // 
            // tb_VIN
            // 
            this.tb_VIN.Location = new System.Drawing.Point(276, 608);
            this.tb_VIN.Margin = new System.Windows.Forms.Padding(4);
            this.tb_VIN.Name = "tb_VIN";
            this.tb_VIN.Size = new System.Drawing.Size(233, 22);
            this.tb_VIN.TabIndex = 15;
            this.tb_VIN.TextChanged += new System.EventHandler(this.Tb_VIN_TextChanged);
            // 
            // tb_EngineSize
            // 
            this.tb_EngineSize.Location = new System.Drawing.Point(721, 512);
            this.tb_EngineSize.Margin = new System.Windows.Forms.Padding(4);
            this.tb_EngineSize.Name = "tb_EngineSize";
            this.tb_EngineSize.Size = new System.Drawing.Size(224, 22);
            this.tb_EngineSize.TabIndex = 14;
            this.tb_EngineSize.TextChanged += new System.EventHandler(this.Tb_EngineSize_TextChanged);
            // 
            // tb_NP
            // 
            this.tb_NP.Location = new System.Drawing.Point(723, 544);
            this.tb_NP.Margin = new System.Windows.Forms.Padding(4);
            this.tb_NP.Name = "tb_NP";
            this.tb_NP.Size = new System.Drawing.Size(224, 22);
            this.tb_NP.TabIndex = 13;
            this.tb_NP.TextChanged += new System.EventHandler(this.Tb_NP_TextChanged);
            // 
            // tb_Capacity
            // 
            this.tb_Capacity.Location = new System.Drawing.Point(723, 576);
            this.tb_Capacity.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Capacity.Name = "tb_Capacity";
            this.tb_Capacity.Size = new System.Drawing.Size(224, 22);
            this.tb_Capacity.TabIndex = 12;
            this.tb_Capacity.TextChanged += new System.EventHandler(this.Tb_Capacity_TextChanged);
            // 
            // tb_Make
            // 
            this.tb_Make.Location = new System.Drawing.Point(276, 512);
            this.tb_Make.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Make.Name = "tb_Make";
            this.tb_Make.Size = new System.Drawing.Size(233, 22);
            this.tb_Make.TabIndex = 11;
            this.tb_Make.TextChanged += new System.EventHandler(this.Tb_Make_TextChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(131)))), ((int)(((byte)(47)))));
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(927, 645);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(173, 33);
            this.btn_Update.TabIndex = 19;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // vehicalTableAdapter
            // 
            this.vehicalTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(276, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "Select the row you would like to edit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(29, 21);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(237, 29);
            this.label10.TabIndex = 73;
            this.label10.Text = "Vehicle Information";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(157, 469);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(352, 20);
            this.label8.TabIndex = 75;
            this.label8.Text = "Enter the information you would like to change";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 612);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 83;
            this.label4.Text = "VIN Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 580);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 82;
            this.label3.Text = "Vehicle Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 546);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 81;
            this.label2.Text = "Vehicle Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 512);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 80;
            this.label1.Text = "Vehicle Make:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(601, 580);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 86;
            this.label6.Text = "Capacity:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(601, 546);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 85;
            this.label9.Text = "Number plate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(601, 512);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 17);
            this.label11.TabIndex = 84;
            this.label11.Text = "Engine size:";
            // 
            // Update_Vehical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.tb_Model);
            this.Controls.Add(this.tb_Year);
            this.Controls.Add(this.tb_VIN);
            this.Controls.Add(this.tb_EngineSize);
            this.Controls.Add(this.tb_NP);
            this.Controls.Add(this.tb_Capacity);
            this.Controls.Add(this.tb_Make);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Update_Vehical";
            this.Size = new System.Drawing.Size(1137, 706);
            this.Load += new System.EventHandler(this.Update_Vehical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseDataSet5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource vehicalBindingSource;
        private DataBaseDataSet5 dataBaseDataSet5;
        private System.Windows.Forms.TextBox tb_Model;
        private System.Windows.Forms.TextBox tb_Year;
        private System.Windows.Forms.TextBox tb_VIN;
        private System.Windows.Forms.TextBox tb_EngineSize;
        private System.Windows.Forms.TextBox tb_NP;
        private System.Windows.Forms.TextBox tb_Capacity;
        private System.Windows.Forms.TextBox tb_Make;
        private System.Windows.Forms.Button btn_Update;
        private DataBaseDataSet5TableAdapters.VehicalTableAdapter vehicalTableAdapter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicalIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicalMakeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicalModelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehicalYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vINNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn engineSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPlateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}
