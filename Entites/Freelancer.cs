using System;
using EfcCodeFirst.Entites.ValueObjects;
using EfcCodeFirst.Enums;

namespace EfcCodeFirst.Entites;
public class Freelancer
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public ICollection<ProjectFreelancer> ProjectFreelancers { get; set; } = new List<ProjectFreelancer>();
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public ICollection<FreelancerSkill> FreelancerSkills { get; set; } = new List<FreelancerSkill>();
    public override string ToString()
    {
        return $"Id : {Id} | Type : {Type} | Name : {Name} | Address : {Address}";
    }
}
public class IndependentFreelancer : Freelancer
{
    public int HourlyRate { get; set; }    
    public Availability Availability { get; set; }
}
public class AgencyFreelancer : Freelancer
{
    public string? AgencyName { get; set; }
    public string? AgencyContactEmail { get; set; }
}
