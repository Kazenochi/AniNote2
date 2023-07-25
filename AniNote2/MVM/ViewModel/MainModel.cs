using AniNote2.Base;
using AniNote2.MVM.View;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AniNote2.MVM.ViewModel
{
    public class MainModel : ObserverNotifyChange
    {
        private MainWindow _mainWindow;
        public AnimeListView animeListView { get; set; } = new();
        public AnimeListModel animeListModel { get; set; }
        public SelectedInfoView selectedInfoView { get; set; } = new();
        public SelectedInfoModel selectedInfoModel { get; set; }
        public string searchText { get; set; }

        private bool _customViewActive = false;
        public bool CustomViewActive { get { return _customViewActive; } set { _customViewActive = value; RaisePropertyChanged(nameof(CustomViewActive)); } }

        private UserControl _customItemView;
        public UserControl CustomItemView { get { return _customItemView; } set { _customItemView = value; RaisePropertyChanged(nameof(CustomItemView)); } }

        public MainModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            selectedInfoModel = new SelectedInfoModel(_mainWindow);
            animeListModel = new AnimeListModel(selectedInfoModel);
            StartupLoad();
            animeListView.DataContext = animeListModel;
            selectedInfoView.DataContext = selectedInfoModel;
        }

        public ICommand AddCommand { get { return new AN_Command.DelegateCommand(o => ListAdd()); } }  
        public ICommand SaveCommand { get { return new AN_Command.DelegateCommand(o => SaveNewCard()); } }
        public ICommand BackCommand { get { return new AN_Command.DelegateCommand(o => Back()); } }

        private void StartupLoad()
        {
            var tmpFile = SaveHelper.LoadFile();
            if (tmpFile != null)
            {
                animeListModel.List = tmpFile;
                //selectedInfoModel.SelectedItem = animeListModel.List.ElementAt(0);
            }
            selectedInfoModel.SelectedItem = animeListModel.List.ElementAt(0);
        }

        private void SaveNewCard()
        {
            animeListModel.List.Add((AnimeItem)((AddItemView)CustomItemView).DataContext);
            Back();
        }

        public void Back()
        {
            if (CustomViewActive)
            {
                CustomViewActive = false;
                CustomItemView = null;
            }
        }

        private void ListAdd()
        {
            CustomViewActive = true;
            AnimeItem tmpAnimeItem = new AnimeItem();
            AddItemView tmpItemView = new AddItemView(tmpAnimeItem, _mainWindow);
            CustomItemView = tmpItemView;
        }
    }
}
