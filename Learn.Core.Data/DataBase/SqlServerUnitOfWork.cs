using Learn.Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learn.Core.Data.DataBase
{
	public class SqlServerUnitOfWork:UnitOfWork
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionSt = Appsettings.app(new string[]{ "DbConfig", "Connection" });
			optionsBuilder.UseSqlServer(connectionSt);
			
		}
	}
}
