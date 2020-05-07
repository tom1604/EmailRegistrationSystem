using System;
using System.Reflection;
using System.Windows.Controls;
using Autofac;
using EmailManager.Interfaces;
using EmailManager.Services;

namespace EmailManager.Integration
{
    public class CompositionRoot
    {
        private static IContainer _container;
        private static IMainViewModel _mainViewModel;

        public static IContainer Container
        {
            get => _container ?? BuildContainer();
            set => _container = value;
        }

        public static IMainViewModel MainViewModel
        {
            get
            {
                if (_mainViewModel == null)
                {
                    _mainViewModel = Container.Resolve<IMainViewModel>();
                }

                return _mainViewModel;
            }
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();
            var dataAccess = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterAssemblyTypes(dataAccess).AsImplementedInterfaces();

            containerBuilder.RegisterAssemblyTypes(dataAccess)
                .Where(x => x.Name.EndsWith("ViewModel", StringComparison.InvariantCultureIgnoreCase))
                .AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            containerBuilder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("Service", StringComparison.CurrentCultureIgnoreCase))
                .AsImplementedInterfaces()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies)
                .SingleInstance();

            _container = containerBuilder.Build();

            return _container;
        }
    }
}
