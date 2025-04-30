using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private List<double> Times => [.. ((_userName != null) ? _statModel.GetSubmitterTimes(_userName) : _statModel.GetSubmitterTimes(_userIndex!.Value)).Select(ms => ms / 1000.0) ];
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
            DataBind();
        }
        public UserStatisticsPage(FormModel model, StatisticsModel statModel, int userIndex)
        {
            _userName = null;
            _userIndex = userIndex;
            _model = model;
            _statModel = statModel;
            InitializeComponent();
            DataBind();
        }
        private void DataBind()
        {
            dateLabel.Text = SubmitDateLabelText;
            timeCumChart.Series.First().Points.DataBindXY(Questions, TimesCumulative);
            timeChart.Series.First().Points.DataBindXY(Questions, Times);
            lostFocusChart.Series.First().Points.DataBindXY(Questions, LostFocusTimes);
            correctionsCumChart.Series.First().Points.DataBindXY(Questions, CorrectionsCumulative);
            correctionsChart.Series.First().Points.DataBindXY(Questions, Corrections);
            CreateAnswerLabels();
        }
        private void CreateAnswerLabels()
        {
            List<Control> answerLabels = new();
            for (int i = 0; i < Answers.Count; i++)
            {
                var label = new Label()
                {
                    Text = $"#{i+1}: {Questions[i]}",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    Dock = DockStyle.Top
                };
                answerLabels.Add(label);
                var subPanel = new Panel()
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(0, 50, 0, 0),
                };
                label.Controls.Add(subPanel);
                foreach (var answer in Answers[i])
                {
                    var answerLabel = new Label()
                    {
                        Text = answer,
                        Dock = DockStyle.Top,
                    };
                    subPanel.Controls.Add(answerLabel);
                }
            }
            for (int i = answerLabels.Count - 1; i >= 0; i--)
            {
                answerPanel.Controls.Add(answerLabels[i]);
            }
        }
    }
}
