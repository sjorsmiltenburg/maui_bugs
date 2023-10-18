using BB.Maui.Services;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using zz_MauiBugs.Messages;

namespace zz_MauiBugs.ViewModels
{

    public class MainViewModel : BaseViewModel
    {
        private readonly INavService _navService;
        private ContentView _content;

        public MainViewModel(INavService navService)
        {
            MenuOptions.Add(new MenuOption("Bug 1", typeof(Bug1ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 2", typeof(Bug2ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 3", typeof(Bug3ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 4 - fixed", typeof(Bug4ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 5 - fixed", typeof(Bug5ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 6", typeof(Bug6ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 7", typeof(Bug7ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 8", typeof(Bug8ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 9", typeof(Bug9ViewModel)));

            WeakReferenceMessenger.Default.Register<LoadViewMessage>(this, (r, m) =>
            {
                _navService.NavigateTo(m.ViewModelType, false);
            });
            _navService = navService;
        }

        public List<MenuOption> MenuOptions { get; set; } = new List<MenuOption>();

        public ContentView Content
        {
            get => _content; set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

    }

    public class MenuOption
    {
        private readonly Type _viewModelType;

        public MenuOption(string name, Type viewModelType)
        {
            Name = name;
            _viewModelType = viewModelType;
        }

        public string Name { get; set; }

        public ICommand TappedCommand
        {
            get
            {
                return new Command(() =>
                {
                    WeakReferenceMessenger.Default.Send(new LoadViewMessage(_viewModelType));
                });
            }
        }

    }
}