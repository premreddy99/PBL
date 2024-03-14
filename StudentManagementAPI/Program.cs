using StudentManagementService;
using SQLRepository;
using System.Data;
//From tools install nuget manager lo microsoft.sql.client
using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository1>();
//builder.Services.AddScoped<IStudentRepository2, StudentRepository2>();


//Get connection string and build connection
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json",optional:false,reloadOnChange:true)
    .AddEnvironmentVariables()
    .Build();

/*string connectionString = configuration.GetConnectionString("SqlConnection");*/


builder.Services.AddScoped<IDbConnection>(provider =>
{
    var connectionString = configuration.GetConnectionString("SqlConnection");

    var connection = new SqlConnection(connectionString);
    return connection;
});

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
