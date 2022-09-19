using Library.SharedKernel;

namespace Library.Domain.ProjectAggregate.Models;

public class Author: EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IList<Book> Books { get; set; } = new List<Book>();
}