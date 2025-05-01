namespace UniversalForm.Client.View
{
    public partial class Login : Form
    {
        private Model.FormModel _model;
        public bool Success { get; private set; } = false;
        public string UserName { get; private set; } = string.Empty;
        public Login(Model.FormModel model)
        {
            InitializeComponent();
            _model = model;
        }
        private void okButton_Click(object sender, System.EventArgs e)
        {
            var pwd = passwordTextBox.Text;
            if (_model.LogIn(usernameTextBox.Text, pwd))
            {
                Success = true;
                UserName = usernameTextBox.Text;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Error");
            }
        }

        private void CancelButton_click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void textBox_TextChanged(object sender, System.EventArgs e)
        {
            if (usernameTextBox.Text.Length > 0 && passwordTextBox.Text.Length > 0)
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }

        private void Login_Load(object sender, System.EventArgs e)
        {

        }
    }
}
