using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Input;
using AniNote2.MVM.ViewModel;
using AniNote2.Base;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AniNote2.MVM.View
{
    /// <summary>
    /// Side View for the currently Selected <see cref="CardView"/>
    /// </summary>
    public sealed partial class SelectedInfoView : UserControl
    {
        public SelectedInfoView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Opens the FlyoutMenu of the Image to change it
        /// </summary>
        /// <param name="isTransient"></param>
        private void ShowMenu(bool isTransient)
        {
            FlyoutShowOptions myOption = new()
            {
                ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard
            };
            CommandBarFlyout1.ShowAt(CardImage, myOption);
        }

        private void MyImageButton_ContextRequested(UIElement sender, ContextRequestedEventArgs args)
        {
            // Show a context menu in standard mode
            // Focus will move to the menu
            ShowMenu(false);
        }

        [STAThread]
        private void ButtonClipBoard_Click(object sender, RoutedEventArgs e)
        {
            var item = (this.DataContext as SelectedInfoModel).SelectedItem;
            ExcelHelper.ToClipBoard(item);
        }
    }
}
