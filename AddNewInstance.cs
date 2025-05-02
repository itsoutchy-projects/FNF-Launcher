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

        public AddNewInstance()
        {
            InitializeComponent();

            doneButton.Click += DoneButton_Click;
        }

        private void DoneButton_Click(object? sender, EventArgs e)
        {
            if (instanceName.Text.Length == 0)
            {
                MessageBox.Show("You need to enter a name");
                return;
            }
            name = instanceName.Text;
            if (radioButton1.Checked)
            {
                type = InstanceType.Psych;
            } else if (radioButton2.Checked)
            {
                type = InstanceType.Codename;
            } else if (radioButton3.Checked)
            {
                type = InstanceType.Kade;
            }
            created = true;
            Close();
        }
    }
}
