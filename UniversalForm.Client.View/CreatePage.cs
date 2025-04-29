using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    internal abstract class CreatePage
    {
        private Control? _parent;
        protected List<Control> _controls = new();
        public Question Question { get; }
        public virtual string Title { get => Question.Title;  set => Question.Title = value; }
        public virtual string Description { get => Question.Description;  set => Question.Description = value; }
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
            DoCreateControls();
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
        protected void AddControl(Control control)
        {
            _controls.Add(control);
            _parent?.Controls.Add(control);
        }
        protected void RemoveControl(Control control)
        {
            _controls.Remove(control);
            _parent?.Controls.Remove(control);
            control.Dispose();
        }
        protected abstract void DoCreateControls();
    }
}
