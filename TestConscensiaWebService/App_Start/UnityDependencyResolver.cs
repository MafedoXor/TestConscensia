using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;

namespace TestConscensiaWebService.App_Start
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer;

        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public IDependencyScope BeginScope()
        {
            var child = _unityContainer.CreateChildContainer();

            return new UnityDependencyResolver(child);
        }

        public void Dispose()
        {
            _unityContainer.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
    }
}