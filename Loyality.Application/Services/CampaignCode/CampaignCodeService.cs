using Loyality.Domain.Dtos.CampaignCode;
using Loyality.Domain.Extentions;

namespace Loyality.Application.Services.CampaignCode;

public class CampaignCodeService : ICampaignCodeService
{
    public Task<List<CampaignCodeDto>> GenerateCode(GenerateCodeRequest request)
    {
        var codes = CampaignCodeExtention.GenerateCode(request.CodeCount);
        return Task.FromResult(codes);
    }

    public Task<CampaginCodeValidationResponse> CodeValidation(CampaignCodeValidationRequest request)
    {
        var codeIsValid = CampaignCodeExtention.ValidateCode(request.Code);
        return Task.FromResult<CampaginCodeValidationResponse>(new CampaginCodeValidationResponse
        {
            CodeIsValid = codeIsValid
        });
    }
}