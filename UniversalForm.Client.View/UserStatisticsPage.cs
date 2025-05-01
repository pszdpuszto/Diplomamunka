using System.Data;
using System.Text;
using UniversalForm.Client.Model;

namespace UniversalForm.Client.View
{
    public partial class UserStatisticsPage : UserControl
    {
        private FormModel _model;
        private StatisticsModel _statModel;
        private string? _userName;
        private int? _userIndex;
        private string SubmitDateLabelText => $"Submitted on: {((_userName != null) ? _statModel.GetSubmitterDate(_userName) : _statModel.GetSubmitterDate(_userIndex!.Value)).ToString("dd/MM/yyyy HH:mm:ss")}";
        private List<string> Questions => _model.GetQuestionLabels();
        private List<double> Times => [.. ((_userName != null) ? _statModel.GetSubmitterTimes(_userName) : _statModel.GetSubmitterTimes(_userIndex!.Value)).Select(ms => ms / 1000.0)];
        private List<double> TimesCumulative
        {
            get
            {
                List<double> cumulative = new();
                double sum = 0;
                foreach (var time in Times)
                {
                    sum += time;
                    cumulative.Add(sum);
                }
                return cumulative;
            }
        }
        private List<double> LostFocusTimes => [.. ((_userName != null) ? _statModel.GetSubmitterLostFocusTimes(_userName) : _statModel.GetSubmitterLostFocusTimes(_userIndex!.Value)).Select(ms => ms / 1000.0)];
        private List<int> Corrections => (_userName != null) ? _statModel.GetSubmitterCorrections(_userName) : _statModel.GetSubmitterCorrections(_userIndex!.Value);
        private List<int> CorrectionsCumulative
        {
            get
            {
                List<int> cumulative = new();
                int sum = 0;
                foreach (var correction in Corrections)
                {
                    sum += correction;
                    cumulative.Add(sum);
                }
                return cumulative;
            }
        }
        private List<HashSet<string>> Answers => (_userName != null) ? _statModel.GetSubmitterAnswers(_userName) : _statModel.GetSubmitterAnswers(_userIndex!.Value);

        public UserStatisticsPage(FormModel model, StatisticsModel statModel, string userName)
        {
            _userName = userName;
            _userIndex = null;
            _model = model;
            _statModel = statModel;
            InitializeComponent();
            DisableUnneccecaryElements();
            DataBind();
        }
        public UserStatisticsPage(FormModel model, StatisticsModel statModel, int userIndex)
        {
            _userName = null;
            _userIndex = userIndex;
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
                timeCumChart.Visible = false;
                timeChart.Visible = false;
            }
            if (!_model.FocusTracking)
            {
                lostFocusChart.Visible = false;
            }
            if (!_model.MeasureCorrections)
            {
                correctionsCumChart.Visible = false;
                correctionsChart.Visible = false;
            }
        }
        private void DataBind()
        {
            dateLabel.Text = SubmitDateLabelText;
            if (timeCumChart.Visible)
                timeCumChart.Series.First().Points.DataBindXY(Questions, TimesCumulative);
            if (timeChart.Visible)
                timeChart.Series.First().Points.DataBindXY(Questions, Times);
            if (lostFocusChart.Visible)
                lostFocusChart.Series.First().Points.DataBindXY(Questions, LostFocusTimes);
            if (correctionsCumChart.Visible)
                correctionsCumChart.Series.First().Points.DataBindXY(Questions, CorrectionsCumulative);
            if (correctionsChart.Visible)
                correctionsChart.Series.First().Points.DataBindXY(Questions, Corrections);
            CreateAnswerLabels();
        }
        private void CreateAnswerLabels()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Answers.Count; i++)
            {
                sb.AppendLine($"#{i + 1}: {Questions[i]}");
                foreach (var answer in Answers[i])
                {
                    sb.AppendLine("    + " + answer);
                }
            }
            answersLabel.Text = sb.ToString();
        }
    }
}
