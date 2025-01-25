using LMS.BooksRecordService.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBooksService(builder.Configuration);

builder.Configuration.AddUserSecrets<Program>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.UseBooksService();

app.Run();