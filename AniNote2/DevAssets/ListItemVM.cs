using AniNote.MVVM.Models;
using AniNote2.Base;
using System.Windows.Input;

namespace AniNote.MVVM.ViewModels
{
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


        /// <summary>
        /// Toggles the Visibility State of the <see cref="ListItemModel"/>
        /// </summary>
        private void StateToggle()
        {
            LIM.Open = !LIM.Open;
        }

        /// <summary>
        /// Handels the UserInput for Counting the Current Episode up or down
        /// </summary>
        /// <param name="updown"></param>
        private void ChangeEpisodeCount(int updown)
        {
            if (updown == 1)
            {
                if(LIM.CurrentEpisode < LIM.EpisodeCount)
                    LIM.CurrentEpisode++;
            }
            else
            {
                if(LIM.CurrentEpisode > 0)
                    LIM.CurrentEpisode--;
            }     
        }

        public void useDummy()
        {
            ListItemModel dummy = new ListItemModel();
            dummy.Name = "Test Anime 子にちわ。私はアンドレアスです。Nochmal deutlich längerter super cooler langer name von heilege";
            dummy.Cover = @"D:\VS\Projekte\AniNote\AniNote\Assets\きつね - 狐.png";
            dummy.URL = "https://www.google.de/";
            dummy.CurrentEpisode = 6;
            dummy.EpisodeCount = 24;
            dummy.Finished = false;
            LIM = dummy;
        }
    }
}
