using Learn.Core.Extensions;
using Learn.Core.Common;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
