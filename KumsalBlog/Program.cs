using Autofac;
//using KumsalBlog.Business.Mapping;
using KumsalBlog.Business.Service;
using KumsalBlog.Kernel.Repository;
using KumsalBlog.Kernel.Service;
using KumsalBlog.Kernel.UnityOfWork;
using KumsalBlog.Types;
using KumsalBlog.Types.Repositories;
using KumsalBlog.Types.UnityOfWork;
using KumsalBlog;
using KumsalBlog.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

//builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
	{
		option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
	});
});

//builder.Services.AddRazorPages()
//	.AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
