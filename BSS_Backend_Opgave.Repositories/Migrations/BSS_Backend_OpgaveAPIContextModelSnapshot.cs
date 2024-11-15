﻿// <auto-generated />
using System;
using BSS_Backend_Opgave.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSS_Backend_Opgave.API.Migrations
{
    [DbContext(typeof(BSS_Backend_OpgaveAPIContext))]
    partial class BSS_Backend_OpgaveAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BSS_Backend_Opgave.Models.EventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("EventTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("EventLog", (string)null);
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Organisation", (string)null);
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int>("SensorCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("SensorCategoryId");

                    b.ToTable("Sensor", (string)null);
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.SensorCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.ToTable("SensorCategory", (string)null);
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventLogId")
                        .HasColumnType("int");

                    b.Property<int>("SensorId")
                        .HasColumnType("int");

                    b.Property<string>("StateType")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("EventLogId")
                        .IsUnique();

                    b.HasIndex("SensorId")
                        .IsUnique();

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<int?>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganisationId1")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("OrganisationId1");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.Sensor", b =>
                {
                    b.HasOne("BSS_Backend_Opgave.Models.Organisation", "Organisation")
                        .WithMany("Sensor")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BSS_Backend_Opgave.Models.SensorCategory", "SensorCategory")
                        .WithMany("Sensors")
                        .HasForeignKey("SensorCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Organisation");

                    b.Navigation("SensorCategory");
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.State", b =>
                {
                    b.HasOne("BSS_Backend_Opgave.Models.EventLog", "EventLog")
                        .WithOne("State")
                        .HasForeignKey("BSS_Backend_Opgave.Models.State", "EventLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BSS_Backend_Opgave.Models.Sensor", "Sensor")
                        .WithOne("State")
                        .HasForeignKey("BSS_Backend_Opgave.Models.State", "SensorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EventLog");

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.User", b =>
                {
                    b.HasOne("BSS_Backend_Opgave.Models.Organisation", null)
                        .WithMany("Users")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BSS_Backend_Opgave.Models.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId1");

                    b.Navigation("Organisation");
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.EventLog", b =>
                {
                    b.Navigation("State");
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.Organisation", b =>
                {
                    b.Navigation("Sensor");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.Sensor", b =>
                {
                    b.Navigation("State");
                });

            modelBuilder.Entity("BSS_Backend_Opgave.Models.SensorCategory", b =>
                {
                    b.Navigation("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
