using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalForm.Client.Model;

namespace UniversalForm.Client.View
{
    public partial class FormStatistics : Form
    {
        private FormModel _model;
        private StatisticsModel _statModel;
        private UserControl? CurrentPage
        {
            get;
            set
            {
                field?.Dispose();
                mainPanel.Controls.Clear();
                if (value != null)
                {
                    field = value;
                    field.Dock = DockStyle.Fill;
                    mainPanel.Controls.Add(field);
                }
            }
        }
        public FormStatistics(FormModel model, StatisticsModel statModel)
        {
            _model = model;
            _statModel = statModel;
            InitializeComponent();
            Text = "Universal Forms - Statistics of: " + _model.Title;
            questionComboBox.DataSource = _model.GetQuestionLabels();
            userComboBox.DataSource = _statModel.GetSubbmitters(_model.Anonymous);
            overviewBtn.Checked = true;
        }

        private void overviewBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (overviewBtn.Checked)
            {
                CurrentPage = new OverviewStatisticsPage(_model, _statModel);
            }
        }
        private void SetQuestionStatisticsPage(object sender, EventArgs e)
        {
            if (questionBtn.Checked)
            {
                var questionIndex = questionComboBox.SelectedIndex;
                if (questionIndex < 0)
                {
                    MessageBox.Show("Please select a question.");
                    questionBtn.Checked = false;
                    return;
                }

                var questionType = _model.GetQuestionType(questionIndex);
                if (!questionType.HasValue)
                {
                    MessageBox.Show("Question type not found.");
                    questionBtn.Checked = false;
                    return;
                }
                CurrentPage = new QuestionStatisticsPage(_model, _statModel, questionType.Value, questionIndex);
            }
        }
        private void SetUserStatisticsPage(object sender, EventArgs e)
        {
            if (userBtn.Checked)
            {
                if (_model.Anonymous)
                {
                    var userIndex = userComboBox.SelectedIndex;
                    if (userIndex < 0)
                    {
                        MessageBox.Show("Please select a user.");
                        userBtn.Checked = false;
                        return;
                    }
                    CurrentPage = new UserStatisticsPage(_model, _statModel, userIndex);
                } else
                {
                    var userName = userComboBox.Text;
                    if (string.IsNullOrEmpty(userName))
                    {
                        MessageBox.Show("Please select a user.");
                        userBtn.Checked = false;
                        return;
                    }
                    CurrentPage = new UserStatisticsPage(_model, _statModel, userName);
                }
            }
        }
    }
}
