using System.Text;
using Loyality.Application.Services.Receipt;
using Loyality.Domain.Dtos.Receipt;
using Microsoft.AspNetCore.Mvc;

namespace Loyality.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceiptController : ControllerBase
{
    private readonly IReceiptService _receiptService;

    public ReceiptController(IReceiptService receiptService)
    {
        _receiptService = receiptService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReceipt()
    {
        var receiptText = await _receiptService.GetReceipt();

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "receipt.txt");
        System.IO.File.WriteAllLines(filePath, receiptText.ToArray(), Encoding.UTF8);
        
        var fileContent = System.IO.File.ReadAllText(filePath);
        
        return Ok(fileContent);
        
    }
}