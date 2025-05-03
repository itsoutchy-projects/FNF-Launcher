namespace FNF_Launcher
{
    partial class About
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
            label3 = new Label();
            label4 = new Label();
            reportbugs = new Button();
            panel1 = new Panel();
            doneBttn = new Button();
            sourcecode = new Button();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(256, 35);
            label1.TabIndex = 0;
            label1.Text = "About FNF Launcher";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(419, 20);
            label2.TabIndex = 1;
            label2.Text = "Cool little FNF Launcher, manage your instances with ease and";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 103);
            label3.Name = "label3";
            label3.Size = new Size(144, 20);
            label3.TabIndex = 2;
            label3.Text = "Created by itsoutchy";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 132);
            label4.Name = "label4";
            label4.Size = new Size(459, 20);
            label4.TabIndex = 3;
            label4.Text = "Ownership of the supported engines goes to their respective owners";
            // 
            // reportbugs
            // 
            reportbugs.AutoSize = true;
            reportbugs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            reportbugs.Dock = DockStyle.Left;
            reportbugs.Location = new Point(0, 0);
            reportbugs.Name = "reportbugs";
            reportbugs.Size = new Size(106, 40);
            reportbugs.TabIndex = 4;
            reportbugs.Text = "Report a bug";
            reportbugs.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(doneBttn);
            panel1.Controls.Add(sourcecode);
            panel1.Controls.Add(reportbugs);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 217);
            panel1.Name = "panel1";
            panel1.Size = new Size(538, 40);
            panel1.TabIndex = 5;
            // 
            // doneBttn
            // 
            doneBttn.AutoSize = true;
            doneBttn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            doneBttn.Dock = DockStyle.Right;
            doneBttn.Location = new Point(483, 0);
            doneBttn.Name = "doneBttn";
            doneBttn.Size = new Size(55, 40);
            doneBttn.TabIndex = 6;
            doneBttn.Text = "Done";
            doneBttn.UseVisualStyleBackColor = true;
            // 
            // sourcecode
            // 
            sourcecode.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            sourcecode.Location = new Point(112, 0);
            sourcecode.Name = "sourcecode";
            sourcecode.Size = new Size(103, 40);
            sourcecode.TabIndex = 5;
            sourcecode.Text = "Source Code";
            sourcecode.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 64);
            label5.Name = "label5";
            label5.Size = new Size(379, 20);
            label5.TabIndex = 6;
            label5.Text = "keep your Friday Night Funkin' installations in one place.";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 257);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "About";
            Text = "About";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button reportbugs;
        private Panel panel1;
        private Button doneBttn;
        private Button sourcecode;
        private Label label5;
    }
}