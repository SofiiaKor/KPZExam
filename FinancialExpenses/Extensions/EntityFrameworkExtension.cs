using FinancialExpenses.Interfaces;
using FinancialExpenses.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FinancialExpenses.Extensions
{
	public static class EntityFrameworkExtension
	{
		public static IServiceCollection WithEntityFramework(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("DefaultConnection"),
					b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

			return services;
		}

		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinancialExpenses", Version = "v1" });
			});

			return services;
		}

		public static IApplicationBuilder MigrateDb(this IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
			if (serviceScope == null) return app;
			var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			context.Database.Migrate();

			return app;
		}

		// Service extensions
		// Move to separate file in Extensions
		public static IServiceCollection WithServices(this IServiceCollection services)
		{
			services.AddTransient<IExpenseService, ExpenseService>();

			return services;
		}

	}
}