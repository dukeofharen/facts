namespace Ducode.Facts.Entities
{
	public class Fact : BaseEntity
	{
		public string Contents { get; set; }
		public string Source { get; set; }

		public Category Category { get; set; }
		public long CategoryId { get; set; }
	}
}
