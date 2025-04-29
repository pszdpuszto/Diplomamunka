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
    public partial class Admin : Form
    {
        public bool FullExit { get; private set; } = true;
        private Model.Model _model;
        public Admin(Model.Model model)
        {
            _model = model;
            InitializeComponent();
            label1.Text = "Logged in as: " + _model.UserName;
            CreateFormList();
        }
        public void CreateFormList()
        {
            formsFlowLayout.Controls.Clear();
            var forms = _model.GetFormList();
            if (forms == null)
            {
                MessageBox.Show("No forms found for user: " + _model.UserName);
                return;
            }
            foreach (var form in forms)
            {
                var formAccess = new AdminFormAccess(form);
                formAccess.Dock = DockStyle.Top;
                formAccess.FormEdit += FormEdit;
                formsFlowLayout.Controls.Add(formAccess);
            }
        }

        private void FormEdit(object? sender, string e)
        {
            var creator = new FormCreator(_model, e, false);
            Hide();
            creator.ShowDialog();
            if (creator.FullExit)
            {
                Close();
                return;
            }
            CreateFormList();
            Show();
        }

        private void newFormBtn_Click(object sender, System.EventArgs e)
        {
            var formName = new FormName(_model);
            formName.ShowDialog();
            if (string.IsNullOrEmpty(formName.FormNameValue))
            {
                return;
            }
            var creator = new FormCreator(_model, formName.FormNameValue, true);
            Hide();
            creator.ShowDialog();
            if (creator.FullExit)
            {
                Close();
                return;
            }
            CreateFormList();
            Show();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FullExit = false;
                Close();
            }
        }
    }
}
