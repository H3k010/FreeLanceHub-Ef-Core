using System;
using EfcCodeFirst.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;
public class AgencyFreelancerConfiguration : IEntityTypeConfiguration<AgencyFreelancer>
{
    public void Configure(EntityTypeBuilder<AgencyFreelancer> builder)
    {
        builder.ToTable("AgencyFreelancers");

        builder.Property(a => a.AgencyName).HasColumnName("Agency_Name").HasColumnType("VARCHAR").HasMaxLength(50);
        builder.Property(a => a.AgencyContactEmail).HasColumnName("Agency_Contact_Email").HasColumnType("VARCHAR").HasMaxLength(100);

        builder.OwnsOne(f => f.Address, a =>
           {
               a.Property(x => x.Street).HasColumnType("VARCHAR").HasMaxLength(50);
               a.Property(x => x.City).HasColumnType("VARCHAR").HasMaxLength(50);
               a.Property(x => x.Country).HasColumnType("VARCHAR").HasMaxLength(50);

               a.HasData(
                   new { AgencyFreelancerId = 2, Street = "Street2", City = "City2", Country = "Country2" },
                   new { AgencyFreelancerId = 3, Street = "Street3", City = "City3", Country = "Country3" },
                   new { AgencyFreelancerId = 5, Street = "Street5", City = "City5", Country = "Country5" }
               );
           });

        builder.HasData(LoadAgencyFreelancers());
    }

    private List<AgencyFreelancer> LoadAgencyFreelancers()
    {
        return
        [
            new ()            
            {
                Id = 2,
                Name = "Name2",
                AgencyName = "AgencyName2",
                AgencyContactEmail = "Email2",
            },
            new ()            
            {
                Id = 3,
                Name = "Name3",
                AgencyName = "AgencyName3",
                AgencyContactEmail = "Email3",
            },
            new ()            
            {
                Id = 5,
                Name = "Name5",
                AgencyName = "AgencyName5",
                AgencyContactEmail = "Email5",
            }
        ];
    }
}
