using System.ComponentModel;


namespace AniNote2.Base
{
    /// <summary>
    /// Boilerplate for bindings / changeevents
    /// </summary>
    public class ObserverNotifyChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RaisePropertyChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
    }
}
