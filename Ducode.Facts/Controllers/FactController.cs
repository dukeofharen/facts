using Ducode.Facts.Business;
using Ducode.Facts.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ducode.Facts.Controllers
{
	[RoutePrefix("api/facts")]
	public class FactController : BaseController
	{
		private readonly IFactManager _factManager;

		public FactController(IFactManager factManager)
		{
			_factManager = factManager;
		}

		[HttpGet]
		[Route("")]
		public async Task<FactModel[]> GetAll()
		{
			return await _factManager.GetAll();
		}

		[HttpGet]
		[Route("{factId:long}")]
		public async Task<FactModel> Get(long factId)
		{
			return await _factManager.Get(factId);
		}

		[HttpGet]
		[Route("random")]
		public async Task<FactModel> GetRandom()
		{
			return await _factManager.GetRandom();
		}

		[HttpPost]
		[Route("")]
		public async Task<FactModel> Add(FactModel factModel)
		{
			return await _factManager.Add(factModel);
		}

		[HttpPut]
		[Route("{factId:long}")]
		public async Task Update(FactModel factModel, long factId)
		{
			await _factManager.Update(factModel, factId);
		}

		[HttpDelete]
		[Route("{factId:long}")]
		public async Task Delete(long factId)
		{
			await _factManager.Delete(factId);
		}
	}
}