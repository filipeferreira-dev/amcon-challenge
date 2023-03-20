using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;
using Challenge.ClientConnector.Contracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace Challenge.ClientConnector
{
    public class ChallengeServiceConnector : IChallengeServiceConnector
    {
        HttpClient Client { get; }

        public ChallengeServiceConnector(HttpClient httpClient)
        {
            Client = httpClient;
        }

        public async Task<IEnumerable<MerchantResponse>?> GetMerchantsAsync()
        {
            using var response = await Client.GetAsync($"/api/merchants");
            return await response.Content.ReadFromJsonAsync<IEnumerable<MerchantResponse>>();
        }

        public async Task<MerchantResponse?> AddAsync(MerchantRequest request)
        {
            using var response = await Client.PostAsJsonAsync($"/api/merchants", request);
            return await response.Content.ReadFromJsonAsync<MerchantResponse?>();
        }

        public async Task<MerchantResponse?> GetMerchantByIdAsync(long id)
        {
            using var response = await Client.GetAsync($"/api/merchants/{id}");
            return await response.Content.ReadFromJsonAsync<MerchantResponse?>();
        }

        public async Task<MerchantResponse?> AddPurchaseAsync(long merchantId, PurchaseRequest request)
        {
            using var response = await Client.PostAsJsonAsync($"/api/merchants/{merchantId}/purchase", request);
            return await response.Content.ReadFromJsonAsync<MerchantResponse?>();
        }

        public async Task<SummaryResponse?> GetSummaryAsync()
        {
            using var response = await Client.GetAsync($"/api/merchants/summary");
            return await response.Content.ReadFromJsonAsync<SummaryResponse?>();
        }

        public async Task<SummaryPerMerchantResponse?> GetSummaryByMerchantAsync(long id)
        {
            using var response = await Client.GetAsync($"/api/merchants/{id}/summary");
            return await response.Content.ReadFromJsonAsync<SummaryPerMerchantResponse>();
        }
    }
}
