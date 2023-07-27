using AniNote2.Base;
using AniNote2.MVM.View;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("Marker: MainModel Init Start");
            _mainWindow = mainWindow;
            selectedInfoModel = new SelectedInfoModel(_mainWindow);
            animeListModel = new AnimeListModel(selectedInfoModel);
            StartupLoad();
            animeListView.DataContext = animeListModel;
            selectedInfoView.DataContext = selectedInfoModel;
            Debug.WriteLine("Marker: MainModel Init Finished");
        }

        public ICommand AddCommand { get { return new AN_Command.DelegateCommand(o => ListAdd()); } }  
        public ICommand SaveCommand { get { return new AN_Command.DelegateCommand(o => SaveNewCard()); } }
        public ICommand BackCommand { get { return new AN_Command.DelegateCommand(o => Back()); } }

        /// <summary>
        /// Restoring the data state at the start 
        /// </summary>
        private void StartupLoad()
        {
            var tmpFile = SaveHelper.LoadFile();
            if (tmpFile != null)
            {
                animeListModel.List = tmpFile;
            }
            if(animeListModel.List.Count > 0)
            {
                selectedInfoModel.SelectedItem = animeListModel.List.First();
            }  
        }

        /// <summary>
        /// Close methode for <see cref="AddItemView"/> to add a new card
        /// </summary>
        private void SaveNewCard()
        {
            animeListModel.List.Add((AnimeItem)((AddItemView)CustomItemView).DataContext);
            Back();
        }

        /// <summary>
        /// Manages the viewstate for the acrylic pane and <see cref="AddItemView"/>
        /// </summary>
        public void Back()
        {
            if (CustomViewActive)
            {
                CustomViewActive = false;
                CustomItemView = null;
            }
        }

        /// <summary>
        /// Prepares a new object for <see cref="AddItemView"/>
        /// </summary>
        private void ListAdd()
        {
            CustomViewActive = true;
            AnimeItem tmpAnimeItem = new AnimeItem();
            AddItemView tmpItemView = new AddItemView(tmpAnimeItem, _mainWindow);
            CustomItemView = tmpItemView;
        }
    }
}
