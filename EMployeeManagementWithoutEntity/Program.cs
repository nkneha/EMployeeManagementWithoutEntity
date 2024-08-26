using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EMployeeManagementWithoutEntity.Data;
using EMployeeManagementWithoutEntity.Repository;
using EMployeeManagementWithoutEntity.Services;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<EMployeeManagementWithoutEntityContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("EMployeeManagementWithoutEntityContext") ?? throw new InvalidOperationException("Connection string 'EMployeeManagementWithoutEntityContext' not found.")));

string connectionString = builder.Configuration.GetConnectionString("DevConnection");


// Add services to the container.
builder.Services.AddControllersWithViews();

// Register your repository and service
builder.Services.AddScoped<IEmployeeRepository>(sp => new EmployeeRepository(connectionString));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

//builder.Services.AddScoped<IEmployeeRepository>(sp =>
//    new EmployeeRepository(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
