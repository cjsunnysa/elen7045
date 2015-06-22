using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace RoadMaintenance.SharedKernel.Specs
{
    public static class TestKernelBootstrapper
    {
        public static StandardKernel InitialiseKernel()
        {
            return new StandardKernel();
            
        }
    }
}
