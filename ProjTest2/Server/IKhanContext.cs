﻿using System;
using System.Threading;
using System.Threading.Tasks;
using ProjTest2.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjTest2.Server;

public interface IKhanContext :IDisposable
{
    DbSet<Content> Contents { get; }
    DbSet<ProgrammingLanguage> ProgrammingLanguages { get; }
    DbSet<Learner> Learners { get; }
    DbSet<Moderator> Moderators { get; }
    DbSet<Rating> Ratings { get; }
    DbSet<HistoryEntry> HistoryEntries { get; }
    DbSet<Image> Images { get; }
    
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
