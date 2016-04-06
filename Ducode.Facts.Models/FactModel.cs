namespace Ducode.Facts.Models
{
	public class FactModel : BaseModel
	{
		public string Contents { get; set; }
		public string Source { get; set; }
		public long CategoryId { get; set; }
	}
}
