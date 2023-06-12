using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace zz_MauiBugs.ViewModels
{
    public class Bug3ViewModel : BaseViewModel
    {
        public ObservableCollection<MyItemViewModel> MyItems { get; set; } = new ObservableCollection<MyItemViewModel>();

        public Bug3ViewModel()
        {
            //calling the AddStuff method here creates a catastrophic exception
            //AddStuff();
        }


        public ICommand CreateCommand
        {
            get
            {
                return new Command(() =>
                {
                    //calling the AddStuff method here creates a Nullreferenceexception
                    AddStuff();
                });
            }
        }

        private void AddStuff()
        {
            try
            {
                MyItems.Add(new MyItemViewModel("a"));
                MyItems.Add(new MyItemViewModel("b"));
                MyItems.Add(new MyItemViewModel("c"));
                MyItems.Add(new MyItemViewModel("d"));
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
        }
    }
}