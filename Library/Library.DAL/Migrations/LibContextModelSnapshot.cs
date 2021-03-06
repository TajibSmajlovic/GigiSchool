﻿// <auto-generated />
using System;
using Library.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.DAL.Migrations
{
    [DbContext(typeof(LibContext))]
    partial class LibContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Library.DAL.AuthBooks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorId");

                    b.Property<int?>("BookId");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Creator");

                    b.Property<bool>("Deleted");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthBooks");
                });

            modelBuilder.Entity("Library.DAL.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Creator");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.DAL.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<int>("Creator");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<int>("Pages");

                    b.Property<decimal>("Price");

                    b.Property<int?>("PublisherId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.DAL.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Creator");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.Property<string>("Road");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("Library.DAL.AuthBooks", b =>
                {
                    b.HasOne("Library.DAL.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.HasOne("Library.DAL.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("Library.DAL.Book", b =>
                {
                    b.HasOne("Library.DAL.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");
                });
#pragma warning restore 612, 618
        }
    }
}
