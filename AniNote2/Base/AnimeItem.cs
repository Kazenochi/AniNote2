using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace AniNote2.Base
{
    public class AnimeItem : ObserverNotifyChange
    {
        private Image _image;
        public Image Image { get { return _image; } set { _image = value; RaisePropertyChanged(nameof(Image)); } }

        private string _title;
        public string Title { get { return _title; } set { _title = value; RaisePropertyChanged(nameof(Title)); } }

        public int Episodes { get; set; }
        public int CurrentEpisode { get; set; }
        public string Url { get; set; }


        public AnimeItem() { 
            this.Image = new Image();
            Image.Source = new BitmapImage(new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location + "/DevAssets/Bungo.jpg")));
            this.Title = "TestTitle";
            this.Episodes = 12;
            this.CurrentEpisode = 4;
            this.Url = "www.google.de";
        }


    }
}
