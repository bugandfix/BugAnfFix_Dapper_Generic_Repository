using AutoMapper;
using BugAnfFix_Dapper_Generic_Repository.Abstraction;
using BugAnfFix_Dapper_Generic_Repository.Entity;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;


namespace BugAnfFix_Dapper_Generic_Repository.Infrastructure.Services;

public class SalesService : ISalesService
{
    private readonly IUnit _unit;
    private readonly IGenericRepository<Sales> _repository;
    private readonly IMapper _mapper;
    
    public SalesService(IUnit unit, IMapper mapper)
    {
        _unit       = unit;
        _repository = _unit.GetRepository<Sales>();
        _mapper     = mapper;
    }
    
    public async Task<int> Create(SalesDTO salesdata)
    {
        var sales       = _mapper.Map<Sales>(salesdata);
        sales.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int result        = await _repository.Add(sales);
        return result;
    }

    public async Task<int> Update(int id, SalesDTO salesdata)
    {
        var sales         = await GetById(id);
        sales.Description = salesdata.Description;
        sales.Amount  = salesdata.Amount;
        sales.UpdatedAt   = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int salesUpdated = await _repository.Update(sales);
        return salesUpdated;
    }

    public async Task<IEnumerable<Sales>> GetAll()
    {
        var sales = await _repository.GetAll();
        return sales;
    }

    public async Task<int> CountAll()
    {
        int count = await _repository.CountAll();
        return count;
    }

    public async Task<Sales> GetById(int id)
    {
        var sales = await _repository.GetById(id);
        if (sales == null)
            throw new Exception("sales record does not exist.");
        return sales;
    }

    public async Task<bool> Delete(int id)
    {
        var sales  = await GetById(id);
        int result   = await _repository.Delete(sales); 
        return (result > 0);
    }
}