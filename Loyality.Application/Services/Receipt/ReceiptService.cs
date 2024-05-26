using Loyality.Application.Services.FakeOcr;
using Loyality.Domain.Dtos.Receipt;
using Loyality.Domain.Extentions;

namespace Loyality.Application.Services.Receipt;

public class ReceiptService : IReceiptService
{
    private readonly IFakeOcrService _fakeOcrService;

    public ReceiptService(IFakeOcrService fakeOcrService)
    {
        _fakeOcrService = fakeOcrService;
    }


    public async Task<List<string>> GetReceipt()
    {
        var ocrResult = await _fakeOcrService.DeserilizeOcrResult();
        var sortedReceipt = ReceiptExtention.GetReceiptDescription(ocrResult);

        return sortedReceipt;
    }
}