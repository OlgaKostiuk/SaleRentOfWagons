namespace RentOfWagons
{
    partial class UpdateRent
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.comboBoxOperationType = new System.Windows.Forms.ComboBox();
            this.labelOperationType = new System.Windows.Forms.Label();
            this.textBoxReceiver = new System.Windows.Forms.TextBox();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.labelTransmitter = new System.Windows.Forms.Label();
            this.textBoxTransmitter = new System.Windows.Forms.TextBox();
            this.labelContractNumber = new System.Windows.Forms.Label();
            this.labelWagonNumber = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(281, 352);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(179, 41);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(173, 258);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(287, 20);
            this.dateTimePickerStart.TabIndex = 20;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(48, 264);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(59, 13);
            this.labelStartDate.TabIndex = 19;
            this.labelStartDate.Text = "Start date: ";
            // 
            // comboBoxOperationType
            // 
            this.comboBoxOperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperationType.FormattingEnabled = true;
            this.comboBoxOperationType.Location = new System.Drawing.Point(173, 214);
            this.comboBoxOperationType.Name = "comboBoxOperationType";
            this.comboBoxOperationType.Size = new System.Drawing.Size(287, 21);
            this.comboBoxOperationType.TabIndex = 18;
            // 
            // labelOperationType
            // 
            this.labelOperationType.AutoSize = true;
            this.labelOperationType.Location = new System.Drawing.Point(48, 217);
            this.labelOperationType.Name = "labelOperationType";
            this.labelOperationType.Size = new System.Drawing.Size(79, 13);
            this.labelOperationType.TabIndex = 17;
            this.labelOperationType.Text = "Operation type:";
            // 
            // textBoxReceiver
            // 
            this.textBoxReceiver.Location = new System.Drawing.Point(173, 167);
            this.textBoxReceiver.Name = "textBoxReceiver";
            this.textBoxReceiver.Size = new System.Drawing.Size(287, 20);
            this.textBoxReceiver.TabIndex = 16;
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Location = new System.Drawing.Point(48, 170);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(53, 13);
            this.labelReceiver.TabIndex = 15;
            this.labelReceiver.Text = "Receiver:";
            // 
            // labelTransmitter
            // 
            this.labelTransmitter.AutoSize = true;
            this.labelTransmitter.Location = new System.Drawing.Point(48, 121);
            this.labelTransmitter.Name = "labelTransmitter";
            this.labelTransmitter.Size = new System.Drawing.Size(62, 13);
            this.labelTransmitter.TabIndex = 14;
            this.labelTransmitter.Text = "Transmitter:";
            // 
            // textBoxTransmitter
            // 
            this.textBoxTransmitter.Location = new System.Drawing.Point(173, 118);
            this.textBoxTransmitter.Name = "textBoxTransmitter";
            this.textBoxTransmitter.Size = new System.Drawing.Size(287, 20);
            this.textBoxTransmitter.TabIndex = 13;
            // 
            // labelContractNumber
            // 
            this.labelContractNumber.AutoSize = true;
            this.labelContractNumber.Location = new System.Drawing.Point(48, 76);
            this.labelContractNumber.Name = "labelContractNumber";
            this.labelContractNumber.Size = new System.Drawing.Size(91, 13);
            this.labelContractNumber.TabIndex = 12;
            this.labelContractNumber.Text = "Contract number: ";
            // 
            // labelWagonNumber
            // 
            this.labelWagonNumber.AutoSize = true;
            this.labelWagonNumber.Location = new System.Drawing.Point(48, 33);
            this.labelWagonNumber.Name = "labelWagonNumber";
            this.labelWagonNumber.Size = new System.Drawing.Size(86, 13);
            this.labelWagonNumber.TabIndex = 11;
            this.labelWagonNumber.Text = "Wagon number: ";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(173, 303);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(287, 20);
            this.dateTimePickerEnd.TabIndex = 23;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(48, 309);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(56, 13);
            this.labelEndDate.TabIndex = 22;
            this.labelEndDate.Text = "End date: ";
            // 
            // UpdateRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 405);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.comboBoxOperationType);
            this.Controls.Add(this.labelOperationType);
            this.Controls.Add(this.textBoxReceiver);
            this.Controls.Add(this.labelReceiver);
            this.Controls.Add(this.labelTransmitter);
            this.Controls.Add(this.textBoxTransmitter);
            this.Controls.Add(this.labelContractNumber);
            this.Controls.Add(this.labelWagonNumber);
            this.Name = "UpdateRent";
            this.Text = "Update rent operation";
            this.Load += new System.EventHandler(this.UpdateRent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.ComboBox comboBoxOperationType;
        private System.Windows.Forms.Label labelOperationType;
        private System.Windows.Forms.TextBox textBoxReceiver;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.Label labelTransmitter;
        private System.Windows.Forms.TextBox textBoxTransmitter;
        private System.Windows.Forms.Label labelContractNumber;
        private System.Windows.Forms.Label labelWagonNumber;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label labelEndDate;
    }
}