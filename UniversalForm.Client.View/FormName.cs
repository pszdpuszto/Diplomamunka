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
    public partial class FormName : Form
    {
        private Model.FormModel _model;
        public string FormNameValue { get; private set; } = string.Empty;
        public FormName(Model.FormModel model)
        {
            _model = model;
            InitializeComponent();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter a form name.");
                return;
            }
            if (_model.FormExists(textBox1.Text))
            {
                MessageBox.Show(" A form with that name already exists. Please choose a different name.");
                return;
            }
            FormNameValue = textBox1.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNameValue = string.Empty;
            Close();
        }
    }
}
