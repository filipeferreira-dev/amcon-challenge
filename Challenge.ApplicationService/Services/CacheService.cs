using Challenge.ApplicationService.Messages.Response;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.SharedKernel.Constants;
using Challenge.SharedKernel.Repositories;

namespace Challenge.ApplicationService.Services
{
    public class CacheService : ICacheService
    {
        ICacheRepository CacheRepository { get; }

        public CacheService(ICacheRepository cacheRepository)
        {
            CacheRepository = cacheRepository;
        }

        public async Task<SummaryResponse?> GetSummaryAsync()
        => await CacheRepository.GetAsync<SummaryResponse>(CacheKeys.Summary);

        public async Task<SummaryPerMerchantResponse?> GetSummaryByMerchantAsync(long id)
        => await CacheRepository.GetAsync<SummaryPerMerchantResponse>($"{CacheKeys.Summary}_{id}");

        public async Task<IEnumerable<MerchantResponse>> GetMerchantsAsync()
        => await CacheRepository.GetAsync<IEnumerable<MerchantResponse>>(CacheKeys.Merchants) ?? new HashSet<MerchantResponse>();

        public async Task<MerchantResponse> GetMerchantByIdAsync(long id)
        => await CacheRepository.GetAsync<MerchantResponse?>($"{CacheKeys.Merchants}_{id}") ?? default;
    }
}
