using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ZRdemoData.Intrefaces;
using ZRdemoData.UnitOfWork;

namespace ZRdemoBll.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule (string conneection)
        {
            connectionString = conneection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
