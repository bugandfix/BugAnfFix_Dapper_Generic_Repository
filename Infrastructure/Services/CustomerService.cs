

using AutoMapper;
using BugAnfFix_Dapper_Generic_Repository.Abstraction;
using BugAnfFix_Dapper_Generic_Repository.Entity;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;



namespace BugAnfFix_Dapper_Generic_Repository.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    
    private readonly IUnit _unit;
    private readonly IGenericRepository<Customer> _repository;
    private readonly IMapper _mapper;
    
    public CustomerService(IUnit unit, IMapper mapper)
    {
        _unit       = unit;
        _repository = _unit.GetRepository<Customer>();
        _mapper     = mapper;
    }
    
    public async Task<int> Create(CustomerDTO categoryDto)
    {
        var category       = _mapper.Map<Customer>(categoryDto);
        category.CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        int result         = await _repository.Add(category);
        return result;
    }

    public async Task<int> Update(int id, CustomerDTO categoryDto)
    {
        var customer          = await GetById(id);
        customer.Name         = categoryDto.Name;
        customer.Email = categoryDto.Email;
        customer.Address = categoryDto.Address;
        customer.UpdatedAt    = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);     
        int customerUpdated = await _repository.Update(customer);
        return customerUpdated;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        var customer = await _repository.GetAll();
        return customer;
    }

    public async Task<int> CountAll()
    {
        int count = await _repository.CountAll();
        return count;
    }

    public async Task<Customer> GetById(int id)
    {
        var customer = await _repository.GetById(id);
        if (customer == null)
            throw new Exception("customer record does not exist.");
        return customer;
    }

    public async Task<bool> Delete(int id)
    {
        var customer = await GetById(id);
        int result   = await _repository.Delete(customer); 
        return (result > 0);
    }
}