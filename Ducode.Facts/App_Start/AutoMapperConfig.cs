using AutoMapper;
using Ducode.Facts.Business;

namespace Ducode.Facts
{
	public static class AutoMapperConfig
	{
		private static MapperConfiguration _configuration;
		public static MapperConfiguration Configuration
		{
			get
			{
				return _configuration ?? (_configuration = Configure());
			}
		}

		private static MapperConfiguration Configure()
		{
			var config = new MapperConfiguration(cfg =>
			{
				AutoMapperBusinessConfig.Configure(cfg);
			});
			return config;
		}
	}
}