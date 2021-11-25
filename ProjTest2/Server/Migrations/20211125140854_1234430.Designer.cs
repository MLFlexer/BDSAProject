﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjTest2.Server;

#nullable disable

namespace ProjTest2.Server.Migrations
{
    [DbContext(typeof(KhanContext))]
    [Migration("20211125140854_1234430")]
    partial class _1234430
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("Difficulty")
                        .HasColumnType("integer");

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

                    b.ToTable("Content");

                    b.HasDiscriminator<string>("Type").HasValue("Content");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.HistoryEntry", b =>
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

                    b.ToTable("HistoryEntry");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("RawImage")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Learner", b =>
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

                    b.ToTable("Learner");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Moderator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Moderator");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ContentId")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("ProgrammingLanguage");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Rating", b =>
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

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.RawVideo", b =>
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

            modelBuilder.Entity("ProjTest2.Shared.Models.Article", b =>
                {
                    b.HasBaseType("Content");

                    b.Property<string>("TextBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Article");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Video", b =>
                {
                    b.HasBaseType("Content");

                    b.Property<int?>("Length")
                        .HasColumnType("integer");

                    b.Property<int>("RawVideoId")
                        .HasColumnType("integer");

                    b.HasIndex("RawVideoId");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.HasOne("ProjTest2.Shared.Models.Moderator", "Creator")
                        .WithMany("Contents")
                        .HasForeignKey("CreatorId");

                    b.HasOne("ProjTest2.Shared.Models.Learner", null)
                        .WithMany("Favorites")
                        .HasForeignKey("LearnerId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.HistoryEntry", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjTest2.Shared.Models.Learner", "Learner")
                        .WithMany("History")
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.ProgrammingLanguage", b =>
                {
                    b.HasOne("Content", null)
                        .WithMany("ProgrammingLanguages")
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Rating", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany("Ratings")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjTest2.Shared.Models.Learner", "Learner")
                        .WithMany("Ratings")
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Video", b =>
                {
                    b.HasOne("ProjTest2.Shared.Models.RawVideo", "RawVideo")
                        .WithMany()
                        .HasForeignKey("RawVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RawVideo");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.Navigation("ProgrammingLanguages");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Learner", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("History");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Moderator", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
