using System;

namespace EfcCodeFirst.Entites.ValueObjects;

public class MoneyAmount
{
    public decimal Amount { get; set; }
    public string Currency { get; set; } = null!;
}
