using Loyality.Domain.Dtos.Ocr;
using Loyality.Domain.Dtos.Receipt;
using Newtonsoft.Json;
namespace Loyality.Application.Services;

public interface IFakeOcrService
{
    Task<OcrResult> GetOcrResult();
    Task<ReceiptDto> DeserilizeOcrResult(OcrResult ocrResult);
}