using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		
        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
		public DbSet<NewsItem> NewsItems { get; set; }
		public DbSet<TechMessage> TechMessages { get; set; }
		public DbSet<NewsMessage> NewsMessages { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = "2B29F253-6559-45F0-83AC-611F6AB6103B",
				Name = "admin",
				NormalizedName = "ADMIN"
			});

			builder.Entity<IdentityUser>().HasData(new IdentityUser
			{
				Id = "404E976E-F70E-43B6-BE11-8EA8BAF188B3",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "my@email.com",
				NormalizedEmail = "MY@EMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
				SecurityStamp = string.Empty
			});

			builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
			{
				RoleId = "2B29F253-6559-45F0-83AC-611F6AB6103B",
				UserId = "404E976E-F70E-43B6-BE11-8EA8BAF188B3"
			});

			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("215A0BCC-A960-4135-9147-CBC78A84DFA1"),
				CodeWord = "PageIndex",
				Title = "Главная"
			});
			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("67C3D69D-E26E-42BF-98F1-7DE7382E3F02"),
				CodeWord = "PageServices",
				Title = "Наши услуги"
			});
			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("4269A391-B514-44AB-A7CC-DF2C68F5BDB1"),
				CodeWord = "PageContacts",
				Title = "Контакты"
			});
			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("A1EE5619-A8C9-4732-88F6-0866B954AA4E"),
				CodeWord = "PageNews",
				Title = "Новости"
			});
		}
	}
}
