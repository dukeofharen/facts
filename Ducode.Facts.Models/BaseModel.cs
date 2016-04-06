using System;

namespace Ducode.Facts.Models
{
	public abstract class BaseModel
	{
		protected BaseModel()
		{
			Created = DateTime.Now;
		}

		public long Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
	}
}
