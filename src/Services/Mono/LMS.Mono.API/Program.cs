using Microsoft.OpenApi.Models;
using src.Services.Mono.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMonoApi(builder.Configuration);
var apiServiceSettings = builder.Configuration.GetSection("ApiServiceSettings").Get<ApiServiceSettings>();
builder.Services.AddApiService(apiServiceSettings!);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> c.SwaggerDoc("v1", new OpenApiInfo
{
	Title = "test Management System",
	Version = "v1"
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UseMonoService();
app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseRouting();
//app.UseAuthorization();

//app.MapControllers();

app.Run();
