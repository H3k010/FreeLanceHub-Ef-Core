using System;
using EfcCodeFirst.Entites.Contracts;
using EfcCodeFirst.Enums;
using Mysqlx.Connection;

namespace EfcCodeFirst.Entites;

public class Project : ISoftDeletable
{
    public int Id { get; set; }
    public int? ClientId { get; set; }
    public string Title { get; set; } = null!;
    public Status? Status { get; set; }
    public bool IsDeleted { get; set;}
    public DateTime? DeleteDate { get; set;}
    public Client? Client { get; set; }
    public Contract Contract { get; set; } = null!;
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    public ICollection<Freelancer> Freelancers { get; set; } = new List<Freelancer>();
    public ICollection<ProjectFreelancer> ProjectFreelancers { get; set; } = new List<ProjectFreelancer>();
    public override string ToString()
    {
        return $"Id : {Id} | ClientId : {ClientId} | Title : {Title} | Status : {Status}"; 
    }
}
