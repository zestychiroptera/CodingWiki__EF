using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
	public class ApplicationDbContext : DbContext
	{
        public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
		public DbSet<BookDetail> BookDetails { get; set; }
		public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
		public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
		public DbSet<Fluent_Book> Fluent_Book { get; set; }
		public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }
		public DbSet<Fluent_Author> Fluent_Author { get; set; }
		public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=ZJW-PC\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
				.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
			modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.IDBook });

			modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
			modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
			modelBuilder.ApplyConfiguration(new FluentBookConfig());
			modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
			modelBuilder.ApplyConfiguration(new FluentPublisherConfig());


			modelBuilder.Entity<Book>().HasData(
				new Book { IDBook = 1, Title = "Their Eyes Were Watching God", ISBN = "0060838671", Price = 9.99m, Publisher_Id = 1 },
				new Book { IDBook = 2, Title = "The Four Winds", ISBN = "1250178614", Price = 10.76m, Publisher_Id = 1 }
				);

			var bookList = new Book[]
			{
				new Book { IDBook = 3, Title = "The Invisible Life of Addie LaRue", ISBN = "0765387573", Price = 13.50m, Publisher_Id = 2 },
				new Book { IDBook = 4, Title = "The Year of the Flood", ISBN = "9780307455475", Price = 14.49m, Publisher_Id = 3 },
				new Book { IDBook = 5, Title = "Educated", ISBN = "0399590528", Price = 11.41m, Publisher_Id = 3 }
			};

			modelBuilder.Entity<Book>().HasData(bookList);


			modelBuilder.Entity<Publisher>().HasData(
				new Publisher { Publisher_Id = 1, Name = "James Carole", Location = "New York" },
				new Publisher { Publisher_Id = 2, Name = "Robin Reynolds", Location = "Miami" },
				new Publisher { Publisher_Id = 3, Name = "Heather Smith", Location = "Saint Paul" }
				);

		}
	}
}
