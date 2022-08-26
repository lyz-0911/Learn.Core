using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.IServices.BASE
{
	public interface IBaseService<TEntity> where TEntity : class
	{
		Task<int> Add(TEntity model);
		Task<bool> DeleteById(object id);
		Task<bool> UpdateById(object id);
		Task<TEntity> QueryById(object objId);
		Task<List<TEntity>> Query();
		
	}
}
