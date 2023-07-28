using AniNote.MVVM.ViewModels;
using AniNote2.MVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace AniNote2.Base
{
    /// <summary>
    /// Helper to streamline saving and loading of files
    /// </summary>
    public static class SaveHelper
    {
        private static readonly string SaveDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static void SaveFile(ObservableCollection<AnimeItem> animeItems)
        {
            try
            {
                if (!Directory.Exists(SaveDir + "\\Saves"))
                    Directory.CreateDirectory(SaveDir + "\\Saves");
            }catch(Exception ex)
            {
                Debug.WriteLine($"Save Error Directory: {ex.Message}");
            }
            
            string jsonString = JsonSerializer.Serialize(animeItems, new JsonSerializerOptions { WriteIndented = true});
            string filePath = SaveDir + "\\Saves\\Cards.json";
            try
            {
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Save Error: {ex.Message}");
            }
            
        }

        public static ObservableCollection<AnimeItem> LoadFile() 
        {
            try
            {
                if (!Directory.Exists(SaveDir + "\\Saves"))
                    Directory.CreateDirectory(SaveDir + "\\Saves");
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Load Error Directory: {ex.Message}");
                return null;
            }

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
                Debug.WriteLine($"Load Error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Hidden function for old save files
        /// </summary>
        /// <param name="oldSaveFilePath"></param>
        /// <returns></returns>
        public static ObservableCollection<AnimeItem> LoadOldFile(string oldSaveFilePath) 
        {
            ObservableCollection<AnimeItem> newAnimeItems = new();

            try
            {
                string jsonString = File.ReadAllText(oldSaveFilePath);

                List<ListItemVM> oldAnimeItems = JsonSerializer.Deserialize<List<ListItemVM>>(jsonString);
                if (oldAnimeItems != null)
                {
                    foreach (ListItemVM item in oldAnimeItems)
                    {
                        AnimeItem animeItem = new()
                        {
                            Title = item.LIM.Name,
                            Url1 = item.LIM.URL,
                            CurrentEpisode = item.LIM.CurrentEpisode,
                            Episodes = item.LIM.EpisodeCount,
                            Finished = item.LIM.Finished,
                            Image = ImageHelper.Load(item.LIM.Cover)
                        };
                        newAnimeItems.Add(animeItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Load Error: {ex.Message}");
                return null;
            }
            return newAnimeItems;
        }
    }
}
