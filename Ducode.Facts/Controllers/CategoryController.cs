using Ducode.Facts.Business;
using Ducode.Facts.Exceptions;
using Ducode.Facts.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ducode.Facts.Controllers
{
	[RoutePrefix("api/categories")]
	public class CategoryController : BaseController
	{
		private readonly ICategoryManager _categoryManager;

		public CategoryController(ICategoryManager categoryManager)
		{
			_categoryManager = categoryManager;
		}

		[HttpGet]
		[Route("")]
		public async Task<CategoryModel[]> GetAll()
		{
			return await _categoryManager.GetAll();
		}

		[HttpGet]
		[Route("{categoryId:long}")]
		public async Task<CategoryModel> Get(long categoryId)
		{
			return await _categoryManager.Get(categoryId);
		}

		[HttpPost]
		[Route("")]
		public async Task<CategoryModel> Add(CategoryModel categoryModel)
		{
			return await _categoryManager.Add(categoryModel);
		}

		[HttpPut]
		[Route("{categoryId:long}")]
		public async Task Update(CategoryModel categoryModel, long categoryId)
		{
			await _categoryManager.Update(categoryModel, categoryId);
		}

		[HttpDelete]
		[Route("{categoryId:long}")]
		public async Task Delete(long categoryId)
		{
			await _categoryManager.Delete(categoryId);
		}
	}
}