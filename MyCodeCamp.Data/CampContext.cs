﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPITest.Data.Entities;

namespace WebAPITest.Data
{
  public class CampContext : IdentityDbContext
  {
    private IConfigurationRoot _config;

    public CampContext(DbContextOptions options, IConfigurationRoot config)
      : base(options)
    {
      _config = config;
    }

    public DbSet<Camp> Camps { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Talk> Talks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Camp>()
        .Property(c => c.Moniker)
        .IsRequired();
      builder.Entity<Camp>()
        .Property(c => c.RowVersion)
        .ValueGeneratedOnAddOrUpdate()
        .IsConcurrencyToken();
      builder.Entity<Speaker>()
        .Property(c => c.RowVersion)
        .ValueGeneratedOnAddOrUpdate()
        .IsConcurrencyToken();
      builder.Entity<Talk>()
        .Property(c => c.RowVersion)
        .ValueGeneratedOnAddOrUpdate()
        .IsConcurrencyToken();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer(_config["Data:ConnectionString"]);
    }
  }
}
