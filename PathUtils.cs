using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNF_Launcher
{
    public class PathUtils
    {
        /// <summary>
        /// Appends <paramref name="path"/> to the current working directory
        /// </summary>
        /// <param name="path"></param>
        /// <returns>An absolute version of <paramref name="path"/></returns>
        public static string Absolute(string path)
        {
            return $"{Directory.GetCurrentDirectory()}/{path}";
        }
    }
}
