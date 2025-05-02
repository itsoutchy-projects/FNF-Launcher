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
        public Downloading()
        {
            InitializeComponent();
            Text = $"{steps[stepNo]}...";
            header.Text = $"{steps[stepNo]} {stepNo + 1} of {steps.Length}";
        }

        public void stepChange()
        {
            stepNo++;
            Text = $"{steps[stepNo]}...";
            header.Text = $"{steps[stepNo]} {stepNo + 1} of {steps.Length}";
        }
    }
}
