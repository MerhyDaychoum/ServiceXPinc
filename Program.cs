using ServiceXPinc.DatabaseContext;
using ServiceXPinc.Repositories;
using ServiceXPinc.Repositories.Interfaces;
using ServiceXPinc.Services;
using ServiceXPinc.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<XPDatabaseContext>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInvestmentProductService, InvestmentProductService>();
builder.Services.AddScoped<ICustomerInvestmentService, CustomerInvestmentService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvestmentProductRepository, InvestmentProductRepository>();
builder.Services.AddScoped<ICustomerInvestmentRepository, CustomerInvestmentRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
