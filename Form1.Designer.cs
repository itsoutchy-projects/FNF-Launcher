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
            renameToolStripMenuItem = new ToolStripMenuItem();
            duplicateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            newInstance = new Button();
            panel1 = new Panel();
            aboutBttn = new Button();
            settingsBttn = new Button();
            pictureBox1 = new PictureBox();
            instances = new ListView();
            panel2 = new Panel();
            installMod = new Button();
            makeshortcut = new Button();
            instanceNameLabel = new Label();
            rightPanelShowFolder = new Button();
            rightPanelRun = new Button();
            addExistingInstance = new Button();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { openInstanceFolderToolStripMenuItem, runToolStripMenuItem, renameToolStripMenuItem, duplicateToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(219, 124);
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
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(218, 24);
            renameToolStripMenuItem.Text = "Rename";
            // 
            // duplicateToolStripMenuItem
            // 
            duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            duplicateToolStripMenuItem.Size = new Size(218, 24);
            duplicateToolStripMenuItem.Text = "Duplicate";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(218, 24);
            deleteToolStripMenuItem.Text = "Delete";
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
            panel1.Controls.Add(addExistingInstance);
            panel1.Controls.Add(aboutBttn);
            panel1.Controls.Add(settingsBttn);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(instances);
            panel1.Controls.Add(newInstance);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(551, 503);
            panel1.TabIndex = 2;
            // 
            // aboutBttn
            // 
            aboutBttn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            aboutBttn.Image = (Image)resources.GetObject("aboutBttn.Image");
            aboutBttn.ImageAlign = ContentAlignment.MiddleLeft;
            aboutBttn.Location = new Point(271, 3);
            aboutBttn.Name = "aboutBttn";
            aboutBttn.Size = new Size(97, 53);
            aboutBttn.TabIndex = 7;
            aboutBttn.Text = "About";
            aboutBttn.TextAlign = ContentAlignment.MiddleRight;
            aboutBttn.UseVisualStyleBackColor = true;
            // 
            // settingsBttn
            // 
            settingsBttn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            settingsBttn.Image = (Image)resources.GetObject("settingsBttn.Image");
            settingsBttn.ImageAlign = ContentAlignment.MiddleLeft;
            settingsBttn.Location = new Point(155, 3);
            settingsBttn.Name = "settingsBttn";
            settingsBttn.Size = new Size(110, 53);
            settingsBttn.TabIndex = 6;
            settingsBttn.Text = "Settings";
            settingsBttn.TextAlign = ContentAlignment.MiddleRight;
            settingsBttn.UseVisualStyleBackColor = true;
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
            instances.LabelEdit = true;
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
            panel2.Controls.Add(installMod);
            panel2.Controls.Add(makeshortcut);
            panel2.Controls.Add(instanceNameLabel);
            panel2.Controls.Add(rightPanelShowFolder);
            panel2.Controls.Add(rightPanelRun);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(556, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(131, 503);
            panel2.TabIndex = 3;
            // 
            // installMod
            // 
            installMod.Enabled = false;
            installMod.Location = new Point(2, 184);
            installMod.Name = "installMod";
            installMod.Size = new Size(123, 29);
            installMod.TabIndex = 6;
            installMod.Text = "Install Mod";
            installMod.UseVisualStyleBackColor = true;
            // 
            // makeshortcut
            // 
            makeshortcut.Enabled = false;
            makeshortcut.Location = new Point(3, 95);
            makeshortcut.Name = "makeshortcut";
            makeshortcut.Size = new Size(123, 48);
            makeshortcut.TabIndex = 5;
            makeshortcut.Text = "Create Shortcut";
            makeshortcut.UseVisualStyleBackColor = true;
            // 
            // instanceNameLabel
            // 
            instanceNameLabel.Location = new Point(2, 4);
            instanceNameLabel.Name = "instanceNameLabel";
            instanceNameLabel.Size = new Size(121, 53);
            instanceNameLabel.TabIndex = 4;
            instanceNameLabel.Text = "{INSTANCE} AGAIN YAYA";
            instanceNameLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // rightPanelShowFolder
            // 
            rightPanelShowFolder.Enabled = false;
            rightPanelShowFolder.Location = new Point(3, 149);
            rightPanelShowFolder.Name = "rightPanelShowFolder";
            rightPanelShowFolder.Size = new Size(123, 29);
            rightPanelShowFolder.TabIndex = 3;
            rightPanelShowFolder.Text = "Show Folder";
            rightPanelShowFolder.UseVisualStyleBackColor = true;
            // 
            // rightPanelRun
            // 
            rightPanelRun.Enabled = false;
            rightPanelRun.Location = new Point(3, 60);
            rightPanelRun.Name = "rightPanelRun";
            rightPanelRun.Size = new Size(123, 29);
            rightPanelRun.TabIndex = 2;
            rightPanelRun.Text = "Run";
            rightPanelRun.UseVisualStyleBackColor = true;
            // 
            // addExistingInstance
            // 
            addExistingInstance.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addExistingInstance.Image = (Image)resources.GetObject("addExistingInstance.Image");
            addExistingInstance.ImageAlign = ContentAlignment.MiddleLeft;
            addExistingInstance.Location = new Point(374, 3);
            addExistingInstance.Name = "addExistingInstance";
            addExistingInstance.Size = new Size(146, 53);
            addExistingInstance.TabIndex = 8;
            addExistingInstance.Text = "Add Instance";
            addExistingInstance.TextAlign = ContentAlignment.MiddleRight;
            addExistingInstance.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 503);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button settingsBttn;
        private Button aboutBttn;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private Button installMod;
        private ToolStripMenuItem renameToolStripMenuItem;
        private Button addExistingInstance;
    }
}
