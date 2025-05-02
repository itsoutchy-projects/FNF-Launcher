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
    public partial class DuplicateMenu : Form
    {
        public string name = string.Empty;
        public DarkModeCS dm;
        public DuplicateMenu()
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
            doneBttn.Click += DoneBttn_Click;
        }

        private void DoneBttn_Click(object? sender, EventArgs e)
        {
            name = nameField.Text;
            if (name == string.Empty)
            {
                Messenger.MessageBox("Instance name cannot be empty");
                return;
            } else if (Directory.Exists($"{Directory.GetCurrentDirectory()}/Instances/{name}"))
            {
                Messenger.MessageBox("An instance with this name already exists");
                return;
            }
            Close();
        }
    }
}
