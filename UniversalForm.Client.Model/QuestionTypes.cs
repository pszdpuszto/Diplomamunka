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

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Title, Description, Required, DefaultText);
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
        public override int GetHashCode()
        {
            var optionsHash = Options.Aggregate(0, (current, option) => current ^ option.GetHashCode());
            return HashCode.Combine(Type, Title, Description, Required, optionsHash, CustomOption);
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
        public override int GetHashCode()
        {
            var optionsHash = Options.Aggregate(0, (current, option) => current ^ option.GetHashCode());
            return HashCode.Combine(Type, Title, Description, Required, optionsHash, CustomOption);
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
        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Title, Description, Required, MinDate, MaxDate);
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
        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Title, Description, Required, Min, Max);
        }
    }
}
