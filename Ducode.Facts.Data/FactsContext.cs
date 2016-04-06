using Ducode.Facts.Entities;
using MySql.Data.Entity;
using System.Data.Entity;

namespace Ducode.Facts.Data
{
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public class FactsContext : DbContext
	{
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Fact> Facts { get; set; }

		public FactsContext() : base("name=FactsDB")
		{

		}
	}
}
