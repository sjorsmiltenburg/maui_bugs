using BB.Maui.Services;

namespace zz_MauiBugs.ViewModels
{
    public class Bug5ViewModel : BaseViewModel
    {
        private readonly INavService _navService;

        public Bug5ViewModel(INavService navService)
        {
            _navService = navService;
        }
    }
}