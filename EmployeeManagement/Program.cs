//using EmployeeManagement.Data;
//using EmployeeManagement.Services;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//var connectionString = builder.Configuration.GetConnectionString("Default");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(connectionString));

//builder.Services.AddScoped<IDepartmentService, DepartmentService>();
//builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using EmployeeManagement.Services;
using EmployeeManagement.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "EmployeeManagement API", Version = "v1" });
//});

//// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); // Add AutoMapper configuration

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmployeeManagement API v1"));
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();





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

