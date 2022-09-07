using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Extensions.AutoMapper
{
	public class CustomProfile:Profile
	{
		/// <summary>
		/// 配置构造函数，在构造函数里进行数据entity与viewmodel对象的关系映射
		/// </summary>
		public CustomProfile()
		{

		}
	}
}
