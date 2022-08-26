using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Repository.BASE
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		/// <summary>
		/// 根据ID查询一条数据
		/// </summary>
		/// <param name="objId"></param>
		/// <returns></returns>
		Task<TEntity> QueryById(object objId);
		/// <summary>
		/// 查询所有数据
		/// </summary>
		/// <param name="objId"></param>
		/// <returns></returns>
		Task<List<TEntity>> Query();
		/// <summary>
		/// 根据ID更新一条数据
		/// </summary>
		/// <param name="objId"></param>
		/// <returns></returns>
		Task<bool> UpdateById(object objId);
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<int> Add(TEntity model);
		/// <summary>
		/// 根据ID删除一条数据
		/// </summary>
		/// <param name="objId"></param>
		/// <returns></returns>
		Task<bool> DeleteById(object objId);
		/// <summary>
		/// 测试求和方法
		/// </summary>
		/// <param name="i"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		int Sum(int i, int j);

	}
}
