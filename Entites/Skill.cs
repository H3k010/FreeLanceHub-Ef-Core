using System;

namespace EfcCodeFirst.Entites;

public class Skill
{
    public int Id { get; set; }
    public string SkillName { get; set; } = null!;
    public ICollection<Freelancer> Freelancers { get; set; } = new List<Freelancer>();
    public ICollection<FreelancerSkill> FreelancerSkills { get; set; } = new List<FreelancerSkill>();
    public override string ToString()
    {
        return $"Id : {Id} | Skill Name : {SkillName}";
    }
}
