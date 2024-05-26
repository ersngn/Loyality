using Microsoft.AspNetCore.Mvc;

namespace Loyality.API.Controllers;

public class CampaignCodeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}