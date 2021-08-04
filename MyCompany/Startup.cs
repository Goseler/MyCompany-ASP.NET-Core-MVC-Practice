using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Domain;
using MyCompany.Domain.Repositories.Abstract;
using MyCompany.Domain.Repositories.EntityFramework;
using MyCompany.Models;
using MyCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration ) => Configuration = configuration;

		public void ConfigureServices(IServiceCollection services)
		{
			// Connect config from appsettings.json
			Configuration.Bind("Project", new Config());

			// Connect required functionality as services
			services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
			services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
			services.AddTransient<DataManager>();

			// Connect context DB
			string connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(connection));

			// Set up identity system
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.User.RequireUniqueEmail = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireDigit = false;
			}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

			// Set up authentication cookie
			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.Name = "myCompanyAuth";
				options.Cookie.HttpOnly = true;
				options.LoginPath = "/account/login";
				options.AccessDeniedPath = "/account/accesdenied";
				options.SlidingExpiration = true;
			});

			// Set up authorization policy for Admin area
			services.AddAuthorization(x =>
			{
				x.AddPolicy("AdminArea", policy =>
				{
					policy.RequireRole("admin");
				});
			});

			// Add services for controllers and views(MVC)
			services.AddControllersWithViews(x =>
				{
					x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				.AddSessionStateTempDataProvider();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) 
				app.UseDeveloperExceptionPage();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseCookiePolicy();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "admin",
					pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
