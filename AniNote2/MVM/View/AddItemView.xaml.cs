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
using Microsoft.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AniNote2.MVM.View
{
    public sealed partial class AddItemView : UserControl
    {
        public AnimeItem AnimeItem { get; set; }
        public AddItemView(AnimeItem animeItem)
        {
            this.InitializeComponent();
            this.AnimeItem = animeItem;
            this.DataContext = AnimeItem;
        }

        private void RadioButtons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RadioButtons rb = (RadioButtons)sender;
            string dayofweek = rb.SelectedItem as string;

            switch (dayofweek) { 
                case "Monday":
                    AnimeItem.AirDay = DayOfWeek.Monday;
                    break;
                case "Tuesday":
                    AnimeItem.AirDay = DayOfWeek.Tuesday;
                    break;
                case "Wednesday":
                    AnimeItem.AirDay = DayOfWeek.Wednesday;
                    break;
                case "Thursday":
                    AnimeItem.AirDay = DayOfWeek.Thursday;
                    break;
                case "Friday":
                    AnimeItem.AirDay = DayOfWeek.Friday;
                    break;
                case "Saturday":
                    AnimeItem.AirDay = DayOfWeek.Saturday;
                    break;
                case "Sunday":
                    AnimeItem.AirDay = DayOfWeek.Sunday;
                    break;
            }
        }
    }
}
