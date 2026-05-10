using System;
namespace EfcCodeFirst.Entites.Contracts;

public interface ISoftDeletable
{
    bool IsDeleted {get; set;}
    DateTime? DeleteDate {get; set;}
    public void Delete()
    {
        IsDeleted = true;
        DeleteDate = DateTime.Now;
    }
    public void UndoDelete()
    {
        IsDeleted = false;
        DeleteDate = null;
    }
}
