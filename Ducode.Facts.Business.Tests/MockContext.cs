using AutoMapper;
using Ducode.Facts.Data.DataLayer;
using Ducode.Facts.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducode.Facts.Business.Tests
{
	public class MockContext
	{
		#region Initialization
		private static MockContext _context;
		private static Random _random;

		public List<object> Entities { get; private set; }

		public static MockContext Instance
		{
			get
			{
				return _context ?? (_context = new MockContext());
			}
		}

		public static MockContext CleanInstance
		{
			get
			{
				var instance = Instance;
				instance.Clear();
				return instance;
			}
		}

		private IUnitOfWorkFactory _unitOfWorkFactory;
		public IUnitOfWorkFactory UnitOfWorkFactory
		{
			get
			{
				return _unitOfWorkFactory;
			}
		}

		private MapperConfiguration _mapperConfiguration;
		public MapperConfiguration MapperConfiguration
		{
			get
			{
				return _mapperConfiguration;
			}
		}

		private MockContext()
		{
			Entities = new List<object>();
			_random = new Random();

			var unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>(MockBehavior.Strict);
			var unitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);

			unitOfWorkMock.Setup(m => m.GetRepository<Fact>()).Returns(CreateRepository<Fact>());
			unitOfWorkMock.Setup(m => m.GetRepository<Category>()).Returns(CreateRepository<Category>());

			unitOfWorkFactoryMock.Setup(m => m.Create()).Returns(unitOfWorkMock.Object);
			unitOfWorkMock.Setup(m => m.Dispose());
			unitOfWorkMock.Setup(m => m.SaveChanges());

			_unitOfWorkFactory = unitOfWorkFactoryMock.Object;

			_mapperConfiguration = new MapperConfiguration(cfg =>
			{
				AutoMapperBusinessConfig.Configure(cfg);
			});
		}

		private IRepository<TEntity> CreateRepository<TEntity>() where TEntity : BaseEntity
		{
			var repoMock = new Mock<IRepository<TEntity>>(MockBehavior.Strict);
			repoMock.Setup(m => m.All()).Returns(Entities.Where(e => e.GetType() == typeof(TEntity)).Cast<TEntity>().AsQueryable());
			repoMock.Setup(m => m.Add(It.IsAny<TEntity>())).Callback<TEntity>(Entities.Add);
			repoMock.Setup(m => m.Delete(It.IsAny<TEntity>())).Callback<TEntity>(e =>
			{
				Entities.Remove(e);
			});
			return repoMock.Object;
		}
		#endregion

		#region Other methods
		public int Random()
		{
			return _random.Next();
		}

		public int Random(int max)
		{
			return _random.Next(0, max);
		}

		public int Random(int min, int max)
		{
			return _random.Next(min, max);
		}

		public TEntity Add<TEntity>(TEntity entity)
		{
			Entities.Add(entity);
			return entity;
		}

		public void Clear()
		{
			Entities.Clear();
		}
		#endregion
	}
}
