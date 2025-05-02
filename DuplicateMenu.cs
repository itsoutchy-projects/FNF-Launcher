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

        public DuplicateMenu()
        {
            InitializeComponent();

            doneBttn.Click += DoneBttn_Click;
        }

        private void DoneBttn_Click(object? sender, EventArgs e)
        {
            name = nameField.Text;
            if (name == string.Empty)
            {
                MessageBox.Show("Instance name cannot be empty");
                return;
            } else if (Directory.Exists($"{Directory.GetCurrentDirectory()}/Instances/{name}"))
            {
                MessageBox.Show("An instance with this name already exists");
                return;
            }
            Close();
        }
    }
}
