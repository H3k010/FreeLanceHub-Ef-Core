using System;
using EfcCodeFirst.Entites.ValueObjects;

namespace EfcCodeFirst.Entites;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Address Address { get; set; } = null!;
    public ICollection<Project> Projects { get; set; } = new List<Project>();
    public override string ToString()
    {
        return $"Id : {Id} | Name : {Name} | Email : {Email} | " +
               $"Street : {Address.Street} | City : {Address.City} | Country : {Address.Country}";
    }
}
