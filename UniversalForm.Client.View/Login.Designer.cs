

namespace UniversalForm.Client.View
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            usernameLabel = new Label();
            passwordLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.Top;
            usernameTextBox.Font = new Font("Segoe UI", 12F);
            usernameTextBox.Location = new Point(111, 135);
            usernameTextBox.Margin = new Padding(4);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "Enter Username";
            usernameTextBox.Size = new Size(268, 29);
            usernameTextBox.TabIndex = 0;
            usernameTextBox.TextChanged += textBox_TextChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Anchor = AnchorStyles.Top;
            passwordTextBox.Font = new Font("Segoe UI", 12F);
            passwordTextBox.Location = new Point(111, 172);
            passwordTextBox.Margin = new Padding(4);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.PlaceholderText = "Enter Password";
            passwordTextBox.Size = new Size(268, 29);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.TextChanged += textBox_TextChanged;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.Font = new Font("Segoe UI", 12F);
            okButton.Location = new Point(286, 284);
            okButton.Margin = new Padding(4);
            okButton.Name = "okButton";
            okButton.Size = new Size(96, 32);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Font = new Font("Segoe UI", 12F);
            cancelButton.Location = new Point(15, 284);
            cancelButton.Margin = new Padding(4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(96, 32);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += CancelButton_click;
            // 
            // usernameLabel
            // 
            usernameLabel.Anchor = AnchorStyles.Top;
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 12F);
            usernameLabel.Location = new Point(15, 138);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(88, 21);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "Username: ";
            // 
            // passwordLabel
            // 
            passwordLabel.Anchor = AnchorStyles.Top;
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F);
            passwordLabel.Location = new Point(15, 175);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(83, 21);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "Password: ";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(83, 9);
            label1.Name = "label1";
            label1.Size = new Size(241, 45);
            label1.TabIndex = 6;
            label1.Text = "Login as Admin";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 333);
            Controls.Add(label1);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Login";
            Text = "Universal Forms - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button okButton;
        private Button cancelButton;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label label1;
    }
}