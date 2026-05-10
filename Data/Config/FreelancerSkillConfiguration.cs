using EfcCodeFirst.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class FreelancerSkillConfiguration : IEntityTypeConfiguration<FreelancerSkill>
{
    public void Configure(EntityTypeBuilder<FreelancerSkill> builder)
    {
        builder.ToTable("FreelancerSkills").HasKey(fs => new { fs.FreelancerId, fs.SkillId });
        builder.Property(fs => fs.Proficiency).HasColumnType("VARCHAR").HasMaxLength(30);
        
        builder.HasData(LoadFreelanceSkills());
    }
    private object[] LoadFreelanceSkills()
    {
        return
        [
            new { FreelancerId = 1, SkillId = 1, Proficiency = "Expert" },
            new { FreelancerId = 1, SkillId = 2, Proficiency = "Advanced" },
            new { FreelancerId = 2, SkillId = 3, Proficiency = "Intermediate" },
            new { FreelancerId = 3, SkillId = 4, Proficiency = "Expert" },
            new { FreelancerId = 4, SkillId = 5, Proficiency = "Beginner" },
            new { FreelancerId = 5, SkillId = 6, Proficiency = "Advanced" },
            new { FreelancerId = 6, SkillId = 7, Proficiency = "Intermediate" }
        ];
    }
}