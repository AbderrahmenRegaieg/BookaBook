// Program.cs

using WebAppcore.Data; // Assuming your DbContext is in this namespace
using WebAppcore.IRepositly; // Make sure this is present for your interfaces and concrete implementations
using Microsoft.EntityFrameworkCore; // For AddDbContext if not already there

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Register your ApplicationDbContext
// (Replace "DefaultConnection" with your actual connection string name from appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register your generic repository
// This line registers IRepository<T> to be implemented by Repository<T> for any T.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 3. Register your specific CategoryRepository
// This line registers ICategoryRepository to be implemented by CategoryRepository.
// It uses AddScoped, meaning a new instance will be created once per HTTP request.
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();