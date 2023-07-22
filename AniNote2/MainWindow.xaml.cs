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
        public ListModel listModel { get; set; } = new();

        public MainWindow()
        {
            this.InitializeComponent();
            RootPanel.DataContext = this;
            animeListView.DataContext = listModel;
        }

        public ICommand ButtonPressedCommand { get { return new AN_Command.DelegateCommand(o => Press()); } }

        private void Press()
        {
            listModel.List.Add(new AnimeItem());
        }

    }
}
