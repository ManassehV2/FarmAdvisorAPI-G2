﻿// <auto-generated />
using System;
using FarmAdvisor.DataAccess.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FarmAdvisor.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(FarmAdvisorDbContext))]
    partial class FarmAdvisorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmDto", b =>
                {
                    b.Property<Guid>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FarmId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmFieldDto", b =>
                {
                    b.Property<Guid>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Altitude")
                        .HasColumnType("float");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Polygon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FieldId");

                    b.HasIndex("FarmId");

                    b.ToTable("FarmFeilds");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.NotificationDto", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FarmId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NotificationId");

                    b.HasIndex("FarmId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorDto", b =>
                {
                    b.Property<Guid>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BatteryStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CuttingDateCaclculated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("FeildId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastCommunication")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastForecastDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<int>("OptimalGDD")
                        .HasColumnType("int");

                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("SensorId");

                    b.HasIndex("FeildId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorResetDateDto", b =>
                {
                    b.Property<Guid>("ResetDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("ResetDateId");

                    b.HasIndex("SensorId")
                        .IsUnique();

                    b.ToTable("SensorResetDates");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.UserDto", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmDto", b =>
                {
                    b.HasOne("FarmAdvisor.DataAccess.MSSQL.Dtos.UserDto", "User")
                        .WithOne("Farm")
                        .HasForeignKey("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmDto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmFieldDto", b =>
                {
                    b.HasOne("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmDto", "Farm")
                        .WithMany("FarmFeilds")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.NotificationDto", b =>
                {
                    b.HasOne("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmDto", "Farm")
                        .WithMany("Notifications")
                        .HasForeignKey("FarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farm");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorDto", b =>
                {
                    b.HasOne("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmFieldDto", "Feild")
                        .WithMany("Sensors")
                        .HasForeignKey("FeildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feild");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorResetDateDto", b =>
                {
                    b.HasOne("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorDto", "Sensor")
                        .WithOne("ResetDate")
                        .HasForeignKey("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorResetDateDto", "SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmDto", b =>
                {
                    b.Navigation("FarmFeilds");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.FarmFieldDto", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.SensorDto", b =>
                {
                    b.Navigation("ResetDate");
                });

            modelBuilder.Entity("FarmAdvisor.DataAccess.MSSQL.Dtos.UserDto", b =>
                {
                    b.Navigation("Farm");
                });
#pragma warning restore 612, 618
        }
    }
}