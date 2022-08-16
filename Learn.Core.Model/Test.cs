using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Model
{
	/// <summary>
	/// 测试Model
	/// </summary>
	public class Test
	{
		/// <summary>
		/// 编号ID（主键）
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 年龄
		/// </summary>
		public int Age { get; set; }
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email { get; set; }
	}
}
