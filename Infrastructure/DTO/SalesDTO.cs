using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BugAnfFix_Dapper_Generic_Repository.Entity;

namespace BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;

public class SalesDTO
{
    public DateTime SaleDate { get; set; }
    public decimal Amount { get; set; }
    public int CustomerID { get; set; }
    public string? Description { get; set; }
    public class SalesDTOProfile : Profile
    {
        public SalesDTOProfile()
        {
            CreateMap<SalesDTO, Sales>();
        }
    }
}
