﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dependency_injection_1.Models;

namespace dependency_injection_1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly GuidService _service1;
    private readonly GuidService _service2;

    public HomeController(ILogger<HomeController> logger, GuidService service1, GuidService service2)
    {
        _logger = logger;
        _service1 = service1;
        _service2 = service2;
    }

    public IActionResult Index()
    {
        ViewBag.Guid1 = _service1.GetGuid();
        ViewBag.Guid2 = _service2.GetGuid();
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
