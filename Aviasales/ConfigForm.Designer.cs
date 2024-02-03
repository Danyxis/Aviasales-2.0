namespace Aviasales
{
    partial class ConfigForm
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
            this.RunwaysLabel = new System.Windows.Forms.Label();
            this.DerivationLabel = new System.Windows.Forms.Label();
            this.SimulationCoefficientLabel = new System.Windows.Forms.Label();
            this.RunwaysCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SimulationCoefficientMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DerivationToMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.RunSimulationButton = new System.Windows.Forms.Button();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RunwaysLabel
            // 
            this.RunwaysLabel.AutoSize = true;
            this.RunwaysLabel.Location = new System.Drawing.Point(8, 34);
            this.RunwaysLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RunwaysLabel.Name = "RunwaysLabel";
            this.RunwaysLabel.Size = new System.Drawing.Size(209, 13);
            this.RunwaysLabel.TabIndex = 0;
            this.RunwaysLabel.Text = "Количество взлётно-посадочных полос:";
            // 
            // DerivationLabel
            // 
            this.DerivationLabel.AutoSize = true;
            this.DerivationLabel.Location = new System.Drawing.Point(8, 65);
            this.DerivationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DerivationLabel.Name = "DerivationLabel";
            this.DerivationLabel.Size = new System.Drawing.Size(160, 13);
            this.DerivationLabel.TabIndex = 1;
            this.DerivationLabel.Text = "Параметры отклонений (мин):";
            this.DerivationLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // SimulationCoefficientLabel
            // 
            this.SimulationCoefficientLabel.AutoSize = true;
            this.SimulationCoefficientLabel.Location = new System.Drawing.Point(8, 96);
            this.SimulationCoefficientLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SimulationCoefficientLabel.Name = "SimulationCoefficientLabel";
            this.SimulationCoefficientLabel.Size = new System.Drawing.Size(193, 13);
            this.SimulationCoefficientLabel.TabIndex = 2;
            this.SimulationCoefficientLabel.Text = "Коэффициент шага симуляции (сек):";
            this.SimulationCoefficientLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // RunwaysCountMaskedTextBox
            // 
            this.RunwaysCountMaskedTextBox.Location = new System.Drawing.Point(235, 31);
            this.RunwaysCountMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RunwaysCountMaskedTextBox.Name = "RunwaysCountMaskedTextBox";
            this.RunwaysCountMaskedTextBox.Size = new System.Drawing.Size(68, 20);
            this.RunwaysCountMaskedTextBox.TabIndex = 4;
            // 
            // SimulationCoefficientMaskedTextBox
            // 
            this.SimulationCoefficientMaskedTextBox.Location = new System.Drawing.Point(235, 93);
            this.SimulationCoefficientMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.SimulationCoefficientMaskedTextBox.Name = "SimulationCoefficientMaskedTextBox";
            this.SimulationCoefficientMaskedTextBox.Size = new System.Drawing.Size(68, 20);
            this.SimulationCoefficientMaskedTextBox.TabIndex = 5;
            this.SimulationCoefficientMaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.SimulationCoefficientMaskedTextBox_MaskInputRejected);
            // 
            // DerivationToMaskedTextBox
            // 
            this.DerivationToMaskedTextBox.Location = new System.Drawing.Point(235, 62);
            this.DerivationToMaskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DerivationToMaskedTextBox.Name = "DerivationToMaskedTextBox";
            this.DerivationToMaskedTextBox.Size = new System.Drawing.Size(68, 20);
            this.DerivationToMaskedTextBox.TabIndex = 10;
            // 
            // RunSimulationButton
            // 
            this.RunSimulationButton.Location = new System.Drawing.Point(208, 251);
            this.RunSimulationButton.Margin = new System.Windows.Forms.Padding(2);
            this.RunSimulationButton.Name = "RunSimulationButton";
            this.RunSimulationButton.Size = new System.Drawing.Size(135, 30);
            this.RunSimulationButton.TabIndex = 11;
            this.RunSimulationButton.Text = "Запустить симуляцию";
            this.RunSimulationButton.UseVisualStyleBackColor = true;
            this.RunSimulationButton.Click += new System.EventHandler(this.RunSimulationButton_Click);
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "MM\'/\'dd\'/\'yyyy HH\':\'mm";
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(197, 124);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(106, 20);
            this.startTimePicker.TabIndex = 12;
            this.startTimePicker.Value = new System.DateTime(2024, 1, 19, 11, 19, 56, 0);
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 127);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Дата и время начала симуляции:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 292);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.RunSimulationButton);
            this.Controls.Add(this.DerivationToMaskedTextBox);
            this.Controls.Add(this.SimulationCoefficientMaskedTextBox);
            this.Controls.Add(this.RunwaysCountMaskedTextBox);
            this.Controls.Add(this.SimulationCoefficientLabel);
            this.Controls.Add(this.DerivationLabel);
            this.Controls.Add(this.RunwaysLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigForm";
            this.Text = "Настройка параметров симуляции";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RunwaysLabel;
        private System.Windows.Forms.Label DerivationLabel;
        private System.Windows.Forms.Label SimulationCoefficientLabel;
        private System.Windows.Forms.MaskedTextBox RunwaysCountMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox SimulationCoefficientMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox DerivationToMaskedTextBox;
        private System.Windows.Forms.Button RunSimulationButton;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label label1;
    }
}