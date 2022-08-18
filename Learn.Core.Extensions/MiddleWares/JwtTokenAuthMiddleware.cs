using Learn.Core.Extensions.Authorizations.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Extensions.MiddleWares
{
	/// <summary>
	/// 自定义授权中间件
	/// </summary>
	public class JwtTokenAuthMiddleware
	{
		private readonly RequestDelegate _next;
		public JwtTokenAuthMiddleware(RequestDelegate next)
		{
			_next=next;
		}
		public Task Invoke(HttpContext httpContext)
		{
			//检测是否包含'Authorization'请求头
			if(!httpContext.Request.Headers.ContainsKey("Authorization"))
			{
				return _next(httpContext);
			}
			//取出token
			var tokenHeader = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

			try
			{
				if(tokenHeader.Length>=128)
				{
					TokenModelJwt tm = JwtHelper.SerializeJwt(tokenHeader);
				}
			}
			catch (Exception)
			{

				throw;
			}

			return _next(httpContext);
		}
	}
}
