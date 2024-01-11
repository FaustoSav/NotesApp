﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotesApp.Data.DBContext;

#nullable disable

namespace NotesApp.Migrations
{
    [DbContext(typeof(NotesContext))]
    [Migration("20240110221534_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("NoteTag", b =>
                {
                    b.Property<int>("NotesNoteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagsTagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NotesNoteId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("NoteTag");
                });

            modelBuilder.Entity("NotesApp.Data.Entities.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("NotesApp.Data.Entities.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagId");

                    b.HasIndex("UserId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            Color = "#90EE90",
                            CreatedAt = new DateTime(2024, 1, 10, 19, 15, 34, 501, DateTimeKind.Local).AddTicks(8201),
                            Description = "Tag creada por default en el DbContext",
                            Name = "Default",
                            State = true,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("NotesApp.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@gmail.com",
                            LastName = "Potter",
                            Name = "Harry",
                            Password = "123456",
                            State = true,
                            UserName = "El chaboncito que sobrevivió"
                        });
                });

            modelBuilder.Entity("NoteTag", b =>
                {
                    b.HasOne("NotesApp.Data.Entities.Note", null)
                        .WithMany()
                        .HasForeignKey("NotesNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NotesApp.Data.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NotesApp.Data.Entities.Note", b =>
                {
                    b.HasOne("NotesApp.Data.Entities.User", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NotesApp.Data.Entities.Tag", b =>
                {
                    b.HasOne("NotesApp.Data.Entities.User", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NotesApp.Data.Entities.User", b =>
                {
                    b.Navigation("Notes");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}