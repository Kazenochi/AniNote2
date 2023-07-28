using AniNote2.Base;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage.Pickers;

namespace AniNote2.MVM.ViewModel
{
    /// <summary>
    /// ContextData for <see cref="MVM.View.SelectedInfoView"/> and mainpoint for changes to the selected <see cref="AnimeItem"/>
    /// </summary>
    public class SelectedInfoModel : ObserverNotifyChange
    {
        private AnimeItem _selectedItem;
        public AnimeItem SelectedItem { get { return _selectedItem; } set { _selectedItem = value; RaisePropertyChanged(nameof(SelectedItem)); } }

        private bool _editMode;
        public bool EditMode { get { return _editMode; } set { _editMode = value; RaisePropertyChanged(nameof(EditMode)); } }

        private List<DayOfWeek> _weekDays;
        public List<DayOfWeek> WeekDays { get { return _weekDays; } set { _weekDays = value; RaisePropertyChanged(nameof(WeekDays)); } }

        private readonly MainWindow MW;

        public SelectedInfoModel(MainWindow mw)
        {
            MW = mw;
            _weekDays = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
        }

        public ICommand ChangeLocalCommand { get { return new AN_Command.DelegateCommand(o => ChangeImageLocal()); } }
        public ICommand ChangeInternetCommand { get { return new AN_Command.DelegateCommand(o => ChangeImageInternet()); } }

        private async void ChangeImageLocal()
        {
            var filePicker = new FileOpenPicker();

            // Get the current window's HWND by passing in the Window object
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(MW);

            // Associate the HWND with the file picker
            WinRT.Interop.InitializeWithWindow.Initialize(filePicker, hwnd);

            // Use file picker like normal!
            filePicker.FileTypeFilter.Add("*");
            var file = await filePicker.PickSingleFileAsync();

            if (file != null )
            {
                Debug.WriteLine("Success" + file.ToString());
                SelectedItem.Image = ImageHelper.Load(file.Path);
            }
        }

        private void ChangeImageInternet()
        {
            SelectedItem.SwitchImageToOnline(true);
        }
    }
}
