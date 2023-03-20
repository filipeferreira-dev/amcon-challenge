using Challenge.ApplicationService.Messages.Request;
using Challenge.ApplicationService.Messages.Response;
using Challenge.ApplicationService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class MerchantsController : ControllerBase
    {
        IMerchantApplicationService MerchantApplicationService { get; }
        ICacheService CacheService { get; }

        public MerchantsController(IMerchantApplicationService merchantApplicationService, ICacheService cacheService)
        {
            MerchantApplicationService = merchantApplicationService;
            CacheService = cacheService;
        }

        [HttpGet]
        [Route("summary")]
        public async Task<SummaryResponse?> GetSummaryAsync() => await CacheService.GetSummaryAsync();


        [HttpGet]
        [Route("{id}/summary")]
        public async Task<SummaryPerMerchantResponse?> GetSummaryByMerchantAsync([FromRoute] long id) => await CacheService.GetSummaryByMerchantAsync(id);

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<MerchantResponse>> GetAllAsync() => await CacheService.GetMerchantsAsync();

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id) 
        { 
            var merchant = await CacheService.GetMerchantByIdAsync(id);
            return merchant == null ? NotFound() : Ok(merchant);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAsync([FromBody] MerchantRequest request)
        {
            var merchant = await MerchantApplicationService.AddAsync(request);
            return merchant == null ? BadRequest() : Created($"api/merchants/{merchant.Id}", merchant);
        }

        [HttpPost]
        [Route("{id}/purchase")]
        public async Task<IActionResult> AddPurchaseAsync([FromRoute]long id, [FromBody] PurchaseRequest request)
        {
            var merchant = await MerchantApplicationService.AddPurchaseAsync(id, request);
            return merchant == null ? BadRequest() : Created($"api/merchants/{merchant.Id}", merchant);
        }
    }
}
