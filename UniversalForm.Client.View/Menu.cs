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
    public partial class Menu : Form
    {
        public bool FullExit { get; private set; } = true;
        private Model.Model _model;
        public Menu(Model.Model model)
        {
            _model = model;
            InitializeComponent();
        }

        private void FormBtn_Click(object sender, System.EventArgs e)
        {
            if (_model.LoadForm(FormCode.Text))
            {
                var fillForm = new FillForm(_model);
                Hide();
                fillForm.ShowDialog();
                if (fillForm.FullExit)
                {
                    Close();
                    return;
                }
                Show();
            } else
            {
                MessageBox.Show("Invalid Form Name");
                FormCode.Clear();
            }
        }

        private void LoginBtn_Click(object sender, System.EventArgs e)
        {
            var loginForm = new Login(_model);
            loginForm.ShowDialog();
            if (loginForm.Success)
            {
                var adminForm = new Admin(_model);
                Hide();
                adminForm.ShowDialog();
                if (adminForm.FullExit)
                {
                    Close();
                    return;
                }
                Show();
            }
        }
    }
}
