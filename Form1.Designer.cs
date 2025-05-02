namespace FNF_Launcher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            contextMenuStrip1 = new ContextMenuStrip(components);
            openInstanceFolderToolStripMenuItem = new ToolStripMenuItem();
            runToolStripMenuItem = new ToolStripMenuItem();
            newInstance = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            instances = new ListView();
            panel2 = new Panel();
            makeshortcut = new Button();
            instanceNameLabel = new Label();
            rightPanelShowFolder = new Button();
            rightPanelRun = new Button();
            duplicateToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openInstanceFolderToolStripMenuItem, runToolStripMenuItem, duplicateToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(219, 104);
            // 
            // openInstanceFolderToolStripMenuItem
            // 
            openInstanceFolderToolStripMenuItem.Name = "openInstanceFolderToolStripMenuItem";
            openInstanceFolderToolStripMenuItem.Size = new Size(218, 24);
            openInstanceFolderToolStripMenuItem.Text = "Open Instance Folder";
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(218, 24);
            runToolStripMenuItem.Text = "Run";
            // 
            // newInstance
            // 
            newInstance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            newInstance.Image = (Image)resources.GetObject("newInstance.Image");
            newInstance.ImageAlign = ContentAlignment.MiddleLeft;
            newInstance.Location = new Point(3, 3);
            newInstance.Name = "newInstance";
            newInstance.Size = new Size(146, 53);
            newInstance.TabIndex = 1;
            newInstance.Text = "New Instance";
            newInstance.TextAlign = ContentAlignment.MiddleRight;
            newInstance.UseVisualStyleBackColor = true;
            newInstance.Click += newInstance_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(instances);
            panel1.Controls.Add(newInstance);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(551, 503);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(533, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(17, 16);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // instances
            // 
            instances.ContextMenuStrip = contextMenuStrip1;
            instances.Dock = DockStyle.Bottom;
            instances.Location = new Point(0, 59);
            instances.MultiSelect = false;
            instances.Name = "instances";
            instances.Size = new Size(549, 442);
            instances.TabIndex = 2;
            instances.UseCompatibleStateImageBehavior = false;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(makeshortcut);
            panel2.Controls.Add(instanceNameLabel);
            panel2.Controls.Add(rightPanelShowFolder);
            panel2.Controls.Add(rightPanelRun);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(554, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(121, 503);
            panel2.TabIndex = 3;
            // 
            // makeshortcut
            // 
            makeshortcut.Enabled = false;
            makeshortcut.Location = new Point(0, 94);
            makeshortcut.Name = "makeshortcut";
            makeshortcut.Size = new Size(115, 48);
            makeshortcut.TabIndex = 5;
            makeshortcut.Text = "Create Shortcut";
            makeshortcut.UseVisualStyleBackColor = true;
            // 
            // instanceNameLabel
            // 
            instanceNameLabel.Location = new Point(-1, 3);
            instanceNameLabel.Name = "instanceNameLabel";
            instanceNameLabel.Size = new Size(121, 53);
            instanceNameLabel.TabIndex = 4;
            instanceNameLabel.Text = "{INSTANCE} AGAIN YAYA";
            instanceNameLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // rightPanelShowFolder
            // 
            rightPanelShowFolder.Enabled = false;
            rightPanelShowFolder.Location = new Point(0, 148);
            rightPanelShowFolder.Name = "rightPanelShowFolder";
            rightPanelShowFolder.Size = new Size(115, 29);
            rightPanelShowFolder.TabIndex = 3;
            rightPanelShowFolder.Text = "Show Folder";
            rightPanelShowFolder.UseVisualStyleBackColor = true;
            // 
            // rightPanelRun
            // 
            rightPanelRun.Enabled = false;
            rightPanelRun.Location = new Point(0, 59);
            rightPanelRun.Name = "rightPanelRun";
            rightPanelRun.Size = new Size(115, 29);
            rightPanelRun.TabIndex = 2;
            rightPanelRun.Text = "Run";
            rightPanelRun.UseVisualStyleBackColor = true;
            // 
            // duplicateToolStripMenuItem
            // 
            duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            duplicateToolStripMenuItem.Size = new Size(218, 24);
            duplicateToolStripMenuItem.Text = "Duplicate";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 503);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "FNF Launcher - Friday Night Funkin' Launcher";
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button newInstance;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem openInstanceFolderToolStripMenuItem;
        private ToolStripMenuItem runToolStripMenuItem;
        private Panel panel1;
        private Panel panel2;
        private Button rightPanelShowFolder;
        private Button rightPanelRun;
        private Label instanceNameLabel;
        private ListView instances;
        private PictureBox pictureBox1;
        private Button makeshortcut;
        private ToolStripMenuItem duplicateToolStripMenuItem;
    }
}
