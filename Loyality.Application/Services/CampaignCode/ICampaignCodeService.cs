using Loyality.Domain.Dtos.CampaignCode;

namespace Loyality.Application.Services.CampaignCode;

public interface ICampaignCodeService
{
    Task<List<CampaignCodeDto>> GenerateCode(GenerateCodeRequest request);
    Task<CampaginCodeValidationResponse> CodeValidation(CampaignCodeValidationRequest request);
}