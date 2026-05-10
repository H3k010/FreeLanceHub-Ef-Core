using EfcCodeFirst.Entites;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices").HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.HasQueryFilter(i => !i.IsDeleted);
        builder.HasIndex(i => i.IsDeleted);

        builder.OwnsOne(i => i.MoneyAmount, ma =>
        {
            ma.Property(x => x.Amount).HasPrecision(15, 3);
            ma.Property(x => x.Currency).HasColumnType("VARCHAR").HasMaxLength(50);

            ma.HasData(
                new { InvoiceId = 1, Amount = 1500.00m, Currency = "USD" },
                new { InvoiceId = 2, Amount = 250.50m, Currency = "EUR" },
                new { InvoiceId = 3, Amount = 3000.00m, Currency = "GBP" },
                new { InvoiceId = 4, Amount = 450.00m, Currency = "USD" },
                new { InvoiceId = 5, Amount = 1200.00m, Currency = "CAD" },
                new { InvoiceId = 6, Amount = 85.00m, Currency = "USD" });
        });

        builder.Property(i => i.Status)
               .HasConversion<string>()
               .HasColumnType("VARCHAR")
               .HasMaxLength(20);

        builder.HasData(LoadInvoices());
    }

    private List<Invoice> LoadInvoices()
    {
        return
        [
            new () { Id = 1, ProjectId = 3, Status = Status.Draft },
            new () { Id = 2, ProjectId = 1, Status = Status.Paid },
            new () { Id = 3, ProjectId = 5, Status = Status.Overdue },
            new () { Id = 4, ProjectId = 4, Status = Status.Sent },
            new () { Id = 5, ProjectId = 2, Status = Status.Paid },
            new () { Id = 6, ProjectId = 1, Status = Status.Draft }
        ];
    }
}
