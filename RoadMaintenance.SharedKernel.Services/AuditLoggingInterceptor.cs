using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Extensions.Interception;

namespace RoadMaintenance.SharedKernel.Services
{
    public class AuditLoggingInterceptor : IInterceptor
    {
        private ILogger logger;

        public AuditLoggingInterceptor(ILogger logger)
        {
            this.logger = logger;
        }
        
        public void Intercept(IInvocation invocation)
        {
            logCallMessage(invocation);
          
            invocation.Proceed();

            logResultsMessage(invocation);
        }

        void logCallMessage(IInvocation invocation)
        {
            var builder = new StringBuilder();
            builder.AppendLine("----------");
            builder.AppendLine("Method Call:");
            builder.AppendLine(String.Format("Method : {0}", invocation.Request.Method.Name));
            builder.AppendLine("Parameters:");
            builder.AppendLine(String.Join(Environment.NewLine,
                invocation.Request.Method.GetParameters()
                    .Select((p, i) => String.Format("{0} : {1}", p.Name, invocation.Request.Arguments[i]))));
            builder.AppendLine("----------");
            logger.Log(builder.ToString(), LogLevel.Audit);
        }

        void logResultsMessage(IInvocation invocation)
        {
            if(invocation.Request.Method.ReturnType == typeof(void))
                return;
            
            var builder = new StringBuilder();
            builder.AppendLine("----------");
            builder.AppendLine("Method Results:");
            builder.AppendLine(String.Format("Method : {0}", invocation.Request.Method.Name));
            builder.AppendLine(String.Format("Results : {0}", invocation.ReturnValue));
            builder.AppendLine("----------");
            logger.Log(builder.ToString(), LogLevel.Audit);
        }
    }
}
