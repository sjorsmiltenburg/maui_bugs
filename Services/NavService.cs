using System.Diagnostics;
using zz_MauiBugs;

namespace BB.Maui.Services
{
    public sealed class NavService : INavService
    {
        private readonly IViewCreationService _viewCreationService;

        public INavigation XamarinFormsNav
        {
            get { return Application.Current.MainPage.Navigation; }
        }

        public NavService(IViewCreationService viewCreationService)
        {
            _viewCreationService = viewCreationService;
        }

        public async Task GoBack()
        {
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                var topView = XamarinFormsNav.NavigationStack.Last();

                if (topView is MainView)
                {
                    return;
                }

                try
                {
                    var top = XamarinFormsNav.NavigationStack.LastOrDefault();
                    await XamarinFormsNav.PopAsync(true);
                }
                catch (Exception e)
                {
                    Debugger.Break();
                    throw;
                }
            });
        }

        private bool _navigating;

        public async Task NavigateTo(Type viewModelType, bool removeCurrentViewFromNavStack)
        {
            try
            {
                Debug.WriteLine("NAV - Navigating to " + viewModelType.ToString());
                if (_navigating)
                {
                    Debugger.Break();
                    Debug.WriteLine("WARNING: double navigation detected");
                }
                _navigating = true;

                var view = _viewCreationService.CreatePage(viewModelType);
                if (view.BindingContext is BaseViewModel baseViewModel)
                {
                    await baseViewModel.Init();
                }
                await NavigateToView(view);

                if (removeCurrentViewFromNavStack)
                {
                    //manipulating the nav stack before running InitAfterLoad because that method may also trigger a navigation
                    RemoveLastView();
                }

                Debug.WriteLine($"navigating to {viewModelType.ToString()} finished");
                _navigating = false;
            }
            catch (Exception e)
            {
                Debugger.Break();
            }

        }



        private void RemoveLastView()
        {
            Application.Current.Dispatcher.DispatchAsync(() =>
            {
                if (XamarinFormsNav.NavigationStack.Any())
                {
                    var lastView = XamarinFormsNav.NavigationStack.ElementAtOrDefault(XamarinFormsNav.NavigationStack.Count - 2);
                    if (lastView != null && lastView.GetType() == typeof(MainView))
                    {
                        Debugger.Break();
                        return;
                    }
                    if (lastView == null)
                    {

                        return;
                    }
                    XamarinFormsNav.RemovePage(lastView);
                }
            });
        }

        private async Task NavigateToView(Page view)
        {
            //await Device.InvokeOnMainThreadAsync(async () =>
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                try
                {
                    if (view.Parent != null)
                    {
                        view.Parent = null;
                    }
                    await XamarinFormsNav.PushAsync(view, true);
                    var vm = view.BindingContext;
                }
                catch (Exception e)
                {
                    Debugger.Break();
                }
            });
        }
    }
}