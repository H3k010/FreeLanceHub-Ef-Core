using System;

namespace EfcCodeFirst.Entites;

public class FreelancerSkill
{
    public int FreelancerId { get; set; }
    public int SkillId { get; set; }
    public string? Proficiency { get; set; }
    public Freelancer Freelancer { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}
