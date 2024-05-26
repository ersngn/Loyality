using Loyality.Domain.Dtos.Receipt;

namespace Loyality.Application.Services.Receipt;

public interface IReceiptService
{
    public Task<List<string>> GetReceipt();
}