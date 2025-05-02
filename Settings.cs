using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            radioButton1.CheckedChanged += RadioButton1_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton2_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton3_CheckedChanged;
            doneBttn.Click += DoneBttn_Click;
            this.form = form;
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
            File.WriteAllText(PathUtils.Absolute("settings.txt"), "theme=system");
        }
        private void RadioButton2_CheckedChanged(object? sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.DarkMode;
                form.dm.ApplyTheme(mode);
                dm.ApplyTheme(mode);
            }
            File.WriteAllText(PathUtils.Absolute("settings.txt"), "theme=dark");
        }
        private void RadioButton3_CheckedChanged(object? sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.ClearMode;
                form.dm.ApplyTheme(mode);
                dm.ApplyTheme(mode);
            }
            File.WriteAllText(PathUtils.Absolute("settings.txt"), "theme=light");
        }
    }
}
