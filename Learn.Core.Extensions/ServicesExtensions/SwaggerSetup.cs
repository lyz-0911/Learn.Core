using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Common;
using static Learn.Core.Extensions.CustomApiVersion;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Learn.Core.Extensions
{
	/// <summary>
	/// swagger 启动服务
	/// </summary>
	public static class SwaggerSetup
	{
		public static void AddSwaggerSetup(this IServiceCollection services)
		{
			if(services==null)throw new ArgumentNullException(nameof(services));
            var basePath = AppContext.BaseDirectory;
            var ApiName = Appsettings.app(new string[] { "Startup", "ApiName" });

   
			services.AddSwaggerGen(c =>
			{
				//遍历所有版本
				typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
				{
					c.SwaggerDoc(version, new OpenApiInfo
					{
						Version = version,
						Title = $"{ApiName} 接口文档",
						Description = $"{ApiName} HTTP API {version}",
						Contact = new OpenApiContact { Name = "刘永振", Email = "774056136@qq.com" },
						License = new OpenApiLicense { Name = "官方文档", Url = new Uri("http://apk.neters.club/.doc/") }
					});
					c.OrderActionsBy(o => o.RelativePath);
				});

				try
				{
					var xmlApiPath = Path.Combine(basePath, "Learn.Core.Api.xml");
					c.IncludeXmlComments(xmlApiPath, true);
					var xmlModelPath = Path.Combine(basePath, "Learn.Core.Model.xml");
					c.IncludeXmlComments(xmlModelPath);

				}
				catch (Exception ex)
				{

					throw ex;
				}


				// 开启加权小锁 使用过滤器扩展swagger生成器
				c.OperationFilter<AddResponseHeadersFilter>();
				c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

				// 在header中添加token，传递到后台
				c.OperationFilter<SecurityRequirementsOperationFilter>();

				//加入Jwt Bearer 认证，必须是 oauth2
				c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
					Name = "Authorization",//jwt默认的参数名称
					In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
					Type = SecuritySchemeType.ApiKey //安全方案的类型
				}); 
			});

			
		}
	}

    /// <summary>
    /// 自定义版本
    /// </summary>
    public class CustomApiVersion
    {
        /// <summary>
        /// Api接口版本 自定义
        /// </summary>
        public enum ApiVersions
        {
            /// <summary>
            /// V1 版本
            /// </summary>
            V1 = 1,
            /// <summary>
            /// V2 版本
            /// </summary>
            V2 = 2,
        }
    }
}
