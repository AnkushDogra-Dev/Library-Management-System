using LMS.BooksRecordService.API.DependencyInjection;
using LMS.BorrowersRecord.API.DependencyInjection;
using LMS.Identity.API.DependencyInjection;

namespace src.Services.Mono.DependencyInjection {
	public static class DependencyInjection {
		public static IServiceCollection AddMonoApi(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentityService(configuration);
			services.AddBorrowersService(configuration);
			services.AddBooksService(configuration);
			return services;
		}

		public static IServiceCollection AddApiService(this IServiceCollection services, ApiServiceSettings settings)
		{
			foreach(var key in settings.Apis.Keys)
			{
				services.AddHttpClient(key, client => client.BaseAddress = settings.GetBaseUri(key));
			}
			//return services.AddTransient<IApiService, ApiService>();
			return services;
		}


		public static async Task<IApplicationBuilder> UseMonoService(this IApplicationBuilder app)
		{
			await app.UseIdentityServices();
			await app.UseBorrowersService();

			await app.UseBooksService();
			return app;
		}
		}
}