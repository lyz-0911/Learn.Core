using Learn.Core.Extensions;
using Learn.Core.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

//配置宿主host(DI、log、AppConfig)
builder.Host
	.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacModuleRegister());
		//builder.RegisterModule<AutofacPropertityModuleReg>();
	});


//注册服务
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddAuthentication_JWTSetup();

//构造程序
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	
}
//添加中间件
app.UseSwaggerMiddle();
app.UseAuthentication();//微软官方认证授权
app.UseAuthorization();

app.MapControllers();

app.Run();
