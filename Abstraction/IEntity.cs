namespace BugAnfFix_Dapper_Generic_Repository.Abstraction;

public interface IEntity
{
    int Id { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}
