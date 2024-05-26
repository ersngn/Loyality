using Microsoft.AspNetCore.Mvc;

namespace Loyality.API.Controllers;

public class ReceiptController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}