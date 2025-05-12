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
    public partial class AddNewInstance : Form
    {
        public string name = "";
        public InstanceType type;

        public bool created = false;

        public DarkModeCS dm;

        public AddNewInstance()
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
            doneButton.Click += DoneButton_Click;
        }

        private void DoneButton_Click(object? sender, EventArgs e)
        {
            if (instanceName.Text.Length == 0)
            {
                Messenger.MessageBox("You need to enter a name");
                return;
            }
            name = instanceName.Text;
            bool pickedEngine = false;
            if (radioButton1.Checked)
            {
                type = InstanceType.Psych;
                pickedEngine = true;
            }
            else if (radioButton2.Checked)
            {
                type = InstanceType.Codename;
                pickedEngine = true;
            }
            else if (radioButton3.Checked)
            {
                type = InstanceType.Kade;
                pickedEngine = true;
            }
            else if (radioButton4.Checked)
            {
                type = InstanceType.LeatherEngine;
                pickedEngine = true;
            }
            else if (radioButton5.Checked)
            {
                type = InstanceType.JSEngine;
                pickedEngine = true;
            }
            else if (radioButton6.Checked)
            {
                type = InstanceType.FPSPlus;
                pickedEngine = true;
            }
            else if (radioButton7.Checked)
            {
                type = InstanceType.DoidoEngine;
                pickedEngine = true;
            }
            else if (radioButton8.Checked)
            {
                type = InstanceType.DenpaEngine;
                pickedEngine = true;
            }
            else if (radioButton9.Checked)
            {
                type = InstanceType.Funkin;
                pickedEngine = true;
            }
            if (!pickedEngine)
            {
                Messenger.MessageBox("You need to pick an engine");
                return;
            }
            created = true;
            Close();
        }
    }
}
