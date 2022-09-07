using Learn.Core.Extensions.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Extensions.ServicesExtensions
{
	public static class AutoMapperSetup
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			if(services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper(typeof(AutoMapperConfig));
			
		}
	}
}
