namespace RentOfWagons
{
    partial class MainForm
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
            this.comboBoxWagons = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddOperation = new System.Windows.Forms.Button();
            this.buttonShowOperations = new System.Windows.Forms.Button();
            this.dataGridViewOperations = new System.Windows.Forms.DataGridView();
            this.buttonDeleteOperation = new System.Windows.Forms.Button();
            this.buttonUpdateOperation = new System.Windows.Forms.Button();
            this.operationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attributeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transmitterContractorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transmitterDepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiverContractorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiverDepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewOperationModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOperationModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxWagons
            // 
            this.comboBoxWagons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWagons.FormattingEnabled = true;
            this.comboBoxWagons.Location = new System.Drawing.Point(15, 50);
            this.comboBoxWagons.Name = "comboBoxWagons";
            this.comboBoxWagons.Size = new System.Drawing.Size(221, 21);
            this.comboBoxWagons.TabIndex = 0;
            this.comboBoxWagons.SelectedIndexChanged += new System.EventHandler(this.comboBoxWagons_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of wagons:";
            // 
            // buttonAddOperation
            // 
            this.buttonAddOperation.Location = new System.Drawing.Point(272, 77);
            this.buttonAddOperation.Name = "buttonAddOperation";
            this.buttonAddOperation.Size = new System.Drawing.Size(221, 23);
            this.buttonAddOperation.TabIndex = 2;
            this.buttonAddOperation.Text = "Add operation for selected wagon";
            this.buttonAddOperation.UseVisualStyleBackColor = true;
            this.buttonAddOperation.Click += new System.EventHandler(this.buttonAddOperation_Click);
            // 
            // buttonShowOperations
            // 
            this.buttonShowOperations.Location = new System.Drawing.Point(15, 77);
            this.buttonShowOperations.Name = "buttonShowOperations";
            this.buttonShowOperations.Size = new System.Drawing.Size(221, 23);
            this.buttonShowOperations.TabIndex = 3;
            this.buttonShowOperations.Text = "Show operations for selected wagon";
            this.buttonShowOperations.UseVisualStyleBackColor = true;
            this.buttonShowOperations.Click += new System.EventHandler(this.buttonShowOperations_Click);
            // 
            // dataGridViewOperations
            // 
            this.dataGridViewOperations.AllowUserToAddRows = false;
            this.dataGridViewOperations.AllowUserToDeleteRows = false;
            this.dataGridViewOperations.AllowUserToOrderColumns = true;
            this.dataGridViewOperations.AllowUserToResizeRows = false;
            this.dataGridViewOperations.AutoGenerateColumns = false;
            this.dataGridViewOperations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOperations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.operationIDDataGridViewTextBoxColumn,
            this.contractNumberDataGridViewTextBoxColumn,
            this.attributeDataGridViewTextBoxColumn,
            this.rentLevelDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.transmitterContractorDataGridViewTextBoxColumn,
            this.transmitterDepartmentDataGridViewTextBoxColumn,
            this.receiverContractorDataGridViewTextBoxColumn,
            this.receiverDepartmentDataGridViewTextBoxColumn,
            this.contractDateDataGridViewTextBoxColumn});
            this.dataGridViewOperations.DataSource = this.viewOperationModelBindingSource;
            this.dataGridViewOperations.Location = new System.Drawing.Point(12, 122);
            this.dataGridViewOperations.MultiSelect = false;
            this.dataGridViewOperations.Name = "dataGridViewOperations";
            this.dataGridViewOperations.ReadOnly = true;
            this.dataGridViewOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOperations.Size = new System.Drawing.Size(1140, 403);
            this.dataGridViewOperations.TabIndex = 4;
            // 
            // buttonDeleteOperation
            // 
            this.buttonDeleteOperation.Location = new System.Drawing.Point(530, 77);
            this.buttonDeleteOperation.Name = "buttonDeleteOperation";
            this.buttonDeleteOperation.Size = new System.Drawing.Size(221, 23);
            this.buttonDeleteOperation.TabIndex = 5;
            this.buttonDeleteOperation.Text = "Delete selected operation";
            this.buttonDeleteOperation.UseVisualStyleBackColor = true;
            this.buttonDeleteOperation.Click += new System.EventHandler(this.buttonDeleteOperation_Click);
            // 
            // buttonUpdateOperation
            // 
            this.buttonUpdateOperation.Location = new System.Drawing.Point(785, 77);
            this.buttonUpdateOperation.Name = "buttonUpdateOperation";
            this.buttonUpdateOperation.Size = new System.Drawing.Size(221, 23);
            this.buttonUpdateOperation.TabIndex = 6;
            this.buttonUpdateOperation.Text = "Update selected operation";
            this.buttonUpdateOperation.UseVisualStyleBackColor = true;
            this.buttonUpdateOperation.Click += new System.EventHandler(this.buttonUpdateOperation_Click);
            // 
            // operationIDDataGridViewTextBoxColumn
            // 
            this.operationIDDataGridViewTextBoxColumn.DataPropertyName = "OperationID";
            this.operationIDDataGridViewTextBoxColumn.HeaderText = "OperationID";
            this.operationIDDataGridViewTextBoxColumn.Name = "operationIDDataGridViewTextBoxColumn";
            this.operationIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.operationIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // contractNumberDataGridViewTextBoxColumn
            // 
            this.contractNumberDataGridViewTextBoxColumn.DataPropertyName = "ContractNumber";
            this.contractNumberDataGridViewTextBoxColumn.HeaderText = "ContractNumber";
            this.contractNumberDataGridViewTextBoxColumn.Name = "contractNumberDataGridViewTextBoxColumn";
            this.contractNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // attributeDataGridViewTextBoxColumn
            // 
            this.attributeDataGridViewTextBoxColumn.DataPropertyName = "Attribute";
            this.attributeDataGridViewTextBoxColumn.HeaderText = "Attribute";
            this.attributeDataGridViewTextBoxColumn.Name = "attributeDataGridViewTextBoxColumn";
            this.attributeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rentLevelDataGridViewTextBoxColumn
            // 
            this.rentLevelDataGridViewTextBoxColumn.DataPropertyName = "RentLevel";
            this.rentLevelDataGridViewTextBoxColumn.HeaderText = "RentLevel";
            this.rentLevelDataGridViewTextBoxColumn.Name = "rentLevelDataGridViewTextBoxColumn";
            this.rentLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "StartDate";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "EndDate";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transmitterContractorDataGridViewTextBoxColumn
            // 
            this.transmitterContractorDataGridViewTextBoxColumn.DataPropertyName = "TransmitterContractor";
            this.transmitterContractorDataGridViewTextBoxColumn.HeaderText = "TransmitterContractor";
            this.transmitterContractorDataGridViewTextBoxColumn.Name = "transmitterContractorDataGridViewTextBoxColumn";
            this.transmitterContractorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transmitterDepartmentDataGridViewTextBoxColumn
            // 
            this.transmitterDepartmentDataGridViewTextBoxColumn.DataPropertyName = "TransmitterDepartment";
            this.transmitterDepartmentDataGridViewTextBoxColumn.HeaderText = "TransmitterDepartment";
            this.transmitterDepartmentDataGridViewTextBoxColumn.Name = "transmitterDepartmentDataGridViewTextBoxColumn";
            this.transmitterDepartmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receiverContractorDataGridViewTextBoxColumn
            // 
            this.receiverContractorDataGridViewTextBoxColumn.DataPropertyName = "ReceiverContractor";
            this.receiverContractorDataGridViewTextBoxColumn.HeaderText = "ReceiverContractor";
            this.receiverContractorDataGridViewTextBoxColumn.Name = "receiverContractorDataGridViewTextBoxColumn";
            this.receiverContractorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receiverDepartmentDataGridViewTextBoxColumn
            // 
            this.receiverDepartmentDataGridViewTextBoxColumn.DataPropertyName = "ReceiverDepartment";
            this.receiverDepartmentDataGridViewTextBoxColumn.HeaderText = "ReceiverDepartment";
            this.receiverDepartmentDataGridViewTextBoxColumn.Name = "receiverDepartmentDataGridViewTextBoxColumn";
            this.receiverDepartmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contractDateDataGridViewTextBoxColumn
            // 
            this.contractDateDataGridViewTextBoxColumn.DataPropertyName = "ContractDate";
            this.contractDateDataGridViewTextBoxColumn.HeaderText = "ContractDate";
            this.contractDateDataGridViewTextBoxColumn.Name = "contractDateDataGridViewTextBoxColumn";
            this.contractDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // viewOperationModelBindingSource
            // 
            this.viewOperationModelBindingSource.DataSource = typeof(RentOfWagons.viewOperationModel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 537);
            this.Controls.Add(this.buttonUpdateOperation);
            this.Controls.Add(this.buttonDeleteOperation);
            this.Controls.Add(this.dataGridViewOperations);
            this.Controls.Add(this.buttonShowOperations);
            this.Controls.Add(this.buttonAddOperation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxWagons);
            this.Name = "MainForm";
            this.Text = "Operations";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewOperationModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWagons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddOperation;
        private System.Windows.Forms.Button buttonShowOperations;
        private System.Windows.Forms.DataGridView dataGridViewOperations;
        private System.Windows.Forms.BindingSource viewOperationModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transmitterContractorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transmitterDepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiverContractorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiverDepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonDeleteOperation;
        private System.Windows.Forms.Button buttonUpdateOperation;
    }
}

