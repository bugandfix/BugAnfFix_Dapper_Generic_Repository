
using BugAnfFix_Dapper_Generic_Repository.Abstraction;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DataBase;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.GenericRepository;

namespace BugAnfFix_Dapper_Generic_Repository.Infrastructure.UnitOfWork;


public class Unit : IUnit
{
    private readonly ApplicationDapperDbContext _context;

    public Unit(ApplicationDapperDbContext context)
    {
        _context = context;
    }

    public GenericRepository<T> GetRepository<T>() where T : class, IEntity
    {
        return new GenericRepository<T>(_context);
    }
}
