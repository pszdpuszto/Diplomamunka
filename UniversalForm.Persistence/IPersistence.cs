using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalForm.Persistence
{
    public interface IPersistence
    {
        Form? LoadForm(string name);
        bool SaveForm(Form form);
    }
}
