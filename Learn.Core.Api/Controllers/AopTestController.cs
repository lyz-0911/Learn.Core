using Learn.Core.IServices;
using Learn.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Core.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AopTestController : ControllerBase
	{
		private readonly IAdvertisementServices _advertisementServices;
		public AopTestController(IAdvertisementServices advertisementServices)
		{
			_advertisementServices=advertisementServices;
		}
		/// <summary>
		/// 测试AOP
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public List<Advertisement> TestAdsFromAOP()
		{
			_advertisementServices.Test();
			return _advertisementServices.TestAOP();
		}
	}
}
