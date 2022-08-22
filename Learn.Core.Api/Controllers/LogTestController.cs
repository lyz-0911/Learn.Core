using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learn.Core.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LogTestController : ControllerBase
	{
		private readonly ILogger<LogTestController> _logger;
		public LogTestController(ILogger<LogTestController> logger)
		{
			_logger = logger;
		}
		// GET: api/<LogTestController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			try
			{
				throw new ApplicationException("这是一个简单的测试");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			
			return new string[] { "value1", "value2" };
		}

	
	
	}
}
