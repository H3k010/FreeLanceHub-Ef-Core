using System;
using EfcCodeFirst.Enums;

namespace EfcCodeFirst.Entites;

public class ProjectFreelancer
{
    public int ProjectId { get; set; }
    public int FreelancerId { get; set; }
    public int HoursAllocated { get; set; }
    public Role Role { get; set; }
    public Project Project { get; set; } = null!;
    public Freelancer Freelancer { get; set; } = null!;
}
