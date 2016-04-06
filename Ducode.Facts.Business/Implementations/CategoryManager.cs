using System;
using System.Threading.Tasks;
using AutoMapper;
using Ducode.Facts.Data.DataLayer;
using Ducode.Facts.Models;
using Ducode.Facts.Entities;
using System.Linq;
using Ducode.Facts.Exceptions;

namespace Ducode.Facts.Business.Implementations
{
	public class CategoryManager : ICategoryManager
	{
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
		private readonly MapperConfiguration _mapperConfiguration;

		public CategoryManager(IUnitOfWorkFactory unitOfWorkFactory, MapperConfiguration mapperConfiguration)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
			_mapperConfiguration = mapperConfiguration;
		}

		public Task<CategoryModel[]> GetAll()
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					var mapper = _mapperConfiguration.CreateMapper();
					var repo = context.GetRepository<Category>();
					var categories = repo.All().ToArray();
					return mapper.Map<CategoryModel[]>(categories);
				}
			});
		}

		public Task<CategoryModel> Get(long id)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					var mapper = _mapperConfiguration.CreateMapper();
					var repo = context.GetRepository<Category>();
					var category = repo.All()
										 .Where(c => c.Id == id)
										 .FirstOrDefault();
					if (category == null)
					{
						throw new NotFoundException(string.Format("category with ID {0}", id));
					}
					return mapper.Map<CategoryModel>(category);
				}
			});
		}

		public Task<CategoryModel> Add(CategoryModel categoryModel)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					if (categoryModel == null)
					{
						throw new ArgumentNullException("categoryModel");
					}
					var mapper = _mapperConfiguration.CreateMapper();
					var category = new Category()
					{
						Description = categoryModel.Description,
						Name = categoryModel.Name
					};
					var repo = context.GetRepository<Category>();
					repo.Add(category);
					context.SaveChanges();
					return mapper.Map<CategoryModel>(category);
				}
			});
		}

		public Task Update(CategoryModel categoryModel, long id)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					if (categoryModel == null)
					{
						throw new ArgumentNullException("categoryModel");
					}
					var repo = context.GetRepository<Category>();
					var category = repo.All()
									   .Where(c => c.Id == id)
									   .FirstOrDefault();
					if (category == null)
					{
						throw new NotFoundException(string.Format("category with ID {0}", id));
					}
					category.Name = categoryModel.Name;
					category.Description = categoryModel.Description;
					category.Updated = DateTime.Now;
					context.SaveChanges();
				}
			});
		}

		public Task Delete(long id)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					var repo = context.GetRepository<Category>();
					var category = repo.All()
									   .Where(c => c.Id == id)
									   .FirstOrDefault();
					if (category == null)
					{
						throw new NotFoundException(string.Format("category with ID {0}", id));
					}
					repo.Delete(category);
					context.SaveChanges();
				}
			});
		}
	}
}
