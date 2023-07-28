using AniNote2.MVM.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AniNote2.Base
{
    public static class SearchHelper
    {
        public static List<AnimeItem> GetSearchResult(ObservableCollection<AnimeItem> CurrentList, string searchText)
        {
            List<AnimeItem> searchResult = CurrentList.Where(AnimeItem => AnimeItem.Title.ToLower().Contains(searchText.ToLower())).ToList();
            return searchResult;
        }
    }
}
