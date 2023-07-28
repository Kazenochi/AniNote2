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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
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
        private readonly MainModel model;
        private int hiddenCounter = 0;


        public MainWindow()
        {
            this.InitializeComponent();
            Debug.WriteLine("Marker: App Init Start");
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);
            this.MainGrid.DataContext = this;
            model = new MainModel(this);
            mainPage.DataContext = model;
            AppWindow.Closing += AppWindow_Closing;
            Debug.WriteLine("Marker: App Init Finished");
        }

        private void AppWindow_Closing(Microsoft.UI.Windowing.AppWindow sender, Microsoft.UI.Windowing.AppWindowClosingEventArgs args)
        {
            Debug.WriteLine("App closing");
            if (this.model.animeListModel.List.Count() < this.model.animeListModel.fullCardList.Count())
                SaveHelper.SaveFile(this.model.animeListModel.fullCardList);
            else
                SaveHelper.SaveFile(this.model.animeListModel.List);

            Debug.WriteLine("App Closed");
        }

        private void AppTitleBar_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            hiddenCounter++;
            if( hiddenCounter > 10 ) { HiddenButton.Visibility = Visibility.Visible; }
        }

        private async void HiddenButton_Click(object sender, RoutedEventArgs e)
        {
            var file = await FilePickHelper.SingleFile(this);
            model.animeListModel.List = SaveHelper.LoadOldFile(file.Path);
        }
    }
}
