using System.Diagnostics;
using System.Windows.Input;

namespace zz_MauiBugs.ViewModels
{
    public class Bug11ViewModel : BaseViewModel
    {
        public ICommand TapUrlCommand => new Command<string>(async (url) =>
        {
            await Launcher.OpenAsync(url);
            Debugger.Break();
        });

        public ICommand TapCommand => new Command(async =>
        {
            Debugger.Break();
        });
    }
}