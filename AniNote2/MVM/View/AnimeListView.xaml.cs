using AniNote2.Base;
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
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AniNote2.MVM.View
{
    /// <summary>
    /// Main view for the <see cref="CardView"/> items
    /// </summary>
    public sealed partial class AnimeListView : UserControl
    {
        public AnimeListView()
        {
            this.InitializeComponent();
        }

        private void ContentGridView_ItemClick(object sender, ItemClickEventArgs e)
        {    
            ((AnimeListModel)this.DataContext).ChangeSelection(e.ClickedItem as AnimeItem);
        }

        private void ContentGridView_Loaded(object sender, RoutedEventArgs e)
        {
            if (CardGridView.Items.Count > 0)
            {
                // Set the first item as selected (you can customize this based on your requirements)
                CardGridView.SelectedIndex = 0;
            }
        }
    }
}
