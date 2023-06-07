
using BB.Maui.Services;
using System.Globalization;
using System.Reflection;
using TinyIoC;
using zz_MauiBugs.ViewModels;

namespace BB.Maui.Ioc
{

    public static class MyTinyIoc
    {
        private static readonly TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(MyTinyIoc), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(MyTinyIoc.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(MyTinyIoc.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        static MyTinyIoc()
        {
            _container = new TinyIoCContainer();

            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            _container.Register<MainViewModel>().AsSingleton();
            _container.Register<Bug1ViewModel>().AsSingleton();

            // views with non-parameterless constructors


            // Services - by default, TinyIoC will register interface registrations as singletons.
            _container.Register<INavService, NavService>().AsSingleton();
            _container.Register<IViewCreationService, ViewCreationService>().AsSingleton();
        }

        public static void UpdateDependencies(bool useMockServices)
        {
            // Change injected dependencies
            if (useMockServices)
            {
                //_container.Register<ICampaignService, CampaignMockService>();

                UseMockService = true;
            }
            else
            {
                //_container.Register<ICampaignService, CampaignService>();

                UseMockService = false;
            }
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static void RegisterMultiInstance<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsMultiInstance();
        }

        public static void RegisterView<T>() where T : class
        {
            _container.Register<T>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        public static object Resolve(Type t)
        {
            return _container.Resolve(t);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}

