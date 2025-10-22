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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            themeGroup = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            doneBttn = new Button();
            panel1 = new Panel();
            openAppFolder = new Button();
            groupBox1 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton6 = new RadioButton();
            toolTip1 = new ToolTip(components);
            themeGroup.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
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
            themeGroup.Location = new Point(0, 3);
            themeGroup.Name = "themeGroup";
            themeGroup.Size = new Size(244, 128);
            themeGroup.TabIndex = 2;
            themeGroup.TabStop = false;
            themeGroup.Text = "Theme";
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
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(openAppFolder);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(themeGroup);
            panel1.Location = new Point(12, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 246);
            panel1.TabIndex = 3;
            // 
            // openAppFolder
            // 
            openAppFolder.Location = new Point(3, 233);
            openAppFolder.Name = "openAppFolder";
            openAppFolder.Size = new Size(553, 29);
            openAppFolder.TabIndex = 4;
            openAppFolder.Text = "Open App Folder";
            openAppFolder.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton5);
            groupBox1.Controls.Add(radioButton6);
            groupBox1.Location = new Point(3, 137);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(244, 90);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Icons";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(22, 56);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(88, 24);
            radioButton5.TabIndex = 1;
            radioButton5.TabStop = true;
            radioButton5.Text = "Constant";
            toolTip1.SetToolTip(radioButton5, "Consistant icon (uses app icon rather than from the engine)");
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Location = new Point(22, 26);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(84, 24);
            radioButton6.TabIndex = 0;
            radioButton6.TabStop = true;
            radioButton6.Text = "Instance";
            toolTip1.SetToolTip(radioButton6, "Loads the icon from the instance (tends to be VERY low quality)");
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.ToolTipTitle = "Icon settings";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 324);
            Controls.Add(panel1);
            Controls.Add(doneBttn);
            Controls.Add(label1);
            Name = "Settings";
            Text = "Settings";
            themeGroup.ResumeLayout(false);
            themeGroup.PerformLayout();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Panel panel1;
        private GroupBox groupBox1;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
        private ToolTip toolTip1;
        private Button openAppFolder;
    }
}