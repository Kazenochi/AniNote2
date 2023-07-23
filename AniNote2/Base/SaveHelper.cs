using AniNote2.MVM.ViewModel;
using AniNote2.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AniNote2.Base
{
    /// <summary>
    /// Helper to streamline saving and loading of files
    /// </summary>
    public static class SaveHelper
    {
        private static string SaveDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static void SaveFile(ObservableCollection<AnimeItem> animeItems)
        {
            if (!Directory.Exists(SaveDir + "\\Saves"))
                Directory.CreateDirectory(SaveDir + "\\Saves");

            string jsonString = JsonSerializer.Serialize(animeItems, new JsonSerializerOptions { WriteIndented = true});
            string filePath = SaveDir + "\\Saves\\Cards.json";
            File.WriteAllText(filePath, jsonString);
        }

        public static ObservableCollection<AnimeItem> LoadFile() 
        {
            if (!Directory.Exists(SaveDir + "\\Saves"))
                Directory.CreateDirectory(SaveDir + "\\Saves");

            string filePath = SaveDir + "\\Saves\\Cards.json";
            try
            {
                string jsonString = File.ReadAllText(filePath);

                ObservableCollection<AnimeItem> animeItems = JsonSerializer.Deserialize<ObservableCollection<AnimeItem>>(jsonString);

                if (animeItems != null)
                    return animeItems;

                return animeItems = new();
            }
            catch (Exception ex)
            {
                return null;
            }
            
            

        }
    }
}
