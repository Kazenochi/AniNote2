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
    public sealed partial class MainWindow : Window
    {
        public AnimeListView animeListView { get; set; } = new();
        public AnimeListModel animeListModel { get; set; }
        public SelectedInfoView selectedInfoView { get; set; } = new();
        public SelectedInfoModel selectedInfoModel { get; set; }
        

        public MainWindow()
        {
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);
            this.InitializeComponent();
            

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

        private void SaveList()
        {
            SaveHelper.SaveFile(animeListModel.List);
        }

        private void ListAdd()
        {
            animeListModel.List.Add(new AnimeItem());
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

    }
}
