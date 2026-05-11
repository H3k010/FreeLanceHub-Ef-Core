using EfcCodeFirst.Entites;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class IndependentFreelancerConfiguration : IEntityTypeConfiguration<IndependentFreelancer>
{
    public void Configure(EntityTypeBuilder<IndependentFreelancer> builder)
    {
        builder.ToTable("IndpendentFreelancers");

        builder.Property(i => i.Availability)
               .HasConversion<string>()
               .HasColumnType("VARCHAR")
               .HasMaxLength(30);

        builder.OwnsOne(f => f.Address, a =>
           {
               a.Property(x => x.Street).HasColumnType("VARCHAR").HasMaxLength(50);
               a.Property(x => x.City).HasColumnType("VARCHAR").HasMaxLength(50);
               a.Property(x => x.Country).HasColumnType("VARCHAR").HasMaxLength(50);

               a.HasData(
                   new { IndependentFreelancerId = 1, Street = "Street1", City = "City1", Country = "Country1" },
                   new { IndependentFreelancerId = 4, Street = "Street4", City = "City4", Country = "Country4" },
                   new { IndependentFreelancerId = 6, Street = "Street6", City = "City6", Country = "Country6" }
               );
           });

        builder.HasData(LoadIndpendentFreelancers());
    }

    private List<IndependentFreelancer> LoadIndpendentFreelancers()
    {
        return
        [
            new ()             
            {
                Id = 1,
                Name = "Name1",
                HourlyRate = 50,
                Availability = Availability.Full_Time,
            },
            new ()            
            {
                Id = 4,
                Name = "Name4",
                HourlyRate = 60,
                Availability = Availability.Part_Time,
            },
            new ()            
            {
                Id = 6,
                Name = "Name6",
                HourlyRate = 70,
                Availability = Availability.Full_Time,
            }
        ];
    }
}
