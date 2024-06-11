using System.Collections.ObjectModel;
using System.Windows.Input;

namespace zz_MauiBugs.ViewModels
{
    public class Bug6ViewModel : BaseViewModel
    {
        public ObservableCollection<Bug6GroupedItemsViewModel> MyGroupedItems2 { get; set; } = new ObservableCollection<Bug6GroupedItemsViewModel>();

        private GridItemsLayout _myItemsLayout;

        private string GetRandomImageUrl()
        {
            return "https://picsum.photos/200/200";
        }

        public GridItemsLayout MyItemsLayout
        {
            get => _myItemsLayout;
            set
            {
                _myItemsLayout = value;
                OnPropertyChanged();
            }
        }

        public ICommand Span4Command
        {
            get
            {
                return new Command(() =>
                {
                    //calling the AddStuff method here creates a Nullreferenceexception
                    MyItemsLayout = new GridItemsLayout(4, ItemsLayoutOrientation.Vertical);
                });
            }
        }

        public ICommand Span6Command
        {
            get
            {
                return new Command(() =>
                {
                    //calling the AddStuff method here creates a Nullreferenceexception
                    MyItemsLayout = new GridItemsLayout(6, ItemsLayoutOrientation.Vertical);
                });
            }
        }

        public Bug6ViewModel()
        {
            MyItemsLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical);

            var group1 = new Bug6GroupedItemsViewModel() { Name = "Group 1" };

            for (int i = 0; i < 8; i++)
            {
                group1.Add(new Bug6ItemViewModel(GetRandomImageUrl()));
            }
            MyGroupedItems2.Add(group1);

            var group2 = new Bug6GroupedItemsViewModel() { Name = "2" };
            for (int i = 0; i < 35; i++)
            {
                group2.Add(new Bug6ItemViewModel(GetRandomImageUrl()));
            }
            MyGroupedItems2.Add(group2);
        }
    }
}