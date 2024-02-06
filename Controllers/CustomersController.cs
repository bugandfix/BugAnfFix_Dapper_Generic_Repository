

using BugAnfFix_Dapper_Generic_Repository.Abstraction;
using BugAnfFix_Dapper_Generic_Repository.Entity;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;



[Route("api/[controller]")]
[ApiController]
public class CustomersController : Controller
{
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CustomerDTO customerdata)
    {
        int CustomersCreated = await _service.Create(customerdata);
        return Created("", new { result = (CustomersCreated > 0) });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CustomerDTO customerdata)
    {
        int CustomersEdited = await _service.Update(id, customerdata);
        return Ok(new { result = (CustomersEdited > 0) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Customer customer = await _service.GetById(id);
        return Ok(new { customer });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customer = (await _service.GetAll()).ToList();
        int totalItems = await _service.CountAll(); 
        return Ok(new { customer, totalItems});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return Ok(new { message = (result) ? "Customer record was deleted." : "An error occured." });
    }
}