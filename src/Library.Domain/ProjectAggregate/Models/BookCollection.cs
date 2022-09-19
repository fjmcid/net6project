using Library.SharedKernel;

namespace Library.Domain.ProjectAggregate.Models;

public class BookCollection: EntityBase
{
    public Library Library { get; set; }
    public IList<Book> Books { get; set; } = new List<Book>();
}