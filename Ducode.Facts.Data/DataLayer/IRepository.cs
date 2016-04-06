using Ducode.Facts.Entities;
using System.Linq;

namespace Ducode.Facts.Data.DataLayer
{
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		IQueryable<TEntity> All();
		TEntity Add(TEntity entity);
		void Delete(TEntity entity);
	}
}
