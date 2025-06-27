using Finances_API.Controllers.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Finances_API.DTOs;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Adiciona serviços ao container

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Registro do AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Registro do repositório
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

// ✅ Registro do AutoMapper (usando o Profile definido)
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// 🔧 Configura o pipeline HTTP

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

 app.Run();