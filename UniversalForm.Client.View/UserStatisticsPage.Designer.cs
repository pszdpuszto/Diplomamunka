namespace UniversalForm.Client.View
{
    partial class UserStatisticsPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            timeCumChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lostFocusChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            correctionsCumChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            timeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            correctionsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            answerLabel = new Label();
            answerPanel = new Panel();
            label1 = new Label();
            dateLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)timeCumChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lostFocusChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)correctionsCumChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)correctionsChart).BeginInit();
            answerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // timeCumChart
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.Title = "Question";
            chartArea1.AxisY.Title = "Time (seconds)";
            chartArea1.Name = "ChartArea1";
            timeCumChart.ChartAreas.Add(chartArea1);
            timeCumChart.Dock = DockStyle.Top;
            timeCumChart.Location = new Point(0, 121);
            timeCumChart.Margin = new Padding(4);
            timeCumChart.Name = "timeCumChart";
            timeCumChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            timeCumChart.Series.Add(series1);
            timeCumChart.Size = new Size(780, 370);
            timeCumChart.TabIndex = 0;
            timeCumChart.Text = "chart1";
            title1.Font = new Font("Microsoft Sans Serif", 16F);
            title1.Name = "Title1";
            title1.Text = "Time Spent (Cumulative)";
            timeCumChart.Titles.Add(title1);
            // 
            // lostFocusChart
            // 
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.AxisX.Title = "Question";
            chartArea2.AxisY.Title = "Time (seconds)";
            chartArea2.Name = "ChartArea1";
            lostFocusChart.ChartAreas.Add(chartArea2);
            lostFocusChart.Dock = DockStyle.Top;
            lostFocusChart.Location = new Point(0, 861);
            lostFocusChart.Margin = new Padding(4);
            lostFocusChart.Name = "lostFocusChart";
            lostFocusChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            lostFocusChart.Series.Add(series2);
            lostFocusChart.Size = new Size(780, 370);
            lostFocusChart.TabIndex = 1;
            lostFocusChart.Text = "chart1";
            title2.Font = new Font("Microsoft Sans Serif", 16F);
            title2.Name = "Title1";
            title2.Text = "Time Spent Without Focus";
            lostFocusChart.Titles.Add(title2);
            // 
            // correctionsCumChart
            // 
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.Title = "Question";
            chartArea3.AxisY.Title = "Corrections";
            chartArea3.Name = "ChartArea1";
            correctionsCumChart.ChartAreas.Add(chartArea3);
            correctionsCumChart.Dock = DockStyle.Top;
            correctionsCumChart.Location = new Point(0, 1231);
            correctionsCumChart.Margin = new Padding(4);
            correctionsCumChart.Name = "correctionsCumChart";
            correctionsCumChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsXValueIndexed = true;
            series3.Name = "Series1";
            correctionsCumChart.Series.Add(series3);
            correctionsCumChart.Size = new Size(780, 370);
            correctionsCumChart.TabIndex = 2;
            correctionsCumChart.Text = "chart1";
            title3.Font = new Font("Microsoft Sans Serif", 16F);
            title3.Name = "Title1";
            title3.Text = "Corrections (Cumulative)";
            correctionsCumChart.Titles.Add(title3);
            // 
            // timeChart
            // 
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.Title = "Question";
            chartArea4.AxisY.Title = "Time (seconds)";
            chartArea4.Name = "ChartArea1";
            timeChart.ChartAreas.Add(chartArea4);
            timeChart.Dock = DockStyle.Top;
            timeChart.Location = new Point(0, 491);
            timeChart.Margin = new Padding(4);
            timeChart.Name = "timeChart";
            timeChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series4.ChartArea = "ChartArea1";
            series4.IsXValueIndexed = true;
            series4.Name = "Series1";
            timeChart.Series.Add(series4);
            timeChart.Size = new Size(780, 370);
            timeChart.TabIndex = 3;
            timeChart.Text = "chart1";
            title4.Font = new Font("Microsoft Sans Serif", 16F);
            title4.Name = "Title1";
            title4.Text = "Time Spent";
            timeChart.Titles.Add(title4);
            // 
            // correctionsChart
            // 
            chartArea5.AxisX.IsMarginVisible = false;
            chartArea5.AxisX.Title = "Question";
            chartArea5.AxisY.Title = "Corrections";
            chartArea5.Name = "ChartArea1";
            correctionsChart.ChartAreas.Add(chartArea5);
            correctionsChart.Dock = DockStyle.Top;
            correctionsChart.Location = new Point(0, 1601);
            correctionsChart.Margin = new Padding(4);
            correctionsChart.Name = "correctionsChart";
            correctionsChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series5.ChartArea = "ChartArea1";
            series5.IsXValueIndexed = true;
            series5.Name = "Series1";
            correctionsChart.Series.Add(series5);
            correctionsChart.Size = new Size(780, 420);
            correctionsChart.TabIndex = 4;
            correctionsChart.Text = "chart1";
            title5.Font = new Font("Microsoft Sans Serif", 16F);
            title5.Name = "Title1";
            title5.Text = "Corrections";
            correctionsChart.Titles.Add(title5);
            // 
            // answerLabel
            // 
            answerLabel.Dock = DockStyle.Top;
            answerLabel.Font = new Font("Segoe UI", 16F);
            answerLabel.Location = new Point(0, 0);
            answerLabel.Margin = new Padding(4, 0, 4, 0);
            answerLabel.Name = "answerLabel";
            answerLabel.Size = new Size(780, 30);
            answerLabel.TabIndex = 5;
            answerLabel.Text = "Answers";
            answerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // answerPanel
            // 
            answerPanel.Controls.Add(answerLabel);
            answerPanel.Dock = DockStyle.Top;
            answerPanel.Location = new Point(0, 21);
            answerPanel.Name = "answerPanel";
            answerPanel.Size = new Size(780, 100);
            answerPanel.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 1588);
            label1.Name = "label1";
            label1.Size = new Size(52, 21);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Dock = DockStyle.Top;
            dateLabel.Location = new Point(0, 0);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(107, 21);
            dateLabel.TabIndex = 8;
            dateLabel.Text = "Submitted on:";
            // 
            // UserStatisticsPage
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(label1);
            Controls.Add(correctionsChart);
            Controls.Add(correctionsCumChart);
            Controls.Add(lostFocusChart);
            Controls.Add(timeChart);
            Controls.Add(timeCumChart);
            Controls.Add(answerPanel);
            Controls.Add(dateLabel);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UserStatisticsPage";
            Size = new Size(780, 2400);
            ((System.ComponentModel.ISupportInitialize)timeCumChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)lostFocusChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)correctionsCumChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)correctionsChart).EndInit();
            answerPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart timeCumChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart lostFocusChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart correctionsCumChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart correctionsChart;
        private Label answerLabel;
        private Panel answerPanel;
        private Label label1;
        private Label dateLabel;
    }
}
