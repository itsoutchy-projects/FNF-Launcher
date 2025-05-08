using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNF_Launcher
{
    public static class PathUtils
    {
        public static string ApplicationDirectory
        {
            get
            {
                // get it in a good way
                return Directory.GetParent(Environment.GetCommandLineArgs()[0]).FullName;
            }
        }

        /// <summary>
        /// Appends <paramref name="path"/> to the current working directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns>An absolute version of <paramref name="path"/></returns>
        public static string Absolute(string path)
        {
            return $"{ApplicationDirectory}/{path}";
        }
    }
}
