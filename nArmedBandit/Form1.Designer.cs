namespace nArmedBandit
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioTask1 = new System.Windows.Forms.RadioButton();
            this.radioTask2 = new System.Windows.Forms.RadioButton();
            this.radioTask3 = new System.Windows.Forms.RadioButton();
            this.radioReward = new System.Windows.Forms.RadioButton();
            this.radioArm = new System.Windows.Forms.RadioButton();
            this.radioHistogram = new System.Windows.Forms.RadioButton();
            this.numericArm = new System.Windows.Forms.NumericUpDown();
            this.numericSelector = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericArm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(176, 12);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(851, 522);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(158, 74);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioTask3);
            this.groupBox1.Controls.Add(this.radioTask2);
            this.groupBox1.Controls.Add(this.radioTask1);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithms";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericSelector);
            this.groupBox2.Controls.Add(this.numericArm);
            this.groupBox2.Controls.Add(this.radioHistogram);
            this.groupBox2.Controls.Add(this.radioArm);
            this.groupBox2.Controls.Add(this.radioReward);
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chart";
            // 
            // radioTask1
            // 
            this.radioTask1.AutoSize = true;
            this.radioTask1.Checked = true;
            this.radioTask1.Location = new System.Drawing.Point(22, 20);
            this.radioTask1.Name = "radioTask1";
            this.radioTask1.Size = new System.Drawing.Size(55, 17);
            this.radioTask1.TabIndex = 0;
            this.radioTask1.TabStop = true;
            this.radioTask1.Text = "Task1";
            this.radioTask1.UseVisualStyleBackColor = true;
            // 
            // radioTask2
            // 
            this.radioTask2.AutoSize = true;
            this.radioTask2.Location = new System.Drawing.Point(22, 44);
            this.radioTask2.Name = "radioTask2";
            this.radioTask2.Size = new System.Drawing.Size(55, 17);
            this.radioTask2.TabIndex = 1;
            this.radioTask2.Text = "Task2";
            this.radioTask2.UseVisualStyleBackColor = true;
            // 
            // radioTask3
            // 
            this.radioTask3.AutoSize = true;
            this.radioTask3.Location = new System.Drawing.Point(22, 68);
            this.radioTask3.Name = "radioTask3";
            this.radioTask3.Size = new System.Drawing.Size(55, 17);
            this.radioTask3.TabIndex = 2;
            this.radioTask3.Text = "Task3";
            this.radioTask3.UseVisualStyleBackColor = true;
            // 
            // radioReward
            // 
            this.radioReward.AutoSize = true;
            this.radioReward.Checked = true;
            this.radioReward.Location = new System.Drawing.Point(7, 20);
            this.radioReward.Name = "radioReward";
            this.radioReward.Size = new System.Drawing.Size(105, 17);
            this.radioReward.TabIndex = 0;
            this.radioReward.TabStop = true;
            this.radioReward.Text = "Algorithm/reward";
            this.radioReward.UseVisualStyleBackColor = true;
            // 
            // radioArm
            // 
            this.radioArm.AutoSize = true;
            this.radioArm.Location = new System.Drawing.Point(7, 44);
            this.radioArm.Name = "radioArm";
            this.radioArm.Size = new System.Drawing.Size(88, 17);
            this.radioArm.TabIndex = 1;
            this.radioArm.TabStop = true;
            this.radioArm.Text = "Arm/Estimate";
            this.radioArm.UseVisualStyleBackColor = true;
            // 
            // radioHistogram
            // 
            this.radioHistogram.AutoSize = true;
            this.radioHistogram.Location = new System.Drawing.Point(7, 68);
            this.radioHistogram.Name = "radioHistogram";
            this.radioHistogram.Size = new System.Drawing.Size(107, 17);
            this.radioHistogram.TabIndex = 2;
            this.radioHistogram.TabStop = true;
            this.radioHistogram.Text = "Action/Histogram";
            this.radioHistogram.UseVisualStyleBackColor = true;
            // 
            // numericArm
            // 
            this.numericArm.Location = new System.Drawing.Point(116, 44);
            this.numericArm.Name = "numericArm";
            this.numericArm.Size = new System.Drawing.Size(36, 20);
            this.numericArm.TabIndex = 3;
            // 
            // numericSelector
            // 
            this.numericSelector.Location = new System.Drawing.Point(116, 70);
            this.numericSelector.Name = "numericSelector";
            this.numericSelector.Size = new System.Drawing.Size(36, 20);
            this.numericSelector.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "N-armed bandit";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericArm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioTask3;
        private System.Windows.Forms.RadioButton radioTask2;
        private System.Windows.Forms.RadioButton radioTask1;
        private System.Windows.Forms.NumericUpDown numericSelector;
        private System.Windows.Forms.NumericUpDown numericArm;
        private System.Windows.Forms.RadioButton radioHistogram;
        private System.Windows.Forms.RadioButton radioArm;
        private System.Windows.Forms.RadioButton radioReward;
    }
}

