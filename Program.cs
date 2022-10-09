using appbuscar.Interfaces;
using appbuscar.Models;
using appbuscar.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration
    .GetConnectionString("DevConnection");

builder
    .Services
    .AddDbContext<appbuscarContext>
    (options => options.UseSqlServer(connectionString));

//IMPLEMENTA DEPENDENCIA
builder.Services.AddTransient<IBusesRepository, BusesRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IRoutesRepository, RoutesRepository>();
builder.Services.AddTransient<IRouteTicketsRepository, RouteTicketsRepository>();
builder.Services.AddTransient<IScheduleRoutesRepository, ScheduleRoutesRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();


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
