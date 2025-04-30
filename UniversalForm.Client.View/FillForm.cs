using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    public partial class FillForm : System.Windows.Forms.Form
    {
        public bool FullExit { get; private set; } = true;
        private FormPage? _page;
        private FormModel _model;
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

        public FillForm(FormModel model)
        {
            _model = model;
            _questionChanged += QuestionChanged;
            InitializeComponent();
            title.Text = _model.Title;
            description.Text = _model.Description;
            Text = "Universal Forms - " + _model.Title;
        }
        private void QuestionChanged(object? sender, QuestionChangedEventArgs e)
        {
            title.Text = e.New.Title;
            description.Text = e.New.Description;
            DisposePage();
            _page = FormPage.Factory(e.New, answerPanel, _model.GetStatisticsOfCurrentQuestion());
            if (_page == null)
            {
                MessageBox.Show("Error creating question page", "Page Creation Error");
                return;
            }
            Deactivate += _page.LostFocus;
            Activated += _page.GotFocus;
            _page.CanProceedChange += CanProceedChange;
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
            CanProceedChange(this, _page.CanProceed);
        }

        private void CanProceedChange(object? sender, bool e)
        {
            nextBtn.Enabled = e;
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
                _page?.StopTimer();
                var result = MessageBox.Show("Finish filling the form and send results?", "Confirm Finish", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (_model.SaveFormStatistics())
                    {
                        MessageBox.Show("Form submitted successfully", "Form Submission");
                        FullExit = false;
                        Close();
                    }
                    else MessageBox.Show("Failed to send results. Please try again.", "Form Submission");
                    _page?.StartTimer();
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            CurrentQuestion = _model.PreviousQuestion()!;
            PageIndex--;
        }

        private void DisposePage()
        {
            if (_page == null)
                return;
            answerPanel.Controls.Clear();
            Deactivate -= _page.LostFocus;
            Activated -= _page.GotFocus;
            _page.Dispose();
        }
    }
}
