using System.Net;
using Octokit;
using System.Diagnostics;
using System.Xml.Linq;
using FNF_Launcher.Properties;
using IWshRuntimeLibrary;
using File = System.IO.File;
using DarkModeForms;

namespace FNF_Launcher
{
    public partial class Form1 : Form
    {
        // FNF Launcher created by itsoutchy
        //
        // Engines were created by their respective owners:
        // Psych Engine    - ShadowMario
        // Kade Engine     - KadeDev
        // Codename Engine - CodenameCrew
        //
        // Please do not copy my code
        // Instead create a fork of my code with your fixes
        // And please keep this here, along with any new credits you need to add
        // (eg: you (for making the fork), and any engines you add)

        // Scroll down since you'll need to make some changes below

        public string GetMetaFile(string name)
        {
            return $"{Directory.GetCurrentDirectory()}/Instances/{name}/meta";
        }

        private void CreateShortcut(string name, string path)
        {
            object shDesktop = "Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @$"\{name}.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = $"Shortcut for the instance {name}";
            shortcut.TargetPath = path;
            shortcut.WorkingDirectory = Directory.GetParent(path).FullName;
            shortcut.Save();
        }

        public DarkModeCS? dm = null;

        public Form1()
        {
            InitializeComponent();
            try
            {
                if (!File.Exists(PathUtils.Absolute("settings.txt")))
                {
                    File.WriteAllText(PathUtils.Absolute("settings.txt"), "theme=system");
                }
                DarkModeCS.DisplayMode mode = DarkModeCS.DisplayMode.SystemDefault;
                string[] settings = File.ReadAllText(PathUtils.Absolute("settings.txt")).Split("\n");
                if (settings[0].Split("=")[1] == "dark")
                {
                    mode = DarkModeCS.DisplayMode.DarkMode;
                } else if (settings[0].Split("=")[1] == "light")
                {
                    mode = DarkModeCS.DisplayMode.ClearMode;
                }
                dm = new DarkModeCS(this)
                {
                    //[Optional] Choose your preferred color mode here:
                    ColorMode = mode
                };

                instanceNameLabel.Text = "...";
                if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/Instances/"))
                {
                    Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Instances/");
                }
                refreshInstances();
                instances.DoubleClick += Instances_DoubleClick;
                contextMenuStrip1.ItemClicked += ContextMenuStrip1_ItemClicked;
                rightPanelRun.Click += RightPanelRun_Click;
                rightPanelShowFolder.Click += RightPanelShowFolder_Click;
                instances.SelectedIndexChanged += Instances_SelectedIndexChanged;
                makeshortcut.Click += Makeshortcut_Click;
                settingsBttn.Click += SettingsBttn_Click;
                aboutBttn.Click += AboutBttn_Click;
                instances.KeyDown += Instances_KeyDown;
            } catch (Exception ex)
            {
                Messenger.MessageBox(ex.Message);
            }
            //AddInstance("test", InstanceType.Psych);
        }

