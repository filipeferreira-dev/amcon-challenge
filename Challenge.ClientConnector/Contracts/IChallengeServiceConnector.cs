using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;

namespace Challenge.ClientConnector.Contracts
{
    public interface IChallengeServiceConnector
    {
        Task<IEnumerable<MerchantResponse>?> GetMerchantsAsync();
        Task<MerchantResponse?> AddAsync(MerchantRequest request);
        Task<MerchantResponse?> GetMerchantByIdAsync(long id);
        Task<MerchantResponse?> AddPurchaseAsync(long merchantId, PurchaseRequest request);
        Task<SummaryResponse?> GetSummaryAsync();
        Task<SummaryPerMerchantResponse?> GetSummaryByMerchantAsync(long id);
    }
}
