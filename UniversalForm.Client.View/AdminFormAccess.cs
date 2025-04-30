namespace UniversalForm.Client.View
{
    public partial class AdminFormAccess : UserControl
    {
        private string _formName = string.Empty;
        public event EventHandler<string>? FormEdit;
        public event EventHandler<string>? FormDelete;
        public event EventHandler<string>? FormViewStats;
        public AdminFormAccess(string formName)
        {
            InitializeComponent();
            label1.Text = formName;
            editBtn.Click += (s, e) => FormEdit?.Invoke(this, formName);
            delBtn.Click += (s, e) => FormDelete?.Invoke(this, formName);
            statBtn.Click += (s, e) => FormViewStats?.Invoke(this, formName);
        }
    }
}
