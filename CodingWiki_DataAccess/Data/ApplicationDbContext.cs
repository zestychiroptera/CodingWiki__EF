using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
	internal class ApplicationDbContext : DbContext
	{
        public DbSet<Book> Books { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=ZJW-PC\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

			modelBuilder.Entity<Book>().HasData(
				new Book { IDBook = 1, Title = "Their Eyes Were Watching God", ISBN = "0060838671", Price = 9.99m },
				new Book { IDBook = 2, Title = "The Four Winds", ISBN = "1250178614", Price = 10.76m }
				);

			var bookList = new Book[]
			{
				new Book { IDBook = 3, Title = "The Invisible Life of Addie LaRue", ISBN = "0765387573", Price = 13.50m },
				new Book { IDBook = 4, Title = "The Year of the Flood", ISBN = "9780307455475", Price = 14.49m },
				new Book { IDBook = 5, Title = "Educated", ISBN = "0399590528", Price = 11.41m }
			};

			modelBuilder.Entity<Book>().HasData(bookList);
		}
	}
}
