
using zz_MauiBugs;

namespace BB.Maui.Services
{
    public sealed class ViewCreationService : IViewCreationService
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewCreationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Page CreatePage(Type viewModelType)
        {
            var page = CreateViewInstance(viewModelType) as Page;
            var viewModel = CreateViewModelInstance(viewModelType);
            page.BindingContext = viewModel;

            return page;
        }

        public View CreateView(Type viewModelType)
        {
            var view = CreateViewInstance(viewModelType) as View;
            var viewModel = CreateViewModelInstance(viewModelType);
            view.BindingContext = viewModel;
            return view;
        }

        private object CreateViewInstance(Type viewModelType)
        {
            if (viewModelType.FullName != null && !viewModelType.FullName.ToLower().EndsWith("model"))
            {
                throw new Exception("you probably did not give a viewmodel type to resolve but a view");
            }

            Type viewType = GetViewTypeForViewModel(viewModelType);
            if (viewType == null)
            {
                throw new Exception($"Cannot locate view type for {viewModelType}");
            }

            var result2 = _serviceProvider.GetService(viewType);
            if (result2 == null)
            {
                throw new Exception(
                    "failed to create instance of view without parameterless constructor, probably not yet added to ioc");
            }

            return result2;
        }

        private Type GetViewTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.Namespace + "." + viewModelType.Name.Replace("Model", string.Empty);
            var viewType = Type.GetType(viewName);
            return viewType;
        }

        public BaseViewModel CreateViewModelInstance(Type viewModelType)
        {
            //todo can we alter this method to a <T> implementation that directly returns the actual type?
            if (!(_serviceProvider.GetService(viewModelType) is BaseViewModel vm))
            {
                throw new Exception("Failed to resolve instance of viewmodel from IOC, problably not added yet");
            }

            return vm;
        }
    }
}