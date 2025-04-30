using UniversalForm.Client.Persistence;

namespace UniversalForm.Client.View
{
    public partial class ConnectionLost : System.Windows.Forms.Form
    {
        public bool FullExit { get; private set; } = true;
        private ClientJsonPersistence _persistence;
        public ConnectionLost(ClientJsonPersistence persistence)
        {
            _persistence = persistence;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_persistence.Reconnect())
            {
                FullExit = false;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to reconnect.", "Connection Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
