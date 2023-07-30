using AniNote.MVVM.ViewModels;
using AniNote2.MVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.Storage;

namespace AniNote2.Base
{
    /// <summary>
    /// Helper to streamline saving and loading of files
    /// </summary>
    public static class SaveHelper
    {
        private static readonly string SaveDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static async void SaveFile(ObservableCollection<AnimeItem> animeItems)
        {
            string fileName = "cards.json";
            string jsonString = JsonSerializer.Serialize(animeItems, new JsonSerializerOptions { WriteIndented = true });
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, jsonString);
        }

        public static async Task<ObservableCollection<AnimeItem>> LoadFile()
        {
            string fileName = "cards.json";
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                StorageFile storageFile = await localFolder.GetFileAsync(fileName);
                string jsonString = await FileIO.ReadTextAsync(storageFile);
                ObservableCollection<AnimeItem> loadedObject = JsonSerializer.Deserialize<ObservableCollection<AnimeItem>>(jsonString);
                return loadedObject;
            }
            catch (FileNotFoundException)
            {
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
