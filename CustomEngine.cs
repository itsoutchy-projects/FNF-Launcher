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
        public int platformNum;
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
                    name = prop[1];
                }
                if (prop[0] == "platform num")
                {
                    platformNum = int.Parse(prop[1]);
                }
                if (prop[0] == "executable")
                {
                    executable = prop[1];
                }
            }
        }
    }
}
