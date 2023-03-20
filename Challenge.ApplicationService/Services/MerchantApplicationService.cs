using Challenge.ApplicationService.Maps;
using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;
using Challenge.ApplicationService.Services.Contracts;
using Challenge.Domain.Repositories;

namespace Challenge.ApplicationService.Services
{
    public class MerchantApplicationService : IMerchantApplicationService
    {
        IMerchantRepository MerchantRepository { get; }
        ISyncService SyncService { get; }

        public MerchantApplicationService(IMerchantRepository merchantRepository, ISyncService syncService)
        {
            MerchantRepository = merchantRepository;
            SyncService = syncService;
        }

        public async Task<MerchantResponse?> AddAsync(MerchantRequest request)
        {
            var entity = request.MapToEntity();
            var id = await MerchantRepository.AddAsync(entity);
            await SyncService.SyncDataAsync();
            return await GetAsync(id);
        }

        public async Task<MerchantResponse?> GetAsync(long id)
        {
            var merchant = await MerchantRepository.GetAsync(id);

            if (merchant == null) return null;

            return merchant.MapToResponse();
        }

        public async Task<MerchantResponse?> AddPurchaseAsync(long merchantId, PurchaseRequest request)
        {
            var merchant = await MerchantRepository.GetAsync(merchantId);

            if (merchant == null) return null;

            var entity = request.MapToEntity();

            merchant.AddPurchase(entity);

            await MerchantRepository.UpdateAsync(merchant);

            await SyncService.SyncDataAsync();

            return await GetAsync(merchantId);
        }
    }
}
