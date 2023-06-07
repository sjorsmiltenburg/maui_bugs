using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using zz_MauiBugs.Messages;

namespace zz_MauiBugs.ViewModels
{
    public class Bug1ViewModel : BaseViewModel
    {
        public ICommand ChangeFontCommand
        {
            get
            {
                return new Command(() =>
                {
                    WeakReferenceMessenger.Default.Send(new ChangeFontMessage());
                });
            }
        }
    }
}