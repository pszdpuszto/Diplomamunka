namespace UniversalForm.Client.View
{
    partial class AdminFormAccess
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            delBtn = new Button();
            editBtn = new Button();
            statBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 0;
            label1.Text = "formLabel";
            // 
            // delBtn
            // 
            delBtn.AutoSize = true;
            delBtn.Dock = DockStyle.Right;
            delBtn.Location = new Point(381, 0);
            delBtn.Name = "delBtn";
            delBtn.Size = new Size(75, 33);
            delBtn.TabIndex = 1;
            delBtn.Text = "Delete";
            delBtn.UseVisualStyleBackColor = true;
            // 
            // editBtn
            // 
            editBtn.AutoSize = true;
            editBtn.Dock = DockStyle.Right;
            editBtn.Location = new Point(306, 0);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 33);
            editBtn.TabIndex = 2;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // statBtn
            // 
            statBtn.AutoSize = true;
            statBtn.Dock = DockStyle.Right;
            statBtn.Location = new Point(226, 0);
            statBtn.Name = "statBtn";
            statBtn.Size = new Size(80, 33);
            statBtn.TabIndex = 3;
            statBtn.Text = "Statistics";
            statBtn.UseVisualStyleBackColor = true;
            // 
            // AdminFormAccess
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(statBtn);
            Controls.Add(editBtn);
            Controls.Add(delBtn);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "AdminFormAccess";
            Size = new Size(456, 33);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button delBtn;
        private Button editBtn;
        private Button statBtn;
    }
}
