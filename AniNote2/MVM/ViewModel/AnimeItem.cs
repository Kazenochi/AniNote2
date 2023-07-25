using AniNote2.Base;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace AniNote2.MVM.ViewModel
{
    /// <summary>
    /// Mainobject that holds every information of an object
    /// </summary>
    public class AnimeItem : ObserverNotifyChange
    {
        private BitmapImage _image;
        public BitmapImage Image { get { return _image; } set { _image = value; RaisePropertyChanged(nameof(Image)); } }

        private string _title;
        public string Title { get { return _title; } set { _title = value; RaisePropertyChanged(nameof(Title)); } }

        private int _episodes;
        public int Episodes { get { return _episodes; } set { _episodes = value; RaisePropertyChanged(nameof(Episodes)); } }

        private int _currentEpisode;
        public int CurrentEpisode { get { return _currentEpisode; } set { _currentEpisode = value; RaisePropertyChanged(nameof(CurrentEpisode)); } }

        private string _url1;
        public string Url1 { get {return _url1; } set { _url1 = value; RaisePropertyChanged(nameof(Url1)); } }

        private string _url2;
        public string Url2 { get { return _url2; } set { _url2 = value; RaisePropertyChanged(nameof(Url2)); } }

        private string _url3;
        public string Url3 { get { return _url3; } set { _url3 = value; RaisePropertyChanged(nameof(Url3)); } }

        private int _rating;
        public int Rating { get { return _rating; } set { _rating = value; RaisePropertyChanged(nameof(Rating)); } }

        private DayOfWeek _airDay;
        public DayOfWeek AirDay { get { return _airDay; } set { _airDay = value; RaisePropertyChanged(nameof(AirDay)); } }

        public AnimeItem() { 
            this.AirDay = DayOfWeek.Monday;
        }
    }
}
