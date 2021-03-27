namespace Lab_1
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
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExecuteAlgorithm = new System.Windows.Forms.Button();
            this.tbAmountOfShapes = new System.Windows.Forms.TextBox();
            this.tbAmountOfClasses = new System.Windows.Forms.TextBox();
            this.shapeLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.gbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCanvas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbCanvas.Location = new System.Drawing.Point(12, 12);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(547, 537);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(10, 112);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(184, 22);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnExecuteAlgorithm
            // 
            this.btnExecuteAlgorithm.Location = new System.Drawing.Point(10, 140);
            this.btnExecuteAlgorithm.Name = "btnExecuteAlgorithm";
            this.btnExecuteAlgorithm.Size = new System.Drawing.Size(184, 23);
            this.btnExecuteAlgorithm.TabIndex = 2;
            this.btnExecuteAlgorithm.Text = "Execute algorithm";
            this.btnExecuteAlgorithm.UseVisualStyleBackColor = true;
            this.btnExecuteAlgorithm.Click += new System.EventHandler(this.btnKMeans_Click);
            // 
            // tbAmountOfShapes
            // 
            this.tbAmountOfShapes.Location = new System.Drawing.Point(10, 42);
            this.tbAmountOfShapes.Name = "tbAmountOfShapes";
            this.tbAmountOfShapes.Size = new System.Drawing.Size(184, 20);
            this.tbAmountOfShapes.TabIndex = 3;
            // 
            // tbAmountOfClasses
            // 
            this.tbAmountOfClasses.Location = new System.Drawing.Point(10, 86);
            this.tbAmountOfClasses.Name = "tbAmountOfClasses";
            this.tbAmountOfClasses.Size = new System.Drawing.Size(184, 20);
            this.tbAmountOfClasses.TabIndex = 4;
            // 
            // shapeLabel
            // 
            this.shapeLabel.AutoSize = true;
            this.shapeLabel.Location = new System.Drawing.Point(7, 26);
            this.shapeLabel.Name = "shapeLabel";
            this.shapeLabel.Size = new System.Drawing.Size(95, 13);
            this.shapeLabel.TabIndex = 5;
            this.shapeLabel.Text = "Amount of _shapes:";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(7, 70);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(96, 13);
            this.classLabel.TabIndex = 6;
            this.classLabel.Text = "Amount of classes:";
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.Controls.Add(this.shapeLabel);
            this.gbSettings.Controls.Add(this.tbAmountOfClasses);
            this.gbSettings.Controls.Add(this.classLabel);
            this.gbSettings.Controls.Add(this.btnGenerate);
            this.gbSettings.Controls.Add(this.btnExecuteAlgorithm);
            this.gbSettings.Controls.Add(this.tbAmountOfShapes);
            this.gbSettings.Location = new System.Drawing.Point(572, 12);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(200, 537);
            this.gbSettings.TabIndex = 7;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.pbCanvas);
            this.Name = "MainForm";
            this.Text = "K-means";
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExecuteAlgorithm;
        private System.Windows.Forms.TextBox tbAmountOfShapes;
        private System.Windows.Forms.TextBox tbAmountOfClasses;
        private System.Windows.Forms.Label shapeLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.GroupBox gbSettings;
    }
}