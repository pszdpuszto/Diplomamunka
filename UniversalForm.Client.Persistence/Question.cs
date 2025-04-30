using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UniversalForm.Client.Persistence
{
    
    public abstract class Question
    {
        public enum QTYPE
        {
            TEXT_AREA,
            SINGLE_SELECT,
            MULTI_SELECT,
            DATE,
            NUMBER
        }
        public static Dictionary<QTYPE, string> TypeToString = new()
        {
            { QTYPE.TEXT_AREA, "Text Area" },
            { QTYPE.SINGLE_SELECT, "Single Select" },
            { QTYPE.MULTI_SELECT, "Multi Select" },
            { QTYPE.DATE, "Date" },
            { QTYPE.NUMBER, "Number" }
        };
        public QTYPE Type { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; } = false;
        public Question(QTYPE type, string title, string description, bool required)
        {
            Type = type;
            Title = title;
            Description = description;
            Required = required;
        }

        public override string ToString()
        {
            return $"Type:{Type.ToString()}\nTitle:{Title}\nDescription:{Description}\n{extraStr()}";
        }

        protected virtual string extraStr() => "Default";
    }
}
