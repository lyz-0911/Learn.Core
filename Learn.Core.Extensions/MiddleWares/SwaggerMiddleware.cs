using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Learn.Core.Common;
using static Learn.Core.Extensions.CustomApiVersion;

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
            app.UseSwaggerUI(c =>
            {
                //根据版本名称倒序 遍历展示
                var apiName = Appsettings.app(new string[] { "Startup", "ApiName" });
                typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{apiName} {version}");
                });

                //c.SwaggerEndpoint($"{外联其他接口文档json地址}", $"{apiName} pet");可以接入其他的接口文档。                                   
            });
        }
	}
}
