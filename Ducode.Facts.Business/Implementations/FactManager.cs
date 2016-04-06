using System;
using System.Threading.Tasks;
using Ducode.Facts.Models;
using Ducode.Facts.Data.DataLayer;
using AutoMapper;
using Ducode.Facts.Entities;
using System.Linq;
using Ducode.Facts.Exceptions;

namespace Ducode.Facts.Business.Implementations
{
	public class FactManager : IFactManager
	{
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;
		private readonly MapperConfiguration _mapperConfiguration;

		public FactManager(IUnitOfWorkFactory unitOfWorkFactory, MapperConfiguration mapperConfiguration)
		{
			_unitOfWorkFactory = unitOfWorkFactory;
			_mapperConfiguration = mapperConfiguration;
		}

		public Task<FactModel[]> GetAll()
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					var mapper = _mapperConfiguration.CreateMapper();
					var repo = context.GetRepository<Fact>();
					var categories = repo.All().ToArray();
					return mapper.Map<FactModel[]>(categories);
				}
			});
		}

		public Task<FactModel> Get(long id)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					var mapper = _mapperConfiguration.CreateMapper();
					var repo = context.GetRepository<Fact>();
					var fact = repo.All()
										 .Where(f => f.Id == id)
										 .FirstOrDefault();
					if (fact == null)
					{
						throw new NotFoundException(string.Format("fact with ID {0}", id));
					}
					return mapper.Map<FactModel>(fact);
				}
			});
		}

		public Task<FactModel> Add(FactModel factModel)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					if (factModel == null)
					{
						throw new ArgumentNullException("factModel");
					}
					var categoryRepo = context.GetRepository<Category>();
					var factRepo = context.GetRepository<Fact>();
					if (!categoryRepo.All().Any(c => c.Id == factModel.CategoryId))
					{
						throw new NotFoundException(string.Format("category with ID {0}", factModel.CategoryId));
					}
					var mapper = _mapperConfiguration.CreateMapper();
					var fact = new Fact()
					{
						CategoryId = factModel.CategoryId,
						Contents = factModel.Contents,
						Source = factModel.Source
					};
					factRepo.Add(fact);
					context.SaveChanges();
					return mapper.Map<FactModel>(fact);
				}
			});
		}

		public Task Update(FactModel factModel, long id)
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					if (factModel == null)
					{
						throw new ArgumentNullException("categoryModel");
					}
					var categoryRepo = context.GetRepository<Category>();
					var factRepo = context.GetRepository<Fact>();
					if (!categoryRepo.All().Any(c => c.Id == factModel.CategoryId))
					{
						throw new NotFoundException(string.Format("category with ID {0}", factModel.CategoryId));
					}
					var fact = factRepo.All()
									   .Where(f => f.Id == id)
									   .FirstOrDefault();
					if (fact == null)
					{
						throw new NotFoundException(string.Format("fact with ID {0}", id));
					}
					fact.CategoryId = factModel.CategoryId;
					fact.Contents = factModel.Contents;
					fact.Source = factModel.Source;
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
					var repo = context.GetRepository<Fact>();
					var fact = repo.All()
									.Where(f => f.Id == id)
									.FirstOrDefault();
					if (fact == null)
					{
						throw new NotFoundException(string.Format("fact with ID {0}", id));
					}
					repo.Delete(fact);
					context.SaveChanges();
				}
			});
		}

		public Task<FactModel> GetRandom()
		{
			return Task.Run(() =>
			{
				using (var context = _unitOfWorkFactory.Create())
				{
					var mapper = _mapperConfiguration.CreateMapper();
					var repo = context.GetRepository<Fact>();
					var fact = repo.All()
									.ToArray()
									.OrderBy(f => Guid.NewGuid())
									.FirstOrDefault();
					return mapper.Map<FactModel>(fact);
				}
			});
		}
	}
}
