using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Template.API.Core;
using Template.BL;
using Template.BL.DTOModels;
using Template.BL.Repositories;
using Template.BL.Services;


//using Template.BL.Repositories;
using Template.DL;
using Template.DL.DBModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddCors(option => option.AddDefaultPolicy(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddAutoMapper(typeof(Program));

var config = new MapperConfiguration(o => o.AddProfile(new AutomapperProfile()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// Logger
builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog(logger);

// Dependency Injection
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGenericInterface<DepartmentDTO>, DepartmentService>();
builder.Services.AddScoped<IGenericInterface<EmployeeDTO>, EmployeeService>();

builder.Services.AddControllers();

//

builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers(option => option.Filters.Add<InvalidModelStateHandlerAttribute>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseMiddleware<LoggingMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
