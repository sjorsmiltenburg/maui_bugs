using System.Collections.ObjectModel;

namespace zz_MauiBugs.ViewModels
{
    public class Bug16ViewModel : BaseViewModel
    {
        public ObservableCollection<Bug16ItemViewModel> MyItems { get; set; } = new ObservableCollection<Bug16ItemViewModel>();

        public Bug16ViewModel()
        {
            for (int i = 0; i < 50; i++)
            {
                MyItems.Add(new Bug16ItemViewModel("https://picsum.photos/200/200"));
            }
        }
    }
}