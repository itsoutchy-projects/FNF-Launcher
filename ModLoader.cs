using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNF_Launcher
{
    public partial class ModLoader : Form
    {
        public string instance = "";
        private string path;
        public List<RadioButton> radioButtons = new List<RadioButton>();

        public ModLoader(string modPath)
        {
            InitializeComponent();
            path = modPath;
            foreach (string p in Directory.GetDirectories($"{PathUtils.ApplicationDirectory}\\Instances"))
            {
                MessageBox.Show(p);
                RadioButton t = new RadioButton();
                t.Dock = DockStyle.Top;
                t.Text = Path.GetFileName(p);
                t.CheckedChanged += instanceSelected;
                radioButtons.Add(t);
                instances.Controls.Add(t);
            }

            doneBttn.Click += DoneBttn_Click;
        }

        private void DoneBttn_Click(object? sender, EventArgs e)
        {
            bool selected = false;
            foreach (RadioButton rb in radioButtons)
            {
                if (rb.Checked)
                {
                    selected = true;
                    break;
                }
            }
            if (!selected)
            {
                Messenger.MessageBox("Select an instance");
                return;
            }
            Install();
        }

        private void instanceSelected(object? sender, EventArgs e)
        {
            instance = (sender as RadioButton).Text;
        }

        public void Install()
        {
            string[] meta = File.ReadAllText(Form1.GetMetaFile(instance)).Split("\n");
            //MessageBox.Show(PathUtils.ApplicationDirectory);
            //MessageBox.Show(Directory.GetParent(meta[0].Split("=")[1]).FullName);
            //MessageBox.Show(Path.Combine(Directory.GetParent(Path.Combine(PathUtils.ApplicationDirectory, meta[0].Split("=")[1])).FullName, "mods"));
            ZipFile.ExtractToDirectory(path, Path.Combine(Directory.GetParent(Path.Combine(PathUtils.ApplicationDirectory, meta[0].Split("=")[1])).FullName, "mods"));
            Messenger.MessageBox("Done!");
            Close();
        }
    }
}
