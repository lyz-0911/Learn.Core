﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Common;
using static Learn.Core.Extensions.CustomApiVersion;
using Microsoft.OpenApi.Models;

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
				//typeof(ApiVersions).GetEnumNames().ToList().ForEach(version =>
				//{
				//	c.SwaggerDoc(version, new OpenApiInfo
				//	{
				//		Version = version,
				//		Title = $"{ApiName} 接口文档",
				//		Description = $"{ApiName} HTTP API {version}",
				//		Contact = new OpenApiContact { Name = "刘永振", Email = "774056136@qq.com" },
				//		License = new OpenApiLicense { Name = "官方文档", Url = new Uri("http://apk.neters.club/.doc/") }
				//	});
				//});

				try
				{
					var xmlApiPath = Path.Combine(basePath, "Learn.Core.Api.xml");
					c.IncludeXmlComments(xmlApiPath, true);
					var xmlModelPath = Path.Combine(basePath, "Learn.Core.Model.xml");
					c.IncludeXmlComments(xmlModelPath, true);

				}
				catch (Exception ex)
				{

					throw ex;
				}
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