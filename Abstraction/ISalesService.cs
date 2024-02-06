


using BugAnfFix_Dapper_Generic_Repository.Entity;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;

namespace BugAnfFix_Dapper_Generic_Repository.Abstraction;

public interface ISalesService
{
    Task<int> Create(SalesDTO productDto);
    Task<int> Update(int id, SalesDTO productDto);
    Task<IEnumerable<Sales>> GetAll();
    Task<int> CountAll();
    Task<Sales> GetById(int id);
    Task<bool> Delete(int id);
}