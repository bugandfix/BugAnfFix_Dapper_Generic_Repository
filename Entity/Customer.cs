using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dapper_Generic_Repository_Tnp.Infrastructure.Contracts;

namespace BugAnfFix_Dapper_Generic_Repository.Entity;

[Table("customer")]
public class Customer : BaseEntity
{
    public Customer()
    { 
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Phone]
    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }
}
