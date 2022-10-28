﻿// <auto-generated />
using System;
using Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Context.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221022144415_addMigration")]
    partial class addMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.BugetPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("April")
                        .HasColumnType("money");

                    b.Property<decimal>("August")
                        .HasColumnType("money");

                    b.Property<decimal>("December")
                        .HasColumnType("money");

                    b.Property<int>("DeparmentId")
                        .HasColumnType("integer");

                    b.Property<decimal>("February")
                        .HasColumnType("money");

                    b.Property<decimal>("January")
                        .HasColumnType("money");

                    b.Property<decimal>("July")
                        .HasColumnType("money");

                    b.Property<decimal>("June")
                        .HasColumnType("money");

                    b.Property<decimal>("March")
                        .HasColumnType("money");

                    b.Property<decimal>("May")
                        .HasColumnType("money");

                    b.Property<decimal>("November")
                        .HasColumnType("money");

                    b.Property<decimal>("October")
                        .HasColumnType("money");

                    b.Property<decimal>("September")
                        .HasColumnType("money");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId")
                        .IsUnique();

                    b.ToTable("bugetPlans");
                });

            modelBuilder.Entity("Domain.Model.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("Domain.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BugetPlanId")
                        .HasColumnType("integer");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("budget")
                        .HasColumnType("money");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasAlternateKey("CompanyId", "Name");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Domain.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Domain.Model.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Confirm")
                        .HasColumnType("boolean");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int>("EmploeeId")
                        .HasColumnType("integer");

                    b.Property<int>("ExpenseTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("Valid")
                        .HasColumnType("boolean");

                    b.Property<decimal>("amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("employeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ExpenseTypeId");

                    b.HasIndex("employeeId");

                    b.ToTable("expenses");
                });

            modelBuilder.Entity("Domain.Model.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Limit")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("expenseTypes");
                });

            modelBuilder.Entity("Domain.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "user",
                            createDate = new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9224),
                            modifyDate = new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9224)
                        },
                        new
                        {
                            Id = 1,
                            Name = "owner",
                            createDate = new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9220),
                            modifyDate = new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9222)
                        },
                        new
                        {
                            Id = 2,
                            Name = "accountant",
                            createDate = new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9223),
                            modifyDate = new DateTime(2022, 10, 22, 14, 44, 15, 680, DateTimeKind.Utc).AddTicks(9223)
                        });
                });

            modelBuilder.Entity("Domain.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Domain.Model.BugetPlan", b =>
                {
                    b.HasOne("Domain.Model.Department", "Department")
                        .WithOne("bugetPlan")
                        .HasForeignKey("Domain.Model.BugetPlan", "DeparmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.Model.Department", b =>
                {
                    b.HasOne("Domain.Model.Company", "Company")
                        .WithMany("departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Model.Employee", b =>
                {
                    b.HasOne("Domain.Model.Department", "Department")
                        .WithMany("employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Model.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.Model.Expense", b =>
                {
                    b.HasOne("Domain.Model.Department", "department")
                        .WithMany("Expenses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.ExpenseType", "expenseType")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Employee", "employee")
                        .WithMany("Expenses")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("department");

                    b.Navigation("employee");

                    b.Navigation("expenseType");
                });

            modelBuilder.Entity("Domain.Model.ExpenseType", b =>
                {
                    b.HasOne("Domain.Model.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Model.User", b =>
                {
                    b.HasOne("Domain.Model.Role", "role")
                        .WithMany("users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("Domain.Model.Company", b =>
                {
                    b.Navigation("departments");
                });

            modelBuilder.Entity("Domain.Model.Department", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("bugetPlan")
                        .IsRequired();

                    b.Navigation("employees");
                });

            modelBuilder.Entity("Domain.Model.Employee", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Domain.Model.ExpenseType", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Domain.Model.Role", b =>
                {
                    b.Navigation("users");
                });
#pragma warning restore 612, 618
        }
    }
}
