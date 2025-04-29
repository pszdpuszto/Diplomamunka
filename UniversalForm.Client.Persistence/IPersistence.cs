using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Client.Persistence
{
    public interface IPersistence
    {
        Form? LoadForm(string name);
        bool SaveForm(string userName, string formName, Form form);
        bool LogIn(string userName, string password);
        List<string>? GetForms(string userName);
    }
}
