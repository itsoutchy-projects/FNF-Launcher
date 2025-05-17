namespace FNF_Launcher
{
    partial class Downloading
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
            header = new Label();
            progressBar1 = new DarkModeForms.FlatProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1, 48);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Please wait...";
            // 
            // header
            // 
            header.AutoSize = true;
            header.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            header.Location = new Point(1, 9);
            header.Name = "header";
            header.Size = new Size(190, 30);
            header.TabIndex = 1;
            header.Text = "(smth) Step _ of _";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 88);
            progressBar1.Name = "progressBar1";
            progressBar1.ProgressBarColor = Color.RoyalBlue;
            progressBar1.Size = new Size(339, 29);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 2;
            // 
            // Downloading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 129);
            Controls.Add(progressBar1);
            Controls.Add(header);
            Controls.Add(label1);
            Name = "Downloading";
            Text = "Downloading";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label header;
        public DarkModeForms.FlatProgressBar progressBar1;
    }
}