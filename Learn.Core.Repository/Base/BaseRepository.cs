using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Repository.BASE
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		public Task<int> Add(TEntity model)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteById(object objId)
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

		public int Sum(int i, int j)
		{
			return i + j;
		}

		public Task<bool> UpdateById(object objId)
		{
			throw new NotImplementedException();
		}
	}
}
