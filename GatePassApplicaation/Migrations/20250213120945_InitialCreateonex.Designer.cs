﻿// <auto-generated />
using System;
using GatePassApplicaation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GatePassApplicaation.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250213120945_InitialCreateonex")]
    partial class InitialCreateonex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GatePassApplicaation.Models.Action", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActionId"));

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActionId");

                    b.ToTable("actions");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateTime")
                        .HasColumnType("date");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassNo")
                        .HasColumnType("int");

                    b.Property<string>("PreparedPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReasonId")
                        .HasColumnType("int");

                    b.Property<string>("SendTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("takenBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ReasonId");

                    b.ToTable("passHeaders");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeaderAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorizedPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateTime")
                        .HasColumnType("date");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassNo")
                        .HasColumnType("int");

                    b.Property<string>("PreparedPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReasonId")
                        .HasColumnType("int");

                    b.Property<string>("SendTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("takenBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ReasonId");

                    b.ToTable("passHeaderAdmins");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeaderLead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorizedPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DateTime")
                        .HasColumnType("date");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassNo")
                        .HasColumnType("int");

                    b.Property<string>("PreparedPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReasonId")
                        .HasColumnType("int");

                    b.Property<string>("SendTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("takenBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("ReasonId");

                    b.ToTable("passHeaderLeads");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassNote", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("LineNo")
                        .HasColumnType("int");

                    b.Property<string>("NameOfGoods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassNo")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("GoodsId");

                    b.HasIndex("Id");

                    b.ToTable("passNotes");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassNoteAdmin", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("LineNo")
                        .HasColumnType("int");

                    b.Property<string>("NameOfGoods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassNo")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("GoodsId");

                    b.HasIndex("Id");

                    b.ToTable("passNoteAdmins");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassNoteLead", b =>
                {
                    b.Property<int>("GoodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodsId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LineNo")
                        .HasColumnType("int");

                    b.Property<string>("NameOfGoods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassHeaderLeadId")
                        .HasColumnType("int");

                    b.Property<int>("PassNo")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("GoodsId");

                    b.HasIndex("PassHeaderLeadId");

                    b.ToTable("passNoteLeads");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.Reasons", b =>
                {
                    b.Property<int>("ReasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReasonId"));

                    b.Property<string>("ReasonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReasonId");

                    b.ToTable("reasons");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Facility")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeader", b =>
                {
                    b.HasOne("GatePassApplicaation.Models.Action", "Actions")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GatePassApplicaation.Models.Reasons", "Reasons")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actions");

                    b.Navigation("Reasons");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeaderAdmin", b =>
                {
                    b.HasOne("GatePassApplicaation.Models.Action", "Actions")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GatePassApplicaation.Models.Reasons", "Reasons")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actions");

                    b.Navigation("Reasons");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeaderLead", b =>
                {
                    b.HasOne("GatePassApplicaation.Models.Action", "Actions")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GatePassApplicaation.Models.Reasons", "Reasons")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actions");

                    b.Navigation("Reasons");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassNote", b =>
                {
                    b.HasOne("GatePassApplicaation.Models.PassHeader", "PassHeader")
                        .WithMany("PassDetails")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PassHeader");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassNoteAdmin", b =>
                {
                    b.HasOne("GatePassApplicaation.Models.PassHeaderAdmin", "PassHeaderAdmin")
                        .WithMany("PassDetails")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PassHeaderAdmin");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassNoteLead", b =>
                {
                    b.HasOne("GatePassApplicaation.Models.PassHeaderLead", "PassHeaderLead")
                        .WithMany("PassDetails")
                        .HasForeignKey("PassHeaderLeadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PassHeaderLead");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeader", b =>
                {
                    b.Navigation("PassDetails");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeaderAdmin", b =>
                {
                    b.Navigation("PassDetails");
                });

            modelBuilder.Entity("GatePassApplicaation.Models.PassHeaderLead", b =>
                {
                    b.Navigation("PassDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
