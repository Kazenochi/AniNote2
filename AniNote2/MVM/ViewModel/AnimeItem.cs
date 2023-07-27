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

        private int _episodes = 12;
        public int Episodes { get { return _episodes; } set { _episodes = value; RaisePropertyChanged(nameof(Episodes)); } }

        private int _currentEpisode = 1;
        public int CurrentEpisode { get { return _currentEpisode; } set { _currentEpisode = value; CheckFinished(); RaisePropertyChanged(nameof(CurrentEpisode)); } }

        private string _url1;
        public string Url1 { get {return _url1; } set { _url1 = value; RaisePropertyChanged(nameof(Url1)); } }

        private string _url2;
        public string Url2 { get { return _url2; } set { _url2 = value; RaisePropertyChanged(nameof(Url2)); } }

        private string _onlineImage;
        public string OnlineImage { get { return _onlineImage; } set { _onlineImage = value; RaisePropertyChanged(nameof(OnlineImage)); } }

        private int _rating = 0;
        public int Rating { get { return _rating; } set { _rating = value; RaisePropertyChanged(nameof(Rating)); } }

        private DayOfWeek _airDay = DayOfWeek.Monday;
        public DayOfWeek AirDay { get { return _airDay; } set { _airDay = value; RaisePropertyChanged(nameof(AirDay)); } }

        private bool _finished = false;
        public bool Finished { get { return _finished; } set { _finished = value; RaisePropertyChanged(nameof(Finished)); } }

        public void SwitchImageToOnline(bool isOnlineImage, string imagePath = "")
        {
            if (_onlineImage == null) return;

            if (isOnlineImage && _onlineImage.Length > 0)
            {
                this.Image = ImageHelper.load(OnlineImage); 
            }
            else
            {
                this.Image = ImageHelper.load(imagePath);
            }
        }

        private void CheckFinished()
        {
            if(CurrentEpisode >= Episodes) Finished = true;
            else Finished = false;
        }
    }
}
