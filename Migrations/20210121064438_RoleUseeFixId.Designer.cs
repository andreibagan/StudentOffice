﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentOffice.Models;

namespace StudentOffice.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210121064438_RoleUseeFixId")]
    partial class RoleUseeFixId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("StudentOffice.Models.Anketa", b =>
                {
                    b.Property<int>("AnketaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AddressFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressMother")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfValidity")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HullNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Institution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IssuedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KinshipTypeFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KinshipTypeMother")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddlenameFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddlenameMother")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddlenameR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameMother")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfSettlement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeries")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfWorkAndPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Postcode")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeniorityGeneral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeniorityProfileSpecialty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<bool>("SocialBehavior")
                        .HasColumnType("bit");

                    b.Property<string>("Specialty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurnameFather")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurnameMother")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurnameR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfSettlement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YearOfEnding")
                        .HasColumnType("datetime2");

                    b.HasKey("AnketaId");

                    b.ToTable("Anketa");
                });

            modelBuilder.Entity("StudentOffice.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("StudentOffice.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "user"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "student"
                        },
                        new
                        {
                            RoleId = 4,
                            Name = "teacher"
                        });
                });

            modelBuilder.Entity("StudentOffice.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AnketaId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("AnketaId");

                    b.HasIndex("GroupId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@mail.ru",
                            Password = "12345",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("StudentOffice.Models.User", b =>
                {
                    b.HasOne("StudentOffice.Models.Anketa", "Anketa")
                        .WithMany("Users")
                        .HasForeignKey("AnketaId");

                    b.HasOne("StudentOffice.Models.Group", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId");

                    b.HasOne("StudentOffice.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anketa");

                    b.Navigation("Group");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("StudentOffice.Models.Anketa", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("StudentOffice.Models.Group", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("StudentOffice.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
