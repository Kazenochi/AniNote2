using AniNote2.Base;
using System;

namespace AniNote.MVVM.Models
{
    /// <summary>
    /// Old class for Import
    /// </summary>
    public class ListItemModel : ObserverNotifyChange
    {
        public String Name { get { return _name; } set { _name = value; RaisePropertyChanged(nameof(Name)); } }
        private String _name;

        public String URL { get { return _url; } set { _url = value; RaisePropertyChanged(nameof(URL)); } }
        private String _url;

        public String Cover { get { return _cover; } set { _cover = value; RaisePropertyChanged(nameof(Cover)); } }
        private String _cover;

        public int EpisodeCount { get { return _episodeCount; } set { _episodeCount = value; RaisePropertyChanged(nameof(EpisodeCount)); } }
        private int _episodeCount;

        public int CurrentEpisode { get { return _currentEpisode; } set { _currentEpisode = value; RaisePropertyChanged(nameof(CurrentEpisode)); } }
        private int _currentEpisode;

        public bool Finished { get { return _finished; } 
            set 
            { 
                _finished = value;
                if (value) FinButtonText = "Fin";
                else FinButtonText = "Airing";
                RaisePropertyChanged(nameof(Finished)); 
            } 
        }
        private bool _finished = false;

        public bool Open { get { return _open; } set { _open = value; RaisePropertyChanged(nameof(Open)); } }
        private bool _open = false;
        
        public String FinButtonText { get { return _finButtonText; } set { _finButtonText = value; RaisePropertyChanged(nameof(FinButtonText)); } }
        private String _finButtonText = "Airing";

        public ListItemModel()
        {

        }
    }
}
