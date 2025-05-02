namespace FNF_Launcher
{
    partial class DuplicateMenu
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
            nameField = new TextBox();
            label2 = new Label();
            doneBttn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(205, 30);
            label1.TabIndex = 0;
            label1.Text = "Duplicate Instance";
            // 
            // nameField
            // 
            nameField.Location = new Point(67, 37);
            nameField.Name = "nameField";
            nameField.Size = new Size(179, 27);
            nameField.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 40);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 2;
            label2.Text = "Name";
            // 
            // doneBttn
            // 
            doneBttn.Dock = DockStyle.Bottom;
            doneBttn.Location = new Point(0, 101);
            doneBttn.Name = "doneBttn";
            doneBttn.Size = new Size(266, 29);
            doneBttn.TabIndex = 3;
            doneBttn.Text = "Done";
            doneBttn.UseVisualStyleBackColor = true;
            // 
            // DuplicateMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 130);
            Controls.Add(doneBttn);
            Controls.Add(label2);
            Controls.Add(nameField);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "DuplicateMenu";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "DuplicateMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nameField;
        private Label label2;
        private Button doneBttn;
    }
}