using BB.Maui.Services;
using System.Collections.ObjectModel;

namespace zz_MauiBugs.ViewModels
{
    public class Bug4ViewModel : BaseViewModel
    {
        public ObservableCollection<MyGroupedItemsViewModel> MyGroupedItems { get; set; } = new ObservableCollection<MyGroupedItemsViewModel>();

        public Bug4ViewModel(IViewCreationService viewCreationService)
        {
            var group1 = new MyGroupedItemsViewModel() { Name = "1" };
            group1.Add(new MyItemViewModel("a"));
            group1.Add(new MyItemViewModel("b"));
            group1.Add(new MyItemViewModel("c"));
            group1.Add(new MyItemViewModel("d"));
            group1.Add(new MyItemViewModel("e"));
            MyGroupedItems.Add(group1);

            var group2 = new MyGroupedItemsViewModel() { Name = "2" };
            group2.Add(new MyItemViewModel("a2"));
            group2.Add(new MyItemViewModel("b2"));
            group2.Add(new MyItemViewModel("c2"));
            group2.Add(new MyItemViewModel("d2"));
            group2.Add(new MyItemViewModel("e2"));
            MyGroupedItems.Add(group2);

        }


    }
}