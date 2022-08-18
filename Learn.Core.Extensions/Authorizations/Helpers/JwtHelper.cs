using Learn.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Learn.Core.Extensions.Authorizations.Helpers
{
	public class JwtHelper
	{
        /// <summary>
        /// 生成JWT
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
		public static string IssueJwt(TokenModelJwt tokenModel)
		{
            //读取Jwt配置信息
            string iss = Appsettings.app(new string[] { "JwtCofing", "Issuer" });//颁发令牌方（服务端）
            string aud = Appsettings.app(new string[] { "JwtCofing", "Audience" });//令牌使用方（子客户端）
            string secret = Appsettings.app(new string[] { "JwtCofing", "Secret" });//加密秘钥

            //JWT有效载荷 也就是jwt三部分中的 中间body部分
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,tokenModel.Uid),//用户ID
                new Claim(JwtRegisteredClaimNames.Iat,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),//jwt创建时间 
                new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),//jwt被接受处理之前的时间
                new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds().ToString()),//过期时间
                new Claim(ClaimTypes.Expiration,DateTime.Now.AddSeconds(1000).ToString()),//
                new Claim(JwtRegisteredClaimNames.Iss,iss),//颁布者
                new Claim(JwtRegisteredClaimNames.Aud,aud),//使用者
                //new Claim(ClaimTypes.Role,tokenModel.Role),//权限  下面代码添加多权限
            };
            claims.AddRange(tokenModel.Role.Split(',').Select(s=>new Claim(ClaimTypes.Role,s)));//一个用户多角色

            //处理秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));//SymmetricSecurityKey会对秘钥进行检测，秘钥长度少于16位会报异常
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//设置秘钥加密方法

            //实例jwt对象
            var jwt = new JwtSecurityToken(
                issuer: iss,
                claims: claims,
                signingCredentials: creds);

            var jwtHandler = new JwtSecurityTokenHandler();//实例jwt操作类
            var encodedJwt = jwtHandler.WriteToken(jwt);//生成jwt字符

            return encodedJwt;
        }

        /// <summary>
        /// 解析JWT
        /// </summary>
        /// <param name="jwtStr"></param>
        /// <returns></returns>
        public static TokenModelJwt SerializeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            TokenModelJwt tokenModelJwt = new TokenModelJwt();

            // token校验
            if (!jwtStr.IsNullOrEmpty() && jwtHandler.CanReadToken(jwtStr))
            {
                //解析jwt字符串成对象
                JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);

                object role;
                //获取权限数据
                jwtToken.Payload.TryGetValue(ClaimTypes.Role, out role);

                tokenModelJwt = new TokenModelJwt
                {
                    Uid = jwtToken.Id,
                    Role = role != null ? role.ToString() : "",
                };
            }
            return tokenModelJwt;

        }
    }
	public class TokenModelJwt
	{
        /// <summary>
        /// Id
        /// </summary>
        public string Uid { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// 职能
        /// </summary>
        public string Work { get; set; }
    }
}
