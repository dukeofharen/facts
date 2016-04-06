using Ducode.Facts.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Ducode.Facts.Data.Mappings
{
	public abstract class BaseMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
	{
		protected BaseMapping(string tableName)
		{
			ToTable(tableName)
				.HasKey(t => t.Id);

			Property(e => e.Id)
				.HasColumnName("id");

			Property(e => e.Created)
				.HasColumnName("created")
				.IsRequired();

			Property(e => e.Updated)
				.HasColumnName("updated");
		}
	}
}
