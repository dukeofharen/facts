using Ducode.Facts.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Ducode.Facts.Data.DataLayer.Implementations
{
	public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		private FactsContext _context;

		public BaseRepository(FactsContext context)
		{
			_context = context;
		}

		public TEntity Add(TEntity entity)
		{
			var set = GetSet();
			return set.Add(entity);
		}

		public IQueryable<TEntity> All()
		{
			return GetSet();
		}

		public void Delete(TEntity entity)
		{
			var set = GetSet();
			set.Remove(entity);
		}

		private DbSet<TEntity> GetSet()
		{
			var set = _context.Set<TEntity>();
			if (set == null)
			{
				throw new ArgumentException(string.Format("'{0}' isn't an entity type!", typeof(TEntity).Name));
			}
			return set;
		}
	}
}
