using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;

namespace Challenge.ApplicationService.Services.Contracts
{
    public interface IMerchantApplicationService
    {
        Task<MerchantResponse?> AddAsync(MerchantRequest request);
        Task<MerchantResponse?> GetAsync(long id);
        Task<MerchantResponse?> AddPurchaseAsync(long merchantId, PurchaseRequest request);
    }
}
