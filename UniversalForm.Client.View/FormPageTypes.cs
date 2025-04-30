using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    internal class FPTextArea(Question question, Control parent, Statistics stats) : FormPage(question, parent, stats)
    {
        protected override void DoCreateControl()
        {
            var textQuestion = (QTextArea)_question;
            var textBox = new TextBox()
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Height = 128,
                Width = 512,
                PlaceholderText = textQuestion.DefaultText
            };
            textBox.LostFocus += (s, e) => { _statistics.Corrections++; };
            if (_statistics.HasAnswer())
                textBox.Text = _statistics.GetSingleAnswer();
            textBox.TextChanged += (s, e) => { _statistics.SetSingleAnswer(textBox.Text); };
            _controls.Add(textBox);
        }
    }

    internal class FPSingleSelect(Question question, Control parent, Statistics stats) : FormPage(question, parent, stats)
    {
        protected override void DoCreateControl()
        {
            var singleSelectQuestion = (QSingleSelect)_question;
            bool hasAnswer = false;
            foreach (var option in singleSelectQuestion.Options)
            {
                var radioButton = new RadioButton()
                {
                    Text = option,
                    Dock = DockStyle.Top,
                };
                if (_statistics.IsAnswer(option))
                {
                    radioButton.Checked = true;
                    hasAnswer = true;
                }
                radioButton.CheckedChanged += (s, e) => { 
                    _statistics.SetSingleAnswer(option); 
                    _statistics.Corrections++;
                };
                _controls.Add(radioButton);
            }
            if (singleSelectQuestion.CustomOption)
            {
                var radioButton = new RadioButton();
                radioButton.Text = "Other, specify below:";
                radioButton.Dock = DockStyle.Top;
                _controls.Add(radioButton);
                var textPanel = new Panel()
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,

                };
                var customTextBox = new TextBox()
                {
                    PlaceholderText = "Enter custom option",
                    Width = 512,
                    Enabled = false,
                };
                textPanel.Controls.Add(customTextBox);
                if (!hasAnswer && _statistics.HasAnswer())
                {
                    customTextBox.Text = _statistics.GetSingleAnswer();
                    radioButton.Checked = true;
                }
                radioButton.CheckedChanged += (s, e) =>
                {
                    if (radioButton.Checked)
                        _statistics.SetSingleAnswer(customTextBox.Text);
                    customTextBox.Enabled = radioButton.Checked;
                    _statistics.Corrections++;
                };
                _controls.Add(textPanel);
            }
        }
    }
    internal class FPMultiSelect(Question question, Control parent, Statistics stats) : FormPage(question, parent, stats)
    {
        protected override void DoCreateControl()
        {
            var multiSelectQuestion = (QMultiSelect)_question;
            foreach (var option in multiSelectQuestion.Options)
            {
                var checkBox = new CheckBox()
                {
                    Text = option,
                    Dock = DockStyle.Top
                };
                if (_statistics.IsAnswer(option))
                    checkBox.Checked = true;
                checkBox.CheckedChanged += (s, e) =>
                {
                    _statistics.ToggleAnswer(option);
                    if (checkBox.Tag != null)
                    {
                        _statistics.Corrections++;
                    } else
                    {
                        checkBox.Tag = new object();
                    }
                };
                _controls.Add(checkBox);
            }
            if (multiSelectQuestion.CustomOption)
            {
                var checkBox = new CheckBox()
                {
                    Dock = DockStyle.Top,
                    Text = "Other, specify below: ",
                };
                _controls.Add(checkBox);
                var textPanel = new Panel()
                {
                    Dock = DockStyle.Top
                };
                var customTextBox = new TextBox()
                {
                    PlaceholderText = "Enter custom option",
                    Enabled = false,
                    Width = 512,

                };
                textPanel.Controls.Add(customTextBox);
                var customAnswer = _statistics.GetCustomAnswer(multiSelectQuestion.Options);
                if (customAnswer != null)
                {
                    customTextBox.Enabled = true;
                    customTextBox.Text = customAnswer;
                    checkBox.Checked = true;
                }
                checkBox.CheckedChanged += (s, e) =>
                {
                    if (!checkBox.Checked)
                        _statistics.ChangeCustomAnswer(multiSelectQuestion.Options, null);
                    if (checkBox.Tag != null)
                    {
                        _statistics.Corrections++;
                    }
                    else
                    {
                        checkBox.Tag = new object();
                    }
                };
                customTextBox.TextChanged += (s, e) => _statistics.ChangeCustomAnswer(multiSelectQuestion.Options, customTextBox.Text);
                _controls.Add(textPanel);
            }
        }
    }
    internal class FPDate(Question question, Control parent, Statistics stats) : FormPage(question, parent, stats)
    {
        protected override void DoCreateControl()
        {
            var dateQuestion = (QDate)_question;
            var datePicker = new DateTimePicker()
            {
                MinDate = dateQuestion.MinDate,
                MaxDate = dateQuestion.MaxDate,
                Format = DateTimePickerFormat.Short,
            };
            if (_statistics.HasAnswer())
            {
                datePicker.Value = DateTime.Parse(_statistics.GetSingleAnswer());
            }
            datePicker.ValueChanged += (s, e) =>
            {
                _statistics.SetSingleAnswer(datePicker.Value.ToString("yyyy-MM-dd"));
                _statistics.Corrections++;
            };
            _controls.Add(datePicker);
        }
    }
    internal class FPNumber(Question question, Control parent, Statistics stats) : FormPage(question, parent, stats)
    {
        protected override void DoCreateControl()
        {
            var sliderQuestion = (QNumber)_question;
            var numInput = new NumericUpDown();
            numInput.Minimum = sliderQuestion.Min;
            numInput.Maximum = sliderQuestion.Max;
            int ans;
            if (Int32.TryParse(_statistics.GetSingleAnswer(), out ans) && sliderQuestion.Min <= ans && sliderQuestion.Max >= ans)
            {
                numInput.Value = ans;
            }
            numInput.ValueChanged += (s, e) =>
            {
                _statistics.SetSingleAnswer(numInput.Value.ToString());
                _statistics.Corrections++;
            };
            _controls.Add(numInput);
        }
    }
}