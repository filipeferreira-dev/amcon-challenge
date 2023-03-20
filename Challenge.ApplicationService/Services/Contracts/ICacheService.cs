using Challenge.ApplicationService.Messages.Response;

namespace Challenge.ApplicationService.Services.Contracts
{
    public interface ICacheService
    {
        public Task<SummaryResponse?> GetSummaryAsync();

        public Task<SummaryPerMerchantResponse?> GetSummaryByMerchantAsync(long id);

        public Task<IEnumerable<MerchantResponse>> GetMerchantsAsync();

        public Task<MerchantResponse?> GetMerchantByIdAsync(long id);
    }
}
