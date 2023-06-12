using System.Windows.Input;

namespace zz_MauiBugs.ViewModels
{
    public class Bug4ViewModel : BaseViewModel
    {
        public ICommand ChangeFontCommand
        {
            get
            {
                return new Command(() =>
                {

                });
            }
        }
    }
}