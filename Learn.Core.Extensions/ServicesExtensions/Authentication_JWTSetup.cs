using Learn.Core.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Extensions
{

	/// <summary>
	/// JWT权限 认证服务
	/// </summary>
	public static class Authentication_JWTSetup
	{
		public static void AddAuthentication_JWTSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));


			var symmetricKeyAsBase64 =Appsettings.app(new string[] { "JwtCofing", "Secret" });
			var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
			var signingKey = new SymmetricSecurityKey(keyByteArray);
			var Issuer = Appsettings.app(new string[] { "JwtCofing", "Issuer" });
			var Audience = Appsettings.app(new string[] { "JwtCofing", "Audience" });

			var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

			// 令牌验证参数
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = signingKey,
				ValidateIssuer = true,
				ValidIssuer = Issuer,//发行人
				ValidateAudience = true,
				ValidAudience = Audience,//订阅人
				ValidateLifetime = true,
				ClockSkew = TimeSpan.FromSeconds(30),//这个是缓冲过期时间，也就是说，即使我们配置了过期时间，这里也要考虑进去，过期时间+缓冲
				RequireExpirationTime = true
			};
			// 开启认证服务
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			 // 添加JwtBearer服务
			 .AddJwtBearer(o =>
			 {
				 o.TokenValidationParameters = tokenValidationParameters;
			 });
		}
	}
}

