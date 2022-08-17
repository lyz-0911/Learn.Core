using Learn.Core.Extensions;
using Learn.Core.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Learn.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

//≈‰÷√Àﬁ÷˜host(DI°¢log°¢AppConfig)
builder.Host
	.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<ContainerBuilder>(builder =>
	{
		builder.RegisterModule(new AutofacModuleRegister());
		//builder.RegisterModule<AutofacPropertityModuleReg>();
	});


// Add services to the container.
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	
}
app.UseSwaggerMiddle();
app.UseAuthorization();

app.MapControllers();

app.Run();
