using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    public partial class FillForm : System.Windows.Forms.Form
    {
        public bool FullExit { get; private set; } = true;
        private FormPage? _page;
        private Model.Model _model;
        private event EventHandler<QuestionChangedEventArgs> _questionChanged;
        private int PageIndex { set { numLabel.Text = $"Question #{value}"; field = value; } get; }

        private Question CurrentQuestion
        {
            set
            {
                _questionChanged?.Invoke(this, new QuestionChangedEventArgs(field, value));
                field = value;
            }
            get;
        } = null!;

        public FillForm(Model.Model model)
        {
            _model = model;
            _questionChanged += QuestionChanged;
            InitializeComponent();
            title.Text = _model.Title;
            description.Text = _model.Description;
        }
        private void QuestionChanged(object? sender, QuestionChangedEventArgs e)
        {
            title.Text = e.New.Title;
            description.Text = e.New.Description;
            answerPanel.Controls.Clear();
            _page?.Dispose();
            _page = new FormPage(e.New, answerPanel);
            if (e.Old == null && e.New != null)
            {
                backBtn.Visible = true;
                nextBtn.Visible = true;
                nextBtn.Enabled = true;
            }
            backBtn.Enabled = _model.HasPreviousQuestion();
            if (!_model.HasNextQuestion())
            {
                nextBtn.Text = "Finish";
            }
            else if (nextBtn.Text == "Finish")
            {
                nextBtn.Text = "Next >";
            }
        }

        private void StartBtn(object sender, EventArgs e)
        {
            var question = _model.FirstQuestion();
            if (question != null)
                CurrentQuestion = question;
            startBtn.Visible = false;
            numLabel.Visible = true;
            title.Font = new Font("Segoe UI", 24);
            description.Font = new Font("Segoe UI", 14);
            PageIndex = 1;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (_model.HasNextQuestion())
            {
                CurrentQuestion = _model.NextQuestion()!;
                PageIndex++;
            }
            else
            {
                var result = MessageBox.Show("Finish filling the form and send results?", "Confirm Finish", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Form submitted successfully");
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            CurrentQuestion = _model.PreviousQuestion()!;
            PageIndex--;
        }
    }
}
