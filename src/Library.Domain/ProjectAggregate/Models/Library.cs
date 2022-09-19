using Library.SharedKernel;

namespace Library.Domain.ProjectAggregate.Models;

public class Library: EntityBase
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DeletedDate { get; set; }
}