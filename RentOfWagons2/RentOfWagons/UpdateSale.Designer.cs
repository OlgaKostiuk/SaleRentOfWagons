namespace RentOfWagons
{
    partial class UpdateSale
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
            this.labelContractNumber = new System.Windows.Forms.Label();
            this.textBoxTransmitter = new System.Windows.Forms.TextBox();
            this.labelTransmitter = new System.Windows.Forms.Label();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.textBoxReceiver = new System.Windows.Forms.TextBox();
            this.labelOperationType = new System.Windows.Forms.Label();
            this.comboBoxOperationType = new System.Windows.Forms.ComboBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelWagonNumber
            // 
            this.labelWagonNumber.AutoSize = true;
            this.labelWagonNumber.Location = new System.Drawing.Point(30, 38);
            this.labelWagonNumber.Name = "labelWagonNumber";
            this.labelWagonNumber.Size = new System.Drawing.Size(86, 13);
            this.labelWagonNumber.TabIndex = 0;
            this.labelWagonNumber.Text = "Wagon number: ";
            // 
            // labelContractNumber
            // 
            this.labelContractNumber.AutoSize = true;
            this.labelContractNumber.Location = new System.Drawing.Point(30, 81);
            this.labelContractNumber.Name = "labelContractNumber";
            this.labelContractNumber.Size = new System.Drawing.Size(91, 13);
            this.labelContractNumber.TabIndex = 1;
            this.labelContractNumber.Text = "Contract number: ";
            // 
            // textBoxTransmitter
            // 
            this.textBoxTransmitter.Location = new System.Drawing.Point(155, 123);
            this.textBoxTransmitter.Name = "textBoxTransmitter";
            this.textBoxTransmitter.Size = new System.Drawing.Size(287, 20);
            this.textBoxTransmitter.TabIndex = 2;
            // 
            // labelTransmitter
            // 
            this.labelTransmitter.AutoSize = true;
            this.labelTransmitter.Location = new System.Drawing.Point(30, 126);
            this.labelTransmitter.Name = "labelTransmitter";
            this.labelTransmitter.Size = new System.Drawing.Size(62, 13);
            this.labelTransmitter.TabIndex = 3;
            this.labelTransmitter.Text = "Transmitter:";
            // 
            // labelReceiver
            // 
            this.labelReceiver.AutoSize = true;
            this.labelReceiver.Location = new System.Drawing.Point(30, 175);
            this.labelReceiver.Name = "labelReceiver";
            this.labelReceiver.Size = new System.Drawing.Size(53, 13);
            this.labelReceiver.TabIndex = 4;
            this.labelReceiver.Text = "Receiver:";
            // 
            // textBoxReceiver
            // 
            this.textBoxReceiver.Location = new System.Drawing.Point(155, 172);
            this.textBoxReceiver.Name = "textBoxReceiver";
            this.textBoxReceiver.Size = new System.Drawing.Size(287, 20);
            this.textBoxReceiver.TabIndex = 5;
            // 
            // labelOperationType
            // 
            this.labelOperationType.AutoSize = true;
            this.labelOperationType.Location = new System.Drawing.Point(30, 222);
            this.labelOperationType.Name = "labelOperationType";
            this.labelOperationType.Size = new System.Drawing.Size(79, 13);
            this.labelOperationType.TabIndex = 6;
            this.labelOperationType.Text = "Operation type:";
            // 
            // comboBoxOperationType
            // 
            this.comboBoxOperationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperationType.FormattingEnabled = true;
            this.comboBoxOperationType.Location = new System.Drawing.Point(155, 219);
            this.comboBoxOperationType.Name = "comboBoxOperationType";
            this.comboBoxOperationType.Size = new System.Drawing.Size(287, 21);
            this.comboBoxOperationType.TabIndex = 7;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(30, 276);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(59, 13);
            this.labelStartDate.TabIndex = 8;
            this.labelStartDate.Text = "Start date: ";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(155, 276);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(287, 20);
            this.dateTimePickerStart.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.Location = new System.Drawing.Point(263, 335);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(179, 41);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // UpdateSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 405);
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
            this.Name = "UpdateSale";
            this.Text = "Update sale operation";
            this.Load += new System.EventHandler(this.UpdateSale_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWagonNumber;
        private System.Windows.Forms.Label labelContractNumber;
        private System.Windows.Forms.TextBox textBoxTransmitter;
        private System.Windows.Forms.Label labelTransmitter;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.TextBox textBoxReceiver;
        private System.Windows.Forms.Label labelOperationType;
        private System.Windows.Forms.ComboBox comboBoxOperationType;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button buttonSave;
    }
}