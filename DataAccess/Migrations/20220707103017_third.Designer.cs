﻿// <auto-generated />
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20220707103017_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Concrete.Developer", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeveloperId"), 1L, 1);

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeveloperId");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            DeveloperId = 1,
                            DeveloperName = "Burak"
                        },
                        new
                        {
                            DeveloperId = 2,
                            DeveloperName = "Merve"
                        },
                        new
                        {
                            DeveloperId = 3,
                            DeveloperName = "Furkan"
                        },
                        new
                        {
                            DeveloperId = 4,
                            DeveloperName = "Enes"
                        },
                        new
                        {
                            DeveloperId = 5,
                            DeveloperName = "Miray"
                        },
                        new
                        {
                            DeveloperId = 6,
                            DeveloperName = "Dilara"
                        },
                        new
                        {
                            DeveloperId = 7,
                            DeveloperName = "Buse"
                        },
                        new
                        {
                            DeveloperId = 8,
                            DeveloperName = "Alper"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.DifficultyLevel", b =>
                {
                    b.Property<int>("DifficultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DifficultyId"), 1L, 1);

                    b.Property<string>("DifficultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DifficultyId");

                    b.ToTable("DifficultyLevels");

                    b.HasData(
                        new
                        {
                            DifficultyId = 1,
                            DifficultyName = "Çok Çok Kolay"
                        },
                        new
                        {
                            DifficultyId = 2,
                            DifficultyName = "Çok Kolay"
                        },
                        new
                        {
                            DifficultyId = 3,
                            DifficultyName = "Kolay"
                        },
                        new
                        {
                            DifficultyId = 4,
                            DifficultyName = "Normal Düzey"
                        },
                        new
                        {
                            DifficultyId = 5,
                            DifficultyName = "Zaman Alıcı"
                        },
                        new
                        {
                            DifficultyId = 6,
                            DifficultyName = "Zor"
                        },
                        new
                        {
                            DifficultyId = 7,
                            DifficultyName = "Çok Zor"
                        },
                        new
                        {
                            DifficultyId = 8,
                            DifficultyName = "Çok Çok Zor"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Analyst"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Personnel"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.TaskModel", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"), 1L, 1);

                    b.Property<int>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int>("DifficultyId")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.ToTable("TaskModels");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@gmail.com",
                            Password = "1234",
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            Email = "analyst@gmail.com",
                            Password = "1234",
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            Email = "personnel@gmail.com",
                            Password = "1234",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.HasOne("Entities.Concrete.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
