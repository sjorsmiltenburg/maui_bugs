using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace zz_MauiBugs
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual async Task Init() { }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
