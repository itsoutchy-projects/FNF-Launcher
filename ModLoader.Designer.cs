namespace FNF_Launcher
{
    partial class ModLoader
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
            instances = new GroupBox();
            doneBttn = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 35);
            label1.TabIndex = 0;
            label1.Text = "Install Mod";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 53);
            label2.Name = "label2";
            label2.Size = new Size(297, 20);
            label2.TabIndex = 1;
            label2.Text = "Choose which instance to install the mod to";
            // 
            // instances
            // 
            instances.Location = new Point(3, 3);
            instances.Name = "instances";
            instances.Size = new Size(480, 153);
            instances.TabIndex = 2;
            instances.TabStop = false;
            instances.Text = "Instance";
            // 
            // doneBttn
            // 
            doneBttn.Dock = DockStyle.Bottom;
            doneBttn.Location = new Point(0, 238);
            doneBttn.Name = "doneBttn";
            doneBttn.Size = new Size(529, 29);
            doneBttn.TabIndex = 3;
            doneBttn.Text = "Done";
            doneBttn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(instances);
            panel1.Location = new Point(12, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(505, 156);
            panel1.TabIndex = 0;
            // 
            // ModLoader
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 267);
            Controls.Add(panel1);
            Controls.Add(doneBttn);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ModLoader";
            Text = "ModLoader";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox instances;
        private Panel panel1;
        private Button doneBttn;
    }
}