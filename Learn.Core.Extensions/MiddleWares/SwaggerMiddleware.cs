using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Learn.Core.Common;

namespace Learn.Core.Extensions
{
	/// <summary>
	/// swagger中间件
	/// </summary>
	public static class SwaggerMiddleware
	{
		public static void UseSwaggerMiddle(this IApplicationBuilder app)
		{
			if(app== null)throw new ArgumentNullException(nameof(app));

			app.UseSwagger();
			app.UseSwaggerUI();
			//app.UseSwaggerUI(c =>
			//{
			//	var apiName = Appsettings.app(new string[] { "Startup", "ApiName" });
			//});
		}
	}
}
