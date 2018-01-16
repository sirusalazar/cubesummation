using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

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
            //contexts
            //container.RegisterType<OpenAreaContext>(new InjectionFactory(x => new OpenAreaContext()));
            //container.Register<OpenAreaContext>(new InjectionFactory(c => new OpenAreaContext()));


            //web respositories
            //container.RegisterType<IUserRepository, UserRepository>();

            //services
            //container.RegisterType<IUserService, UserService>();

        }
    }
}