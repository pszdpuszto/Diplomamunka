
namespace UniversalForm.Client.View
{
    partial class Menu
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
            Title = new Label();
            FormCode = new TextBox();
            LoadFormBtn = new Button();
            LoginBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top;
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 24F);
            Title.Location = new Point(84, 9);
            Title.Name = "Title";
            Title.Size = new Size(246, 45);
            Title.TabIndex = 0;
            Title.Text = "Universal Forms";
            // 
            // FormCode
            // 
            FormCode.Anchor = AnchorStyles.Top;
            FormCode.Font = new Font("Segoe UI", 12F);
            FormCode.Location = new Point(44, 126);
            FormCode.Name = "FormCode";
            FormCode.PlaceholderText = "Enter Form Name";
            FormCode.Size = new Size(192, 29);
            FormCode.TabIndex = 1;
            // 
            // LoadFormBtn
            // 
            LoadFormBtn.Anchor = AnchorStyles.Top;
            LoadFormBtn.AutoSize = true;
            LoadFormBtn.Font = new Font("Segoe UI", 12F);
            LoadFormBtn.Location = new Point(243, 124);
            LoadFormBtn.Name = "LoadFormBtn";
            LoadFormBtn.Size = new Size(139, 31);
            LoadFormBtn.TabIndex = 2;
            LoadFormBtn.Text = "Fill out Form";
            LoadFormBtn.UseVisualStyleBackColor = true;
            LoadFormBtn.Click += FormBtn_Click;
            // 
            // LoginBtn
            // 
            LoginBtn.Anchor = AnchorStyles.Top;
            LoginBtn.AutoSize = true;
            LoginBtn.Font = new Font("Segoe UI", 12F);
            LoginBtn.Location = new Point(142, 208);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(124, 31);
            LoginBtn.TabIndex = 3;
            LoginBtn.Text = "login as Admin";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(191, 174);
            label1.Name = "label1";
            label1.Size = new Size(32, 21);
            label1.TabIndex = 4;
            label1.Text = "OR";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(142, 83);
            label2.Name = "label2";
            label2.Size = new Size(140, 21);
            label2.TabIndex = 5;
            label2.Text = "Enter a form name";
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 260);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LoginBtn);
            Controls.Add(LoadFormBtn);
            Controls.Add(FormCode);
            Controls.Add(Title);
            Name = "Menu";
            Text = "Universal Forms";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private TextBox FormCode;
        private Button LoadFormBtn;
        private Button LoginBtn;
        private Label label1;
        private Label label2;
    }
}