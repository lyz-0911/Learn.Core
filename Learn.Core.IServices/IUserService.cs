using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.IServices.BASE;
using Learn.Core.Model.Entities;

namespace Learn.Core.IServices
{
	public interface IUserService:IBaseService<User>
	{
		int Sum(int i, int j);
	}
}
