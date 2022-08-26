using Learn.Core.IServices;
using Learn.Core.Model.Entities;
using Learn.Core.Repository.BASE;
using Learn.Core.Services.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Services
{
	internal class UserService :  BaseService<User>,IUserService
	{

		public  int Sum(int i, int j)
		{
			return i+ j;
		}	
	}
}
