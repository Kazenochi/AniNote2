using AniNote2.MVM.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

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
                CardGridView.SelectedIndex = 0;
            }
        }
    }
}
