﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShortUrl;

namespace ShortUrl.Migrations
{
    [DbContext(typeof(LinksContext))]
    partial class LinksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShortUrl.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("CreatedData")
                        .HasColumnType("text");

                    b.Property<string>("LongURL")
                        .HasColumnType("text");

                    b.Property<string>("ShortUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });
#pragma warning restore 612, 618
        }
    }
}