
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniNote2.Base
{
    /// <summary>
    /// Helper Class for more streamline image loading
    /// </summary>
    public static class ImageHelper
    {
        public static string BaseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string GetImageUri(string relativePath)
        {
            return BaseDir + relativePath;
        }

        public static BitmapImage load(String Path)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(Path);
            return bitmapImage;          
        }
    }
}
