using WebWellsMVC.WellDb.DBContext;
using Microsoft.EntityFrameworkCore;
using WebWellsMVC.Models;
using System;
using WebWellsMVC.WellDb.DbModels;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//app.UseDefaultFiles();
//app.UseStaticFiles();

//app.MapGet("/api/wells", () => wells);

//app.MapGet("/api/wells/{uwi}", (int uwi) =>
//{
//    // �������� �������� �� id
//    Wells? well = wells.FirstOrDefault(u => u.UWI == uwi);
//    // ���� �� �������, ���������� ��������� ��� � ��������� �� ������
//    if (well == null) return Results.NotFound(new { message = "�������� �� �������" });

//    // ���� ������������ ������, ���������� ���
//    return Results.Json(well);
//});

//app.MapDelete("/api/wells/{uwi}", (int uwi) =>
//{
//    // �������� �������� �� id
//    Wells? well = wells.FirstOrDefault(u => u.UWI == uwi);

//    // ���� �� �������, ���������� ��������� ��� � ��������� �� ������
//    if (well == null) return Results.NotFound(new { message = "�������� �� �������" });

//    // ���� �������� �������, ������� �
//    wells.Remove(well);
//    return Results.Json(wells);
//});

//app.MapPost("/api/wells", (Wells well) => {


//    // ��������� �������� � ������
//    wells.Add(well);
//    return well;

//});

//app.MapPut("/api/wells", (Wells wellData) => {

//    // �������� �������� �� id
//    var well = wells.FirstOrDefault(u => u.UWI == wellData.UWI);
//    // ���� �� �������, ���������� ��������� ��� � ��������� �� ������
//    if (well == null) return Results.NotFound(new { message = "�������� �� �������" });
//    // ���� �������� �������, �������� � ������ � ���������� ������� �������

//    well.Name = wellData.Name;
//    well.Bush = wellData.Bush;
//    well.Type = wellData.Type;
//    well.OpMethod = wellData.OpMethod;
//    well.Stage = wellData.Stage;
//    well.Date = DateTime.Now;
//    return Results.Json(well);
//});



string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();  // ��������� ��������� ������������

var app = builder.Build();
app.MapDefaultControllerRoute();


var builder1 = new ConfigurationBuilder();
builder1.SetBasePath(Directory.GetCurrentDirectory());
builder1.AddJsonFile("appsettings.json");
var config = builder1.Build();
string connectionString = config.GetConnectionString("DefaultConnection");

//var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//var options = optionsBuilder
//    .UseSqlServer(connectionString)
//    .Options;
//using (ApplicationDbContext db = new ApplicationDbContext(options))
//{

//}
var optionsBuilderWellDb = new DbContextOptionsBuilder<WellsDbContext>();
var optionsWellDb = optionsBuilderWellDb
    .UseSqlServer(connectionString)
    .Options;
using (WellsDbContext db2 = new WellsDbContext(optionsWellDb))
{
    db2.Database.EnsureCreated();
    try
    {
        await db2.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}






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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
