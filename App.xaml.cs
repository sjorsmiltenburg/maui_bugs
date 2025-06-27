using zz_MauiBugs.ViewModels;

namespace zz_MauiBugs
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var mainView = serviceProvider.GetService<MainView>();
            var mainViewModel = serviceProvider.GetService<MainViewModel>();
            mainView.BindingContext = mainViewModel;

            var navigationPage = new NavigationPage(mainView);
            NavigationPage.SetHasNavigationBar(navigationPage, false);

            MainPage = navigationPage;
        }
    }
}