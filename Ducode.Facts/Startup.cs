using Ducode.Facts.Business;
using Ducode.Facts.Filters;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Practices.Unity;
using Owin;
using System.Collections.Generic;
using System.Web.Http;
using Unity.WebApi;

namespace Ducode.Facts
{
	public class Startup
	{
		public void Configuration(IAppBuilder builder)
		{
			XmlConfigurator.Configure();

			builder.UseDefaultFiles(new DefaultFilesOptions()
			{
				RequestPath = new PathString(),
				DefaultFileNames = new List<string>() { "index.html" },
				FileSystem = new PhysicalFileSystem(@".\app")
			});

			builder.UseStaticFiles(new StaticFileOptions()
			{
				RequestPath = new PathString(),
				FileSystem = new PhysicalFileSystem(@".\app")
			});

			HttpConfiguration httpConfiguration = new HttpConfiguration();

			UnityContainer container = UnityConfig.Init();
			httpConfiguration.DependencyResolver = new UnityDependencyResolver(container);

			httpConfiguration.Filters.Add(new FactsExceptionFilter(container.Resolve<ILoggingService>()));

			httpConfiguration.MapHttpAttributeRoutes();
			httpConfiguration.EnsureInitialized();

			builder.UseWebApi(httpConfiguration);
		}
	}
}