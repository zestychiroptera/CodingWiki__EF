﻿// <auto-generated />
using System;
using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240111232020_addFluent_BookDetailToDb")]
    partial class addFluent_BookDetailToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.7.22376.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingWiki_Model.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Property<int>("IDBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDBook"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDBook");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            IDBook = 1,
                            ISBN = "0060838671",
                            Price = 9.99m,
                            Publisher_Id = 1,
                            Title = "Their Eyes Were Watching God"
                        },
                        new
                        {
                            IDBook = 2,
                            ISBN = "1250178614",
                            Price = 10.76m,
                            Publisher_Id = 1,
                            Title = "The Four Winds"
                        },
                        new
                        {
                            IDBook = 3,
                            ISBN = "0765387573",
                            Price = 13.50m,
                            Publisher_Id = 2,
                            Title = "The Invisible Life of Addie LaRue"
                        },
                        new
                        {
                            IDBook = 4,
                            ISBN = "9780307455475",
                            Price = 14.49m,
                            Publisher_Id = 3,
                            Title = "The Year of the Flood"
                        },
                        new
                        {
                            IDBook = 5,
                            ISBN = "0399590528",
                            Price = 11.41m,
                            Publisher_Id = 3,
                            Title = "Educated"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookAuthorMap", b =>
                {
                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.Property<int>("IDBook")
                        .HasColumnType("int");

                    b.HasKey("Author_Id", "IDBook");

                    b.HasIndex("IDBook");

                    b.ToTable("BookAuthorMap");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("IDBook")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("IDBook")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Fluent_BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("int")
                        .HasColumnName("NoOfChapters");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookDetail_Id");

                    b.ToTable("Fluent_BookDetails", (string)null);
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Publisher_Id = 1,
                            Location = "New York",
                            Name = "James Carole"
                        },
                        new
                        {
                            Publisher_Id = 2,
                            Location = "Miami",
                            Name = "Robin Reynolds"
                        },
                        new
                        {
                            Publisher_Id = 3,
                            Location = "Saint Paul",
                            Name = "Heather Smith"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategory_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategory_Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubCategory_Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookAuthorMap", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Author", "Author")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodingWiki_Model.Models.Book", "Book")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("IDBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.BookDetail", b =>
                {
                    b.HasOne("CodingWiki_Model.Models.Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("CodingWiki_Model.Models.BookDetail", "IDBook")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Author", b =>
                {
                    b.Navigation("BookAuthorMap");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Navigation("BookAuthorMap");

                    b.Navigation("BookDetail");
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
