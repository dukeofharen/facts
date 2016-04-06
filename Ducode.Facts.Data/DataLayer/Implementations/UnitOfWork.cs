using System;
using System.Threading.Tasks;
using Ducode.Facts.Entities;

namespace Ducode.Facts.Data.DataLayer.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		private FactsContext _context = null;

		public UnitOfWork()
		{
			_context = new FactsContext();
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
				_context = null;
			}
		}

		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
		{
			var repo = new BaseRepository<TEntity>(_context);
			return repo;
		}

		public Task<int> SaveChangesAsync()
		{
			return _context.SaveChangesAsync();
		}

		public int SaveChanges()
		{
			return _context.SaveChanges();
		}
	}
}
