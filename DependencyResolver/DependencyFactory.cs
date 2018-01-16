using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;
using BussinessLayer.Interfaces;
using BussinessLayer.Implementations;

namespace Training.Angular.DependencyResolver
{
    public class DependencyFactory
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        static DependencyFactory()
        {
            var container = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            if (section != null)
            {
                section.Configure(container);
            }
            RegisterTypes(container);
            _container = container;
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            //Bussiness Layer Dependencies

            container.RegisterType<ICubeProcessor, CubeProcessor>();
            container.RegisterType<ICubeUpdate, CubeUpdater>();
            container.RegisterType<ICubeQuery, CubeRetriever>();
            container.RegisterType<IValidator, InputValidator>();

        }
    }
}