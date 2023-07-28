using AniNote.MVVM.Models;
using AniNote2.Base;

namespace AniNote.MVVM.ViewModels
{
    /// <summary>
    /// Old class for import
    /// </summary>
    public class ListItemVM : ObserverNotifyChange
    {
        public ListItemModel LIM { get; set; }

        public ListItemVM()
        {
            LIM = new ListItemModel();
            assignListener(); 
        }

        public void assignListener()
        {
            LIM.PropertyChanged += LIM_PropertyChanged;
        }

        private void LIM_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (LIM == null) return;

            if(e.PropertyName == nameof(LIM.CurrentEpisode)) 
            {
                if (LIM.CurrentEpisode >= AiringEpisode)
                    NewEpisode = false;
                else
                    NewEpisode = true;
            }
        }

        public int AiringEpisode = 0;

        public bool NewEpisode { get { return _newEpisode; } set { _newEpisode = value; RaisePropertyChanged(nameof(NewEpisode)); } }
        private bool _newEpisode;

    }
}
