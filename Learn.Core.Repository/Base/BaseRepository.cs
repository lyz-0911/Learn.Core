using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Repository.Base
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
	{
		public Task<int> Add(TEntity model)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteById(object id)
		{
			throw new NotImplementedException();
		}

		public Task<List<TEntity>> Query()
		{
			throw new NotImplementedException();
		}

		public Task<TEntity> QueryById(object objId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(TEntity model)
		{
			throw new NotImplementedException();
		}
	}
}
