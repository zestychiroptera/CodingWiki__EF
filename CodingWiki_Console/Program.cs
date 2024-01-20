// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//using (ApplicationDbContext context = new())
//{
//	context.Database.EnsureCreated();
//	if(context.Database.GetPendingMigrations().Count() > 0)
//	{
//		context.Database.Migrate();
//	}
//}

//AddBook();
//GetAllBooks();
//GetBook();
//UpdateBook();
//DeleteBook();

//async void DeleteBook()
//{
//	using var context = new ApplicationDbContext();
//	var book = await context.Books.FindAsync(9);
//	context.Books.Remove(book);
//	await context.SaveChangesAsync();
//}

//async void UpdateBook()
//{
//	try
//	{
//		using var context = new ApplicationDbContext();
//		var books = await context.Books.Where(u=>u.Publisher_Id==1).ToListAsync();
//		//Console.WriteLine($"{book.Title} - {book.ISBN}");
//		foreach (var book in books)
//		{
//			book.Price = 55.55m;
//		}
//		context.SaveChanges();
		
//	}
//	catch (Exception e)
//	{

//	}
//}

//async void GetBook()
//{
//	try
//	{
//		using var context = new ApplicationDbContext();
//		var input = "Educated";
//		//var book = context.Books.FirstOrDefault(u => u.Title == input);
//		//var book = context.Books.Find(8);
//		//var book = context.Books.Single(u => u.ISBN == "9780307455475");
//		//var books = context.Books.Where(u => u.ISBN.Contains("12"));
//		//var books = context.Books.Where(u =>EF.Functions.Like(u.ISBN,"12%"));
//		//var books = context.Books.Where(u=>u.Price>10).OrderBy(u=>u.Title).ThenByDescending(u=>u.ISBN);
//		var books = await context.Books.Skip(0).Take(2).ToListAsync();
//		//Console.WriteLine($"{book.Title} - {book.ISBN}");
//		foreach (var book in books)
//		{
//			Console.WriteLine($"{book.Title} - {book.ISBN}");

//		}
//		books = await context.Books.Skip(4).Take(1).ToListAsync();
//		//Console.WriteLine($"{book.Title} - {book.ISBN}");
//		foreach (var book in books)
//		{
//			Console.WriteLine($"{book.Title} - {book.ISBN}");

//		}
//	}
//	catch (Exception e)
//	{

//	}
	
//}

//void GetAllBooks()
//{
//	using var context = new ApplicationDbContext();
//	var books = context.Books.ToList();
//	foreach (var book in books)
//	{
//		//Console.WriteLine(book.Title + " - " + book.ISBN);
//		Console.WriteLine($"{book.Title} - {book.ISBN}");

//	}	
//}
//async void AddBook()
//{
//	Book book = new() { Title = "New EF Core Book", ISBN = "999999", Price = 10.93m, Publisher_Id = 1 };
//	using var context = new ApplicationDbContext();
//	var books = await context.Books.AddAsync(book);
//	await context.SaveChangesAsync();
//}