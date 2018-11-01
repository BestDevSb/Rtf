﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RtfWebApp.Data;

namespace RtfWebApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181101104031_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RtfWebApp.Models.Achivment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("SkilId");

                    b.HasKey("Id");

                    b.HasIndex("SkilId");

                    b.ToTable("Achivments");
                });

            modelBuilder.Entity("RtfWebApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("ProfileId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RtfWebApp.Models.EmployeeAchivments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AchivmentId");

                    b.Property<int>("EmployeeId");

                    b.HasKey("Id");

                    b.HasIndex("AchivmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("UserAchivments");
                });

            modelBuilder.Entity("RtfWebApp.Models.EmployeeSolutions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("SolutionId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SolutionId");

                    b.ToTable("EmployeeSolutions");
                });

            modelBuilder.Entity("RtfWebApp.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("RtfWebApp.Models.ProfileSkils", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProfileId");

                    b.Property<int>("SkilId");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("SkilId");

                    b.ToTable("ProfileSkils");
                });

            modelBuilder.Entity("RtfWebApp.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<int>("Rate");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("RtfWebApp.Models.Skil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("RtfWebApp.Models.SkillDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SkilAId");

                    b.Property<int>("SkilBId");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("SkilAId");

                    b.HasIndex("SkilBId");

                    b.ToTable("SkillDependencies");
                });

            modelBuilder.Entity("RtfWebApp.Models.Solution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Solutions");
                });

            modelBuilder.Entity("RtfWebApp.Models.Achivment", b =>
                {
                    b.HasOne("RtfWebApp.Models.Skil", "Skil")
                        .WithMany()
                        .HasForeignKey("SkilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RtfWebApp.Models.Employee", b =>
                {
                    b.HasOne("RtfWebApp.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RtfWebApp.Models.EmployeeAchivments", b =>
                {
                    b.HasOne("RtfWebApp.Models.Achivment", "Achivment")
                        .WithMany()
                        .HasForeignKey("AchivmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RtfWebApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RtfWebApp.Models.EmployeeSolutions", b =>
                {
                    b.HasOne("RtfWebApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RtfWebApp.Models.Solution", "Solution")
                        .WithMany()
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RtfWebApp.Models.ProfileSkils", b =>
                {
                    b.HasOne("RtfWebApp.Models.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RtfWebApp.Models.Skil", "Skil")
                        .WithMany()
                        .HasForeignKey("SkilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RtfWebApp.Models.Rating", b =>
                {
                    b.HasOne("RtfWebApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RtfWebApp.Models.SkillDependency", b =>
                {
                    b.HasOne("RtfWebApp.Models.Skil", "SkilA")
                        .WithMany("Dependencies")
                        .HasForeignKey("SkilAId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("RtfWebApp.Models.Skil", "SkilB")
                        .WithMany("Dependendenties")
                        .HasForeignKey("SkilBId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}