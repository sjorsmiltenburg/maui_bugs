using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using zz_MauiBugs.Messages;

namespace zz_MauiBugs.ViewModels
{
    public class Bug2ViewModel : BaseViewModel
    {
        public ICommand Bug2Command
        {
            get
            {
                return new Command(() =>
                {
                    WeakReferenceMessenger.Default.Send(new Bug2Message());
                });
            }
        }
    }
}