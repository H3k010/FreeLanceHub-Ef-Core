using System;
using EfcCodeFirst.Entites;
using EfcCodeFirst.Entites.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Configs;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients").HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Name).HasColumnType("VARCHAR").HasMaxLength(50);
        builder.Property(e => e.Email).HasColumnType("VARCHAR").HasMaxLength(50);

        builder.OwnsOne(c => c.Address, a =>
        {
            a.Property(x => x.Street).HasColumnType("VARCHAR").HasMaxLength(50);
            a.Property(x => x.City).HasColumnType("VARCHAR").HasMaxLength(50);
            a.Property(x => x.Country).HasColumnType("VARCHAR").HasMaxLength(50);

            a.HasData(
                new {ClientId = 1 , Street = "Street1", City = "City1", Country = "Country1" },
                new {ClientId = 2 , Street = "Street2", City = "City2", Country = "Country2" },
                new {ClientId = 3 , Street = "Street3", City = "City3", Country = "Country3" },
                new {ClientId = 4 , Street = "Street4", City = "City4", Country = "Country4" },
                new {ClientId = 5 , Street = "Street5", City = "City5", Country = "Country5" }
                );
        });

        builder.HasMany(c => c.Projects)
               .WithOne(p => p.Client)
               .HasForeignKey(p => p.ClientId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(LoadClients());
    }
    private static List<Client> LoadClients()
    {
        return
        [
            new() {Id = 1 , Name = "Name1", Email = "Email1"},
            new() {Id = 2 , Name = "Name2", Email = "Email2"},
            new() {Id = 3 , Name = "Name3", Email = "Email3"},
            new() {Id = 4 , Name = "Name4", Email = "Email4"},
            new() {Id = 5 , Name = "Name5", Email = "Email5"}
        ];
    }
}
