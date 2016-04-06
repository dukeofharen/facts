using Ducode.Facts.Entities;

namespace Ducode.Facts.Data.Mappings
{
	public class FactMapping : BaseMapping<Fact>
	{
		public FactMapping() : base("facts")
		{
			Property(f => f.Contents)
				.HasColumnName("contents");

			Property(f => f.Source)
				.HasColumnName("source");

			HasRequired(f => f.Category)
				.WithMany(c => c.Facts)
				.HasForeignKey(f => f.CategoryId);
		}
	}
}
