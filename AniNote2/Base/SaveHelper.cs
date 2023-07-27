﻿using AniNote.MVVM.Models;
using AniNote.MVVM.ViewModels;
using AniNote2.MVM.ViewModel;
using AniNote2.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
                        AnimeItem animeItem = new();
                        animeItem.Title = item.LIM.Name;
                        animeItem.Url1 = item.LIM.URL;
                        animeItem.CurrentEpisode = item.LIM.CurrentEpisode;
                        animeItem.Episodes = item.LIM.EpisodeCount;
                        animeItem.Finished = item.LIM.Finished;
                        animeItem.Image = ImageHelper.load(item.LIM.Cover);
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
