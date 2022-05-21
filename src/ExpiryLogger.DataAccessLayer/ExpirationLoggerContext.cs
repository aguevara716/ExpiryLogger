﻿using ExpiryLogger.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpiryLogger.DataAccessLayer;

public class ExpirationLoggerContext : DbContext
{
    private readonly IConfiguration _configuration;

    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Location> Locations { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    public ExpirationLoggerContext(IConfiguration configuration, DbContextOptions<ExpirationLoggerContext> options)
        : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
            return;

        var connectionString = _configuration.GetConnectionString("ExpirationLoggerConnectionString");
        optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("10.3.34-mariadb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDetail>().HasNoKey().ToView("ProductDetails");
    }

}
