using Microsoft.EntityFrameworkCore;
using SchoolGradeManager.Models;
using SchoolGradeManager.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolTestManager.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentManagerContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("StudentManagerDatabase")));

/*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.AccessDeniedPath = "/Forbidden/";
});*/

//dependecny injection
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IGradeRepository, GradeRepository>();
builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<ITestRepository, TestRepository>();
builder.Services.AddTransient<ITestQuestionRepository, TestQuestionRepository>();
builder.Services.AddTransient<IHomeworkRepository, HomeworkRepository>();

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
app.UseSession();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Student}/{action=Index}/{id?}");
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
