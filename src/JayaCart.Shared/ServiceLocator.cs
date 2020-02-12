using Nancy.TinyIoc;
using System;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace JayaCart.Shared
{
    public class ServiceLocator
    {
        static ServiceLocator _instance;
        readonly TinyIoCContainer _container;

        private ServiceLocator()
        {
            _container = new TinyIoCContainer();
        }

        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceLocator();

                return _instance;
            }
        }

        public void DiscoverAndRegisterSingelton(Type[] types, string keywoard)
        {
            foreach(var type in types)
            {
                if (type.IsClass && !type.IsAbstract && type.Name.Contains(keywoard))
                    _container.Register(type);
            }
        }

        public void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
        {
            _container.Register<TInterface, T>().AsSingleton();
        }

        public void RegisterSingleton<T>() where T: class
        {
            _container.Register<T>().AsSingleton();
        }

        public T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }
    }
}
