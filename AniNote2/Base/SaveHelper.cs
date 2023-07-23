using AniNote2.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniNote2.Base
{
    /// <summary>
    /// Helper to streamline saving and loading of files
    /// </summary>
    public static class SaveHelper
    {
        private static string SaveDir = Resource1.SaveDir;

        public static void SaveFile()
        {
            if (!Directory.Exists(SaveDir))
                Directory.CreateDirectory(SaveDir);


        }
    }
}
