using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.Model
{

    public class QTextArea : Question
    {
        public string DefaultText { get; set; }
        public QTextArea(string title, string description, bool required = false, string defaultText = "") : base(QTYPE.TEXT_AREA, title, description, required)
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
        public QSingleSelect(string title, string description, List<string> options, bool customOption, bool required = false) : base(QTYPE.SINGLE_SELECT, title, description, required)
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
        public QMultiSelect(string title, string description, List<string> options, bool customOption, bool required = false) : base(QTYPE.MULTI_SELECT, title, description, required)
        {
            Options = options;
            CustomOption = customOption;
        }
    }
    public class QDate : Question
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public QDate(string title, string description, DateTime minDate, DateTime maxDate, bool required = false) : base(QTYPE.DATE, title, description, required)
        {
            MinDate = minDate;
            MaxDate = maxDate;
        }
    }
    public class QNumber : Question
    {
        public int Min;
        public int Max;
        public QNumber(string title, string description, int min, int max, bool required = false) : base(QTYPE.NUMBER, title, description, required)
        {
            Min = min;
            Max = max;
        }
    }
}
