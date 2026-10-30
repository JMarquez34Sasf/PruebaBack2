using Cuentas.Data;
using Cuentas.Interfaces;
using Cuentas.Middleware;
using Cuentas.Repositories;
using Cuentas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CuentasDbContext>();
builder.Services.AddScoped<ICuenta, CuentaRepository>();
builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<IMoneda, MonedaRepository>();
builder.Services.AddScoped<IMonedaService, MonedaService>();
builder.Services.AddScoped<IDivision, DivisionRepository>();
builder.Services.AddScoped<IDivisionService, DivisionService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
