using System.Diagnostics;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    internal interface IPage
    {
        string Title { get; }
        string Description { get; }
        void Dispose();
    }
    internal abstract class FormPage
    {
        private Control _parent;
        protected Question _question;
        protected Statistics _statistics;
        protected List<Control> _controls = new();
        private Stopwatch _elapsedTime = new();
        private Stopwatch _lostFocusTime = new();
        private bool _noFocus = false;

        public event EventHandler<bool>? CanProceedChange;
        public bool CanProceed => !_question.Required || _statistics.HasAnswer();


        protected FormPage(Question question, Control parent, Statistics stats)
        {
            _parent = parent;
            _question = question;
            _statistics = stats;
            CreateControl();
            _elapsedTime.Start();
            _statistics.HasAnserChanged += (s, b) => CanProceedChange?.Invoke(this, CanProceed);
        }

        public static FormPage? Factory(Question question, Control parent, Statistics stats)
        {
            return question.Type switch
            {
                Question.QTYPE.TEXT_AREA => new FPTextArea((QTextArea)question, parent, stats),
                Question.QTYPE.SINGLE_SELECT => new FPSingleSelect((QSingleSelect)question, parent, stats),
                Question.QTYPE.MULTI_SELECT => new FPMultiSelect((QMultiSelect)question, parent, stats),
                Question.QTYPE.DATE => new FPDate((QDate)question, parent, stats),
                Question.QTYPE.NUMBER => new FPNumber((QNumber)question, parent, stats),
                _ => null,
            };
        }
        public void StopTimer()
        {
            _noFocus = true;
            _elapsedTime.Stop();
            _statistics.Time += _elapsedTime.ElapsedMilliseconds;
            _elapsedTime.Reset();
        }
        public void StartTimer()
        {
            _noFocus = false;
            _elapsedTime.Start();
        }
        public void Dispose()
        {
            StopTimer();
            foreach (var control in _controls)
            {
                _parent.Controls.Remove(control);
                control.Dispose();
            }
            _controls.Clear();
        }
        private void CreateControl()
        {
            if (_question.Required)
                AddRequiredLabel();
            DoCreateControl();
            for (int i = _controls.Count - 1; i >= 0; i--)
            {
                _parent.Controls.Add(_controls[i]);
            }
        }

        private void AddRequiredLabel()
        {
            var requiredLabel = new Label
            {
                Text = "*required*",
                ForeColor = System.Drawing.Color.Red,
                AutoSize = true,
                Location = new Point(0, 0),
                Dock = DockStyle.Top,
            };
            _controls.Add(requiredLabel);
        }

        protected abstract void DoCreateControl();

        public void LostFocus(object? _, EventArgs __)
        {
            if (_noFocus)
                return;
            _lostFocusTime.Start();
        }
        public void GotFocus(object? _, EventArgs __)
        {
            if (_noFocus)
                return;
            _lostFocusTime.Stop();
            _statistics.LostFocusTime += _lostFocusTime.ElapsedMilliseconds;
            _lostFocusTime.Reset();
        }
        public string Title
        {
            get { return _question.Title; }
        }
        public string Description
        {
            get { return _question.Description; }
        }
    }
}
