using Ducode.Facts.Entities;

namespace Ducode.Facts.Data.Mappings
{
	public class CategoryMapping : BaseMapping<Category>
	{
		public CategoryMapping() : base("categories")
		{
			Property(c => c.Name)
				.HasColumnName("name");

			Property(c => c.Description)
				.HasColumnName("description");
		}
	}
}
