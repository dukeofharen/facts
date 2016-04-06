using System;

namespace Ducode.Facts.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string resource) : base(string.Format("Resource not found: {0}", resource))
		{

		}
	}
}
