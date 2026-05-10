using EfcCodeFirst.Entites;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Data.Config;

public class ProjectFreelancerConfiguration : IEntityTypeConfiguration<ProjectFreelancer>
{
    public void Configure(EntityTypeBuilder<ProjectFreelancer> builder)
    {
        builder.ToTable("ProjectFreelancer").HasKey(pf => new {pf.ProjectId, pf.FreelancerId});
        builder.Property(pf => pf.HoursAllocated).HasColumnName("Hours_Allocated");
        builder.Property(pf => pf.Role)
               .HasConversion<string>()
               .HasColumnType("VARCHAR")
               .HasMaxLength(30);

        builder.HasData(LoadProjectFreelancers());
    }
    private object[] LoadProjectFreelancers()
    {
        return
        [
            new { ProjectId = 1, FreelancerId = 1, HoursAllocated = 40, Role = Role.Developer },
            new { ProjectId = 1, FreelancerId = 2, HoursAllocated = 20, Role = Role.Project_Management },
            new { ProjectId = 2, FreelancerId = 3, HoursAllocated = 35, Role = Role.Designer },
            new { ProjectId = 3, FreelancerId = 4, HoursAllocated = 15, Role = Role.Developer },
            new { ProjectId = 3, FreelancerId = 1, HoursAllocated = 10, Role = Role.Markting },
            new { ProjectId = 4, FreelancerId = 5, HoursAllocated = 50, Role = Role.Project_Management },
            new { ProjectId = 5, FreelancerId = 6, HoursAllocated = 25, Role = Role.Developer },
            new { ProjectId = 5, FreelancerId = 2, HoursAllocated = 30, Role = Role.Markting }
        ];
    }
}
