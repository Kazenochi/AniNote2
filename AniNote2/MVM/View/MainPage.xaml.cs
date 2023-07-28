using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using AniNote2.MVM.ViewModel;
using AniNote2.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Foundation.Metadata;
using System.Runtime.CompilerServices;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AniNote2.MVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool _searchActive = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new()
            {
                // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
                XamlRoot = this.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = "Quit? All changes will be lost!",
                PrimaryButtonText = "No",
                SecondaryButtonText = "Yes",
                //dialog.CloseButtonText = "Cancel";
                DefaultButton = ContentDialogButton.Primary
            };

            var result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Secondary)
            {
                ((MainModel)this.DataContext).Back();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text;

            if (this.DataContext is not MainModel tmpModel) { return; }

            var tmpFullList = (DataContext as MainModel).animeListModel.fullCardList;

            if (searchText.Length > 0 && !_searchActive)
            {
                _searchActive = true;
                tmpFullList = new ObservableCollection<AnimeItem>(tmpModel.animeListModel.List);
                tmpModel.animeListModel.fullCardList = tmpFullList;
            }
            if(searchText.Length <= 0 && _searchActive)
            {
                _searchActive = false;
                if(tmpFullList != null)
                    tmpModel.animeListModel.List = tmpFullList;

                tmpFullList = null;
            }
             
            if (_searchActive)
            {
                ObservableCollection<AnimeItem> filteredList = new(SearchHelper.GetSearchResult(tmpFullList, searchText));
                tmpModel.animeListModel.List = filteredList;
            }
        }

        private async void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = this.DataContext as MainModel;
            ContentDialog dialog2 = new()
            {
                XamlRoot = this.XamlRoot,
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                Title = $"Delete? This is irreversible!",
                PrimaryButtonText = "No",
                SecondaryButtonText = "Yes",
                DefaultButton = ContentDialogButton.Primary,
                Content = new CustomContentDialog($"You are about to delete: \"{dataContext.selectedInfoModel.SelectedItem.Title}\"\nAre you sure?")
            };
            var result = await dialog2.ShowAsync();
            if (result == ContentDialogResult.Secondary)
            {
                dataContext.animeListModel.List.Remove(dataContext.selectedInfoModel.SelectedItem);
                if(dataContext.animeListModel.List.Count > 0)
                {
                    dataContext.selectedInfoModel.SelectedItem = dataContext.animeListModel.List.First();
                }
            }
        }

        private void ButtonResize_Click(object sender, RoutedEventArgs e)
        {
            RightPane.Visibility = (RightPane.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;

            (DataContext as MainModel).animeListModel.SmallViewActive = ((DataContext as MainModel).animeListModel.SmallViewActive == false) ? true : false;


        }
    }
}