        private void Instances_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && instances.SelectedItems.Count > 0)
            {
                deleteSelected();
            }
        }

        public void deleteSelected()
        {
            if (instances.SelectedItems.Count > 0)
            {
                string s = instances.SelectedItems[0].Text;
                if (Messenger.MessageBox($"Are you sure you want to delete {s}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    instances.SelectedItems[0].Selected = false;
                    Directory.Delete($"{Directory.GetCurrentDirectory()}/Instances/{s}", true);
                    refreshInstances();
                }
            }
        }

        private void AboutBttn_Click(object? sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void SettingsBttn_Click(object? sender, EventArgs e)
        {
            Settings settings = new Settings(this);
            settings.Show();
        }

        public void changeTheme(DarkModeCS.DisplayMode theme)
        {
            dm = new DarkModeCS(this)
            {
                //[Optional] Choose your preferred color mode here:
                ColorMode = theme
            };
        }

        private void Makeshortcut_Click(object? sender, EventArgs e)
        {
            string[] meta = File.ReadAllText(GetMetaFile(instances.SelectedItems[0].Text)).Split("\n");
            CreateShortcut(instances.SelectedItems[0].Text, $"{Directory.GetCurrentDirectory()}/{meta[0].Split("=")[1]}");
            Messenger.MessageBox("Done!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RightPanelShowFolder_Click(object? sender, EventArgs e)
        {
            showInExplorer();
        }

        private void RightPanelRun_Click(object? sender, EventArgs e)
        {
            run();
        }

        private void Instances_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (instances.SelectedItems.Count > 0)
            {
                instanceNameLabel.Text = instances.SelectedItems[0].Text;
                rightPanelRun.Enabled = true;
                rightPanelShowFolder.Enabled = true;
                makeshortcut.Enabled = true;
            } else
            {
                instanceNameLabel.Text = "...";
                rightPanelRun.Enabled = false;
                rightPanelShowFolder.Enabled = false;
                makeshortcut.Enabled = false;
            }
        }

        private void ContextMenuStrip1_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (instances.SelectedItems.Count != 0)
            {
                switch (e.ClickedItem.Text)
                {
                    case "Open Instance Folder":
                        showInExplorer();
                        return;
                    case "Run":
                        run();
                        return;
                    case "Duplicate":
                        DuplicateMenu menu = new DuplicateMenu();
                        menu.ShowDialog();
                        if (menu.name == string.Empty)
                        {
                            return;
                        }
                        Folder.CopyDirectory($"{Directory.GetCurrentDirectory()}/Instances/{instances.SelectedItems[0].Text}", $"{Directory.GetCurrentDirectory()}/Instances/{menu.name}", true);
                        File.WriteAllText(GetMetaFile(menu.name), instanceNameLabel.Text);
                        if (Directory.Exists($"{Directory.GetCurrentDirectory()}/Instances/{menu.name}/PsychEngine"))
                        {
                            File.WriteAllText(GetMetaFile(menu.name), $"exepath=Instances/{menu.name}/{InstanceTypeToParent(InstanceType.Psych)}/{InstanceTypeToParent(InstanceType.Psych)}.exe");
                        }
                        else
                        {
                            InstanceType type = InstanceType.Kade;
                            if (File.Exists($"{Directory.GetCurrentDirectory()}/Instances/{menu.name}/CodenameEngine.exe"))
                            {
                                type = InstanceType.Codename;
                            } else if (File.Exists($"{Directory.GetCurrentDirectory()}/Instances/{menu.name}/Leather Engine.exe"))
                            {
                                type = InstanceType.LeatherEngine;
                            }
                            File.WriteAllText(GetMetaFile(menu.name), $"exepath=Instances/{menu.name}/{InstanceTypeToParent(type)}.exe");
                        }
                        refreshInstances();
                        return;
                    case "Delete":
                        deleteSelected();
                        return;
                }
            }
        }

        public void showInExplorer()
        {
            string[] meta = File.ReadAllText(GetMetaFile(instances.SelectedItems[0].Text)).Split("\n");
            if (meta[0].Split("=")[1].Contains("PsychEngine"))
            {
                Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", $"{Directory.GetCurrentDirectory()}\\instances\\{instances.SelectedItems[0].Text}\\PsychEngine\\");
            }
            else
            {
                Process.Start(Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe", $"{Directory.GetCurrentDirectory()}\\instances\\{instances.SelectedItems[0].Text}\\");
            }
        }

        private void Instances_DoubleClick(object? sender, EventArgs e)
        {
            run();
        }

        public void run()
        {
            if (instances.SelectedItems.Count > 0)
            {
                string[] meta = File.ReadAllText(GetMetaFile(instances.SelectedItems[0].Text)).Split("\n");
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo
                {
                    FileName = $"{Directory.GetCurrentDirectory()}/{meta[0].Split("=")[1]}"
                };
                p.StartInfo.WorkingDirectory = (new DirectoryInfo($"{Directory.GetCurrentDirectory()}/{meta[0].Split("=")[1]}").Parent.FullName);
                if (meta[0].Contains("Psych"))
                {
                    //p.StartInfo.WorkingDirectory = $"{Directory.GetCurrentDirectory()}/{(string)instances.Items[instances.SelectedIndex]}/PsychEngine/".Replace("\\", "/");
                }
                else
                {
                    //p.StartInfo.WorkingDirectory = $"{Directory.GetCurrentDirectory()}/{(string)instances.Items[instances.SelectedIndex]}/".Replace("\\", "/");
                }
                p.Start();
            }
        }

        public void refreshInstances() // STUPIDSTUPIDSTUPIDSTUPID FFS OMFGGGGGGGGGGGGGGGG
        {
            //int s = hasBeenused ? instances.Items.IndexOf(instances.SelectedItems[0]) : 0;
            
            if (instances.Items.Count > 0)
            {
                instances.Items.Clear(); // prepare it for refreshing them
            }
            foreach (string p in Directory.GetDirectories($"{Directory.GetCurrentDirectory()}/Instances"))
            {   
                instances.Items.Add(new ListViewItem
                {
                    Text = Path.GetFileName(p.Replace("/", @"\")),
                    //ImageIndex = 0
                });
            }
        }

        public async void AddInstance(string name, InstanceType type)
        {
            try
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/Instances");

                WebClient webclient = new WebClient();
                webclient.Headers.Add("user-agent", "Anything");
                string ext = "zip";
                Downloading downloading = new Downloading();
                downloading.Show();
                if (type == InstanceType.Psych)
                {
                    // Change this to associate it with you
                    // Replace "itsoutchy-projects" with your Github name
                    GitHubClient client = new GitHubClient(new ProductHeaderValue("itsoutchy-projects"));
                    Tuple<string, string> rn = InstanceTypeToPair(type);
                    Release rel = await client.Repository.Release.GetLatest(rn.Item1, rn.Item2);

                    webclient.DownloadFile(rel.Assets[3].BrowserDownloadUrl, $"{Directory.GetCurrentDirectory()}/Instances/{name}.zip");
                } else if (type == InstanceType.Kade)
                {
                    // idrk if this actually gets the latest version - im trying to figure this out
                    webclient.DownloadFile("https://gamebanana.com/dl/619823", $"{Directory.GetCurrentDirectory()}/Instances/{name}.7z");
                    ext = "7z";
                } else if (type == InstanceType.Codename)
                {
                    // this one is automatically updated so its all good
                    webclient.DownloadFile("https://nightly.link/CodenameCrew/CodenameEngine/workflows/windows/main/Codename%20Engine.zip", $"{Directory.GetCurrentDirectory()}/Instances/{name}.zip");
                } else if (type == InstanceType.LeatherEngine)
                {
                    GitHubClient client = new GitHubClient(new ProductHeaderValue("itsoutchy-projects"));
                    Tuple<string, string> rn = InstanceTypeToPair(type);
                    Release rel = await client.Repository.Release.GetLatest(rn.Item1, rn.Item2);

                    int no = Environment.Is64BitOperatingSystem ? 3 : 4;

                    webclient.DownloadFile(rel.Assets[no].BrowserDownloadUrl, $"{Directory.GetCurrentDirectory()}/Instances/{name}.zip");
                }
                    downloading.stepChange();
                ExtractFile($"{Directory.GetCurrentDirectory()}/Instances/{name}.{ext}", $"{Directory.GetCurrentDirectory()}/Instances/{name}");

                File.Delete($"{Directory.GetCurrentDirectory()}/Instances/{name}.{ext}");

                if (type == InstanceType.Psych)
                {
                    File.WriteAllText($"{Directory.GetCurrentDirectory()}/Instances/{name}/meta", $"exepath=Instances/{name}/{InstanceTypeToParent(type)}/{InstanceTypeToParent(type)}.exe");
                } else
                {
                    File.WriteAllText($"{Directory.GetCurrentDirectory()}/Instances/{name}/meta", $"exepath=Instances/{name}/{InstanceTypeToParent(type)}.exe");
                }
                downloading.Close();

                refreshInstances();
            }
            catch (Exception ex)
            {
                Messenger.MessageBox($"{ex.Message} \n{ex.StackTrace}");
            }
        }

        public Tuple<string, string> InstanceTypeToPair(InstanceType type)
        {
            Tuple<string, string>[] engines =
            {
                new Tuple<string, string>("ShadowMario", "FNF-PsychEngine"),
                new Tuple<string, string>("KadeDev", "Kade-Engine"),
                new Tuple<string, string>("CodenameCrew", "CodenameEngine"),
                new Tuple<string, string>("Leather128", "LeatherEngine")
            };
            return engines[(int)type];
        }

        public void ExtractFile(string sourceArchive, string destination)
        {
            string zPath = "7za.exe"; //add to proj and set CopyToOuputDir
            try
            {
                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", sourceArchive, destination);
                Process x = Process.Start(pro);
                x.WaitForExit();
            }
            catch (Exception Ex)
            {
                //handle error
            }
        }

        public string InstanceTypeToParent(InstanceType type)
        {
            string[] engines =
            {
                "PsychEngine",
                "Kade Engine",
                "CodenameEngine",
                "Leather Engine"
            };
            return engines[(int)type];
        }

        private void newInstance_Click(object sender, EventArgs e)
        {
            AddNewInstance addNewInstance = new AddNewInstance();
            addNewInstance.ShowDialog();
            if (!addNewInstance.created)
            {
                return;
            }
            AddInstance(addNewInstance.name, addNewInstance.type);
        }
    }

    // FNF Engines, so it knows where to get the files from
    public enum InstanceType
    {
        Psych,
        Kade,
        Codename,
        LeatherEngine
    }
}
