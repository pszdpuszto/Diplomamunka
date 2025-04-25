using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Server.Persistence
{
    public interface IPersistence
    {
        public const string ERROR = "ERROR";
        public const string FORM_EXTENSION = ".uff";
        public const string STAT_EXTENSION = ".ufs";
        public bool CheckLogin(string userName, string password);
        public string GetJsonForm(string formName);
        public string GetJsonStatistics(string formName);
        public bool SaveForm(string formName, string jsonStr);
        public bool SaveStatistics(string formName, string jsonStr);
    }
}
