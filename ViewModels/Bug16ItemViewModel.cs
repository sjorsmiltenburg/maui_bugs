using Caliburn.Micro;

namespace zz_MauiBugs.ViewModels
{
    public class Bug16ItemViewModel : PropertyChangedBase
    {
        private double _myWidth = 200;

        public Bug16ItemViewModel(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

        public string ImageUrl { get; set; }

        public double MyWidth
        {
            get => _myWidth; set
            {
                _myWidth = value;
                NotifyOfPropertyChange();
            }
        }
    }
}