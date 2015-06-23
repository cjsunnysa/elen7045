using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using RoadMaintenance.SharedKernel.Repos;
using RoadMaintenance.SharedKernel.Services;

namespace RoadMaintenance.SharedKernel.Specs
{
    public static class TestKernelBootstrapper
    {
        public static StandardKernel InitialiseKernel()
        {
            var kernel = new StandardKernel();
            var logger = new DummyLogger();

            kernel.Bind<ILogger>().ToConstant(logger);

            kernel.Intercept(context => context.Binding.Service != typeof(ILogger)).With<AuditLoggingInterceptor>();

            var accessRepo = new DummyMethodAccessRepository();
            kernel.Bind<IMethodAccessRepository>().ToConstant(accessRepo);

            return kernel;
        }
    }
}
