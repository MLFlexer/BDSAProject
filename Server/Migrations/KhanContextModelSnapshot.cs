﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SETraining.Server.Contexts;

#nullable disable

namespace SETraining.Server.Migrations
{
    [DbContext(typeof(KhanContext))]
    partial class KhanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float?>("AvgRating")
                        .HasColumnType("real");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Difficulty")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("LearnerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LearnerId");

                    b.ToTable("Contents");

                    b.HasDiscriminator<string>("Type").HasValue("Content");
                });

            modelBuilder.Entity("ContentProgrammingLanguage", b =>
                {
                    b.Property<int>("ContentsId")
                        .HasColumnType("integer");

                    b.Property<string>("ProgrammingLanguagesLanguage")
                        .HasColumnType("text");

                    b.HasKey("ContentsId", "ProgrammingLanguagesLanguage");

                    b.HasIndex("ProgrammingLanguagesLanguage");

                    b.ToTable("ContentProgrammingLanguage");
                });

            modelBuilder.Entity("SETraining.Shared.Models.HistoryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LearnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("LearnerId");

                    b.ToTable("HistoryEntries");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("RawData")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Learner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Learners");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Moderator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Moderators");
                });

            modelBuilder.Entity("SETraining.Shared.Models.ProgrammingLanguage", b =>
                {
                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.HasKey("Language");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentId")
                        .HasColumnType("integer");

                    b.Property<int>("LearnerId")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("LearnerId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("SETraining.Shared.Models.RawVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("Video")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("RawVideo");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Article", b =>
                {
                    b.HasBaseType("Content");

                    b.Property<string>("TextBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Article");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Video", b =>
                {
                    b.HasBaseType("Content");

                    b.Property<int?>("Length")
                        .HasColumnType("integer");

                    b.Property<int>("RawDataId")
                        .HasColumnType("integer");

                    b.HasIndex("RawDataId");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.HasOne("SETraining.Shared.Models.Moderator", "Creator")
                        .WithMany("Contents")
                        .HasForeignKey("CreatorId");

                    b.HasOne("SETraining.Shared.Models.Learner", null)
                        .WithMany("Favorites")
                        .HasForeignKey("LearnerId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ContentProgrammingLanguage", b =>
                {
                    b.HasOne("Content", null)
                        .WithMany()
                        .HasForeignKey("ContentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SETraining.Shared.Models.ProgrammingLanguage", null)
                        .WithMany()
                        .HasForeignKey("ProgrammingLanguagesLanguage")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SETraining.Shared.Models.HistoryEntry", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SETraining.Shared.Models.Learner", "Learner")
                        .WithMany("History")
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Rating", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany("Ratings")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SETraining.Shared.Models.Learner", "Learner")
                        .WithMany("Ratings")
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Video", b =>
                {
                    b.HasOne("SETraining.Shared.Models.RawVideo", "RawData")
                        .WithMany()
                        .HasForeignKey("RawDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RawData");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Learner", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("History");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("SETraining.Shared.Models.Moderator", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
