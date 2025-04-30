namespace UniversalForm.Client.View
{
    partial class OverviewStatisticsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            avgTimeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            correctionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1 = new Panel();
            lostFocusLabel = new Label();
            correctionLabel = new Label();
            timeLabel = new Label();
            userNumLabel = new Label();
            lostFocusChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)avgTimeChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)correctionChart).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lostFocusChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateChart).BeginInit();
            SuspendLayout();
            // 
            // avgTimeChart
            // 
            chartArea1.AxisX.Title = "Question";
            chartArea1.AxisY.Title = "Time Spent (seconds)";
            chartArea1.Name = "AverageTime";
            avgTimeChart.ChartAreas.Add(chartArea1);
            avgTimeChart.Dock = DockStyle.Top;
            avgTimeChart.Location = new Point(0, 460);
            avgTimeChart.Margin = new Padding(4);
            avgTimeChart.Name = "avgTimeChart";
            avgTimeChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "AverageTime";
            series1.IsXValueIndexed = true;
            series1.Name = "Series3";
            avgTimeChart.Series.Add(series1);
            avgTimeChart.Size = new Size(780, 370);
            avgTimeChart.TabIndex = 0;
            avgTimeChart.Text = "Average Time Spent Per Question";
            title1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title1.Name = "Title1";
            title1.Text = "Average Time Spent Per Question";
            avgTimeChart.Titles.Add(title1);
            // 
            // correctionChart
            // 
            chartArea2.AxisX.Title = "Question";
            chartArea2.AxisY.Title = "Corrections";
            chartArea2.Name = "ChartArea1";
            correctionChart.ChartAreas.Add(chartArea2);
            correctionChart.Dock = DockStyle.Top;
            correctionChart.Location = new Point(0, 830);
            correctionChart.Name = "correctionChart";
            correctionChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            correctionChart.Series.Add(series2);
            correctionChart.Size = new Size(780, 370);
            correctionChart.TabIndex = 1;
            correctionChart.Text = "chart1";
            title2.Font = new Font("Microsoft Sans Serif", 16F);
            title2.Name = "Title1";
            title2.Text = "Average Corrections Per Question";
            correctionChart.Titles.Add(title2);
            // 
            // panel1
            // 
            panel1.Controls.Add(lostFocusLabel);
            panel1.Controls.Add(correctionLabel);
            panel1.Controls.Add(timeLabel);
            panel1.Controls.Add(userNumLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 90);
            panel1.TabIndex = 2;
            // 
            // lostFocusLabel
            // 
            lostFocusLabel.AutoSize = true;
            lostFocusLabel.Dock = DockStyle.Top;
            lostFocusLabel.Location = new Point(0, 63);
            lostFocusLabel.Name = "lostFocusLabel";
            lostFocusLabel.Size = new Size(203, 21);
            lostFocusLabel.TabIndex = 3;
            lostFocusLabel.Text = "Average time without focus:";
            // 
            // correctionLabel
            // 
            correctionLabel.AutoSize = true;
            correctionLabel.Dock = DockStyle.Top;
            correctionLabel.Location = new Point(0, 42);
            correctionLabel.Name = "correctionLabel";
            correctionLabel.Size = new Size(212, 21);
            correctionLabel.TabIndex = 2;
            correctionLabel.Text = "Average Overall Corrections: ";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Location = new Point(0, 21);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(234, 21);
            timeLabel.TabIndex = 1;
            timeLabel.Text = "Average Completion Time: 10.6s";
            // 
            // userNumLabel
            // 
            userNumLabel.AutoSize = true;
            userNumLabel.Dock = DockStyle.Top;
            userNumLabel.Location = new Point(0, 0);
            userNumLabel.Name = "userNumLabel";
            userNumLabel.Size = new Size(201, 21);
            userNumLabel.TabIndex = 0;
            userNumLabel.Text = "Number of submissions: 10";
            // 
            // lostFocusChart
            // 
            chartArea3.AxisX.Title = "Question";
            chartArea3.AxisY.Title = "Time Without Focus (seconds)";
            chartArea3.Name = "ChartArea1";
            lostFocusChart.ChartAreas.Add(chartArea3);
            lostFocusChart.Dock = DockStyle.Top;
            lostFocusChart.Location = new Point(0, 1200);
            lostFocusChart.Name = "lostFocusChart";
            lostFocusChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.IsXValueIndexed = true;
            series3.Name = "Series1";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            lostFocusChart.Series.Add(series3);
            lostFocusChart.Size = new Size(780, 370);
            lostFocusChart.TabIndex = 3;
            lostFocusChart.Text = "chart2";
            title3.Font = new Font("Microsoft Sans Serif", 16F);
            title3.Name = "Title1";
            title3.Text = "Average Time Without Focus";
            lostFocusChart.Titles.Add(title3);
            // 
            // dateChart
            // 
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.Title = "Date";
            chartArea4.AxisY.Title = "Submissions";
            chartArea4.Name = "AverageTime";
            dateChart.ChartAreas.Add(chartArea4);
            dateChart.Dock = DockStyle.Top;
            dateChart.Location = new Point(0, 90);
            dateChart.Margin = new Padding(4);
            dateChart.Name = "dateChart";
            dateChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series4.ChartArea = "AverageTime";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsXValueIndexed = true;
            series4.Name = "Series3";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            dateChart.Series.Add(series4);
            dateChart.Size = new Size(780, 370);
            dateChart.TabIndex = 4;
            dateChart.Text = "Average Time Spent Per Question";
            title4.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title4.Name = "Title1";
            title4.Text = "Amount Of Submissions";
            dateChart.Titles.Add(title4);
            // 
            // OverviewStatisticsPage
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            Controls.Add(lostFocusChart);
            Controls.Add(correctionChart);
            Controls.Add(avgTimeChart);
            Controls.Add(dateChart);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "OverviewStatisticsPage";
            Size = new Size(780, 1570);
            ((System.ComponentModel.ISupportInitialize)avgTimeChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)correctionChart).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lostFocusChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateChart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart avgTimeChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart correctionChart;
        private Panel panel1;
        private Label userNumLabel;
        private Label timeLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart lostFocusChart;
        private Label correctionLabel;
        private Label lostFocusLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart dateChart;
    }
}
