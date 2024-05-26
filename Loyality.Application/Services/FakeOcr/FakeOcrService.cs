using Loyality.Domain.Dtos.Ocr;
using Loyality.Domain.Dtos.Receipt;
using Loyality.Domain.Extentions;
using Newtonsoft.Json;

namespace Loyality.Application.Services.FakeOcr;

public class FakeOcrService : IFakeOcrService
{
    public Task<OcrResult> GetOcrResult()
    {
        var jsonString = File.ReadAllText("/Users/eg/src/StudyCase/Kaizen/Loyality/SolutionItems/response.json");

        var result = new OcrResult
        {
            Result = jsonString
        };

        return Task.FromResult(result);
    }

    public async Task<List<ReceiptDto>> DeserilizeOcrResult()
    {
        var ocrResult = await GetOcrResult();
        if (string.IsNullOrWhiteSpace(ocrResult.Result))
        {
            throw new Exception();
        }
        var receipts = JsonExtention<List<ReceiptDto>>.DeserilizeJsonString(ocrResult.Result);

        if (receipts == null && !receipts.Any())
        {
            throw new Exception();
        }
        return receipts;
    }
}