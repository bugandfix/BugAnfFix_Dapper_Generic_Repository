

using BugAnfFix_Dapper_Generic_Repository.Abstraction;
using BugAnfFix_Dapper_Generic_Repository.Entity;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;



[Route("api/[controller]")]
[ApiController]
public class SalesController : Controller
{
    private readonly ISalesService _service;

    public SalesController(ISalesService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SalesDTO salesdata)
    {
        int SalesCreated = await _service.Create(salesdata);
        return Created("", new { result = (SalesCreated > 0) });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] SalesDTO categoryDto)
    {
        int SalesEdited = await _service.Update(id, categoryDto);
        return Ok(new { result = (SalesEdited > 0) });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Sales sales = await _service.GetById(id);
        return Ok(new { sales });
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sales = (await _service.GetAll()).ToList();
        int totalItems = await _service.CountAll(); // Note that this can be paginated
        return Ok(new { sales, totalItems});
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool result = await _service.Delete(id);
        return Ok(new { message = (result) ? "sales record was deleted." : "An error occured." });
    }
}