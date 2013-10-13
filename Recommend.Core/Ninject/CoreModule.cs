using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Recommend.Core.DAL;

namespace Recommend.Core.Ninject
{
    public class CoreModule : NinjectModule
    {
        //private const string ConnectionStringName = "DefaultConnection";

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            //.WithConstructorArgument("nameOrConnectionString", ConnectionStringName);
        }
    }
}
