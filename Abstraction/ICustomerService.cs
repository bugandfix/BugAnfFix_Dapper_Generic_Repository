


using BugAnfFix_Dapper_Generic_Repository.Entity;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;

namespace BugAnfFix_Dapper_Generic_Repository.Abstraction;

public interface ICustomerService
{
    Task<int> Create(CustomerDTO categoryDto);
    Task<int> Update(int id, CustomerDTO categoryDto);
    Task<IEnumerable<Customer>> GetAll();
    Task<int> CountAll();
    Task<Customer> GetById(int id);
    Task<bool> Delete(int id);
}