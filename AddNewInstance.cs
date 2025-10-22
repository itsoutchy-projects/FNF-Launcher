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
using System.IO;

namespace FNF_Launcher
{
    public partial class AddNewInstance : Form
    {
        public string name = "";
        public InstanceType type;

        public bool created = false;

        public CustomEngine? engine = null;

        public DarkModeCS dm;

        public List<RadioButton> customEngineRadios = new List<RadioButton>();

        public List<CustomEngine> engines = new List<CustomEngine>();

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
            
            foreach (string s in Directory.GetFiles(PathUtils.Absolute("engines")))
            {
                CustomEngine eng = new CustomEngine(s);
                engines.Add(eng);
                RadioButton lastEngine = radioButton8;
                if (customEngineRadios.Count > 0)
                {
                    lastEngine = customEngineRadios[customEngineRadios.Count - 1];
                }
                RadioButton thisRad = new RadioButton()
                {
                    Text = eng.name,
                    Parent = groupBox1,
                    Location = new Point(lastEngine.Location.X, lastEngine.Location.Y + 30)
                };
                thisRad.Size = new Size(groupBox1.Size.Width - 15, thisRad.Size.Height);
                customEngineRadios.Add(thisRad);
                groupBox1.Size = new Size(groupBox1.Size.Width, groupBox1.Size.Height + 30);
            }
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
            else
            {
                int i = 0;
                foreach (RadioButton radio in customEngineRadios)
                {
                    if (radio.Checked)
                    {
                        pickedEngine = true;
                        engine = engines[i];
                        break;
                    }
                    i++;
                }
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
