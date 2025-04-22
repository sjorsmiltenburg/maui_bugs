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
            MenuOptions.Add(new MenuOption("Bug 1 - Updating the fontfamily property of a label does not work if the FormattedText property is used to set the text", typeof(Bug1ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 2 - ScrollTo hangs code", typeof(Bug2ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 3 - Provide better exception message when binding a normal list to a collecitonview that has IsGrouped=True\"", typeof(Bug3ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 4 - fixed", typeof(Bug4ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 5 - fixed", typeof(Bug5ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 6 - update itemslayout of collection view not working", typeof(Bug6ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 7 - Rowdefenition *,Auto,* allows flexlayout to go offscreen", typeof(Bug7ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 8 - Memoryleak collectionview", typeof(Bug8ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 9 - The fontsize of a label with text is not the same as the fontsize of a label with formattedtext", typeof(Bug9ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 10 - AnimationManager not set yet", typeof(Bug10ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 11 - FIXED Tapgesture does not work on span", typeof(Bug11ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 12 - Android: certain spans create unwanted vertical shift in text.", typeof(Bug12ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 13 - Android: underlining linebreak creates visual 'space' character that is underlined.", typeof(Bug13ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 14 - Windows: scrollto item works on labels but not on Span in Label.FormattedText.FormattedString.", typeof(Bug14ViewModel)));
            MenuOptions.Add(new MenuOption("Bug 16 - Resize items in collectionview.", typeof(Bug16ViewModel)));

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