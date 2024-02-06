using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dapper_Generic_Repository_Tnp.Infrastructure.Contracts;


namespace BugAnfFix_Dapper_Generic_Repository.Entity;


[Table("sales")]
public class Sales : BaseEntity
{
    public Sales()
    {
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    [Required]
    public DateTime SaleDate { get; set; }


    [Required]
    [Range(0, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public string? Description { get; set; }

}