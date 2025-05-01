using System.Data;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    public partial class FormCreator : System.Windows.Forms.Form
    {
        private FormModel _model;
        private string _formName = string.Empty;
        private CreatePage? Page
        {
            set
            {
                field = value;
                _questionChanged?.Invoke(this, new CreatePageChangedEventArgs(field, value!));
            }
            get;
        }
        private event EventHandler<CreatePageChangedEventArgs> _questionChanged;

        private readonly IEnumerable<Question.QTYPE> _questionTypes = Enum.GetValues(typeof(Question.QTYPE)).Cast<Question.QTYPE>();
        public FormCreator(FormModel model, string formName, bool newForm)
        {
            _model = model;
            _formName = formName;
            if (newForm)
            {
                _model.CreateEmptyForm(_formName);
            }
            else
            {
                _model.LoadForm(_formName);
            }
            InitializeComponent();
            qTypes.DataSource = _questionTypes.Select(q => Question.TypeToString[q]).ToList();
            qTypes.SelectedIndex = 0;
            Text = "Universal Forms - " + _formName;
            _questionChanged += PageChanged;
            SetPage(new CPTitlePage(_model));
        }
        private void SetPage(CreatePage? newPage)
        {
            Page?.Dispose();
            if (newPage == null)
                newPage = new CPTitlePage(_model);
            newPage.CreateControl(optionsPanel);
            Page = newPage;
        }

        private void PageChanged(object? sender, CreatePageChangedEventArgs e)
        {
            var titlePage = e.New is CPTitlePage;
            backBtn.Enabled = !titlePage;
            var hasNext = _model.HasNextQuestion() || titlePage && _model.HasQuestion();
            nextBtn.Visible = hasNext;
            createBtn.Visible = !hasNext;
            qTypes.Visible = !hasNext;
            titleTextBox.Text = e.New.Title;
            descriptionTextBox.Text = e.New.Description;
            var formOrQuestion = titlePage ? "Form" : "Question";
            titleTextBox.PlaceholderText = formOrQuestion + " Title";
            descriptionTextBox.PlaceholderText = formOrQuestion + " Description";

            numLabel.Text = (titlePage) ? "Title Page" : $"Question #{_model.Index + 1}: {e.New.GetQuestionType()}";
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Finish creating form and save?", "Confirm finish", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (_model.SaveForm())
                {
                    MessageBox.Show("Form saved successfully.", "Form Saved");
                    Close();
                }
                else
                {
                    MessageBox.Show("Failed to save form.", "Form Save Error");
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Exit without saving?", "Confirm cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            SetPage(CreatePage.Factory(_model.PreviousQuestion()));
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Page == null)
            {
                _model.Title = titleTextBox.Text;
            }
            else
            {
                Page.Title = titleTextBox.Text;
            }
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Page == null)
            {
                _model.Description = descriptionTextBox.Text;
            }
            else
            {
                Page.Description = descriptionTextBox.Text;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            SetPage(CreatePage.Factory((Page?.Question == null) ? _model.FirstQuestion() : _model.NextQuestion()));
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            var firstQuestion = !_model.HasQuestion();
            var questionType = _questionTypes.ElementAt(qTypes.SelectedIndex);
            _model.AddQuestion(QuestionFactory(questionType));
            Question? newQuestion = null;
            if (firstQuestion)
            {
                newQuestion = _model.FirstQuestion();
            }
            else
            {
                while (_model.HasNextQuestion())
                {
                    newQuestion = _model.NextQuestion();
                }
            }
            SetPage(CreatePage.Factory(newQuestion));
        }
        private Question QuestionFactory(Question.QTYPE type)
        {
            return type switch
            {
                Question.QTYPE.TEXT_AREA => new QTextArea("", ""),
                Question.QTYPE.SINGLE_SELECT => new QSingleSelect("", "", new(), false),
                Question.QTYPE.MULTI_SELECT => new QMultiSelect("", "", new(), false),
                Question.QTYPE.DATE => new QDate("", "", DateTimePicker.MinimumDateTime, new DateTime(2100, 1, 1)),
                Question.QTYPE.NUMBER => new QNumber("", "", 0, 100),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Delete this question?", "Confirm delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (Page?.Question != null)
                {
                    _model.RemoveQuestion(Page.Question);
                    SetPage(CreatePage.Factory(_model.CurrentQuestion()));
                }
            }
        }
    }
}
