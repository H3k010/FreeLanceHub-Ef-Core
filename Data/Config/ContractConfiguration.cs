using System;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("Contracts").HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.OwnsOne(c => c.MoneyAmount, ma =>
        {
            ma.Property(x => x.Amount).HasPrecision(15, 3);
            ma.Property(x => x.Currency).HasColumnType("VARCHAR").HasMaxLength(50);

            ma.HasData(
                new { ContractId = 1, Amount = 50.00m, Currency = "USD" },
                new { ContractId = 2, Amount = 5000.00m, Currency = "EUR" },
                new { ContractId = 3, Amount = 75.00m, Currency = "GBP" },
                new { ContractId = 4, Amount = 1200.00m, Currency = "USD" },
                new { ContractId = 5, Amount = 45.00m, Currency = "CAD" });
        });

        builder.Property(c => c.RateType)
               .HasConversion<string>()
               .HasColumnName("Rate_Type")
               .HasColumnType("VARCHAR")
               .HasMaxLength(20);

        builder.HasData(LoadContracts());
    }
    private List<Contract> LoadContracts()
    {
        return
        [
            new () { Id = 1, ProjectId = 4, RateType = RateType.Hourly },
            new () { Id = 2, ProjectId = 1, RateType = RateType.Fixed },
            new () { Id = 3, ProjectId = 3, RateType = RateType.Fixed },
            new () { Id = 4, ProjectId = 2, RateType = RateType.Hourly },
            new () { Id = 5, ProjectId = 5, RateType = RateType.Hourly },
        ];
    }
}
