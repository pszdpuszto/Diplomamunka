using System.Data;
using UniversalForm.Client.Model;

namespace UniversalForm.Client.View
{
    public partial class OverviewStatisticsPage : UserControl
    {
        private FormModel _model;
        private StatisticsModel _statModel;
        private string SubmissionLabelText => $"Number of submissions: {_statModel.GetSubmissionCount()}";
        private string AverageTimeLabelText => $"Average time: {_statModel.GetAllAverageTime() / 1000.0} seconds";
        private string AverageLostFocusLabelText => $"Average time without focus: {_statModel.GetAllAverageLostFocus() / 1000.0}";
        private string AverageCorrectionsLabelText => $"Average corrections: {_statModel.GetAllAverageCorrections()} seconds";
        private List<DateTime> SubmissionDates => _statModel.GetSubmissionDates();
        private List<int> SubmissionCount
        {
            get
            {
                List<int> submissionCount = new();
                for (int i = 0; i < SubmissionDates.Count; i++)
                {
                    submissionCount.Add(i + 1);
                }
                return submissionCount;
            }
        }
        private List<string> QuestionLabels => _model.GetQuestionLabels();
        private List<double> AverageTimesSeconds => [.. _statModel.GetQuestionAverageTimes().Select(ms => ms / 1000.0)];
        private List<double> AverageLostFocus => [.. _statModel.GetQuestionAverageLostFocusTimes().Select(ms => ms / 1000.0)];
        private List<int> AverageCorrections => _statModel.GetQuestionAverageCorrections();
        public OverviewStatisticsPage(FormModel model, StatisticsModel statModel)
        {
            _model = model;
            _statModel = statModel;
            InitializeComponent();
            DisableUnneccecaryElements();
            DataBind();
        }
        private void DisableUnneccecaryElements()
        {
            if (!_model.MeasureTime)
            {
                timeLabel.Visible = false;
                avgTimeChart.Visible = false;

            }
            if (!_model.FocusTracking)
            {
                lostFocusLabel.Visible = false;
                lostFocusChart.Visible = false;
            }
            if (!_model.MeasureCorrections)
            {
                correctionLabel.Visible = false;
                correctionChart.Visible = false;
            }
        }
        private void DataBind()
        {
            userNumLabel.Text = SubmissionLabelText;
            if (timeLabel.Visible)
                timeLabel.Text = AverageTimeLabelText;
            if (correctionLabel.Visible)
                correctionLabel.Text = AverageCorrectionsLabelText;
            if (lostFocusLabel.Visible)
                lostFocusLabel.Text = AverageLostFocusLabelText;
            dateChart.Series.First().Points.DataBindXY(SubmissionDates, SubmissionCount);
            if (avgTimeChart.Visible)
                avgTimeChart.Series.First().Points.DataBindXY(QuestionLabels, AverageTimesSeconds);
            if (correctionChart.Visible)
                correctionChart.Series.First().Points.DataBindXY(QuestionLabels, AverageCorrections);
            if (lostFocusChart.Visible)
                lostFocusChart.Series.First().Points.DataBindXY(QuestionLabels, AverageLostFocus);
        }
    }
}
