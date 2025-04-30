namespace UniversalForm.Client.View
{
    public partial class Menu : Form
    {
        public bool FullExit { get; private set; } = true;
        private Model.FormModel _model;
        public Menu(Model.FormModel model)
        {
            _model = model;
            InitializeComponent();
        }

        private void FormBtn_Click(object sender, System.EventArgs e)
        {
            if (_model.LoadForm(FormCode.Text))
            {
                if (!_model.IsAnonymous())
                {
                    var userNameForm = new UserName();
                    userNameForm.ShowDialog();
                    var userName = userNameForm.UserNameValue;
                    if (userName == string.Empty)
                        return;
                    _model.SetUserName(userName);
                }
                var fillForm = new FillForm(_model);
                Hide();
                fillForm.ShowDialog();
                if (fillForm.FullExit)
                {
                    Close();
                    return;
                }
                Show();
            }
            else
            {
                MessageBox.Show("Invalid Form Name", "Form Name Error");
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
