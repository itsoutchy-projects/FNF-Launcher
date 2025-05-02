namespace FNF_Launcher
{
    partial class Settings
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
            themeGroup = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            doneBttn = new Button();
            themeGroup.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(-1, -1);
            label1.Name = "label1";
            label1.Size = new Size(122, 37);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            // 
            // themeGroup
            // 
            themeGroup.Controls.Add(radioButton3);
            themeGroup.Controls.Add(radioButton2);
            themeGroup.Controls.Add(radioButton1);
            themeGroup.Location = new Point(12, 39);
            themeGroup.Name = "themeGroup";
            themeGroup.Size = new Size(244, 128);
            themeGroup.TabIndex = 2;
            themeGroup.TabStop = false;
            themeGroup.Text = "Theme";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(22, 26);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(77, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "System";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(22, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(61, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Dark";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(22, 86);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(63, 24);
            radioButton3.TabIndex = 2;
            radioButton3.TabStop = true;
            radioButton3.Text = "Light";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // doneBttn
            // 
            doneBttn.Dock = DockStyle.Bottom;
            doneBttn.Location = new Point(0, 295);
            doneBttn.Name = "doneBttn";
            doneBttn.Size = new Size(604, 29);
            doneBttn.TabIndex = 0;
            doneBttn.Text = "Done";
            doneBttn.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 324);
            Controls.Add(doneBttn);
            Controls.Add(themeGroup);
            Controls.Add(label1);
            Name = "Settings";
            Text = "Settings";
            themeGroup.ResumeLayout(false);
            themeGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox themeGroup;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button doneBttn;
    }
}