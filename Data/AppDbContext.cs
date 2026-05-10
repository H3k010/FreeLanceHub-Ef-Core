using System;
using System.Configuration;
using System.Reflection;
using EfcCodeFirst.Configs;
using EfcCodeFirst.Data.Interceptors;
using EfcCodeFirst.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfcCodeFirst.Data;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<IndependentFreelancer> IndependentFreelancers { get; set; }
    public DbSet<AgencyFreelancer> AgencyFreelancers { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ProjectFreelancer> ProjectFreelancers { get; set; }
    public DbSet<FreelancerSkill> FreelancerSkills { get; set; }
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var constr = config.GetSection("constr").Value;
        optionsBuilder.UseMySQL(constr!);

        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()))
        {
            modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedAt")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedAt")
                .HasColumnType("timestamp")
                .HasDefaultValueSql("CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}