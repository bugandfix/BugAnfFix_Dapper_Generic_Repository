using BugAnfFix_Dapper_Generic_Repository.Abstraction;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.DataBase;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.Services;
using BugAnfFix_Dapper_Generic_Repository.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddSingleton<ApplicationDapperDbContext>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Service
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISalesService, SalesService>();

// Repository
builder.Services.AddScoped<IUnit, Unit>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();