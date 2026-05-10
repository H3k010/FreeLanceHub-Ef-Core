using EfcCodeFirst.Entites;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class IndependentFreelancerConfiguration : IEntityTypeConfiguration<IndependentFreelancer>
{
    public void Configure(EntityTypeBuilder<IndependentFreelancer> builder)
    {
        builder.Property(i => i.Availability)
               .HasConversion<string>()
               .HasColumnType("VARCHAR")
               .HasMaxLength(30);

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
                Type = "Type1",
                HourlyRate = 50,
                Availability = Availability.Full_Time,
            },
            new ()            
            {
                Id = 4,
                Name = "Name4",
                Type = "Type4",
                HourlyRate = 60,
                Availability = Availability.Part_Time,
            },
            new ()            
            {
                Id = 6,
                Name = "Name6",
                Type = "Type6",
                HourlyRate = 70,
                Availability = Availability.Full_Time,
            }
        ];
    }
}
