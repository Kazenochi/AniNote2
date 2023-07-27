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
using static System.Net.Mime.MediaTypeNames;
using AniNote2.MVM.ViewModel;
using AniNote2.Base;
using Windows.ApplicationModel.DataTransfer;

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
            FlyoutShowOptions myOption = new FlyoutShowOptions();
            myOption.ShowMode = isTransient ? FlyoutShowMode.Transient : FlyoutShowMode.Standard;
            CommandBarFlyout1.ShowAt(CardImage, myOption);
        }

        private void MyImageButton_ContextRequested(Microsoft.UI.Xaml.UIElement sender, ContextRequestedEventArgs args)
        {
            // Show a context menu in standard mode
            // Focus will move to the menu
            ShowMenu(false);
        }

        private void ButtonWeekday_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                var newDay = ((SelectedInfoModel)this.DataContext).SelectedItem;

                switch (button.Tag as string) {
                    case "Monday":
                        newDay.AirDay = DayOfWeek.Monday;
                        break;
                    case "Tuesday":
                        newDay.AirDay = DayOfWeek.Tuesday;
                        break;
                    case "Wednesday":
                        newDay.AirDay = DayOfWeek.Wednesday;
                        break;
                    case "Thursday":
                        newDay.AirDay = DayOfWeek.Thursday;
                        break;
                    case "Friday":
                        newDay.AirDay = DayOfWeek.Friday;
                        break;
                    case "Saturday":
                        newDay.AirDay = DayOfWeek.Saturday;
                        break;
                    case "Sunday":
                        newDay.AirDay = DayOfWeek.Sunday;
                        break;
                }
            }
        }
        [STAThread]
        private void ButtonClipBoard_Click(object sender, RoutedEventArgs e)
        {
            var item = (this.DataContext as SelectedInfoModel).SelectedItem;
            ExcelHelper.ToClipBoard(item);
        }
    }
}
