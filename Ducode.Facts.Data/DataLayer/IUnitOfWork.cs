using Ducode.Facts.Entities;
using System;
using System.Threading.Tasks;

namespace Ducode.Facts.Data.DataLayer
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
		int SaveChanges();
		Task<int> SaveChangesAsync();
	}
}
