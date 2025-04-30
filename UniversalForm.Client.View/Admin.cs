namespace UniversalForm.Client.View
{
    public partial class Admin : Form
    {
        public bool FullExit { get; private set; } = true;
        private Model.FormModel _model;
        public Admin(Model.FormModel model)
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
                MessageBox.Show("No forms found for user: " + _model.UserName, "Form List Load Error");
                return;
            }
            foreach (var form in forms)
            {
                var formAccess = new AdminFormAccess(form);
                formAccess.Dock = DockStyle.Top;
                formAccess.FormEdit += FormEdit;
                formAccess.FormDelete += FormDelete;
                formAccess.FormViewStats += FormViewStats;
                formsFlowLayout.Controls.Add(formAccess);
            }
        }

        private void FormViewStats(object? sender, string e)
        {
            _model.LoadForm(e);
            if (_model == null)
            {
                MessageBox.Show("Error loading form: " + e, "Form Load Error");
                return;
            }
            var statModel = _model.GetStatisticsModel();
            if (statModel == null)
            {
                MessageBox.Show("No statistics found for form: " + e, "Statistics Load Error");
                return;
            }
            var stats = new FormStatistics(_model, statModel);
            Hide();
            stats.ShowDialog();
            Show();
        }

        private void FormDelete(object? sender, string e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this form?", "Delete Form", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _model.DeleteForm(e);
                CreateFormList();
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
