using System;

namespace EfcCodeFirst.Entites.ValueObjects;

public class Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}
