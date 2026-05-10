using EfcCodeFirst.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skills").HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();        
        builder.Property(s => s.SkillName).HasColumnName("Skill_Name")
               .HasColumnType("VARCHAR").HasMaxLength(50);        
        
        builder.HasData(LoadSkills());
    }
    private List<Skill> LoadSkills()
    {
        return
        [
            new () { Id = 1, SkillName = "C# Development" },
            new () { Id = 2, SkillName = "ASP.NET Core" },
            new () { Id = 3, SkillName = "React.js" },
            new () { Id = 4, SkillName = "SQL Server" },
            new () { Id = 5, SkillName = "UI/UX Design" },
            new () { Id = 6, SkillName = "DevOps" },
            new () { Id = 7, SkillName = "Project Management" },
            new () { Id = 8, SkillName = "Mobile App Development" }
        ];
    }
}
