using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fetch.Model.RestaurantModels;

public partial class FetchDbContext : DbContext
{
    private readonly IConfiguration _config;
    public FetchDbContext(IConfiguration config)
    {
        _config = config;
    }

    public FetchDbContext(DbContextOptions<FetchDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FoodType> FoodTypes { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantType> RestaurantTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _config.GetConnectionString("RestaurantConnectionString");
        optionsBuilder.UseNpgsql(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_types_pkey");

            entity.ToTable("food_types", "restaurant");

            entity.HasIndex(e => e.TypeName, "food_types_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("locations_pkey");

            entity.ToTable("locations", "restaurant");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");
            entity.Property(e => e.State)
                .HasMaxLength(100)
                .HasColumnName("state");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("zip_code");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("restaurants_pkey");

            entity.ToTable("restaurants", "restaurant");

            entity.HasIndex(e => e.FoodTypeId, "fki_foods_type_id_fkey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FoodTypeId).HasColumnName("food_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OpeningHours)
                .HasMaxLength(100)
                .HasColumnName("opening_hours");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RestaurantTypeId).HasColumnName("restaurant_type_id");
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(255)
                .HasColumnName("website_url");

            entity.HasOne(d => d.FoodType).WithMany(p => p.RestaurantFoodTypes)
                .HasForeignKey(d => d.FoodTypeId)
                .HasConstraintName("food_types_id_fkey");

            entity.HasOne(d => d.RestaurantType).WithMany(p => p.RestaurantRestaurantTypes)
                .HasForeignKey(d => d.RestaurantTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("restaurants_type_id_fkey");
        });

        modelBuilder.Entity<RestaurantType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("restaurant_types_pkey");

            entity.ToTable("restaurant_types", "restaurant");

            entity.HasIndex(e => e.TypeName, "restaurant_types_type_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasColumnName("type_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
