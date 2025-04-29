using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniversalForm.Client.Model;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    internal class CPTitlePage : CreatePage
    {
        private Model.Model _model;
        public override string Title
        {
            get => _model.Title;
            set => _model.Title = value;
        }
        public override string Description
        {
            get => _model.Description;
            set => _model.Description = value;
        }
        public CPTitlePage(Model.Model model) : base(null!)
        {
            _model = model;
        }

        protected override void DoCreateControls()
        {
            var checkBoxAnonymous = new CheckBox
            {
                Text = "Anonymous form (Warning: statistics by user won't be available!)",
                Dock = DockStyle.Top,
                AutoSize = true,
                Checked = _model.Anonymous
            };
            checkBoxAnonymous.CheckedChanged += (s, e) =>
            {
                _model.Anonymous = checkBoxAnonymous.Checked;
            };
            AddControl(checkBoxAnonymous);
            var checkBoxCorrection = new CheckBox
            {
                Text = "Measure Corrections",
                Dock = DockStyle.Top,
                AutoSize = true,
                Checked = _model.MeasureCorrections
            };
            checkBoxCorrection.CheckedChanged += (s, e) =>
            {
                _model.MeasureCorrections = checkBoxCorrection.Checked;
            };
            AddControl(checkBoxCorrection);
            var checkBoxTime = new CheckBox
            {
                Text = "Measure Time",
                Dock = DockStyle.Top,
                AutoSize = true,
                Checked = _model.MeasureTime
            };
            checkBoxTime.CheckedChanged += (s, e) =>
            {
                _model.MeasureTime = checkBoxTime.Checked;
            };
            AddControl(checkBoxTime);
            var checkBoxFocus = new CheckBox
            {
                Text = "Focus Tracking",
                Dock = DockStyle.Top,
                AutoSize = true,
                Checked = _model.FocusTracking
            };
            AddControl(checkBoxFocus);
        }
    }

        internal class CPTextArea : CreatePage
    {
        private QTextArea _question;
        public CPTextArea(QTextArea question) : base(question)
        {
            _question = question;
        }
        protected override void DoCreateControls()
        {
            var lable = new Label
            {
                Text = "Default Text (can be empty):",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            var defArea = new TextBox
            {
                Multiline = true,
                Font = new Font("Segoe UI", 12F),
                Size = new Size(400, 200),
                ScrollBars = ScrollBars.Vertical,
                PlaceholderText = "Default Text (can be empty)",
                Text = _question.DefaultText
            };
            defArea.TextChanged += (s, e) =>
            {
                _question.DefaultText = defArea.Text;
            };
            AddControl(defArea);
        }
    }

    internal abstract class CPSelect : CreatePage
    {
        private int _optionCount = 0;
        protected CPSelect(Question question) : base(question)
        {
        }
        protected abstract void SetCustomOption(bool custom);
        protected abstract List<string> GetOptions();
        protected override void DoCreateControls()
        {
            var custom = new CheckBox
            {
                Text = "Allow custom option",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            custom.CheckedChanged += (s, e) =>
            {
                SetCustomOption(custom.Checked);
            };
            AddControl(custom);
            var newBtn = new Button
            {
                Text = "Add Option",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            AddControl(newBtn);
            newBtn.Click += (s, e) =>
            {
                var option = CreateOption();
                AddControl(option);
            };
            foreach (var option in GetOptions())
            {
                var optionControl = CreateOption(option);
                AddControl(optionControl);
            }
        }
        private Control CreateOption(string? option = null)
        {
            if (option == null)
                GetOptions().Add("");
            var group = new FlowLayoutPanel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(5),
                Margin = new Padding(5),
                Tag = _optionCount++
            };
            var textBox = new TextBox
            {
                Font = new Font("Segoe UI", 12F),
                Size = new Size(400, 200),
                PlaceholderText = "Type Option here",
                Text = option ?? string.Empty
            };
            textBox.TextChanged += (s, e) =>
            {
                GetOptions()[(Convert.ToInt32(group.Tag))] = textBox.Text;
            };
            var deleteBtn = new Button
            {
                Text = "Delete",
                AutoSize = true,
                Dock = DockStyle.Left
            };
            deleteBtn.Click += (s, e) =>
            {
                GetOptions().RemoveAt(Convert.ToInt32(group.Tag));
                RemoveControl(group);
                group.Dispose();
                UpdateOptionName();
            };
            group.Controls.Add(textBox);
            group.Controls.Add(deleteBtn);
            return group;
        }
        private void UpdateOptionName()
        {
            _optionCount = 0;
            foreach (var control in _controls)
            {
                if (control is Panel group)
                {
                    group.Text = "Option #" + _optionCount;
                    group.Tag = _optionCount++;
                }
            }
        }
    }

    internal class CPSingleSelect : CPSelect
    {
        private QSingleSelect _question;
        public CPSingleSelect(QSingleSelect question) : base(question)
        {
            _question = question;
        }

        protected override List<string> GetOptions()
        {
            return _question.Options;
        }

        protected override void SetCustomOption(bool custom)
        {
            _question.CustomOption = custom;
        }
    }

    internal class CPMultiSelect : CPSelect
    {
        private QMultiSelect _question;
        public CPMultiSelect(QMultiSelect question) : base(question)
        {
            _question = question;
        }
        protected override List<string> GetOptions()
        {
            return _question.Options;
        }
        protected override void SetCustomOption(bool custom)
        {
            _question.CustomOption = custom;
        }
    }
    internal class CPDate : CreatePage
    {
        private QDate _question;
        public CPDate(QDate question) : base(question)
        {
            _question = question;
        }
        protected override void DoCreateControls()
        {
            var label = new Label
            {
                Text = "Min Date:",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            AddControl(label);
            var minDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = (_question.MinDate < DateTimePicker.MinimumDateTime) ? DateTimePicker.MinimumDateTime : _question.MinDate,
                Dock = DockStyle.Top,
                AutoSize = true
            };
            minDate.ValueChanged += (s, e) =>
            {
                _question.MinDate = minDate.Value;
            };
            AddControl(minDate);
            var label2 = new Label
            {
                Text = "Max Date:",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            AddControl(label2);
            var maxDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Value = (_question.MaxDate > DateTimePicker.MaximumDateTime) ? DateTimePicker.MaximumDateTime : _question.MaxDate,
                Dock = DockStyle.Top,
                AutoSize = true
            };
            maxDate.ValueChanged += (s, e) =>
            {
                _question.MaxDate = maxDate.Value;
            };
            AddControl(maxDate);
        }
    }
    internal class CPNumber : CreatePage
    {
        private QNumber _question;
        public CPNumber(QNumber question) : base(question)
        {
            _question = question;
        }
        protected override void DoCreateControls()
        {
            var label = new Label
            {
                Text = "Min Value:",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            AddControl(label);
            var minValue = new NumericUpDown
            {
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = _question.Min,
                Dock = DockStyle.Top,
                AutoSize = true
            };
            minValue.ValueChanged += (s, e) =>
            {
                _question.Min = (int)minValue.Value;
            };
            AddControl(minValue);
            var label2 = new Label
            {
                Text = "Max Value:",
                Dock = DockStyle.Top,
                AutoSize = true,
            };
            AddControl(label2);
            var maxValue = new NumericUpDown
            {
                Minimum = int.MinValue,
                Maximum = int.MaxValue,
                Value = _question.Max,
                Dock = DockStyle.Top,
                AutoSize = true
            };
            maxValue.ValueChanged += (s, e) =>
            {
                _question.Max = (int)maxValue.Value;
            };
            AddControl(maxValue);
        }
    }
}
