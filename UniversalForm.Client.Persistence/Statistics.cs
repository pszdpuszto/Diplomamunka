using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Client.Persistence
{
    public class Statistics
    {
        public List<string> Answers { get; set; } = new();
        public int Corrections { get; set; } = 0;
        public int Time { get; set; } = 0;
        public int LostFocusTime { get; set; } = 0;
    }
}
