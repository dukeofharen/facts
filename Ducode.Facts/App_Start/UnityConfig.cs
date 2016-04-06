using Ducode.Facts.Business;
using Ducode.Facts.Business.Implementations;
using Ducode.Facts.Data.DataLayer;
using Ducode.Facts.Data.DataLayer.Implementations;
using Ducode.Facts.Implementations;
using Microsoft.Practices.Unity;

namespace Ducode.Facts
{
    public static class UnityConfig
    {
		public static UnityContainer Init()
		{
			UnityContainer container = new UnityContainer();

			//other
			container.RegisterInstance(AutoMapperConfig.Configuration);
			container.RegisterType<ILoggingService, Log4NetService>();

			//data
			container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>(new TransientLifetimeManager(), new InjectionMember[0]);

			//business
			container.RegisterType<ICategoryManager, CategoryManager>();
			container.RegisterType<IFactManager, FactManager>();

			return container;
		}
	}
}