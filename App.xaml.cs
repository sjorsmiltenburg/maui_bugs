using BB.Maui.Ioc;
using zz_MauiBugs.ViewModels;

namespace zz_MauiBugs
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainView = MyTinyIoc.Resolve<MainView>();
            var mainViewModel = MyTinyIoc.Resolve<MainViewModel>();
            mainView.BindingContext = mainViewModel;

            var navigationPage = new NavigationPage(mainView);
            NavigationPage.SetHasNavigationBar(navigationPage, false);

            MainPage = navigationPage;
        }
    }
}