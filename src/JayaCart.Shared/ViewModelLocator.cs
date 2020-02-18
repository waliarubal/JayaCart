using Nancy.TinyIoc;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

[assembly: Preserve]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared")]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared.Base")]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared.Behaviors")]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared.Commands")]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared.Controls")]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared.Converters")]
[assembly: XmlnsDefinition("https://github.com/waliarubal/schemas", "JayaCart.Mobile.Shared.Styles")]

namespace JayaCart.Mobile.Shared
{
    public static class ViewModelLocator
    {
        static TinyIoCContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty;

        static ViewModelLocator()
        {
            AutoWireViewModelProperty = BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

            _container = new TinyIoCContainer();
        }

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public static void Register<T>() where T: class
        {
            _container.Register<T>();
        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
                return;

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
                return;
            
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
