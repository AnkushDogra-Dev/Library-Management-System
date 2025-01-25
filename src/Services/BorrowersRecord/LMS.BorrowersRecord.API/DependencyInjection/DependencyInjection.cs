using LMS.BorrowersRecord.API.Entities;
using LMS.BorrowersRecord.API.Persistance;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace LMS.BorrowersRecord.API.DependencyInjection {
	public static class DependencyInjection {
		public static IServiceCollection AddBorrowersService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<BorrowerDbContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("LMSDbConnectionString")
				?? throw new InvalidOperationException("Connection string 'LMSDbConnectionString' not found.")));

			services.AddScoped<BorrowerDbContext>();

			services.AddEndpointsApiExplorer();

			//services.AddSingleton<IHostedService, DbInitializerService>();
			services.AddControllers().AddApplicationPart(typeof(LMS.BorrowersRecord.API.Controllers.BorrowersController).Assembly);

			return services;
		}

		public static async Task<IApplicationBuilder> UseBorrowersService(this IApplicationBuilder app)
		{
			return app;
		}
		}
	}
//}

