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

    public IActionResult Index(){
        using var log1 = 
            new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .CreateLogger();
        log1.Debug("Msg from log1");
        log1.Information("Msg from log1");
        log1.Error("Msg from log1");
        log1.Warning("Msg from log1");
        log1.Fatal("Msg from log1");
        
        using var log2 = 
            new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();
        log2.Debug("Msg from log2");
        log2.Information("Msg from log2");
        log2.Error("Msg from log2");
        log2.Warning("Msg from log2");
        log2.Fatal("Msg from log2");
    
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
