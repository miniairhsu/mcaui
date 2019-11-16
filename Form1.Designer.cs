namespace mca
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.adaPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sendButton = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.adaVerticalBox = new System.Windows.Forms.ComboBox();
            this.adaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.adaPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // adaPlot
            // 
            chartArea2.Name = "ChartArea1";
            this.adaPlot.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.adaPlot.Legends.Add(legend2);
            this.adaPlot.Location = new System.Drawing.Point(12, 83);
            this.adaPlot.Name = "adaPlot";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "ADSeries";
            this.adaPlot.Series.Add(series2);
            this.adaPlot.Size = new System.Drawing.Size(694, 553);
            this.adaPlot.TabIndex = 0;
            this.adaPlot.Text = "ADC value";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(255, 642);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(95, 31);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sendButton_MouseClick);
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(12, 642);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(221, 29);
            this.commandBox.TabIndex = 2;
            // 
            // adaVerticalBox
            // 
            this.adaVerticalBox.FormattingEnabled = true;
            this.adaVerticalBox.Location = new System.Drawing.Point(125, 15);
            this.adaVerticalBox.Name = "adaVerticalBox";
            this.adaVerticalBox.Size = new System.Drawing.Size(188, 26);
            this.adaVerticalBox.TabIndex = 3;
            this.adaVerticalBox.SelectedIndexChanged += new System.EventHandler(this.adaVertical_changed);
            // 
            // adaLabel
            // 
            this.adaLabel.AutoSize = true;
            this.adaLabel.Location = new System.Drawing.Point(9, 15);
            this.adaLabel.Name = "adaLabel";
            this.adaLabel.Size = new System.Drawing.Size(110, 18);
            this.adaLabel.TabIndex = 4;
            this.adaLabel.Text = "Veretical Axis";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 928);
            this.Controls.Add(this.adaLabel);
            this.Controls.Add(this.adaVerticalBox);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.adaPlot);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.adaPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart adaPlot;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.ComboBox adaVerticalBox;
        private System.Windows.Forms.Label adaLabel;
    }
}

