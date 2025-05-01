namespace UniversalForm.Client.View
{
    partial class UserName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserName));
            label1 = new Label();
            userNameText = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(23, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(275, 63);
            label1.TabIndex = 0;
            label1.Text = "This form is not anonymous.\r\nPlease provide a username with which\r\nthe form's creator can identify you.";
            // 
            // userNameText
            // 
            userNameText.Anchor = AnchorStyles.Top;
            userNameText.Location = new Point(59, 91);
            userNameText.Name = "userNameText";
            userNameText.PlaceholderText = "Enter Username";
            userNameText.Size = new Size(194, 29);
            userNameText.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.AutoSize = true;
            button1.Location = new Point(237, 159);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.AutoSize = true;
            button2.Location = new Point(12, 159);
            button2.Name = "button2";
            button2.Size = new Size(75, 31);
            button2.TabIndex = 3;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // UserName
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 202);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(userNameText);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "UserName";
            Text = "Universal Forms - Username";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox userNameText;
        private Button button1;
        private Button button2;
    }
}