using Learn.Core.Extensions;
using Learn.Core.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

//��������host(DI��log��AppConfig)
builder.Host
	.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacModuleRegister());
		//builder.RegisterModule<AutofacPropertityModuleReg>();
	});


//ע�����
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddControllers();
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
