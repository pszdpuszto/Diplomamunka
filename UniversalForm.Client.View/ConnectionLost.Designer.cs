namespace UniversalForm.Client.View
{
    partial class ConnectionLost
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
            reconnectBtn = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(7, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(210, 21);
            label1.TabIndex = 0;
            label1.Text = "Lost connection to the server";
            // 
            // reconnectBtn
            // 
            reconnectBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            reconnectBtn.AutoSize = true;
            reconnectBtn.Location = new Point(123, 56);
            reconnectBtn.Name = "reconnectBtn";
            reconnectBtn.Size = new Size(92, 31);
            reconnectBtn.TabIndex = 1;
            reconnectBtn.Text = "Reconnect";
            reconnectBtn.UseVisualStyleBackColor = true;
            reconnectBtn.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.AutoSize = true;
            button2.Location = new Point(12, 56);
            button2.Name = "button2";
            button2.Size = new Size(75, 31);
            button2.TabIndex = 2;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ConnectionLost
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(227, 99);
            Controls.Add(button2);
            Controls.Add(reconnectBtn);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "ConnectionLost";
            Text = "ConnectionLost";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button reconnectBtn;
        private Button button2;
    }
}