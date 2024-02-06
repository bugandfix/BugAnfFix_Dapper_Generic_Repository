
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BugAnfFix_Dapper_Generic_Repository.Abstraction;

namespace Dapper_Generic_Repository_Tnp.Infrastructure.Contracts;

[Serializable]
public class BaseEntity : IEntity
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
