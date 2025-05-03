using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNF_Launcher
{
    public partial class About : Form
    {
        private DarkModeCS dm;

        public About()
        {
            InitializeComponent();

            DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.SystemDefault;
            string[] settings = File.ReadAllText(PathUtils.Absolute("settings.txt")).Split("\n");
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

            reportbugs.Click += Reportbugs_Click;
            sourcecode.Click += Sourcecode_Click;
            doneBttn.Click += DoneBttn_Click;
        }

        private void DoneBttn_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void Sourcecode_Click(object? sender, EventArgs e)
        {
            OpenUrl("https://github.com/itsoutchy-projects/FNF-Launcher");
        }

        private void Reportbugs_Click(object? sender, EventArgs e)
        {
            OpenUrl("https://github.com/itsoutchy-projects/FNF-Launcher/issues");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
