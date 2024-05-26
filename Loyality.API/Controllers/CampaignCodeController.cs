using Loyality.Application.Services.CampaignCode;
using Loyality.Domain.Dtos.CampaignCode;
using Microsoft.AspNetCore.Mvc;

namespace Loyality.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CampaignCodeController : ControllerBase
{
    private readonly ICampaignCodeService _campaignCodeService;

    public CampaignCodeController(ICampaignCodeService campaignCodeService)
    {
        _campaignCodeService = campaignCodeService;
    }

    [HttpPost("Generete")]
    public IActionResult GenereteCode(GenerateCodeRequest request)
    {
        return Ok(_campaignCodeService.GenerateCode(request));
    }
    
    [HttpPost("Validate")]
    public IActionResult ValidateCode(CampaignCodeValidationRequest request)
    {
        return Ok(_campaignCodeService.CodeValidation(request));
    }
    

}