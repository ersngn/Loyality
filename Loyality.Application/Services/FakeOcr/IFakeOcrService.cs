using Loyality.Domain.Dtos.Ocr;
using Loyality.Domain.Dtos.Receipt;

namespace Loyality.Application.Services.FakeOcr;

public interface IFakeOcrService
{
    Task<OcrResult> GetOcrResult();
    Task<List<ReceiptDto>> DeserilizeOcrResult();
}