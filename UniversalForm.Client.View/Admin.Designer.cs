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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 13);
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
            label2.Location = new Point(148, 76);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(149, 21);
            label2.TabIndex = 1;
            label2.Text = "View Form Statistics";
            // 
            // formsFlowLayout
            // 
            formsFlowLayout.Anchor = AnchorStyles.Top;
            formsFlowLayout.AutoScroll = true;
            formsFlowLayout.AutoSize = true;
            formsFlowLayout.Location = new Point(33, 101);
            formsFlowLayout.Margin = new Padding(4);
            formsFlowLayout.Name = "formsFlowLayout";
            formsFlowLayout.Size = new Size(383, 512);
            formsFlowLayout.TabIndex = 2;
            // 
            // newFormBtn
            // 
            newFormBtn.Anchor = AnchorStyles.Bottom;
            newFormBtn.AutoSize = true;
            newFormBtn.Location = new Point(152, 680);
            newFormBtn.Margin = new Padding(4);
            newFormBtn.Name = "newFormBtn";
            newFormBtn.Size = new Size(142, 35);
            newFormBtn.TabIndex = 3;
            newFormBtn.Text = "Create New Form";
            newFormBtn.UseVisualStyleBackColor = true;
            newFormBtn.Click += newFormBtn_Click;
            // 
            // logOut
            // 
            logOut.AutoSize = true;
            logOut.Location = new Point(382, 13);
            logOut.Name = "logOut";
            logOut.Size = new Size(76, 31);
            logOut.TabIndex = 4;
            logOut.Text = "Log Out";
            logOut.UseVisualStyleBackColor = true;
            logOut.Click += logOut_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 732);
            Controls.Add(logOut);
            Controls.Add(newFormBtn);
            Controls.Add(formsFlowLayout);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "Admin";
            Text = "Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel formsFlowLayout;
        private Button newFormBtn;
        private Button logOut;
    }
}