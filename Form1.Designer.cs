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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.adaPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sendButton = new System.Windows.Forms.Button();
            this.commandBox = new System.Windows.Forms.TextBox();
            this.adaVerticalBox = new System.Windows.Forms.ComboBox();
            this.adaLabel = new System.Windows.Forms.Label();
            this.adbPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.adaPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adbPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // adaPlot
            // 
            chartArea3.Name = "ChartArea1";
            this.adaPlot.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.adaPlot.Legends.Add(legend3);
            this.adaPlot.Location = new System.Drawing.Point(8, 60);
            this.adaPlot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adaPlot.Name = "adaPlot";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "ADSeries";
            this.adaPlot.Series.Add(series3);
            this.adaPlot.Size = new System.Drawing.Size(463, 399);
            this.adaPlot.TabIndex = 0;
            this.adaPlot.Text = "ADC value";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(170, 464);
            this.sendButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(63, 22);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sendButton_MouseClick);
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(8, 464);
            this.commandBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(149, 20);
            this.commandBox.TabIndex = 2;
            // 
            // adaVerticalBox
            // 
            this.adaVerticalBox.FormattingEnabled = true;
            this.adaVerticalBox.Location = new System.Drawing.Point(83, 11);
            this.adaVerticalBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adaVerticalBox.Name = "adaVerticalBox";
            this.adaVerticalBox.Size = new System.Drawing.Size(127, 21);
            this.adaVerticalBox.TabIndex = 3;
            this.adaVerticalBox.SelectedIndexChanged += new System.EventHandler(this.adaVertical_changed);
            // 
            // adaLabel
            // 
            this.adaLabel.AutoSize = true;
            this.adaLabel.Location = new System.Drawing.Point(6, 11);
            this.adaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.adaLabel.Name = "adaLabel";
            this.adaLabel.Size = new System.Drawing.Size(70, 13);
            this.adaLabel.TabIndex = 4;
            this.adaLabel.Text = "Veretical Axis";
            // 
            // adbPlot
            // 
            chartArea4.Name = "ChartArea1";
            this.adbPlot.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.adbPlot.Legends.Add(legend4);
            this.adbPlot.Location = new System.Drawing.Point(499, 60);
            this.adbPlot.Name = "adbPlot";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.adbPlot.Series.Add(series4);
            this.adbPlot.Size = new System.Drawing.Size(480, 399);
            this.adbPlot.TabIndex = 5;
            this.adbPlot.Text = "ADSeries";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 670);
            this.Controls.Add(this.adbPlot);
            this.Controls.Add(this.adaLabel);
            this.Controls.Add(this.adaVerticalBox);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.adaPlot);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.adaPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adbPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart adaPlot;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.ComboBox adaVerticalBox;
        private System.Windows.Forms.Label adaLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart adbPlot;
    }
}

