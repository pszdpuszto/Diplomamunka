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
                    MessageBox.Show("Please enter a username.");
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
