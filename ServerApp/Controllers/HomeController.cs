using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using System.Linq;

namespace ServerApp.Controllers;

public class HomeController : Controller
{
    private DataContext context;

    public HomeController(DataContext ctx)
    {
        context = ctx;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
