using EfcCodeFirst.Entites;
using EfcCodeFirst.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfcCodeFirst.Configs;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects").HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.HasQueryFilter(p => !p.IsDeleted);
        builder.HasIndex(p => p.IsDeleted);

        builder.Property(e => e.Title).HasColumnType("VARCHAR").HasMaxLength(50);

        builder.HasOne(p => p.Contract)
               .WithOne(c => c.Project)
               .HasForeignKey<Contract>(c => c.ProjectId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.Property(p => p.Status)
               .HasConversion<string>()
               .HasColumnType("VARCHAR")
               .HasMaxLength(20);

        builder.HasMany(p => p.Invoices)
               .WithOne(i => i.Project).
               HasForeignKey(i => i.ProjectId)
               .IsRequired();

        builder.HasMany(p => p.Freelancers)
               .WithMany(f => f.Projects)
               .UsingEntity<ProjectFreelancer>(
                l => l.HasOne(pf => pf.Freelancer).WithMany(f => f.ProjectFreelancers).HasForeignKey(pf => pf.FreelancerId),
                r => r.HasOne(pf => pf.Project).WithMany(p => p.ProjectFreelancers).HasForeignKey(pf => pf.ProjectId));


        builder.HasData(LoadProjects());
    }
    private static List<Project> LoadProjects()
    {
        return
        [
            new() {Id = 1 , ClientId = 3 , Title = "Title1" , Status = Status.Draft },
            new() {Id = 2 , ClientId = 5 , Title = "Title2" , Status = Status.Overdue },
            new() {Id = 3 , ClientId = 4 , Title = "Title3" , Status = Status.Sent },
            new() {Id = 4 , ClientId = 1 , Title = "Title4" , Status = Status.Overdue },
            new() {Id = 5 , ClientId = 2 , Title = "Title5" , Status = Status.Paid }
        ];
    }
}
