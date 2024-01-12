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
		public DbSet<BookDetail> BookDetails { get; set; }
		public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
		public DbSet<Fluent_Book> Fluent_Book { get; set; }
		public DbSet<Fluent_Publisher> Fluent_Publisher { get; set; }
		public DbSet<Fluent_Author> Fluent_Author { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer("Server=ZJW-PC\\SQLEXPRESS;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Fluent_BookDetail>().ToTable("Fluent_BookDetails");
			modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
			modelBuilder.Entity<Fluent_BookDetail>().Property(u => u.NumberOfChapters).IsRequired();
			modelBuilder.Entity<Fluent_BookDetail>().HasKey(u => u.BookDetail_Id);
			modelBuilder.Entity<Fluent_BookDetail>().HasOne(b => b.Book).WithOne(b => b.BookDetail).HasForeignKey<Fluent_BookDetail>(u => u.IDBook);
			
			modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).HasMaxLength(30);
			modelBuilder.Entity<Fluent_Book>().Property(u => u.ISBN).IsRequired();
			modelBuilder.Entity<Fluent_Book>().HasKey(u => u.IDBook);
			modelBuilder.Entity<Fluent_Book>().Ignore(u => u.PriceRange);
			modelBuilder.Entity<Fluent_Book>().HasOne(u => u.Publisher).WithMany(u => u.Books)
				.HasForeignKey(u => u.Publisher_Id);
			
			modelBuilder.Entity<Fluent_Publisher>().Property(u => u.Name).IsRequired();
			modelBuilder.Entity<Fluent_Publisher>().HasKey(u => u.Publisher_Id);

			
			modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).IsRequired();
			modelBuilder.Entity<Fluent_Author>().Property(u => u.FirstName).HasMaxLength(50);
			modelBuilder.Entity<Fluent_Author>().Property(u => u.LastName).IsRequired();
			modelBuilder.Entity<Fluent_Author>().HasKey(u => u.Author_Id);
			modelBuilder.Entity<Fluent_Author>().Ignore(u => u.FullName);





			modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

			modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.IDBook });

			modelBuilder.Entity<Fluent_BookAuthorMap>().HasKey(u => new { u.Author_Id, u.IDBook });
			modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u => u.Book).WithMany(u => u.BookAuthorMap)
				.HasForeignKey(u => u.IDBook);
			modelBuilder.Entity<Fluent_BookAuthorMap>().HasOne(u => u.Author).WithMany(u => u.BookAuthorMap)
				.HasForeignKey(u => u.Author_Id);



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
