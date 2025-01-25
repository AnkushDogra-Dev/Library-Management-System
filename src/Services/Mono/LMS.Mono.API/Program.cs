using Microsoft.OpenApi.Models;
using src.Services.Mono.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
// Add Services
builder.Services.AddMonoApi(builder.Configuration);
var apiServiceSettings = builder.Configuration.GetSection("ApiServiceSettings").Get<ApiServiceSettings>();
builder.Services.AddApiService(apiServiceSettings!);

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "Library Management System",
				Version = "v1"
			}));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c =>
{
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
});

// User Services
await app.UseMonoService();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

await app.RunAsync();
