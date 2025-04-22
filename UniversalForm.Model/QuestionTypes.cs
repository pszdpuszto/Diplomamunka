using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniversalForm.Persistence;

namespace UniversalForm.Model
{

    public class QTextArea : Question
    {
        [JsonInclude]
        string DefaultText { get; }
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
        [JsonInclude]
        private readonly List<string> Options;
        public QSingleSelect(string title, string description, List<string> options) : base(QTYPE.SINGLE_SELECT, title, description)
        {
            Options = options;
        }

        protected override string extraStr()
        {
            return $"# options:{Options.Count} options";
        }
    }
}
