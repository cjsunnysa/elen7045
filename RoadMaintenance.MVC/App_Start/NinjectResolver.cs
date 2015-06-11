using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Http.Dependencies;
using System.Web.Services.Description;
using Ninject;

namespace RoadMaintenance.MVC.App_Start
{
    public class NinjectResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        public IKernel Kernel {get; private set; }

        public NinjectResolver(IKernel kernel)
        {
            Kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Kernel.GetService(serviceType);
            }
            catch (ActivationException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Kernel.GetAll(serviceType);
            }
            catch (ActivationException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }

        public void Rebind<TAb>(TAb instance)
        {
            Kernel.Rebind<TAb>().ToConstant(instance);
        }
    
    }
}