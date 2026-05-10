using System;
using EfcCodeFirst.Entites.Contracts;
using EfcCodeFirst.Entites.ValueObjects;
using EfcCodeFirst.Enums;

namespace EfcCodeFirst.Entites;

public class Invoice : ISoftDeletable
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Status? Status { get; set; } = null!;
    public MoneyAmount MoneyAmount { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public DateTime? DeleteDate { get; set; }
    public Project Project { get; set; } = null!;
    public override string ToString()
    {
        return $"Id : {Id} | Project Id : {ProjectId} | Status : {Status} | " +
               $"Amount : {MoneyAmount.Amount} | Currency : {MoneyAmount.Currency}";
    }
}
