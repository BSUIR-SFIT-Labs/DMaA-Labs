namespace Lab_3
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClassify = new System.Windows.Forms.Button();
            this.tbFirstProbability = new System.Windows.Forms.TextBox();
            this.tbSecondProbability = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tbFalseAlarmProbability = new System.Windows.Forms.TextBox();
            this.tbProbabilityOfMissingErrorDetection = new System.Windows.Forms.TextBox();
            this.tbProbabilityOfTotalClassificationError = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(9, 102);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(185, 23);
            this.btnClassify.TabIndex = 0;
            this.btnClassify.Text = "Classify";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.btnClassify_Click);
            // 
            // tbFirstProbability
            // 
            this.tbFirstProbability.Location = new System.Drawing.Point(9, 37);
            this.tbFirstProbability.Name = "tbFirstProbability";
            this.tbFirstProbability.Size = new System.Drawing.Size(185, 20);
            this.tbFirstProbability.TabIndex = 1;
            this.tbFirstProbability.Text = "0.4";
            // 
            // tbSecondProbability
            // 
            this.tbSecondProbability.Location = new System.Drawing.Point(9, 76);
            this.tbSecondProbability.Name = "tbSecondProbability";
            this.tbSecondProbability.Size = new System.Drawing.Size(185, 20);
            this.tbSecondProbability.TabIndex = 2;
            this.tbSecondProbability.Text = "0.6";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(554, 537);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // tbFalseAlarmProbability
            // 
            this.tbFalseAlarmProbability.Enabled = false;
            this.tbFalseAlarmProbability.Location = new System.Drawing.Point(9, 168);
            this.tbFalseAlarmProbability.Name = "tbFalseAlarmProbability";
            this.tbFalseAlarmProbability.Size = new System.Drawing.Size(185, 20);
            this.tbFalseAlarmProbability.TabIndex = 4;
            // 
            // tbProbabilityOfMissingErrorDetection
            // 
            this.tbProbabilityOfMissingErrorDetection.Enabled = false;
            this.tbProbabilityOfMissingErrorDetection.Location = new System.Drawing.Point(9, 207);
            this.tbProbabilityOfMissingErrorDetection.Name = "tbProbabilityOfMissingErrorDetection";
            this.tbProbabilityOfMissingErrorDetection.Size = new System.Drawing.Size(185, 20);
            this.tbProbabilityOfMissingErrorDetection.TabIndex = 5;
            // 
            // tbProbabilityOfTotalClassificationError
            // 
            this.tbProbabilityOfTotalClassificationError.Enabled = false;
            this.tbProbabilityOfTotalClassificationError.Location = new System.Drawing.Point(9, 248);
            this.tbProbabilityOfTotalClassificationError.Name = "tbProbabilityOfTotalClassificationError";
            this.tbProbabilityOfTotalClassificationError.Size = new System.Drawing.Size(185, 20);
            this.tbProbabilityOfTotalClassificationError.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Probability 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Probability 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "False alarm probability:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Probability of missing error detection:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Probability of total classification error:";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.tbProbabilityOfTotalClassificationError);
            this.gbSettings.Controls.Add(this.btnClassify);
            this.gbSettings.Controls.Add(this.label5);
            this.gbSettings.Controls.Add(this.tbFirstProbability);
            this.gbSettings.Controls.Add(this.label4);
            this.gbSettings.Controls.Add(this.tbProbabilityOfMissingErrorDetection);
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label3);
            this.gbSettings.Controls.Add(this.tbSecondProbability);
            this.gbSettings.Controls.Add(this.tbFalseAlarmProbability);
            this.gbSettings.Location = new System.Drawing.Point(572, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(200, 537);
            this.gbSettings.TabIndex = 12;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.pictureBox);
            this.Name = "MainForm";
            this.Text = "Lab_3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.TextBox tbFirstProbability;
        private System.Windows.Forms.TextBox tbSecondProbability;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox tbFalseAlarmProbability;
        private System.Windows.Forms.TextBox tbProbabilityOfMissingErrorDetection;
        private System.Windows.Forms.TextBox tbProbabilityOfTotalClassificationError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbSettings;
    }
}

