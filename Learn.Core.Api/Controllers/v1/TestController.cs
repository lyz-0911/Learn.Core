using Microsoft.AspNetCore.Mvc;
using Learn.Core.Model;
using Learn.Core.Api.Filter;
using static Learn.Core.Extensions.CustomApiVersion;
using Learn.Core.IServices;

namespace Learn.Core.Api.Controllers.v1
{
	/// <summary>
	/// 测试v1版本
	/// </summary>
	//[Route("api/[controller]")]
	[CustomRoute(ApiVersions.V1, "test")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly ITestService _testService;
		public TestController(ITestService testService)
		{
			_testService=testService;
		}
		/// <summary>
		/// 数据存储集合
		/// </summary>
		private readonly static List<Test> DataList=new List<Test>()
		{
			new Test(){Id=1,Name="熊大1",Age=8,Email="Xiong1@qq.com"},
			new Test(){Id=2,Name="熊二1",Age=9,Email="Xiosng2@qq.com"},
			new Test(){Id=3,Name="光头强1",Age=20,Email="GuangTouqiang@qq.com"}			
		};

		/// <summary>
		/// 读取所有记录
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			_testService.ToString();
			return new JsonResult(DataList.OrderBy(d=>d.Id));
		}

		/// <summary>
		/// 读取单条记录
		/// </summary>
		/// <param name="id">编号</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var result = DataList.Find(d => d.Id == id);
			return new JsonResult(result);
		}

		/// <summary>
		/// 添加一条记录
		/// </summary>
		/// <param name="TestModel"></param>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Post([FromBody] Test TestModel)
		{
			DataList.Add(TestModel);
			return new JsonResult(TestModel);
		}

		/// <summary>
		/// 修改一条记录
		/// </summary>
		/// <param name="id"></param>
		/// <param name="TestModel"></param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Test TestModel)
		{
			var rem= DataList.Find(d => d.Id == id);
			DataList.Remove(rem);
			DataList.Add(new Test { Id = id, Name = TestModel.Name, Age = TestModel.Age, Email = TestModel.Email });
			return new JsonResult(DataList.OrderBy(d => d.Id));
		}

		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			DataList.Remove(DataList.Find(d => d.Id == id));
			return new JsonResult(DataList.OrderBy(d => d.Id));
		}
	}
}
