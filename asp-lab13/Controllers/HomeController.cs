using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using asp_lab13.Models;
using Serilog;
namespace asp_lab13.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int a, int b)
    {
        using var log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        try 
        {
            ViewData["Result"] = a / b;
            log.Information(ViewData["Result"].ToString());
        }
        catch (Exception ex) 
        {
            log.Error(ex.Message);
        }
    
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
