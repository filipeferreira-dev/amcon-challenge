using Challenge.ClientConnector.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Web.Controllers
{
    public class MerchantController : Controller
    {
        IChallengeServiceConnector ChallengeServiceConnector { get; }

        public MerchantController(IChallengeServiceConnector challengeServiceConnector)
        {
            ChallengeServiceConnector  = challengeServiceConnector;
        }

        public async Task<IActionResult> Index()
        {
            var merchants = await ChallengeServiceConnector.GetMerchantsAsync();
            return View(merchants);
        }

        public async Task<IActionResult> Details(long id)
        {
            var merchant = await ChallengeServiceConnector.GetMerchantByIdAsync(id);
            return View(merchant);
        }

        public async Task<IActionResult> Summary(long id)
        {
            var merchant = await ChallengeServiceConnector.GetSummaryByMerchantAsync(id);
            return View(merchant);
        }
    }
}
