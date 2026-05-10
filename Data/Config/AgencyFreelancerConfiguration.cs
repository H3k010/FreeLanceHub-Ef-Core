using System;
using EfcCodeFirst.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;
public class AgencyFreelancerConfiguration : IEntityTypeConfiguration<AgencyFreelancer>
{
    public void Configure(EntityTypeBuilder<AgencyFreelancer> builder)
    {
        builder.Property(a => a.AgencyName).HasColumnName("Agency_Name").HasColumnType("VARCHAR").HasMaxLength(50);
        builder.Property(a => a.AgencyContactEmail).HasColumnName("Agency_Contact_Email").HasColumnType("VARCHAR").HasMaxLength(100);

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
                Type = "Type2",
                AgencyName = "AgencyName2",
                AgencyContactEmail = "Email2",
            },
            new ()            
            {
                Id = 3,
                Name = "Name3",
                Type = "Type3",
                AgencyName = "AgencyName3",
                AgencyContactEmail = "Email3",
            },
            new ()            
            {
                Id = 5,
                Name = "Name5",
                Type = "Type5",
                AgencyName = "AgencyName5",
                AgencyContactEmail = "Email5",
            }
        ];
    }
}
