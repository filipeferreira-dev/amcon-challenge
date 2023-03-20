using Challenge.ApplicationService.Maps;
using Challenge.ApplicationService.Messages.Response;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Repositories;
using Challenge.SharedKernel.Constants;
using Challenge.SharedKernel.Repositories;

namespace Challenge.ApplicationService.Services
{
    public class SyncService : ISyncService
    {
        ICacheRepository CacheRepository { get; }
        IMerchantRepository MerchantRepository { get; }

        public SyncService(ICacheRepository cacheRepository, IMerchantRepository merchantRepository)
        {
            CacheRepository = cacheRepository;
            MerchantRepository = merchantRepository;
        }

        public async Task SyncDataAsync()
        {
            var merchants = await MerchantRepository.GetAllAsync();

            await CacheRepository.SetAsync(CacheKeys.Merchants, merchants.MapToResponse());

            var summary = new SummaryResponse
            {
                MerchantsCount = merchants.Count(),
                PurchaseCount = merchants.Sum(i => i.Purchases.Count),
                PurchaseAmmount = merchants.Sum(i => i.Purchases.Sum(p => p.Amount))
            };

            await CacheRepository.SetAsync(CacheKeys.Summary, summary);

            foreach(var merchant in merchants)
            {
                var summaryPerMerchant = new SummaryPerMerchantResponse();

                summaryPerMerchant.MerchantName = merchant.Name;
                summaryPerMerchant.PurchaseCount = merchant.Purchases.Count;
                summaryPerMerchant.Balance = merchant.Purchases.Sum(p => p.Amount);

                await CacheRepository.SetAsync($"{CacheKeys.Summary}_{merchant.Id}", summaryPerMerchant);
                await CacheRepository.SetAsync($"{CacheKeys.Merchants}_{merchant.Id}", merchant.MapToResponse());
            }
        }
    }
}
