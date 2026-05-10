using System;
using EfcCodeFirst.Entites;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
{
    public void Configure(EntityTypeBuilder<Freelancer> builder)
    {
        builder.ToTable("Freelancers").HasKey(f => f.Id);
        builder.Property(f => f.Id).ValueGeneratedOnAdd();
        builder.UseTphMappingStrategy();
        builder.HasDiscriminator<string>("Freelancer")
               .HasValue<IndependentFreelancer>("INDEPENDENT")
               .HasValue<AgencyFreelancer>("AGENCY");

        builder.Property("Freelancer").HasColumnType("VARCHAR").HasMaxLength(30);
        builder.Property(f => f.Name).HasColumnType("VARCHAR").HasMaxLength(255);
        builder.Property(f => f.Type).HasColumnType("VARCHAR").HasMaxLength(50);

        builder.OwnsOne(f => f.Address, a =>
            {
                a.Property(x => x.Street).HasColumnType("VARCHAR").HasMaxLength(50);
                a.Property(x => x.City).HasColumnType("VARCHAR").HasMaxLength(50);
                a.Property(x => x.Country).HasColumnType("VARCHAR").HasMaxLength(50);

                a.HasData(
                    new { FreelancerId = 1, Street = "Street1", City = "City1", Country = "Country1" },
                    new { FreelancerId = 2, Street = "Street2", City = "City2", Country = "Country2" },
                    new { FreelancerId = 3, Street = "Street3", City = "City3", Country = "Country3" },
                    new { FreelancerId = 4, Street = "Street4", City = "City4", Country = "Country4" },
                    new { FreelancerId = 5, Street = "Street5", City = "City5", Country = "Country5" },
                    new { FreelancerId = 6, Street = "Street6", City = "City6", Country = "Country6" }
);
            });

        builder.HasMany(f => f.Skills)
               .WithMany(s => s.Freelancers)
               .UsingEntity<FreelancerSkill>(
                r => r.HasOne(fs => fs.Skill).WithMany(s => s.FreelancerSkills).HasForeignKey(fs => fs.SkillId),
                l => l.HasOne(fs => fs.Freelancer).WithMany(f => f.FreelancerSkills).HasForeignKey(fs => fs.FreelancerId)
               );

//         builder.HasData(LoadFreelancers());
//     }
//     private object[] LoadFreelancers()
//     {
//         return
//         [
//             new             // Independent Freelancer
//             {
//                 Id = 1,
//                 Name = "Name1",
//                 Type = "Type1",
//                 HourlyRate = 50,
//                 Availability = Availability.Full_Time,
//                 Freelancer = "INDEPENDENT"
//             },
//             new             // Agency Freelancer
//             {
//                 Id = 2,
//                 Name = "Name2",
//                 Type = "Type2",
//                 AgencyName = "AgencyName2",
//                 AgencyContactEmail = "Email2",
//                 Freelancer = "AGENCY"
//             },
//             new             // Agency Freelancer
//             {
//                 Id = 3,
//                 Name = "Name3",
//                 Type = "Type3",
//                 AgencyName = "AgencyName3",
//                 AgencyContactEmail = "Email3",
//                 Freelancer = "AGENCY"
//             },
//             new             // Independent Freelancer
//             {
//                 Id = 4,
//                 Name = "Name4",
//                 Type = "Type4",
//                 HourlyRate = 60,
//                 Availability = Availability.Part_Time,
//                 Freelancer = "INDEPENDENT"
//             },
//             new             // Agency Freelancer
//             {
//                 Id = 5,
//                 Name = "Name5",
//                 Type = "Type5",
//                 AgencyName = "AgencyName5",
//                 AgencyContactEmail = "Email5",
//                 Freelancer = "AGENCY"
//             },
//             new             // Independent Freelancer
//             {
//                 Id = 6,
//                 Name = "Name6",
//                 Type = "Type6",
//                 HourlyRate = 70,
//                 Availability = Availability.Full_Time,
//                 Freelancer = "INDEPENDENT"
//             }
//         ];
    }
}

