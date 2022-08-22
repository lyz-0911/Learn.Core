using Learn.Core.Extensions;
using Learn.Core.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static Learn.Core.Api.Filter.GlobalExceptionFilter;

var builder = WebApplication.CreateBuilder(args);

//配置宿主host(DI、log、AppConfig)
builder.Host
	.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacModuleRegister());
		//builder.RegisterModule<AutofacPropertityModuleReg>();
	})
	.ConfigureLogging((hostingContext, builder) =>
	{
		builder.AddFilter("System", LogLevel.Error);
		builder.AddFilter("Microsoft", LogLevel.Error);
		builder.SetMinimumLevel(LogLevel.Error);
		builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "Log4net.config"));
	});


//注册服务
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddControllers(o =>
{
	o.Filters.Add(typeof(GlobalExceptionsFilter));//添加全局异常服务

});

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
