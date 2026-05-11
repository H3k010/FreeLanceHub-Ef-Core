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
        builder.Property(f => f.Id).ValueGeneratedOnAdd();
        builder.UseTpcMappingStrategy();

        builder.Property(f => f.Name).HasColumnType("VARCHAR").HasMaxLength(255);

        builder.HasMany(f => f.Skills)
               .WithMany(s => s.Freelancers)
               .UsingEntity<FreelancerSkill>(
                r => r.HasOne(fs => fs.Skill).WithMany(s => s.FreelancerSkills).HasForeignKey(fs => fs.SkillId),
                l => l.HasOne(fs => fs.Freelancer).WithMany(f => f.FreelancerSkills).HasForeignKey(fs => fs.FreelancerId)
            );
    }
}

