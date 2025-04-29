using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    internal class FormPage
    {
        private Control _parent;
        private Question _question;
        private Statistics _statistics;
        private List<Control> _controls = new();

        public FormPage(Question question, Control parent)
        {
            _parent = parent;
            _question = question;
            CreateControl();
        }
        public void Dispose()
        {
            foreach (var control in _controls)
            {
                _parent.Controls.Remove(control);
                control.Dispose();
            }
            _controls.Clear();
        }
        private void CreateControl()
        {
            switch (_question.Type)
            {
                case Question.QTYPE.TEXT_AREA:
                    var textQuestion = (QTextArea)_question;
                    var textBox = new TextBox();
                    textBox.Multiline = true;
                    textBox.ScrollBars = ScrollBars.Vertical;
                    textBox.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    textBox.Height = 128;
                    textBox.Width = 512;
                    textBox.PlaceholderText = textQuestion.DefaultText;
                    if (textQuestion.AnswerText != string.Empty)
                        textBox.Text = textQuestion.AnswerText;
                    textBox.TextChanged += (s, e) => { textQuestion.AnswerText = textBox.Text; };
                    _controls.Add(textBox);
                    break;
                case Question.QTYPE.SINGLE_SELECT:
                    var singleSelectQuestion = (QSingleSelect)_question;
                    bool hasAnswer = false;
                    foreach (var option in singleSelectQuestion.Options)
                    {
                        var radioButton = new RadioButton();
                        radioButton.Text = option;
                        radioButton.Dock = DockStyle.Top;
                        if (singleSelectQuestion.AnswerText == option)
                        {
                            radioButton.Checked = true;
                            hasAnswer = true;
                        }
                        radioButton.CheckedChanged += (s, e) => { singleSelectQuestion.AnswerText = option; };
                        _controls.Add(radioButton);
                    }
                    if (singleSelectQuestion.CustomOption)
                    {
                        var radioButton = new RadioButton();
                        radioButton.Text = "Other, specify below:";
                        radioButton.Dock = DockStyle.Top;
                        _controls.Add(radioButton);
                        var textPanel = new Panel();
                        var customTextBox = new TextBox();
                        customTextBox.PlaceholderText = "Enter custom option";
                        customTextBox.Width = 512;
                        customTextBox.Enabled = false;
                        textPanel.Controls.Add(customTextBox); 
                        textPanel.Dock = DockStyle.Top;
                        textPanel.AutoSize = true;
                        textPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        if (!hasAnswer && singleSelectQuestion.AnswerText != string.Empty)
                        {
                            customTextBox.Text = singleSelectQuestion.AnswerText;
                            radioButton.Checked = true;
                        }
                        radioButton.CheckedChanged += (s, e) => 
                        {
                            singleSelectQuestion.AnswerText = customTextBox.Text; 
                            customTextBox.Enabled = radioButton.Checked;
                        };
                        _controls.Add(textPanel);
                    }
                    break;
                case Question.QTYPE.MULTI_SELECT:
                    var multiSelectQuestion = (QMultiSelect)_question;
                    foreach (var option in multiSelectQuestion.Options)
                    {
                        var checkBox = new CheckBox();
                        checkBox.Text = option;
                        checkBox.Dock = DockStyle.Top;
                        if (multiSelectQuestion.AnswerTexts.Contains(option))
                        {
                            checkBox.Checked = true;
                        }
                        checkBox.CheckedChanged += (s, e) => 
                        {
                            if (checkBox.Checked)
                            {
                                multiSelectQuestion.AnswerTexts.Add(option);
                            }
                            else
                            {
                                multiSelectQuestion.AnswerTexts.Remove(option);
                            }
                        };
                        _controls.Add(checkBox);
                    }
                    if (multiSelectQuestion.CustomOption)
                    {
                        var checkBox = new CheckBox();
                        checkBox.Text = "Other, specify below: ";
                        checkBox.Dock = DockStyle.Top;
                        _controls.Add(checkBox);
                        var textPanel = new Panel();
                        textPanel.Dock = DockStyle.Top;
                        var customTextBox = new TextBox();
                        customTextBox.PlaceholderText = "Enter custom option";
                        customTextBox.Enabled = false;
                        customTextBox.Width = 512;
                        textPanel.Controls.Add(customTextBox);
                        if (multiSelectQuestion.CustomAnswerText != string.Empty)
                        {
                            customTextBox.Enabled = true;
                            customTextBox.Text = multiSelectQuestion.CustomAnswerText;
                            checkBox.Checked = true;
                        }
                        checkBox.CheckedChanged += (s, e) => 
                        {
                            if (checkBox.Checked)
                            {
                                multiSelectQuestion.CustomAnswerText = customTextBox.Text;
                            }
                            else
                            {
                                multiSelectQuestion.CustomAnswerText = string.Empty;
                            }
                            customTextBox.Enabled = checkBox.Checked;
                        };
                        customTextBox.TextChanged += (s, e) =>
                        {
                            multiSelectQuestion.CustomAnswerText = customTextBox.Text;
                        };
                        _controls.Add(textPanel);
                    }
                    break;
                case Question.QTYPE.DATE:
                    var dateQuestion = (QDate)_question;
                    var datePicker = new DateTimePicker();
                    datePicker.MinDate = dateQuestion.MinDate;
                    datePicker.MaxDate = dateQuestion.MaxDate;
                    datePicker.Format = DateTimePickerFormat.Short;
                    if (dateQuestion.AnswerDate != null)
                    {
                            datePicker.Value = (DateTime)dateQuestion.AnswerDate;
                    }
                    _controls.Add(datePicker);
                    break;
                case Question.QTYPE.NUMBER:
                    var sliderQuestion = (QNumber)_question;
                    var numInput = new NumericUpDown();
                    numInput.Minimum = sliderQuestion.Min;
                    numInput.Maximum = sliderQuestion.Max;
                    var ans = sliderQuestion.AnswerInt;
                    if (sliderQuestion.Min <= ans && sliderQuestion.Max >= ans)
                    {
                            numInput.Value = ans;
                    }
                    _controls.Add(new Label()
                    {
                        Text = sliderQuestion.Min.ToString(),
                    });
                    _controls.Add(numInput);
                    break;
            }
            for (int i = _controls.Count - 1; i >= 0; i--)
            {
                _parent.Controls.Add(_controls[i]);
            }
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
