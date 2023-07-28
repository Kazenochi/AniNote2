using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Diagnostics;
using System.IO;

namespace AniNote2.Base
{
    /// <summary>
    /// Helper Class for more streamline image loading
    /// </summary>
    public static class ImageHelper
    {
        private static readonly string BaseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string GetImageUri(string relativePath)
        {
            return BaseDir + relativePath;
        }

        public static BitmapImage Load(String Path)
        {
            BitmapImage bitmapImage = new();
            try
            {
                bitmapImage.UriSource = new Uri(Path);
            }
            catch(ArgumentNullException ex)
            {
                Debug.WriteLine($"Image could not be loaded:{ex.Message}");
            }
            
            return bitmapImage;          
        }

    }
}
