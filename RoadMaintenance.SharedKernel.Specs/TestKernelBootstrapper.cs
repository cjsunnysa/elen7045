using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.SharedKernel.Services;
using TechTalk.SpecFlow;

namespace RoadMaintenance.SharedKernel.Specs
{
    public static class TestKernelBootstrapper
    {
        public static StandardKernel InitialiseKernel()
        {
            var kernel = new StandardKernel();
            var logger = new DummyLogger();

            kernel.Bind<ILogger>().ToConstant(logger);

            var methodAccessRepo = kernel.Get<DummyMethodAccessRepository>();
            kernel.Bind<IMethodAccessRepository>().ToConstant(methodAccessRepo);

            kernel.Intercept(context => context.Binding.Service != typeof(ILogger)).With<AuditLoggingInterceptor>();            

            return kernel;
        }
        
        public static void SetupUser(string userName)
        {
            var kernel = ScenarioContext.Current.Get<StandardKernel>("kernel");
            IUser user = new User(userName);
            kernel.Bind<IUser>().ToConstant(user);
        }
        
    }
}
