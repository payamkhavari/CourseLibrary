﻿// <auto-generated />
using System;
using CourseLibrary.APII.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseLibrary.APII.Migrations
{
    [DbContext(typeof(CourseLibraryDbContext))]
    [Migration("20250330131522_initial3")]
    partial class initial3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseLibrary.APII.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateofBirth")
                        .HasMaxLength(50)
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MainCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("449e14d5-b4dc-41b8-b563-1f229641c6b4"),
                            DateofBirth = new DateTimeOffset(new DateTime(1650, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 30, 0, 0)),
                            FirstName = "Berry",
                            LastName = "Griffin Beak Eldritch",
                            MainCategory = "Ships"
                        },
                        new
                        {
                            Id = new Guid("e5eb6801-effb-474f-aada-96d43e2a7994"),
                            DateofBirth = new DateTimeOffset(new DateTime(1668, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 4, 30, 0, 0)),
                            FirstName = "Nancy",
                            LastName = "Swashbuckler Rye",
                            MainCategory = "Rum"
                        },
                        new
                        {
                            Id = new Guid("1c3c1278-f976-4fda-82e1-d90e8ef03e77"),
                            DateofBirth = new DateTimeOffset(new DateTime(1701, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 30, 0, 0)),
                            FirstName = "Eli",
                            LastName = "Ivory Bones Sweet",
                            MainCategory = "Singing"
                        });
                });

            modelBuilder.Entity("CourseLibrary.APII.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9a494ff2-697f-4496-99ce-bc6b997548e8"),
                            AuthorId = new Guid("1c3c1278-f976-4fda-82e1-d90e8ef03e77"),
                            Description = "Griffin Beak Eldritch",
                            Title = "Romance of Arabica"
                        },
                        new
                        {
                            Id = new Guid("dd569c04-6b46-4326-be09-c9cf9014a1c1"),
                            AuthorId = new Guid("e5eb6801-effb-474f-aada-96d43e2a7994"),
                            Description = "Griffin Beak Eldritch",
                            Title = "Romance of Arabica"
                        },
                        new
                        {
                            Id = new Guid("292765b0-2627-433a-aae1-f58767bda127"),
                            AuthorId = new Guid("1c3c1278-f976-4fda-82e1-d90e8ef03e77"),
                            Description = "Griffin Beak Eldritch",
                            Title = "Romance of Arabica"
                        });
                });

            modelBuilder.Entity("CourseLibrary.APII.Entities.Course", b =>
                {
                    b.HasOne("CourseLibrary.APII.Entities.Author", "Author")
                        .WithMany("Courses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("CourseLibrary.APII.Entities.Author", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
