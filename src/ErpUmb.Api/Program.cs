using Microsoft.EntityFrameworkCore;
using ErpUmb.Api.Data;
using ErpUmb.Api.Interfaces;
using ErpUmb.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Base de datos SQL Server LocalDB / In-Memory
builder.Services.AddDbContext<ComprasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=(localdb)\\mssqllocaldb;Database=ErpUmbComprasDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

// Inyección de Dependencias (DIP)
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();