﻿// <auto-generated />
using BSS_Backend_Opgave.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSS_Backend_Opgave.Repositories.Migrations;

[DbContext(typeof(BSS_Backend_OpgaveAPIContext))]
[Migration("20241104094425_Initial_Create")]
partial class Initial_Create
{
    /// <inheritdoc />
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.10")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("BSS_Backend_Opgave.Models.Organisation", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Organisation");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.Sensor", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("Location")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("OrganisationId")
                    .HasColumnType("int");

                b.Property<int>("SensorCategoryId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("OrganisationId");

                b.HasIndex("SensorCategoryId");

                b.ToTable("Sensor");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.SensorCategory", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("SensorCategory");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("OrganisationId")
                    .HasColumnType("int");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("OrganisationId");

                b.ToTable("User");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.Sensor", b =>
            {
                b.HasOne("BSS_Backend_Opgave.Models.Organisation", "Organisation")
                    .WithMany("Sensor")
                    .HasForeignKey("OrganisationId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("BSS_Backend_Opgave.Models.SensorCategory", "SensorCategory")
                    .WithMany("Sensors")
                    .HasForeignKey("SensorCategoryId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Organisation");

                b.Navigation("SensorCategory");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.User", b =>
            {
                b.HasOne("BSS_Backend_Opgave.Models.Organisation", "Organisation")
                    .WithMany("Users")
                    .HasForeignKey("OrganisationId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Organisation");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.Organisation", b =>
            {
                b.Navigation("Sensor");

                b.Navigation("Users");
            });

        modelBuilder.Entity("BSS_Backend_Opgave.Models.SensorCategory", b =>
            {
                b.Navigation("Sensors");
            });
#pragma warning restore 612, 618
    }
}
