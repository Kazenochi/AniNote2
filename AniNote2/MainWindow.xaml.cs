using AniNote2.Base;
using AniNote2.MVM.View;
using AniNote2.MVM.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AniNote2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window, INotifyPropertyChanged
    {
        public AnimeListView animeListView { get; set; } = new();
        public AnimeListModel animeListModel { get; set; }
        public SelectedInfoView selectedInfoView { get; set; } = new();
        public SelectedInfoModel selectedInfoModel { get; set; }

        private bool _customViewActive = false;
        public bool CustomViewActive { get { return _customViewActive; } set { _customViewActive = value; RaisePropertyChanged(nameof(CustomViewActive)); } }

        private UserControl _customItemView;
        public UserControl CustomItemView { get { return _customItemView; } set { _customItemView = value; RaisePropertyChanged(nameof(CustomItemView)); } }

        private ObservableCollection<AnimeItem> tmpOriginalList = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            selectedInfoModel = new SelectedInfoModel(this);
            animeListModel = new AnimeListModel(selectedInfoModel);
            StartupLoad();
            RootPanel.DataContext = this;
            animeListView.DataContext = animeListModel;
            selectedInfoView.DataContext = selectedInfoModel;
        }

        public ICommand AddCommand { get { return new AN_Command.DelegateCommand(o => ListAdd()); } }
        public ICommand DeleteCommand { get { return new AN_Command.DelegateCommand(o => ListDelete()); } }
        public ICommand SaveCommand { get { return new AN_Command.DelegateCommand(o => SaveList()); } }
        public ICommand BackCommand { get { return new AN_Command.DelegateCommand(o => Back()); } }

        private void SaveList()
        {
            SaveHelper.SaveFile(animeListModel.List);
        }

        private void Back()
        {
            if(CustomViewActive)
            {
                CustomViewActive = false;
                CustomItemView = null;
            }
        }

        private void ListAdd()
        {
            CustomViewActive = true;
            AnimeItem tmpAnimeItem = new AnimeItem();
            AddItemView tmpItemView = new AddItemView(tmpAnimeItem);
            CustomItemView = tmpItemView;
            
            //animeListModel.List.Add(new AnimeItem());
        }
        private void ListDelete()
        {
            
        }

        private void StartupLoad()
        {
            var tmpFile = SaveHelper.LoadFile();
            if (tmpFile != null) 
            { 
                animeListModel.List = tmpFile; 
                selectedInfoModel.SelectedItem = animeListModel.List.ElementAt(0);
            }              
        }

        /// <summary>
        /// Not Working
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          string searchText = SearchTextBox.Text;
            if (searchText.Length > 2)
            {
                tmpOriginalList.Clear();
                foreach (var item in animeListModel.List) 
                {
                    tmpOriginalList.Add(item);
                }
                animeListModel.List.Clear();
                var result = SearchHelper.GetSearchResult(tmpOriginalList, searchText);

                foreach (var item in animeListModel.List) 
                { 
                    animeListModel.List.Add(item); 
                }
            }
            else if(tmpOriginalList.Count > 0)
            {
                animeListModel.List = tmpOriginalList;
            } 
        }
    }
}
