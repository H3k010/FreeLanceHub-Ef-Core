using System;
using EfcCodeFirst.Entites;
using EfcCodeFirst.Entites.ValueObjects;
using EfcCodeFirst.Enums;

namespace EfcCodeFirst;

public class Contract
{
    public int Id { get; set; }
    public int? ProjectId { get; set; }
    public RateType? RateType { get; set;}
    public MoneyAmount MoneyAmount { get; set; } = null!;
    public Project? Project { get; set; }
    public override string ToString()
    {
        return $"Id : {Id} | Project Id : {ProjectId} | Rate Type : {RateType} | " +
               $"Amount : {MoneyAmount.Amount} | Currency : {MoneyAmount.Currency}";
    }
}
