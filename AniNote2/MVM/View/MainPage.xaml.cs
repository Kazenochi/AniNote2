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
        private ObservableCollection<AnimeItem> fullCardList;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Quit? All changes will be lost!";
            dialog.PrimaryButtonText = "No";
            dialog.SecondaryButtonText = "Yes";
            //dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;

            var result = await dialog.ShowAsync();
            if(result == ContentDialogResult.Secondary)
            {
                ((MainModel)this.DataContext).Back();
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text;
            MainModel tmpModel = this.DataContext as MainModel;

            if (tmpModel == null) { return; }
            if (!_searchActive)
            {
                fullCardList = new ObservableCollection<AnimeItem>(tmpModel.animeListModel.List);
            }

            if (searchText.Length > 0)
            {
                _searchActive = true;
                ObservableCollection<AnimeItem> filteredList = new ObservableCollection<AnimeItem>(SearchHelper.GetSearchResult(tmpModel.animeListModel.List, searchText));
                tmpModel.animeListModel.List = filteredList;
            }
            else if (_searchActive)
            {
                _searchActive = false;
                if(fullCardList != null)
                {
                    tmpModel.animeListModel.List = fullCardList;
                    fullCardList = null;
                }
            }
        }
    }
}
