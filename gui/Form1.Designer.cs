namespace gui
{
    partial class MainWindow
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
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.PointsAmountLabel = new System.Windows.Forms.Label();
            this.RightBorderLabel = new System.Windows.Forms.Label();
            this.LeftBorderLabel = new System.Windows.Forms.Label();
            this.PointsAmountField = new System.Windows.Forms.TextBox();
            this.RightBorderField = new System.Windows.Forms.TextBox();
            this.LeftBorderField = new System.Windows.Forms.TextBox();
            this.SelectMethodField = new System.Windows.Forms.ComboBox();
            this.PointsBox = new System.Windows.Forms.GroupBox();
            this.AnalyticFunctionsCombo = new System.Windows.Forms.ComboBox();
            this.AnalyticFunctionRadio = new System.Windows.Forms.RadioButton();
            this.GeneratePointsAmoutLabel = new System.Windows.Forms.Label();
            this.GeneratePointAmountField = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.GenerateRangeLabel = new System.Windows.Forms.Label();
            this.GenerateToField = new System.Windows.Forms.TextBox();
            this.GenerateFromField = new System.Windows.Forms.TextBox();
            this.ReadPointsFromFileLabel = new System.Windows.Forms.Label();
            this.ReadPointsFromFileButton = new System.Windows.Forms.Button();
            this.InputPointsRadio = new System.Windows.Forms.RadioButton();
            this.GeneratePointsRadio = new System.Windows.Forms.RadioButton();
            this.ApproximationGraphBox = new System.Windows.Forms.PictureBox();
            this.ErrorGraphBox = new System.Windows.Forms.PictureBox();
            this.ApproximationResultLabel = new System.Windows.Forms.Label();
            this.ApproximationErrorLabel = new System.Windows.Forms.Label();
            this.SaveResultCheck = new System.Windows.Forms.CheckBox();
            this.ApproximateButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SettingsBox.SuspendLayout();
            this.PointsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApproximationGraphBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorGraphBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.PointsAmountLabel);
            this.SettingsBox.Controls.Add(this.RightBorderLabel);
            this.SettingsBox.Controls.Add(this.LeftBorderLabel);
            this.SettingsBox.Controls.Add(this.PointsAmountField);
            this.SettingsBox.Controls.Add(this.RightBorderField);
            this.SettingsBox.Controls.Add(this.LeftBorderField);
            this.SettingsBox.Controls.Add(this.SelectMethodField);
            this.SettingsBox.Location = new System.Drawing.Point(12, 62);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(269, 324);
            this.SettingsBox.TabIndex = 0;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Settings";
            // 
            // PointsAmountLabel
            // 
            this.PointsAmountLabel.AutoSize = true;
            this.PointsAmountLabel.Location = new System.Drawing.Point(40, 178);
            this.PointsAmountLabel.Name = "PointsAmountLabel";
            this.PointsAmountLabel.Size = new System.Drawing.Size(75, 13);
            this.PointsAmountLabel.TabIndex = 7;
            this.PointsAmountLabel.Text = "Points Amount";
            // 
            // RightBorderLabel
            // 
            this.RightBorderLabel.AutoSize = true;
            this.RightBorderLabel.Location = new System.Drawing.Point(40, 128);
            this.RightBorderLabel.Name = "RightBorderLabel";
            this.RightBorderLabel.Size = new System.Drawing.Size(66, 13);
            this.RightBorderLabel.TabIndex = 6;
            this.RightBorderLabel.Text = "Right Border";
            // 
            // LeftBorderLabel
            // 
            this.LeftBorderLabel.AutoSize = true;
            this.LeftBorderLabel.Location = new System.Drawing.Point(40, 78);
            this.LeftBorderLabel.Name = "LeftBorderLabel";
            this.LeftBorderLabel.Size = new System.Drawing.Size(59, 13);
            this.LeftBorderLabel.TabIndex = 5;
            this.LeftBorderLabel.Text = "Left Border";
            // 
            // PointsAmountField
            // 
            this.PointsAmountField.Location = new System.Drawing.Point(126, 175);
            this.PointsAmountField.Name = "PointsAmountField";
            this.PointsAmountField.Size = new System.Drawing.Size(100, 20);
            this.PointsAmountField.TabIndex = 4;
            // 
            // RightBorderField
            // 
            this.RightBorderField.Location = new System.Drawing.Point(126, 125);
            this.RightBorderField.Name = "RightBorderField";
            this.RightBorderField.Size = new System.Drawing.Size(100, 20);
            this.RightBorderField.TabIndex = 3;
            // 
            // LeftBorderField
            // 
            this.LeftBorderField.Location = new System.Drawing.Point(126, 75);
            this.LeftBorderField.Name = "LeftBorderField";
            this.LeftBorderField.Size = new System.Drawing.Size(100, 20);
            this.LeftBorderField.TabIndex = 2;
            // 
            // SelectMethodField
            // 
            this.SelectMethodField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectMethodField.FormattingEnabled = true;
            this.SelectMethodField.Items.AddRange(new object[] {
            "Approximation Method",
            "Cube Splines",
            "Factorial",
            "Lagrange polynomial",
            "Least Squares",
            "Newton polynomial"});
            this.SelectMethodField.Location = new System.Drawing.Point(6, 19);
            this.SelectMethodField.Name = "SelectMethodField";
            this.SelectMethodField.Size = new System.Drawing.Size(257, 21);
            this.SelectMethodField.TabIndex = 1;
            this.SelectMethodField.SelectedIndexChanged += new System.EventHandler(this.SelectMethodField_SelectedIndexChanged);
            // 
            // PointsBox
            // 
            this.PointsBox.Controls.Add(this.AnalyticFunctionsCombo);
            this.PointsBox.Controls.Add(this.AnalyticFunctionRadio);
            this.PointsBox.Controls.Add(this.GeneratePointsAmoutLabel);
            this.PointsBox.Controls.Add(this.GeneratePointAmountField);
            this.PointsBox.Controls.Add(this.GenerateButton);
            this.PointsBox.Controls.Add(this.GenerateRangeLabel);
            this.PointsBox.Controls.Add(this.GenerateToField);
            this.PointsBox.Controls.Add(this.GenerateFromField);
            this.PointsBox.Controls.Add(this.ReadPointsFromFileLabel);
            this.PointsBox.Controls.Add(this.ReadPointsFromFileButton);
            this.PointsBox.Controls.Add(this.InputPointsRadio);
            this.PointsBox.Controls.Add(this.GeneratePointsRadio);
            this.PointsBox.Location = new System.Drawing.Point(18, 411);
            this.PointsBox.Name = "PointsBox";
            this.PointsBox.Size = new System.Drawing.Size(257, 197);
            this.PointsBox.TabIndex = 1;
            this.PointsBox.TabStop = false;
            this.PointsBox.Text = "Points";
            // 
            // AnalyticFunctionsCombo
            // 
            this.AnalyticFunctionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnalyticFunctionsCombo.FormattingEnabled = true;
            this.AnalyticFunctionsCombo.Items.AddRange(new object[] {
            "Choose analytic function",
            "2 * cos(x)",
            "sin(x)",
            "exp(x)",
            "1 / (1 + x^2)"});
            this.AnalyticFunctionsCombo.Location = new System.Drawing.Point(39, 61);
            this.AnalyticFunctionsCombo.Name = "AnalyticFunctionsCombo";
            this.AnalyticFunctionsCombo.Size = new System.Drawing.Size(181, 21);
            this.AnalyticFunctionsCombo.TabIndex = 1;
            this.AnalyticFunctionsCombo.Visible = false;
            // 
            // AnalyticFunctionRadio
            // 
            this.AnalyticFunctionRadio.AutoSize = true;
            this.AnalyticFunctionRadio.Location = new System.Drawing.Point(12, 42);
            this.AnalyticFunctionRadio.Name = "AnalyticFunctionRadio";
            this.AnalyticFunctionRadio.Size = new System.Drawing.Size(106, 17);
            this.AnalyticFunctionRadio.TabIndex = 9;
            this.AnalyticFunctionRadio.Text = "Analytic Function";
            this.AnalyticFunctionRadio.UseVisualStyleBackColor = true;
            this.AnalyticFunctionRadio.CheckedChanged += new System.EventHandler(this.AnalyticFunctionRadio_CheckedChanged);
            // 
            // GeneratePointsAmoutLabel
            // 
            this.GeneratePointsAmoutLabel.AutoSize = true;
            this.GeneratePointsAmoutLabel.Location = new System.Drawing.Point(56, 136);
            this.GeneratePointsAmoutLabel.Name = "GeneratePointsAmoutLabel";
            this.GeneratePointsAmoutLabel.Size = new System.Drawing.Size(75, 13);
            this.GeneratePointsAmoutLabel.TabIndex = 8;
            this.GeneratePointsAmoutLabel.Text = "Points Amount";
            this.GeneratePointsAmoutLabel.Visible = false;
            // 
            // GeneratePointAmountField
            // 
            this.GeneratePointAmountField.Location = new System.Drawing.Point(137, 133);
            this.GeneratePointAmountField.Name = "GeneratePointAmountField";
            this.GeneratePointAmountField.Size = new System.Drawing.Size(63, 20);
            this.GeneratePointAmountField.TabIndex = 6;
            this.GeneratePointAmountField.Visible = false;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(37, 159);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(183, 23);
            this.GenerateButton.TabIndex = 7;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Visible = false;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // GenerateRangeLabel
            // 
            this.GenerateRangeLabel.AutoSize = true;
            this.GenerateRangeLabel.Location = new System.Drawing.Point(71, 85);
            this.GenerateRangeLabel.Name = "GenerateRangeLabel";
            this.GenerateRangeLabel.Size = new System.Drawing.Size(129, 13);
            this.GenerateRangeLabel.TabIndex = 6;
            this.GenerateRangeLabel.Text = "Generate Points in Range";
            this.GenerateRangeLabel.Visible = false;
            // 
            // GenerateToField
            // 
            this.GenerateToField.Location = new System.Drawing.Point(137, 105);
            this.GenerateToField.Name = "GenerateToField";
            this.GenerateToField.Size = new System.Drawing.Size(63, 20);
            this.GenerateToField.TabIndex = 5;
            this.GenerateToField.Visible = false;
            // 
            // GenerateFromField
            // 
            this.GenerateFromField.Location = new System.Drawing.Point(53, 105);
            this.GenerateFromField.Name = "GenerateFromField";
            this.GenerateFromField.Size = new System.Drawing.Size(63, 20);
            this.GenerateFromField.TabIndex = 4;
            this.GenerateFromField.Visible = false;
            // 
            // ReadPointsFromFileLabel
            // 
            this.ReadPointsFromFileLabel.AutoSize = true;
            this.ReadPointsFromFileLabel.Location = new System.Drawing.Point(71, 114);
            this.ReadPointsFromFileLabel.Name = "ReadPointsFromFileLabel";
            this.ReadPointsFromFileLabel.Size = new System.Drawing.Size(110, 13);
            this.ReadPointsFromFileLabel.TabIndex = 3;
            this.ReadPointsFromFileLabel.Text = "Read Points From File";
            // 
            // ReadPointsFromFileButton
            // 
            this.ReadPointsFromFileButton.Location = new System.Drawing.Point(37, 131);
            this.ReadPointsFromFileButton.Name = "ReadPointsFromFileButton";
            this.ReadPointsFromFileButton.Size = new System.Drawing.Size(183, 23);
            this.ReadPointsFromFileButton.TabIndex = 2;
            this.ReadPointsFromFileButton.Text = "Open File";
            this.ReadPointsFromFileButton.UseVisualStyleBackColor = true;
            this.ReadPointsFromFileButton.Click += new System.EventHandler(this.ReadPointsFromFileButton_Click);
            // 
            // InputPointsRadio
            // 
            this.InputPointsRadio.AutoSize = true;
            this.InputPointsRadio.Checked = true;
            this.InputPointsRadio.Location = new System.Drawing.Point(12, 19);
            this.InputPointsRadio.Name = "InputPointsRadio";
            this.InputPointsRadio.Size = new System.Drawing.Size(81, 17);
            this.InputPointsRadio.TabIndex = 1;
            this.InputPointsRadio.TabStop = true;
            this.InputPointsRadio.Text = "Input Points";
            this.InputPointsRadio.UseVisualStyleBackColor = true;
            this.InputPointsRadio.CheckedChanged += new System.EventHandler(this.InputPointsRadio_CheckedChanged);
            // 
            // GeneratePointsRadio
            // 
            this.GeneratePointsRadio.AutoSize = true;
            this.GeneratePointsRadio.Location = new System.Drawing.Point(99, 19);
            this.GeneratePointsRadio.Name = "GeneratePointsRadio";
            this.GeneratePointsRadio.Size = new System.Drawing.Size(101, 17);
            this.GeneratePointsRadio.TabIndex = 0;
            this.GeneratePointsRadio.Text = "Generate Points";
            this.GeneratePointsRadio.UseVisualStyleBackColor = true;
            this.GeneratePointsRadio.CheckedChanged += new System.EventHandler(this.GeneratePointsRadio_CheckedChanged);
            // 
            // ApproximationGraphBox
            // 
            this.ApproximationGraphBox.Location = new System.Drawing.Point(310, 62);
            this.ApproximationGraphBox.Name = "ApproximationGraphBox";
            this.ApproximationGraphBox.Size = new System.Drawing.Size(850, 300);
            this.ApproximationGraphBox.TabIndex = 2;
            this.ApproximationGraphBox.TabStop = false;
            // 
            // ErrorGraphBox
            // 
            this.ErrorGraphBox.Location = new System.Drawing.Point(310, 411);
            this.ErrorGraphBox.Name = "ErrorGraphBox";
            this.ErrorGraphBox.Size = new System.Drawing.Size(850, 300);
            this.ErrorGraphBox.TabIndex = 3;
            this.ErrorGraphBox.TabStop = false;
            // 
            // ApproximationResultLabel
            // 
            this.ApproximationResultLabel.AutoSize = true;
            this.ApproximationResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproximationResultLabel.Location = new System.Drawing.Point(634, 30);
            this.ApproximationResultLabel.Name = "ApproximationResultLabel";
            this.ApproximationResultLabel.Size = new System.Drawing.Size(241, 29);
            this.ApproximationResultLabel.TabIndex = 4;
            this.ApproximationResultLabel.Text = "Approximation Result";
            // 
            // ApproximationErrorLabel
            // 
            this.ApproximationErrorLabel.AutoSize = true;
            this.ApproximationErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproximationErrorLabel.Location = new System.Drawing.Point(634, 379);
            this.ApproximationErrorLabel.Name = "ApproximationErrorLabel";
            this.ApproximationErrorLabel.Size = new System.Drawing.Size(227, 29);
            this.ApproximationErrorLabel.TabIndex = 5;
            this.ApproximationErrorLabel.Text = "Approximation Error";
            // 
            // SaveResultCheck
            // 
            this.SaveResultCheck.AutoSize = true;
            this.SaveResultCheck.Location = new System.Drawing.Point(73, 614);
            this.SaveResultCheck.Name = "SaveResultCheck";
            this.SaveResultCheck.Size = new System.Drawing.Size(126, 17);
            this.SaveResultCheck.TabIndex = 6;
            this.SaveResultCheck.Text = "Save Results In File?";
            this.SaveResultCheck.UseVisualStyleBackColor = true;
            // 
            // ApproximateButton
            // 
            this.ApproximateButton.Location = new System.Drawing.Point(90, 660);
            this.ApproximateButton.Name = "ApproximateButton";
            this.ApproximateButton.Size = new System.Drawing.Size(75, 23);
            this.ApproximateButton.TabIndex = 7;
            this.ApproximateButton.Text = "Approximate";
            this.ApproximateButton.UseVisualStyleBackColor = true;
            this.ApproximateButton.Click += new System.EventHandler(this.ApproximateButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 749);
            this.Controls.Add(this.ApproximateButton);
            this.Controls.Add(this.SaveResultCheck);
            this.Controls.Add(this.ApproximationErrorLabel);
            this.Controls.Add(this.ApproximationResultLabel);
            this.Controls.Add(this.ErrorGraphBox);
            this.Controls.Add(this.ApproximationGraphBox);
            this.Controls.Add(this.PointsBox);
            this.Controls.Add(this.SettingsBox);
            this.Name = "MainWindow";
            this.Text = "Approximation Application - FeI-21";
            this.SettingsBox.ResumeLayout(false);
            this.SettingsBox.PerformLayout();
            this.PointsBox.ResumeLayout(false);
            this.PointsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApproximationGraphBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorGraphBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.ComboBox SelectMethodField;
        private System.Windows.Forms.TextBox PointsAmountField;
        private System.Windows.Forms.TextBox RightBorderField;
        private System.Windows.Forms.TextBox LeftBorderField;
        private System.Windows.Forms.Label PointsAmountLabel;
        private System.Windows.Forms.Label RightBorderLabel;
        private System.Windows.Forms.Label LeftBorderLabel;
        private System.Windows.Forms.GroupBox PointsBox;
        private System.Windows.Forms.Label GenerateRangeLabel;
        private System.Windows.Forms.TextBox GenerateToField;
        private System.Windows.Forms.TextBox GenerateFromField;
        private System.Windows.Forms.Label ReadPointsFromFileLabel;
        private System.Windows.Forms.Button ReadPointsFromFileButton;
        private System.Windows.Forms.RadioButton InputPointsRadio;
        private System.Windows.Forms.RadioButton GeneratePointsRadio;
        private System.Windows.Forms.PictureBox ApproximationGraphBox;
        private System.Windows.Forms.PictureBox ErrorGraphBox;
        private System.Windows.Forms.Label ApproximationResultLabel;
        private System.Windows.Forms.Label ApproximationErrorLabel;
        private System.Windows.Forms.CheckBox SaveResultCheck;
        private System.Windows.Forms.Button ApproximateButton;
        private System.Windows.Forms.Label GeneratePointsAmoutLabel;
        private System.Windows.Forms.TextBox GeneratePointAmountField;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton AnalyticFunctionRadio;
        private System.Windows.Forms.ComboBox AnalyticFunctionsCombo;
    }
}

