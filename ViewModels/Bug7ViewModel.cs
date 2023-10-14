using System.Collections.ObjectModel;

namespace zz_MauiBugs.ViewModels
{
    public class Bug7ViewModel : BaseViewModel
    {
        public ObservableCollection<Bug6ItemViewModel> FlexItems { get; set; } = new ObservableCollection<Bug6ItemViewModel>();

        public Bug7ViewModel()
        {
            for (int i = 0; i < 15; i++)
            {
                FlexItems.Add(new Bug6ItemViewModel(GetRandomImageUrl()));
            }
        }

        int _random = 0;

        private string GetRandomImageUrl()
        {
            _random++;
            return "https://source.unsplash.com/random/200x200?sig=" + _random;
        }
    }
}