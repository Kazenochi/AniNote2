using AniNote2.Base;
using System.Collections.ObjectModel;

namespace AniNote2.MVM.ViewModel
{
    /// <summary>
    /// ContextData for <see cref="MVM.View.AnimeListView"/>
    /// </summary>
    public class AnimeListModel : ObserverNotifyChange
    {
        private ObservableCollection<AnimeItem> _list;
        public ObservableCollection<AnimeItem> List { get { return _list; } set { _list = value; RaisePropertyChanged(nameof(List)); } }

        //Used for search function as "clipboard"
        public ObservableCollection<AnimeItem> fullCardList = new();

        private bool _smallViewActive = false;
        public bool SmallViewActive { get { return _smallViewActive; } set { _smallViewActive = value; RaisePropertyChanged(nameof(SmallViewActive)); } }

        private SelectedInfoModel _selectedInfoModel;

        public AnimeListModel(SelectedInfoModel selectedInfoModel)
        {
            _list = new ObservableCollection<AnimeItem>();
            _selectedInfoModel = selectedInfoModel;
        }

        public void ChangeSelection(AnimeItem item)
        {
            _selectedInfoModel.SelectedItem = item;
        }

    }
}
