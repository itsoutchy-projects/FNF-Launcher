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
    public partial class Downloading : Form
    {
        public string[] steps =
        {
            "Downloading",
            "Extracting"
        };
        public int stepNo = 0;
        public DarkModeCS dm;

        public float progress
        {
            set
            {
                progressBar1.Value = (int)(value * 100);
            }
        }
        public Downloading()
        {
            InitializeComponent();
            string[] settings = File.ReadAllText(PathUtils.Absolute("settings.txt")).Split("\n");
            DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.SystemDefault;
            if (settings[0].Split("=")[1] == "dark")
            {
                mode = DarkModeCS.DisplayMode.DarkMode;
            }
            else if (settings[0].Split("=")[1] == "light")
            {
                mode = DarkModeCS.DisplayMode.ClearMode;
            }
            dm = new DarkModeCS(this)
            {
                //[Optional] Choose your preferred color mode here:
                ColorMode = mode
            };
            Text = $"{steps[stepNo]}...";
            header.Text = $"{steps[stepNo]} {stepNo + 1} of {steps.Length}";
        }

        public void stepChange()
        {
            stepNo++;
            Text = $"{steps[stepNo]}...";
            header.Text = $"{steps[stepNo]} {stepNo + 1} of {steps.Length}";
            progress = 0; // reset, extracting has no progress so no point
        }
    }
}
