using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Model
{

    public class QTextArea : Question
    {
        public string DefaultText { get; set; }
        [JsonIgnore]
        public string AnswerText { get; set; } = string.Empty;
        public QTextArea(string title, string description, string defaultText = "") : base(QTYPE.TEXT_AREA, title, description)
        {
            DefaultText = defaultText;
        }
        protected override string extraStr()
        {
            return $"DefaultText:{DefaultText}";
        }
    }

    public class QSingleSelect : Question
    {
        public List<string> Options { get; }
        public bool CustomOption { get; set; }
        [JsonIgnore]
        public string AnswerText { get; set; } = string.Empty;
        public QSingleSelect(string title, string description, List<string> options, bool customOption) : base(QTYPE.SINGLE_SELECT, title, description)
        {
            Options = options;
            CustomOption = customOption;
        }

        protected override string extraStr()
        {
            return $"# options:{Options.Count} options";
        }
    }
    public class QMultiSelect : Question
    {
        public List<string> Options { get; }
        public bool CustomOption { get; set; }
        [JsonIgnore]
        public List<string> AnswerTexts { get; set; } = new();
        [JsonIgnore]
        public string CustomAnswerText { get; set; } = string.Empty;
        public QMultiSelect(string title, string description, List<string> options, bool customOption) : base(QTYPE.MULTI_SELECT, title, description)
        {
            Options = options;
            CustomOption = customOption;
        }
    }
    public class QDate : Question
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        [JsonIgnore]
        public DateTime? AnswerDate { get; set; } = null;
        public QDate(string title, string description, DateTime minDate, DateTime maxDate) : base(QTYPE.DATE, title, description)
        {
            MinDate = minDate;
            MaxDate = maxDate;
        }
    }
    public class QNumber : Question
    {
        public int Min;
        public int Max;
        [JsonIgnore]
        public int AnswerInt { get; set; } = 0;
        public QNumber(string title, string description, int min, int max) : base(QTYPE.NUMBER, title, description)
        {
            Min = min;
            Max = max;
        }
    }
}
