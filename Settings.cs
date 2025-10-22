using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNF_Launcher
{
    public partial class Settings : Form
    {
        public Form1 form; // main form, needed to change theme
        private DarkModeCS dm;
        public Settings(Form1 form)
        {
            InitializeComponent();
            
            string[] settings = File.ReadAllText(PathUtils.Absolute("settings.txt")).Split("\n");
            switch (settings[0].Split("=")[1])
            {
                case "system":
                    radioButton1.Checked = true;
                    dm = new DarkModeCS(this)
                    {
                        ColorMode = DarkModeCS.DisplayMode.SystemDefault
                    };
                    break;
                case "dark":
                    radioButton2.Checked = true;
                    dm = new DarkModeCS(this)
                    {
                        ColorMode = DarkModeCS.DisplayMode.DarkMode
                    };
                    break;
                case "light":
                    radioButton3.Checked = true;
                    dm = new DarkModeCS(this)
                    {
                        ColorMode = DarkModeCS.DisplayMode.ClearMode
                    };
                    break;
            }
            switch (settings[1].Split("=")[1])
            {
                case "instance":
                    radioButton6.Checked = true;
                    break;
                case "constant":
                    radioButton5.Checked = true;
                    break;
            }
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton3_CheckedChanged;

            radioButton5.CheckedChanged += RadioButton5_CheckedChanged;
            radioButton6.CheckedChanged += RadioButton5_CheckedChanged;
            doneBttn.Click += DoneBttn_Click;
            openAppFolder.Click += OpenAppFolder_Click;
            this.form = form;
        }

        private void OpenAppFolder_Click(object? sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", PathUtils.ApplicationDirectory);
        }

        private void RadioButton5_CheckedChanged(object? sender, EventArgs e)
        {
            Form1.instanceIcons = radioButton6.Checked;

            string[] settings = File.ReadAllLines(PathUtils.Absolute("settings.txt"));
            File.WriteAllText(PathUtils.Absolute("settings.txt"), $"{settings[0]}\nicons={(Form1.instanceIcons ? "instance" : "constant")}");
        }

        private void RadioButton6_CheckedChanged(object? sender, EventArgs e)
        {
            Form1.instanceIcons = !radioButton5.Checked;

            string[] settings = File.ReadAllLines(PathUtils.Absolute("settings.txt"));
            File.WriteAllText(PathUtils.Absolute("settings.txt"), $"{settings[0]}\nicons={(Form1.instanceIcons ? "instance" : "constant")}");
        }

        private void DoneBttn_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void RadioButton1_CheckedChanged(object? sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.SystemDefault;
                form.dm.ApplyTheme(mode);
                dm.ApplyTheme(mode);
            }
            string[] settings = File.ReadAllLines(PathUtils.Absolute("settings.txt"));
            File.WriteAllText(PathUtils.Absolute("settings.txt"), $"theme=system\n{settings[1]}");
        }
        private void RadioButton2_CheckedChanged(object? sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.DarkMode;
                form.dm.ApplyTheme(mode);
                dm.ApplyTheme(mode);
            }
            string[] settings = File.ReadAllLines(PathUtils.Absolute("settings.txt"));
            File.WriteAllText(PathUtils.Absolute("settings.txt"), $"theme=dark\n{settings[1]}");
        }
        private void RadioButton3_CheckedChanged(object? sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.ClearMode;
                form.dm.ApplyTheme(mode);
                dm.ApplyTheme(mode);
            }
            string[] settings = File.ReadAllLines(PathUtils.Absolute("settings.txt"));
            File.WriteAllText(PathUtils.Absolute("settings.txt"), $"theme=light\n{settings[1]}");
        }
    }
}
