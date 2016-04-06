namespace Ducode.Facts.Data.DataLayer.Implementations
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork Create()
		{
			return new UnitOfWork();
		}
	}
}
