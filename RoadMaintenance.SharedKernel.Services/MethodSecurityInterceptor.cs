using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Extensions.Interception;
using RoadMaintenance.SharedKernel.Core;
using RoadMaintenance.SharedKernel.Repos;

namespace RoadMaintenance.SharedKernel.Services
{
    public class MethodSecurityInterceptor : IInterceptor
    {
        private IMethodAccessRepository methodAccessRepository;
        public MethodSecurityInterceptor(IMethodAccessRepository methodAccessRepository)
        {
            this.methodAccessRepository = methodAccessRepository;
        }
        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Request.Context.Plan.Type.Name + "." + invocation.Request.Method.Name;
            var methodAccess = methodAccessRepository.Find(methodName);
            if (methodAccess != null)
            {
                var user = invocation.Request.Context.Kernel.TryGet<IUser>();
                if (user == null || !methodAccess.Roles.Contains(user.Role))
                    throw new MethodAccessException("Your user does not have access to this method.");
            }

            invocation.Proceed();
        }
    }
}
