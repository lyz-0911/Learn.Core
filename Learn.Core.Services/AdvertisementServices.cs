using Learn.Core.IServices;
using Learn.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Services
{
	public class AdvertisementServices : IAdvertisementServices
	{
		public void Test()
		{


			throw new ApplicationException("这是一个测试日志AOP的切面！");
			
			
		}

		public List<Advertisement> TestAOP() => new List<Advertisement>() { new Advertisement() { Id = 1, Name = "测试AOP" } };
		
	}
}
