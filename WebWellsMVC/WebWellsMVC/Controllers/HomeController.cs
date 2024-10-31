using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebWellsMVC.Models;
using WebWellsMVC.WellDb.DBContext;
using WebWellsMVC.WellDb.DbModels;
using Microsoft.EntityFrameworkCore;

namespace WebWellsMVC.Controllers
{
    public class HomeController : Controller
    {


          ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.wells.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Wells well)
        {
            db.wells.Add(well);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? UWI)
        {
          //  if (UWI != null)
          //  {
                Wells? well = await db.wells.FirstOrDefaultAsync(p => p.UWI == UWI);
              //  if (well != null)
               // {
                    db.wells.Remove(well);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
               // }
           // }
           //  return NotFound();
           
        }

        public async Task<IActionResult> Edit(int? UWI)
        {
            if (UWI != null)
            {
                Wells? well = await db.wells.FirstOrDefaultAsync(p => p.UWI == UWI);
                if (well != null) return View(well);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Wells well)
        {
            db.wells.Update(well);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task Index()
        //{
        //    string content = @"<form method='post'>
        //        <label>Имя скважины:</label><br />
        //        <input name='name' /><br />
        //        <label>Куст:</label><br />
        //        <input name='bush' /><br />
        //        <label>Тип скважины:</label><br />
        //        <input name='type' /><br />
        //        <label>Способ эксплуатации:</label><br />
        //        <input name='opMethod' /><br />
        //        <label>Этап:</label><br />
        //        <input name='stage' /><br />
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);
        //}
        //[HttpPost]
        //public string Index(Wells wells) => $"{wells.Name}: {wells.Bush}: {wells.Type}: {wells.OpMethod}: {wells.Stage}";
        //public string Index(string name, string bush, string type, string opMethod, string stage) => $"{name}: {bush}: {type}: {opMethod}: {stage}";







        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
   
}
