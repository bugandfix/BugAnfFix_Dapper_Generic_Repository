
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.GenericRepository;

namespace BugAnfFix_Dapper_Generic_Repository.Abstraction;


public interface IUnit
{
    GenericRepository<T> GetRepository<T>() where T : class, IEntity;
}
