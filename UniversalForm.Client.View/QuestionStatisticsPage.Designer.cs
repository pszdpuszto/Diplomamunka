namespace UniversalForm.Client.View
{
    partial class QuestionStatisticsPage
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
            panel1 = new Panel();
            correctionLabel = new Label();
            lostFocusLabel = new Label();
            timeLabel = new Label();
            timeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            answerChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lostFocusChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            correctionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)answerChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lostFocusChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)correctionChart).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(correctionLabel);
            panel1.Controls.Add(lostFocusLabel);
            panel1.Controls.Add(timeLabel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 90);
            panel1.TabIndex = 0;
            // 
            // correctionLabel
            // 
            correctionLabel.AutoSize = true;
            correctionLabel.Dock = DockStyle.Top;
            correctionLabel.Location = new Point(0, 42);
            correctionLabel.Name = "correctionLabel";
            correctionLabel.Size = new Size(154, 21);
            correctionLabel.TabIndex = 2;
            correctionLabel.Text = "Average Corrections:";
            // 
            // lostFocusLabel
            // 
            lostFocusLabel.AutoSize = true;
            lostFocusLabel.Dock = DockStyle.Top;
            lostFocusLabel.Location = new Point(0, 21);
            lostFocusLabel.Name = "lostFocusLabel";
            lostFocusLabel.Size = new Size(207, 21);
            lostFocusLabel.TabIndex = 1;
            lostFocusLabel.Text = "Average time without focus: ";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Dock = DockStyle.Top;
            timeLabel.Location = new Point(0, 0);
            timeLabel.Margin = new Padding(4, 0, 4, 0);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(112, 21);
            timeLabel.TabIndex = 0;
            timeLabel.Text = "Average Time: ";
            // 
            // timeChart
            // 
            chartArea1.AxisX.Title = "Submitter";
            chartArea1.AxisY.Title = "Time (seconds)";
            chartArea1.Name = "ChartArea1";
            timeChart.ChartAreas.Add(chartArea1);
            timeChart.Dock = DockStyle.Top;
            timeChart.Location = new Point(0, 460);
            timeChart.Name = "timeChart";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            timeChart.Series.Add(series1);
            timeChart.Size = new Size(780, 370);
            timeChart.TabIndex = 1;
            timeChart.Text = "chart1";
            title1.Font = new Font("Microsoft Sans Serif", 16F);
            title1.Name = "Title1";
            title1.Text = "Time Spent";
            timeChart.Titles.Add(title1);
            // 
            // answerChart
            // 
            chartArea2.AxisX.Title = "Answer";
            chartArea2.AxisY.Title = "Occurrences";
            chartArea2.Name = "ChartArea1";
            answerChart.ChartAreas.Add(chartArea2);
            answerChart.Dock = DockStyle.Top;
            answerChart.Location = new Point(0, 90);
            answerChart.Name = "answerChart";
            series2.ChartArea = "ChartArea1";
            series2.IsXValueIndexed = true;
            series2.Name = "Series1";
            answerChart.Series.Add(series2);
            answerChart.Size = new Size(780, 370);
            answerChart.TabIndex = 2;
            answerChart.Text = "chart2";
            title2.Font = new Font("Microsoft Sans Serif", 16F);
            title2.Name = "Title1";
            title2.Text = "Answers";
            answerChart.Titles.Add(title2);
            // 
            // lostFocusChart
            // 
            chartArea3.AxisX.Title = "Submitter";
            chartArea3.AxisY.Title = "Time (seconds)";
            chartArea3.Name = "ChartArea1";
            lostFocusChart.ChartAreas.Add(chartArea3);
            lostFocusChart.Dock = DockStyle.Top;
            lostFocusChart.Location = new Point(0, 830);
            lostFocusChart.Name = "lostFocusChart";
            series3.ChartArea = "ChartArea1";
            series3.IsXValueIndexed = true;
            series3.Name = "Series1";
            lostFocusChart.Series.Add(series3);
            lostFocusChart.Size = new Size(780, 370);
            lostFocusChart.TabIndex = 3;
            lostFocusChart.Text = "chart3";
            title3.Font = new Font("Microsoft Sans Serif", 16F);
            title3.Name = "Title1";
            title3.Text = "Time Without Focus";
            lostFocusChart.Titles.Add(title3);
            // 
            // correctionChart
            // 
            chartArea4.AxisX.Title = "Submitter";
            chartArea4.AxisY.Title = "Corrections";
            chartArea4.Name = "ChartArea1";
            correctionChart.ChartAreas.Add(chartArea4);
            correctionChart.Dock = DockStyle.Top;
            correctionChart.Location = new Point(0, 1200);
            correctionChart.Name = "correctionChart";
            series4.ChartArea = "ChartArea1";
            series4.IsXValueIndexed = true;
            series4.Name = "Series1";
            correctionChart.Series.Add(series4);
            correctionChart.Size = new Size(780, 370);
            correctionChart.TabIndex = 4;
            correctionChart.Text = "chart4";
            title4.Font = new Font("Microsoft Sans Serif", 16F);
            title4.Name = "Title1";
            title4.Text = "Corrections";
            correctionChart.Titles.Add(title4);
            // 
            // QuestionStatisticsPage
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(correctionChart);
            Controls.Add(lostFocusChart);
            Controls.Add(timeChart);
            Controls.Add(answerChart);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "QuestionStatisticsPage";
            Size = new Size(780, 1570);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)answerChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)lostFocusChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)correctionChart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label timeLabel;
        private Label lostFocusLabel;
        private Label correctionLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart timeChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart answerChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart lostFocusChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart correctionChart;
    }
}
