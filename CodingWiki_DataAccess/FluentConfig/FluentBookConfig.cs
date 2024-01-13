using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
	public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
	{
		public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
		{
			
			modelBuilder.Property(u => u.ISBN).HasMaxLength(30);
			modelBuilder.Property(u => u.ISBN).IsRequired();
			modelBuilder.HasKey(u => u.IDBook);
			modelBuilder.Ignore(u => u.PriceRange);
			modelBuilder.HasOne(u => u.Publisher).WithMany(u => u.Books)
				.HasForeignKey(u => u.Publisher_Id);
		}
	}
}
