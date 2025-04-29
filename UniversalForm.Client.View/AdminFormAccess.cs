using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversalForm.Client.View
{
    public partial class AdminFormAccess : UserControl
    {
        private string _formName = string.Empty;
        public event EventHandler<string>? FormEdit;
        public AdminFormAccess(string formName)
        {
            InitializeComponent();
            label1.Text = formName;
            editBtn.Click += (s, e) =>
            {
                FormEdit?.Invoke(this, formName);
            };
        }
    }
}
