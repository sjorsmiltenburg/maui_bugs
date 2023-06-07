namespace BB.Maui.Services
{
    public interface INavService
    {
        INavigation XamarinFormsNav { get; }

        Task GoBack();
        Task NavigateTo(Type viewModelType, bool removeCurrentViewFromNavStack);
    }
}