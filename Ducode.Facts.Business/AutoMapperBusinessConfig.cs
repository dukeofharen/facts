using AutoMapper;
using Ducode.Facts.Entities;
using Ducode.Facts.Models;

namespace Ducode.Facts.Business
{
	public static class AutoMapperBusinessConfig
	{
		public static void Configure(IProfileExpression profile)
		{
			profile.CreateMap<Fact, FactModel>();
			profile.CreateMap<FactModel, Fact>();

			profile.CreateMap<Category, CategoryModel>();
			profile.CreateMap<CategoryModel, Category>();
		}
	}
}
