namespace UniversalForm.Client.View
{
    partial class FormStatistics
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
            overviewBtn = new RadioButton();
            questionBtn = new RadioButton();
            userBtn = new RadioButton();
            userComboBox = new ComboBox();
            panel1 = new Panel();
            questionComboBox = new ComboBox();
            mainPanel = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // overviewBtn
            // 
            overviewBtn.AutoSize = true;
            overviewBtn.Location = new Point(13, 13);
            overviewBtn.Margin = new Padding(4);
            overviewBtn.Name = "overviewBtn";
            overviewBtn.Size = new Size(94, 25);
            overviewBtn.TabIndex = 0;
            overviewBtn.TabStop = true;
            overviewBtn.Text = "Overview";
            overviewBtn.UseVisualStyleBackColor = true;
            overviewBtn.CheckedChanged += overviewBtn_CheckedChanged;
            // 
            // questionBtn
            // 
            questionBtn.AutoSize = true;
            questionBtn.Location = new Point(114, 13);
            questionBtn.Name = "questionBtn";
            questionBtn.Size = new Size(115, 25);
            questionBtn.TabIndex = 1;
            questionBtn.TabStop = true;
            questionBtn.Text = "By Question:";
            questionBtn.UseVisualStyleBackColor = true;
            questionBtn.CheckedChanged += SetQuestionStatisticsPage;
            // 
            // userBtn
            // 
            userBtn.AutoSize = true;
            userBtn.Location = new Point(453, 13);
            userBtn.Name = "userBtn";
            userBtn.Size = new Size(121, 25);
            userBtn.TabIndex = 2;
            userBtn.TabStop = true;
            userBtn.Text = "By Submitter:";
            userBtn.UseVisualStyleBackColor = true;
            userBtn.CheckedChanged += SetUserStatisticsPage;
            // 
            // userComboBox
            // 
            userComboBox.FormattingEnabled = true;
            userComboBox.Location = new Point(580, 13);
            userComboBox.Name = "userComboBox";
            userComboBox.Size = new Size(173, 29);
            userComboBox.TabIndex = 3;
            userComboBox.SelectedIndexChanged += SetUserStatisticsPage;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(userComboBox);
            panel1.Controls.Add(userBtn);
            panel1.Controls.Add(questionComboBox);
            panel1.Controls.Add(overviewBtn);
            panel1.Controls.Add(questionBtn);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 56);
            panel1.TabIndex = 4;
            // 
            // questionComboBox
            // 
            questionComboBox.FormattingEnabled = true;
            questionComboBox.Location = new Point(232, 12);
            questionComboBox.Name = "questionComboBox";
            questionComboBox.Size = new Size(215, 29);
            questionComboBox.TabIndex = 4;
            questionComboBox.SelectedIndexChanged += SetQuestionStatisticsPage;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 56);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(773, 508);
            mainPanel.TabIndex = 5;
            // 
            // FormStatistics
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 564);
            Controls.Add(mainPanel);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FormStatistics";
            Text = "FormStatistics";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton overviewBtn;
        private RadioButton questionBtn;
        private RadioButton userBtn;
        private ComboBox userComboBox;
        private Panel panel1;
        private Panel mainPanel;
        private ComboBox questionComboBox;
    }
}