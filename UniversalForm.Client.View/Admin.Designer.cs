namespace UniversalForm.Client.View
{
    partial class Admin
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
            label1 = new Label();
            label2 = new Label();
            formsFlowLayout = new Panel();
            newFormBtn = new Button();
            logOut = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 4);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 21);
            label1.TabIndex = 0;
            label1.Text = "Logged in as: no one";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(178, 57);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(56, 21);
            label2.TabIndex = 1;
            label2.Text = "Forms";
            // 
            // formsFlowLayout
            // 
            formsFlowLayout.AutoScroll = true;
            formsFlowLayout.AutoSize = true;
            formsFlowLayout.Dock = DockStyle.Fill;
            formsFlowLayout.Location = new Point(8, 96);
            formsFlowLayout.Margin = new Padding(10);
            formsFlowLayout.Name = "formsFlowLayout";
            formsFlowLayout.Size = new Size(425, 200);
            formsFlowLayout.TabIndex = 2;
            // 
            // newFormBtn
            // 
            newFormBtn.AutoSize = true;
            newFormBtn.Dock = DockStyle.Bottom;
            newFormBtn.Location = new Point(8, 296);
            newFormBtn.Margin = new Padding(4);
            newFormBtn.Name = "newFormBtn";
            newFormBtn.Size = new Size(425, 35);
            newFormBtn.TabIndex = 3;
            newFormBtn.Text = "Create New Form";
            newFormBtn.UseVisualStyleBackColor = true;
            newFormBtn.Click += newFormBtn_Click;
            // 
            // logOut
            // 
            logOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            logOut.AutoSize = true;
            logOut.Location = new Point(346, 4);
            logOut.Name = "logOut";
            logOut.Size = new Size(76, 31);
            logOut.TabIndex = 4;
            logOut.Text = "Log Out";
            logOut.UseVisualStyleBackColor = true;
            logOut.Click += logOut_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(logOut);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(8, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 88);
            panel1.TabIndex = 5;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 339);
            Controls.Add(formsFlowLayout);
            Controls.Add(panel1);
            Controls.Add(newFormBtn);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Admin";
            Padding = new Padding(8);
            Text = "Universal Forms - Admin Page";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel formsFlowLayout;
        private Button newFormBtn;
        private Button logOut;
        private Panel panel1;
    }
}