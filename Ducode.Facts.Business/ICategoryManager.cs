using Ducode.Facts.Models;
using System.Threading.Tasks;

namespace Ducode.Facts.Business
{
	public interface ICategoryManager
	{
		Task<CategoryModel[]> GetAll();
		Task<CategoryModel> Get(long id);
		Task<CategoryModel> Add(CategoryModel categoryModel);
		Task Update(CategoryModel categoryModel, long id);
		Task Delete(long id);
	}
}
