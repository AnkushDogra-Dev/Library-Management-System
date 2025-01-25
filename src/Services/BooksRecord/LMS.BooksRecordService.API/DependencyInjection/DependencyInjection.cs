using LMS.BooksRecordService.API.Persistance;
using Microsoft.EntityFrameworkCore;

namespace LMS.BooksRecordService.API.DependencyInjection
{
	public static class DependencyInjection
	{
		//Extension method to register services in DI Container.
		public static IServiceCollection AddBooksService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BooksDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("LMSDbConnectionString")
				?? throw new InvalidOperationException("Connection string 'LMSDbConnectionString' not found.")));

			services.AddScoped<BooksDbContext>();

			services.AddEndpointsApiExplorer();
			// services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
			// {
			// 	Title = "Books Management System",
			// 	Version = "v1"
			// }));
			services.AddControllers();
			services.AddControllers().AddApplicationPart(typeof(LMS.BooksRecordService.API.Controllers.BooksController).Assembly);

			return services;
		}

		public static async Task<IApplicationBuilder> UseBooksService(this IApplicationBuilder app)
		{
			app.UseHttpsRedirection();
			return app;
		}
	}
}
//}

