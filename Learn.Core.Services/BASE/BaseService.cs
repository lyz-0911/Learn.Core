using Learn.Core.IServices.BASE;
using Learn.Core.Repository.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Services.BASE
{
	public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
		public IBaseRepository<TEntity> _baseDal { get; set; }//基类不用构造函数注入
		public async Task<int> Add(TEntity model)
		{
			return await _baseDal.Add(model);
		}

		public async Task<bool> DeleteById(object id)
		{
			return await _baseDal.DeleteById(id);
		}

		public async Task<List<TEntity>> Query()
		{
			throw new NotImplementedException();
		}

		public async Task<TEntity> QueryById(object objId)
		{
			throw new NotImplementedException();
		}

		

		public async Task<bool> UpdateById(object id)
		{
			throw new NotImplementedException();
		}
	}
}
