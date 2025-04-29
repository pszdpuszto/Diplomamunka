namespace UniversalForm.Client.View
{
    partial class FormCreator
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
            titleTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            cancelBtn = new Button();
            finishBtn = new Button();
            optionsPanel = new FlowLayoutPanel();
            createBtn = new Button();
            nextBtn = new Button();
            backBtn = new Button();
            panel1 = new Panel();
            numLabel = new Label();
            qTypes = new ComboBox();
            delBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Dock = DockStyle.Top;
            titleTextBox.Font = new Font("Segoe UI", 32F);
            titleTextBox.Location = new Point(0, 0);
            titleTextBox.Margin = new Padding(4);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.PlaceholderText = "Form Title";
            titleTextBox.Size = new Size(710, 64);
            titleTextBox.TabIndex = 2;
            titleTextBox.TextChanged += titleTextBox_TextChanged;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Dock = DockStyle.Top;
            descriptionTextBox.Font = new Font("Segoe UI", 18F);
            descriptionTextBox.Location = new Point(0, 64);
            descriptionTextBox.Margin = new Padding(26, 28, 26, 28);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.PlaceholderText = "Form Description";
            descriptionTextBox.Size = new Size(710, 145);
            descriptionTextBox.TabIndex = 3;
            descriptionTextBox.TextChanged += descriptionTextBox_TextChanged;
            // 
            // cancelBtn
            // 
            cancelBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelBtn.AutoSize = true;
            cancelBtn.Location = new Point(15, 57);
            cancelBtn.Margin = new Padding(4);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(96, 32);
            cancelBtn.TabIndex = 4;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // finishBtn
            // 
            finishBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            finishBtn.AutoSize = true;
            finishBtn.Location = new Point(598, 57);
            finishBtn.Margin = new Padding(4);
            finishBtn.Name = "finishBtn";
            finishBtn.Size = new Size(96, 32);
            finishBtn.TabIndex = 5;
            finishBtn.Text = "Finish";
            finishBtn.UseVisualStyleBackColor = true;
            finishBtn.Click += finishBtn_Click;
            // 
            // optionsPanel
            // 
            optionsPanel.Dock = DockStyle.Fill;
            optionsPanel.FlowDirection = FlowDirection.TopDown;
            optionsPanel.Location = new Point(0, 209);
            optionsPanel.Margin = new Padding(4);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(710, 245);
            optionsPanel.TabIndex = 6;
            // 
            // createBtn
            // 
            createBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            createBtn.AutoSize = true;
            createBtn.Location = new Point(526, 9);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(168, 31);
            createBtn.TabIndex = 9;
            createBtn.Text = "Create New Question";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nextBtn.AutoSize = true;
            nextBtn.Location = new Point(598, 8);
            nextBtn.Margin = new Padding(4);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(96, 32);
            nextBtn.TabIndex = 7;
            nextBtn.Text = "Next >";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Click += nextBtn_Click;
            // 
            // backBtn
            // 
            backBtn.AutoSize = true;
            backBtn.Location = new Point(15, 8);
            backBtn.Margin = new Padding(4);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(96, 32);
            backBtn.TabIndex = 8;
            backBtn.Text = "< Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(delBtn);
            panel1.Controls.Add(numLabel);
            panel1.Controls.Add(createBtn);
            panel1.Controls.Add(qTypes);
            panel1.Controls.Add(cancelBtn);
            panel1.Controls.Add(nextBtn);
            panel1.Controls.Add(backBtn);
            panel1.Controls.Add(finishBtn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 454);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(710, 106);
            panel1.TabIndex = 9;
            // 
            // numLabel
            // 
            numLabel.AutoSize = true;
            numLabel.Location = new Point(311, 68);
            numLabel.Name = "numLabel";
            numLabel.Size = new Size(76, 21);
            numLabel.TabIndex = 10;
            numLabel.Text = "Title Page";
            // 
            // qTypes
            // 
            qTypes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            qTypes.FormattingEnabled = true;
            qTypes.Location = new Point(321, 11);
            qTypes.Margin = new Padding(4);
            qTypes.Name = "qTypes";
            qTypes.Size = new Size(198, 29);
            qTypes.TabIndex = 0;
            // 
            // delBtn
            // 
            delBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            delBtn.AutoSize = true;
            delBtn.Location = new Point(118, 9);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(131, 31);
            delBtn.TabIndex = 10;
            delBtn.Text = "Delete Question";
            delBtn.UseVisualStyleBackColor = true;
            delBtn.Click += delBtn_Click;
            // 
            // FormCreator
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 560);
            Controls.Add(optionsPanel);
            Controls.Add(descriptionTextBox);
            Controls.Add(titleTextBox);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FormCreator";
            Text = "FormCreator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private Button cancelBtn;
        private Button finishBtn;
        private FlowLayoutPanel optionsPanel;
        private Button nextBtn;
        private Button backBtn;
        private Panel panel1;
        private ComboBox qTypes;
        private Button createBtn;
        private Label numLabel;
        private Button delBtn;
    }
}