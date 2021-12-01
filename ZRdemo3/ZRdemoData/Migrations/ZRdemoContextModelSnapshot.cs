﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZRdemoData.Models;

namespace ZRdemoData.Migrations
{
    [DbContext(typeof(ZRdemoContext))]
    partial class ZRdemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ZRdemoData.Models.Coach", b =>
                {
                    b.Property<int>("CoachId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Belt")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoachId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("ZRdemoData.Models.GroupOfStudents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GroupOfStudents");
                });

            modelBuilder.Entity("ZRdemoData.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Belt")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("ZRdemoData.Models.GuestTraining", b =>
                {
                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("GuestId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("GuestTrainings");
                });

            modelBuilder.Entity("ZRdemoData.Models.Gym", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("WorkingHours")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("ZRdemoData.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Belt")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("GroupOfStudentsId")
                        .HasColumnType("int");

                    b.Property<bool>("Injury")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("GroupOfStudentsId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ZRdemoData.Models.Training", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<int>("GroupOfStudentsId")
                        .HasColumnType("int");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeOfTraining")
                        .HasColumnType("int");

                    b.Property<int>("Uniform")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("GroupOfStudentsId");

                    b.HasIndex("GymId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("ZRdemoData.Models.GuestTraining", b =>
                {
                    b.HasOne("ZRdemoData.Models.Guest", "Guest")
                        .WithMany("GuestTrainings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZRdemoData.Models.Training", "Training")
                        .WithMany("GuestTrainigs")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("ZRdemoData.Models.Student", b =>
                {
                    b.HasOne("ZRdemoData.Models.GroupOfStudents", "GroupOfStudents")
                        .WithMany("Students")
                        .HasForeignKey("GroupOfStudentsId");

                    b.Navigation("GroupOfStudents");
                });

            modelBuilder.Entity("ZRdemoData.Models.Training", b =>
                {
                    b.HasOne("ZRdemoData.Models.Coach", "Coach")
                        .WithMany("Trainings")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZRdemoData.Models.GroupOfStudents", "GroupOfStudents")
                        .WithMany("Trainings")
                        .HasForeignKey("GroupOfStudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZRdemoData.Models.Gym", "Gym")
                        .WithMany()
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("GroupOfStudents");

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("ZRdemoData.Models.Coach", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("ZRdemoData.Models.GroupOfStudents", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("ZRdemoData.Models.Guest", b =>
                {
                    b.Navigation("GuestTrainings");
                });

            modelBuilder.Entity("ZRdemoData.Models.Training", b =>
                {
                    b.Navigation("GuestTrainigs");
                });
#pragma warning restore 612, 618
        }
    }
}
