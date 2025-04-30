namespace UniversalForm.Client.View
{
    public partial class UserName : Form
    {
        public string UserNameValue { get; private set; } = string.Empty;
        public UserName()
        {
            InitializeComponent();
            userNameText.TextChanged += (s, e) => UserNameValue = userNameText.Text;
            button1.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(UserNameValue))
                {
                    MessageBox.Show("Please enter a username.", "Username error");
                    return;
                }
                Close();
            };
            button2.Click += (s, e) =>
            {
                UserNameValue = string.Empty;
                Close();
            };
        }
    }
}
