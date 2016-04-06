using Ducode.Facts.Business.Implementations;
using Ducode.Facts.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducode.Facts.Business.Tests.Implementations
{
	[TestClass]
	public class CategoryManagerFacts
	{
		#region GetAll
		[TestMethod]
		public async Task CategoryManager_GetAll_HappyFlow()
		{
			//act
			var context = MockContext.CleanInstance;
			var service = CreateService();

			var category1 = new Category()
			{
				Description = context.Random().ToString(),
				Name = context.Random().ToString()
			};
			var category2 = new Category()
			{
				Description = context.Random().ToString(),
				Name = context.Random().ToString()
			};

			context.Add(category1);
			context.Add(category2);

			//arrange
			var result = await service.GetAll();

			//assert
			Assert.AreEqual(2, result.Length);
			Assert.AreEqual(category1.Description, result[0].Description);
			Assert.AreEqual(category1.Name, result[0].Name);
		}
		#endregion

		#region Private methods
		private ICategoryManager CreateService()
		{
			var context = MockContext.Instance;
			return new CategoryManager(context.UnitOfWorkFactory, context.MapperConfiguration);
		}
		#endregion
	}
}
