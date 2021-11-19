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
    [Migration("20211119130702_test2")]
    partial class test2
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

                    b.Property<float>("AvgRating")
                        .HasColumnType("real");

                    b.Property<string>("Creator")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("Difficulty")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<int?>("LearnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ModeratorId")
                        .HasColumnType("integer");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LearnerId");

                    b.HasIndex("ModeratorId");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("level")
                        .HasColumnType("integer");

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
                    b.Property<string>("Language")
                        .HasColumnType("text");

                    b.Property<int?>("ContentId")
                        .HasColumnType("integer");

                    b.HasKey("Language");

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

                    b.Property<byte[]>("RawVideo")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.HasOne("ProjTest2.Shared.Models.Learner", null)
                        .WithMany("favorites")
                        .HasForeignKey("LearnerId");

                    b.HasOne("ProjTest2.Shared.Models.Moderator", null)
                        .WithMany("Contents")
                        .HasForeignKey("ModeratorId");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.HistoryEntry", b =>
                {
                    b.HasOne("Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjTest2.Shared.Models.Learner", "Learner")
                        .WithMany("history")
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
                        .WithMany("ratings")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjTest2.Shared.Models.Learner", "Learner")
                        .WithMany("ratings")
                        .HasForeignKey("LearnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Learner");
                });

            modelBuilder.Entity("Content", b =>
                {
                    b.Navigation("ProgrammingLanguages");

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Learner", b =>
                {
                    b.Navigation("favorites");

                    b.Navigation("history");

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("ProjTest2.Shared.Models.Moderator", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
