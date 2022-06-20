using MediatR;
using Microsoft.EntityFrameworkCore;
using SainsburyPractice.Domain.Handler;
using SainsburyPractice.Domain.MediatRServices;
using SainsburyPractice.Domain.Services;
using SainsburyPractice.Interfaces;
using SainsburyPractice.Repository.DataModel;
using SainsburyPractice.Repository.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");


//register the mediator
//builder.Services.AddMediatR(typeof(Program));
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(EmployeeListCommand).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AddEmployeeCommand).GetTypeInfo().Assembly);
builder.Services.AddHealthChecks().AddMySql(mySqlConnectionStr);

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
 
// Add services to the container. 
builder.Services.AddDbContextPool<SainsburysContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

builder.Services.AddCors();
//builder.Services.AddCors(
//     c => {
//         c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//     }
//    );
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

app.MapHealthChecks("/healthchecks");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
