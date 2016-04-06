using Ducode.Facts.Models;
using System.Threading.Tasks;

namespace Ducode.Facts.Business
{
	public interface IFactManager
	{
		Task<FactModel[]> GetAll();
		Task<FactModel> Get(long id);
		Task<FactModel> GetRandom();
		Task<FactModel> Add(FactModel factModel);
		Task Update(FactModel factModel, long id);
		Task Delete(long id);
	}
}
