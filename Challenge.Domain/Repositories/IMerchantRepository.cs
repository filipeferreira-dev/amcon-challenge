using Challenge.Domain.Models;

namespace Challenge.Domain.Repositories
{
    public interface IMerchantRepository
    {
        Task AddRangeAsync(IEnumerable<Merchant> entities);

        Task<long> AddAsync(Merchant entity);

        Task<IEnumerable<Merchant>> GetAllAsync();

        Task<Merchant?> GetAsync(long id);

        Task UpdateAsync(Merchant entity);
    }
}
