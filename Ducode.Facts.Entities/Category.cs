using System.Collections.Generic;

namespace Ducode.Facts.Entities
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ICollection<Fact> Facts { get; set; }
	}
}
