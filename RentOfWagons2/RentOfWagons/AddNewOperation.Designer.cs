namespace RentOfWagons
{
    partial class AddNewOperation
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
            this.labelWagonNumber = new System.Windows.Forms.Label();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioButtonRent = new System.Windows.Forms.RadioButton();
            this.radioButtonSale = new System.Windows.Forms.RadioButton();
            this.labelTransmitter = new System.Windows.Forms.Label();
            this.comboBoxTransmitters = new System.Windows.Forms.ComboBox();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.comboBoxReceivers = new System.Windows.Forms.ComboBox();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxContractNumber = new System.Windows.Forms.TextBox();
            this.labelContractNumber = new System.Windows.Forms.Label();
            this.labelOperationType = new System.Windows.Forms.Label();
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWagonNumber
            // 
            this.labelWagonNumber.AutoSize = true;
            this.labelWagonNumber.Location = new System.Drawing.Point(53, 22);
            this.labelWagonNumber.Name = "labelWagonNumber";
            this.labelWagonNumber.Size = new System.Drawing.Size(86, 13);
            this.labelWagonNumber.TabIndex = 0;
            this.labelWagonNumber.Text = "Wagon number: ";
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.radioButtonRent);
            this.groupBoxType.Controls.Add(this.radioButtonSale);
            this.groupBoxType.Location = new System.Drawing.Point(34, 53);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Size = new System.Drawing.Size(149, 100);
            this.groupBoxType.TabIndex = 1;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Operation attribute";
            // 
            // radioButtonRent
            // 
            this.radioButtonRent.AutoSize = true;
            this.radioButtonRent.Location = new System.Drawing.Point(22, 62);
            this.radioButtonRent.Name = "radioButtonRent";
            this.radioButtonRent.Size = new System.Drawing.Size(48, 17);
            this.radioButtonRent.TabIndex = 1;
            this.radioButtonRent.TabStop = true;
            this.radioButtonRent.Text = "Rent";
            this.radioButtonRent.UseVisualStyleBackColor = true;
            this.radioButtonRent.CheckedChanged += new System.EventHandler(this.radioButtonRent_CheckedChanged);
            // 
            // radioButtonSale
            // 
            this.radioButtonSale.AutoSize = true;
            this.radioButtonSale.Location = new System.Drawing.Point(22, 29);
            this.radioButtonSale.Name = "radioButtonSale";
            this.radioButtonSale.Size = new System.Drawing.Size(46, 17);
            this.radioButtonSale.TabIndex = 0;
            this.radioButtonSale.TabStop = true;
            this.radioButtonSale.Text = "Sale";
            this.radioButtonSale.UseVisualStyleBackColor = true;
            // 
            // labelTransmitter
            // 
            this.labelTransmitter.AutoSize = true;
            this.labelTransmitter.Location = new System.Drawing.Point(203, 53);
            this.labelTransmitter.Name = "labelTransmitter";
            this.labelTransmitter.Size = new System.Drawing.Size(65, 13);
            this.labelTransmitter.TabIndex = 2;
            this.labelTransmitter.Text = "Transmitter: ";
            // 
            // comboBoxTransmitters
            // 
            this.comboBoxTransmitters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransmitters.FormattingEnabled = true;
            this.comboBoxTransmitters.Location = new System.Drawing.Point(206, 69);
            this.comboBoxTransmitters.Name = "comboBoxTransmitters";
            this.comboBoxTransmitters.Size = new System.Drawing.Size(234, 21);
            this.comboBoxTransmitters.TabIndex = 3;
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Location = new System.Drawing.Point(499, 53);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(56, 13);
            this.labelReceiver.TabIndex = 4;
            this.labelReceiver.Text = "Receiver: ";
            // 
            // comboBoxReceivers
            // 
            this.comboBoxReceivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReceivers.FormattingEnabled = true;
            this.comboBoxReceivers.Location = new System.Drawing.Point(502, 68);
            this.comboBoxReceivers.Name = "comboBoxReceivers";
            this.comboBoxReceivers.Size = new System.Drawing.Size(234, 21);
            this.comboBoxReceivers.TabIndex = 5;
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(34, 265);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(234, 21);
            this.comboBoxTypes.TabIndex = 6;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(206, 171);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerStart.TabIndex = 7;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(502, 171);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerEnd.TabIndex = 8;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(206, 139);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(59, 13);
            this.labelStartDate.TabIndex = 9;
            this.labelStartDate.Text = "Start date: ";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(499, 139);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(56, 13);
            this.labelEndDate.TabIndex = 10;
            this.labelEndDate.Text = "End date: ";
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(557, 245);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(179, 41);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxContractNumber
            // 
            this.textBoxContractNumber.Location = new System.Drawing.Point(352, 266);
            this.textBoxContractNumber.MaxLength = 10;
            this.textBoxContractNumber.Name = "textBoxContractNumber";
            this.textBoxContractNumber.Size = new System.Drawing.Size(149, 20);
            this.textBoxContractNumber.TabIndex = 12;
            // 
            // labelContractNumber
            // 
            this.labelContractNumber.AutoSize = true;
            this.labelContractNumber.Location = new System.Drawing.Point(349, 245);
            this.labelContractNumber.Name = "labelContractNumber";
            this.labelContractNumber.Size = new System.Drawing.Size(91, 13);
            this.labelContractNumber.TabIndex = 13;
            this.labelContractNumber.Text = "Contract number: ";
            // 
            // labelOperationType
            // 
            this.labelOperationType.AutoSize = true;
            this.labelOperationType.Location = new System.Drawing.Point(34, 244);
            this.labelOperationType.Name = "labelOperationType";
            this.labelOperationType.Size = new System.Drawing.Size(79, 13);
            this.labelOperationType.TabIndex = 14;
            this.labelOperationType.Text = "Operation type:";
            // 
            // AddNewOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 334);
            this.Controls.Add(this.labelOperationType);
            this.Controls.Add(this.labelContractNumber);
            this.Controls.Add(this.textBoxContractNumber);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.comboBoxTypes);
            this.Controls.Add(this.comboBoxReceivers);
            this.Controls.Add(this.labelReceiver);
            this.Controls.Add(this.comboBoxTransmitters);
            this.Controls.Add(this.labelTransmitter);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.labelWagonNumber);
            this.Name = "AddNewOperation";
            this.Text = "Add new operation";
            this.Load += new System.EventHandler(this.AddNewOperation_Load);
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWagonNumber;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioButtonRent;
        private System.Windows.Forms.RadioButton radioButtonSale;
        private System.Windows.Forms.Label labelTransmitter;
        private System.Windows.Forms.ComboBox comboBoxTransmitters;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.ComboBox comboBoxReceivers;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxContractNumber;
        private System.Windows.Forms.Label labelContractNumber;
        private System.Windows.Forms.Label labelOperationType;
    }
}