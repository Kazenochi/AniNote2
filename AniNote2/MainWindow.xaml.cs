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
    public sealed partial class MainWindow : Window
    {
        public MainPage mainPage { get; set; } = new MainPage();
        private MainModel model;
        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
            this.MainGrid.DataContext = this;
            model = new MainModel(this);
            mainPage.DataContext = model;
        }

        private void ListDelete()
        {
            
        }


        /*
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
        }*/
    }
}
