using zz_MauiBugs;

namespace BB.Maui.Services
{
    public interface IViewCreationService
    {
        Page CreatePage(Type viewModelType);
        View CreateView(Type viewModelType);
        BaseViewModel CreateViewModelInstance(Type viewModelType);
    }
}