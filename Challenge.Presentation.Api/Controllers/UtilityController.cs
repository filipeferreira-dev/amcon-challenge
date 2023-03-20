using Challenge.ApplicationService.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class UtilityController : ControllerBase
    {
        ISyncService SyncService { get; }

        public UtilityController(ISyncService cacheService)
        {
            SyncService = cacheService;
        }

        [HttpPost]
        [Route("sync-cache")]
        public async Task<IActionResult> Sync()
        {
            await SyncService.SyncDataAsync();
            return Ok();
        }
    }
}
