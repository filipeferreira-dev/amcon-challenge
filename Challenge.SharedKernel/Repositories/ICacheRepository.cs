namespace Challenge.SharedKernel.Repositories
{
    public interface ICacheRepository
    {
        Task<T?> GetAsync<T>(string key);

        Task SetAsync<T>(string key, T value);
    }
}
