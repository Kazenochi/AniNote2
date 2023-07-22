using AniNote2.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniNote2.MVM.ViewModel
{
    public class ListModel
    {
        public ObservableCollection<AnimeItem> List { get; set; } = new();

        public ListModel()
        {
            List.Add(new AnimeItem());
            List.Add(new AnimeItem());
            List.Add(new AnimeItem());
        }
    }
}
