﻿using SETraining.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SETraining.Server.Contexts;

public class KhanContext : DbContext, IKhanContext
{
    public DbSet<Content> Contents => Set<Content>();
    public DbSet<Learner> Learners => Set<Learner>();
    public DbSet<Moderator> Moderators => Set<Moderator>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<ProgrammingLanguage> ProgrammingLanguages => Set<ProgrammingLanguage>();
    public DbSet<HistoryEntry> HistoryEntries => Set<HistoryEntry>();
    public DbSet<Image> Images => Set<Image>();

    public KhanContext(DbContextOptions<KhanContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        modelBuilder.Entity<Content>()
            .HasDiscriminator(c => c.Type)
            .HasValue<Article>("Article")
            .HasValue<Video>("Video");
            
        modelBuilder.Entity<Content>()
            .Property(c => c.Difficulty)
            .HasConversion(new EnumToStringConverter<DifficultyLevel>());
    }
}
