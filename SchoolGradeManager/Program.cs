using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentManagerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagerDatabase")));

//dependecny injection
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IGradeRepository, GradeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
