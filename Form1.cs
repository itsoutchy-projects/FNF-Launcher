using System.Net;
using Octokit;
using System.Diagnostics;
using System.Xml.Linq;
using FNF_Launcher.Properties;
using IWshRuntimeLibrary;
using File = System.IO.File;
using DarkModeForms;
using System.Security.Permissions;

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
        // Leather Engine  - Leather128
        // JS Engine       - JordanSantiagoYT
        // FPS Plus        - ThatRozebudDude
        // Doido Engine    - DoidoTeam
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

        public void ProtocolINIT()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = $"{Directory.GetCurrentDirectory()}/FNFLauncherInit.exe",
                UseShellExecute = true
            });
        }

        public static bool instanceIcons = true;

        public Form1()
        {
            InitializeComponent();
            try
            {
                instances.View = View.LargeIcon;
                ImageList imageList = new ImageList();
                imageList.ColorDepth = ColorDepth.Depth32Bit;
                imageList.ImageSize = new Size(64, 64);
                //imageList.Images.Add(Icon);
                instances.LargeImageList = imageList;
                instances.SmallImageList = imageList;

                if (!File.Exists(PathUtils.Absolute("settings.txt")))
                {
                    //MessageBox.Show("Btw, if you want to be able to install mods via a url, run FNFLauncherInit.exe. Though this may not be supported");
                    // ^ I would add this but
                    // 1. Not likely to be widely supported on sites like Gamebanana
                    // 2. SUPER difficult to implement (cant request admin permission while still allowing app to be run)
                    // So uhh if you want you can fork this repo and try it
                    // gl
                    
                    File.WriteAllText(PathUtils.Absolute("settings.txt"), "theme=system\nicons=instance");
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
                if (settings[1].Split("=")[1] == "instance")
                {
                    instanceIcons = true;
                }
                else if (settings[1].Split("=")[1] == "constant")
                {
                    instanceIcons = false;
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
                installMod.Click += InstallMod_Click;
            } catch (Exception ex)
            {
                Messenger.MessageBox(ex.Message);
            }
            //AddInstance("test", InstanceType.Psych);
        }

        private void InstallMod_Click(object? sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archives|*.zip;*.7z";
            fileDialog.Multiselect = false;
            fileDialog.Title = "Choose a mod to install";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] meta = File.ReadAllText(GetMetaFile(instances.SelectedItems[0].Text)).Split("\n");
                
                ExtractFile(fileDialog.FileName, Path.Combine(Directory.GetParent(meta[0].Split("=")[1]).FullName, $"mods/"));
                
                //if (Directory.Exists(Path.Combine(Directory.GetParent(meta[0].Split("=")[1]).FullName, $"mods/{Path.GetFileNameWithoutExtension(fileDialog.FileName)}/{Path.GetFileNameWithoutExtension(fileDialog.FileName)}")))
                //{
                //    Directory.Move(Path.Combine(Directory.GetParent(meta[0].Split("=")[1]).FullName, $"mods/{Path.GetFileNameWithoutExtension(fileDialog.FileName)}/{Path.GetFileNameWithoutExtension(fileDialog.FileName)}"), Path.Combine(Directory.GetParent(meta[0].Split("=")[1]).FullName, $"mods/"));
                //}
                //ExtractFile(fileDialog.FileName, $"{Directory.GetParent($"{Directory.GetCurrentDirectory()}\\{meta[0].Split("=")[1]}").FullName}/mods/{Path.GetFileNameWithoutExtension(fileDialog.FileName)}");
            }
        }

        private void Instances_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && instances.SelectedItems.Count > 0)
            {
                deleteSelected();
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.R)
            {
                refreshInstances();
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
            settings.FormClosed += Settings_FormClosed;
        }

        private void Settings_FormClosed(object? sender, FormClosedEventArgs e)
        {
            refreshInstances();
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
                installMod.Enabled = true;
            } else
            {
                instanceNameLabel.Text = "...";
                rightPanelRun.Enabled = false;
                rightPanelShowFolder.Enabled = false;
                makeshortcut.Enabled = false;
                installMod.Enabled = false;
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
                instances.LargeImageList.Images.Clear();
            }
            int i = 0;
            foreach (string p in Directory.GetDirectories($"{Directory.GetCurrentDirectory()}/Instances"))
            {
                if (instanceIcons)
                {
                    if (Directory.GetDirectories(p).Length != 1)
                    {
                        // not psych or fps plus
                        instances.LargeImageList.Images.Add(new Icon($"{p}/icon.ico"));
                    }
                    else
                    {

                        instances.LargeImageList.Images.Add(new Icon($"{Directory.GetDirectories(p)[0]}/icon.ico"));
                    }
                } else
                {
                    instances.LargeImageList.Images.Add(Icon);
                }

                instances.Items.Add(new ListViewItem
                {
                    Text = Path.GetFileName(p.Replace("/", @"\")),
                    ImageIndex = i
                });
                i++;
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
                else if (type == InstanceType.JSEngine)
                {
                    GitHubClient client = new GitHubClient(new ProductHeaderValue("itsoutchy-projects"));
                    Tuple<string, string> rn = InstanceTypeToPair(type);
                    Release rel = await client.Repository.Release.GetLatest(rn.Item1, rn.Item2);

                    int no = 4;

                    webclient.DownloadFile(rel.Assets[no].BrowserDownloadUrl, $"{Directory.GetCurrentDirectory()}/Instances/{name}.zip");
                }
                else if (type == InstanceType.FPSPlus)
                {
                    GitHubClient client = new GitHubClient(new ProductHeaderValue("itsoutchy-projects"));
                    Tuple<string, string> rn = InstanceTypeToPair(type);
                    Release rel = await client.Repository.Release.GetLatest(rn.Item1, rn.Item2);

                    int no = 0;

                    webclient.DownloadFile(rel.Assets[no].BrowserDownloadUrl, $"{Directory.GetCurrentDirectory()}/Instances/{name}.zip");
                }
                else if (type == InstanceType.DoidoEngine)
                {
                    GitHubClient client = new GitHubClient(new ProductHeaderValue("itsoutchy-projects"));
                    Tuple<string, string> rn = InstanceTypeToPair(type);
                    Release rel = await client.Repository.Release.GetLatest(rn.Item1, rn.Item2);

                    int no = 4;

                    webclient.DownloadFile(rel.Assets[no].BrowserDownloadUrl, $"{Directory.GetCurrentDirectory()}/Instances/{name}.zip");
                }
                downloading.stepChange();
                ExtractFile($"{Directory.GetCurrentDirectory()}/Instances/{name}.{ext}", $"{Directory.GetCurrentDirectory()}/Instances/{name}");

                File.Delete($"{Directory.GetCurrentDirectory()}/Instances/{name}.{ext}");

                if (type == InstanceType.Psych)
                {
                    File.WriteAllText($"{Directory.GetCurrentDirectory()}/Instances/{name}/meta", $"exepath=Instances/{name}/{InstanceTypeToParent(type)}/{InstanceTypeToParent(type)}.exe");
                } else if (type == InstanceType.FPSPlus)
                {
                    File.WriteAllText($"{Directory.GetCurrentDirectory()}/Instances/{name}/meta", $"exepath=Instances/{name}/FPS Plus/{InstanceTypeToParent(type)}.exe");
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
                new Tuple<string, string>("Leather128", "LeatherEngine"),
                new Tuple<string, string>("JordanSantiagoYT", "FNF-JS-Engine"),
                new Tuple<string, string>("ThatRozebudDude", "FPS-Plus-Public"),
                new Tuple<string, string>("DoidoTeam", "FNF-Doido-Engine")
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
                "Leather Engine",
                "JSEngine",
                "FunkinFPSPlus",
                "DoidoEngine"
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
        LeatherEngine,
        JSEngine,
        FPSPlus,
        DoidoEngine
    }
}
