using AutoMapper;
using BugAnfFix_Dapper_Generic_Repository.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;

public class CustomerDTO
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

    public class CustomerDTOProfile : Profile
    {
        public CustomerDTOProfile()
        {
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
