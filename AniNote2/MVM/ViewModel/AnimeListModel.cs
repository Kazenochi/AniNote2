using AniNote2.Base;
using AniNote2.Properties;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace AniNote2.MVM.ViewModel
{
    /// <summary>
    /// ContextData for <see cref="MVM.View.AnimeListView"/>
    /// </summary>
    public class AnimeListModel : ObserverNotifyChange
    {
        private ObservableCollection<AnimeItem> _list;
        public ObservableCollection<AnimeItem> List { get { return _list; } set { _list = value; RaisePropertyChanged(nameof(List)); } }

        public ObservableCollection<AnimeItem> fullCardList = new();

        private bool _smallViewActive = false;
        public bool SmallViewActive { get { return _smallViewActive; } set { _smallViewActive = value; RaisePropertyChanged(nameof(SmallViewActive)); } }

        private SelectedInfoModel _selectedInfoModel;

        public AnimeListModel(SelectedInfoModel selectedInfoModel)
        {
            _list = new ObservableCollection<AnimeItem>();
            _selectedInfoModel = selectedInfoModel;

            AnimeItem item1 = new AnimeItem();
            AnimeItem item2 = new AnimeItem();
            AnimeItem item3 = new AnimeItem();

            item1.Image = new BitmapImage(new Uri("ms-appx:///DevAssets/Bungo.jpg"));
            item1.Title = "Title 1";
            item1.Rating = 3;
            item1.AirDay = DayOfWeek.Monday;

            item2.Image = new BitmapImage(new Uri("ms-appx:///DevAssets/Healer.jpg"));
            item2.Title = "Title 2";
            item2.Rating = 1;
            item2.AirDay = DayOfWeek.Tuesday;

            item3.Image = new BitmapImage(new Uri("ms-appx:///DevAssets/Jujugsu.jpg"));
            item3.Title = "Title 3";
            item3.Rating = 5;
            item3.AirDay = DayOfWeek.Wednesday;

            List.Add(item1);
            List.Add(item2);
            List.Add(item3);
        }

        public void ChangeSelection(AnimeItem item)
        {
            _selectedInfoModel.SelectedItem = item;
        }

    }
}
