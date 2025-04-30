namespace UniversalForm.Client.View
{
    partial class FillForm
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
            components = new System.ComponentModel.Container();
            backBtn = new Button();
            nextBtn = new Button();
            answerPanel = new Panel();
            startBtn = new Button();
            panel1 = new Panel();
            numLabel = new Label();
            bindingSource1 = new BindingSource(components);
            title = new Label();
            description = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backBtn.AutoSize = true;
            backBtn.Enabled = false;
            backBtn.Location = new Point(4, 8);
            backBtn.Margin = new Padding(4);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(68, 35);
            backBtn.TabIndex = 0;
            backBtn.Text = "< Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Visible = false;
            backBtn.Click += backBtn_Click;
            // 
            // nextBtn
            // 
            nextBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nextBtn.AutoSize = true;
            nextBtn.Enabled = false;
            nextBtn.Location = new Point(617, 8);
            nextBtn.Margin = new Padding(4);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(67, 35);
            nextBtn.TabIndex = 1;
            nextBtn.Text = "Next >";
            nextBtn.UseVisualStyleBackColor = true;
            nextBtn.Visible = false;
            nextBtn.Click += nextBtn_Click;
            // 
            // answerPanel
            // 
            answerPanel.AutoScroll = true;
            answerPanel.AutoSize = true;
            answerPanel.Dock = DockStyle.Fill;
            answerPanel.Location = new Point(13, 103);
            answerPanel.Margin = new Padding(13, 14, 13, 14);
            answerPanel.Name = "answerPanel";
            answerPanel.Size = new Size(687, 368);
            answerPanel.TabIndex = 4;
            // 
            // startBtn
            // 
            startBtn.Anchor = AnchorStyles.Bottom;
            startBtn.AutoSize = true;
            startBtn.Location = new Point(286, 8);
            startBtn.Margin = new Padding(4);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(111, 35);
            startBtn.TabIndex = 5;
            startBtn.Text = "Fill Out Form";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += StartBtn;
            // 
            // panel1
            // 
            panel1.Controls.Add(numLabel);
            panel1.Controls.Add(backBtn);
            panel1.Controls.Add(startBtn);
            panel1.Controls.Add(nextBtn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(13, 471);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(687, 48);
            panel1.TabIndex = 6;
            // 
            // numLabel
            // 
            numLabel.Anchor = AnchorStyles.Top;
            numLabel.AutoSize = true;
            numLabel.Location = new Point(286, 15);
            numLabel.Margin = new Padding(4, 0, 4, 0);
            numLabel.Name = "numLabel";
            numLabel.Size = new Size(95, 21);
            numLabel.TabIndex = 0;
            numLabel.Text = "Question #1";
            numLabel.Visible = false;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Dock = DockStyle.Top;
            title.Font = new Font("Segoe UI", 24F);
            title.Location = new Point(13, 14);
            title.Margin = new Padding(13, 14, 13, 14);
            title.Name = "title";
            title.Size = new Size(81, 45);
            title.TabIndex = 2;
            title.Text = "Title";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Dock = DockStyle.Top;
            description.Font = new Font("Segoe UI", 16F);
            description.Location = new Point(13, 59);
            description.Margin = new Padding(13, 14, 13, 14);
            description.Name = "description";
            description.Padding = new Padding(0, 0, 0, 14);
            description.Size = new Size(122, 44);
            description.TabIndex = 3;
            description.Text = "Description";
            // 
            // FillForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 533);
            Controls.Add(answerPanel);
            Controls.Add(description);
            Controls.Add(title);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "FillForm";
            Padding = new Padding(13, 14, 13, 14);
            Text = "Universal Forms - ";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Button backBtn;
        private Button nextBtn;
        private Panel answerPanel;
        private Button startBtn;
        private Panel panel1;
        private BindingSource bindingSource1;
        private Label numLabel;
        private Label title;
        private Label description;
    }
}