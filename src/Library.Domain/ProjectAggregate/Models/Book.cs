using Library.SharedKernel;

namespace Library.Domain.ProjectAggregate.Models;

public class Book: EntityBase
{
    public string Name { get; set; }
    public DateTime PublishedDate { get; set; }
    public Author Author { get; set; }
    public Library Library { get; set; }
    public Genre Genre { get; set; }
}