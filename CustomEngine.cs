using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FNF_Launcher
{
    public class CustomEngine
    {
        public string name;
        public string repo;
        public int? platformNum;
        public string executable; // this is basically whether its "PsychEngine/PsychEngine.exe" or "FunkinFPSPlus/FPS Plus.exe" etc.

        public CustomEngine(string path)
        {
            string engine = File.ReadAllText(path);
            foreach (string line in engine.Split("\n"))
            {
                string[] prop = line.Split("=");
                if (prop[0] == "name")
                {
                    name = prop[1];
                }
                if (prop[0] == "repo")
                {
                    repo = prop[1];
                }
                if (prop[0] == "platformNum")
                {
                    platformNum = int.Parse(prop[1]);
                }
                if (prop[0] == "executable")
                {
                    executable = prop[1];
                }
            }
            if (name == null)
            {
                name = Path.GetFileNameWithoutExtension(path);
            }
            if (repo == null)
            {
                throw new ArgumentNullException(nameof(repo), $"Instance '{name}' is missing property 'repo'");
            }
            if (platformNum == null)
            {
                throw new ArgumentNullException(nameof(platformNum), $"Instance '{platformNum}' is missing property 'platformNum'");
            }
            if (executable == null)
            {
                throw new ArgumentNullException(nameof(executable), $"Instance '{executable}' is missing property 'executable'");
            }
        }
    }
}
