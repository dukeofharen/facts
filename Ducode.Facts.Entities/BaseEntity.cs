using System;

namespace Ducode.Facts.Entities
{
	public abstract class BaseEntity
	{
		protected BaseEntity()
		{
			Created = DateTime.Now;
		}

		public long Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
	}
}
