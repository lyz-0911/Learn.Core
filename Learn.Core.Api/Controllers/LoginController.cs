using Learn.Core.Extensions.Authorizations.Helpers;
using Learn.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Core.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		/// <summary>
		/// 获取JWT
		/// </summary>
		/// <param name="name">用户名</param>
		/// <param name="password">密码</param>
		/// <returns></returns>
		[HttpGet]
		[Route("Token")]
		public async Task<MessageModel<string>> GetJwt(string name, string password)
		{
			string jwtStr = string.Empty;
			bool suc=false;

			//判断用户登录，并读取用户权限
			//var user = await _sysUserInfoServices.GetUserRoleNameStr(name, MD5Helper.MD5Encrypt32(pass));
			var user = name;
			if(user!=null)
			{
				TokenModelJwt tokenModel = new TokenModelJwt { Uid = new Guid().ToString(), Role = user };

				jwtStr = JwtHelper.IssueJwt(tokenModel);
				suc = true;
			}
			else
			{
				jwtStr = "登录错误！";
			}
			return new MessageModel<string>()
			{
				success = suc,
				msg = suc ? "获取成功" : "获取失败",
				response = jwtStr
			};
		}
	}
}
