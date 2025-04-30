using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    internal abstract class CreatePage
    {
        private Control? _parent;
        protected List<Control> _controls = new();
        public Question Question { get; }
        public virtual string Title { get => Question.Title; set => Question.Title = value; }
        public virtual string Description { get => Question.Description; set => Question.Description = value; }
        protected CreatePage(Question question)
        {
            Question = question;
        }
        public static CreatePage? Factory(Question? question)
        {
            if (question == null)
                return null;
            switch (question.Type)
            {
                case Question.QTYPE.TEXT_AREA:
                    return new CPTextArea((QTextArea)question);
                case Question.QTYPE.SINGLE_SELECT:
                    return new CPSingleSelect((QSingleSelect)question);
                case Question.QTYPE.MULTI_SELECT:
                    return new CPMultiSelect((QMultiSelect)question);
                case Question.QTYPE.DATE:
                    return new CPDate((QDate)question);
                case Question.QTYPE.NUMBER:
                    return new CPNumber((QNumber)question);
                default:
                    return null;
            }
        }
        public void CreateControl(Control parent)
        {
            _parent = parent;
            if (Question != null)
                AddIsRequiredControl();
            DoCreateControls();
            for (int i = _controls.Count - 1; i >= 0; i--)
            {
                _parent.Controls.Add(_controls[i]);
            }
        }
        public void Dispose()
        {
            if (_parent == null)
                return;
            foreach (var control in _controls)
            {
                _parent.Controls.Remove(control);
                control.Dispose();
            }
            _controls.Clear();
        }
        protected void RemoveControl(Control control)
        {
            _controls.Remove(control);
            _parent?.Controls.Remove(control);
            control.Dispose();
        }
        public string GetQuestionType()
        {
            return Question.TypeToString[Question.Type];
        }
        protected abstract void DoCreateControls();
        protected void AddToFront(Control control)
        {
            _controls.Add(control);
            if (_parent != null)
            {
                _parent.Controls.Add(control);
            }
        }
        private void AddIsRequiredControl()
        {
            var isRequired = new CheckBox
            {
                Text = "Is Required",
                Checked = Question.Required,
                AutoSize = true,
                Location = new Point(0, 0),
                Dock = DockStyle.Top
            };
            isRequired.CheckedChanged += (s, e) =>
            {
                Question.Required = isRequired.Checked;
            };
            _controls.Add(isRequired);
        }
    }
}
