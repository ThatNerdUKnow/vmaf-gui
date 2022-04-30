
namespace vmaf_gui
{
    partial class results
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.resultsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.resultsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.resultsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.resultsChart.Legends.Add(legend1);
            this.resultsChart.Location = new System.Drawing.Point(12, 12);
            this.resultsChart.Name = "resultsChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.resultsChart.Series.Add(series1);
            this.resultsChart.Size = new System.Drawing.Size(776, 426);
            this.resultsChart.TabIndex = 0;
            this.resultsChart.Text = "chart1";
            // 
            // results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resultsChart);
            this.Name = "results";
            this.Text = "results";
            ((System.ComponentModel.ISupportInitialize)(this.resultsChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart resultsChart;
    }
}