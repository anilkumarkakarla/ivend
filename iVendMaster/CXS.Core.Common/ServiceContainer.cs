using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightInject;

namespace CXS.Core.Common
{
    public class ServiceContainer
    {
        public static ServiceContainer Instance = new ServiceContainer();

        private LightInject.ServiceContainer _container;

        private ServiceContainer()
        {
            _container = new LightInject.ServiceContainer();
        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>();
        }
        public void RegisterInstance<TService>(TService instance)
        {
            _container.RegisterInstance<TService>(instance);
        }

        public void Register(Type serviceType)
        {
            _container.Register(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return _container.GetInstance<TService>();
        }
    }
}
