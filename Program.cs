using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using newproject2.EmployeeDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeDetailsDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBconnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EmployeeDetailsDBContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/login/Login";

});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
