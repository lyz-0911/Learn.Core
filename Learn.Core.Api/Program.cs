using Learn.Core.Extensions;
using Learn.Core.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using static Learn.Core.Api.Filter.GlobalExceptionFilter;

var builder = WebApplication.CreateBuilder(args);

//��������host(DI��log��AppConfig)
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


//ע�����
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddControllers(o =>
{
	o.Filters.Add(typeof(GlobalExceptionsFilter));//���ȫ���쳣����

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddAuthentication_JWTSetup();

//�������
var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}
//����м��
app.UseSwaggerMiddle();
app.UseAuthentication();//΢��ٷ���֤��Ȩ
app.UseAuthorization();

app.MapControllers();

app.Run();
