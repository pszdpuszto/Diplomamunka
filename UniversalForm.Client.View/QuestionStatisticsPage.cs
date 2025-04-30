using System.Data;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    public partial class QuestionStatisticsPage : UserControl
    {
        private FormModel _model;
        private StatisticsModel _statModel;
        private Question.QTYPE _qType;
        private int _qIndex;
        private string AverageTimeLabelText => $"Average time: {_statModel.GetQuestionAverageTimes()[_qIndex] / 1000.0} seconds";
        private string AverageCorrectionsLabelText => $"Average corrections: {_statModel.GetQuestionAverageCorrections()[_qIndex]}";
        private string AverageLostFocusLabelText => $"Average time without focus: {_statModel.GetQuestionAverageLostFocusTimes()[_qIndex] / 1000.0}";
        private List<string> SubmitterLabels => _statModel.GetSubbmitters(_model.Anonymous);
        private List<double> Times => [.. _statModel.GetTimesOfQuestion(_qIndex).Select(ms => ms / 1000.0)];
        private List<double> LostFocusTimes => [.. _statModel.GetLostFocusTimesOfQuestion(_qIndex).Select(ms => ms / 1000.0)];
        private List<int> Corrections => _statModel.GetCorrectionsOfQuestion(_qIndex);
        private List<string> Answers => _statModel.GetAnswersOfQuestion(_qIndex).Keys.ToList();
        private List<int> AnswerCounts => _statModel.GetAnswersOfQuestion(_qIndex).Values.ToList();

        public QuestionStatisticsPage(FormModel model, StatisticsModel statModel, Question.QTYPE qType, int qIndex)
        {
            _model = model;
            _statModel = statModel;
            _qType = qType;
            _qIndex = qIndex;
            InitializeComponent();
            DataBind();
        }
        private void DataBind()
        {
            timeLabel.Text = AverageTimeLabelText;
            lostFocusLabel.Text = AverageLostFocusLabelText;
            correctionLabel.Text = AverageCorrectionsLabelText;
            timeChart.Series.First().Points.DataBindXY(SubmitterLabels, Times);
            lostFocusChart.Series.First().Points.DataBindXY(SubmitterLabels, LostFocusTimes);
            correctionChart.Series.First().Points.DataBindXY(SubmitterLabels, Corrections);
            BindAnswers();
        }
        private void BindAnswers()
        {
            switch (_qType)
            {
                case Question.QTYPE.TEXT_AREA:
                    answerChart.Visible = false;
                    break;
                case Question.QTYPE.SINGLE_SELECT:
                case Question.QTYPE.MULTI_SELECT:
                    answerChart.Series.First().Points.DataBindXY(Answers, AnswerCounts);
                    break;
                case Question.QTYPE.NUMBER:
                    answerChart.Series.First().Points.DataBindXY(Answers.Select(int.Parse).ToList(), AnswerCounts);
                    break;
                case Question.QTYPE.DATE:
                    answerChart.Series.First().Points.DataBindXY(Answers.Select(DateTime.Parse).ToList(), AnswerCounts);
                    break;
            }
        }
    }
}
