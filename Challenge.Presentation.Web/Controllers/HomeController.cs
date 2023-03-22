using Challenge.ClientConnector.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        IChallengeServiceConnector ChallengeServiceConnector { get; }

        public HomeController(IChallengeServiceConnector challengeServiceConnector)
        {
            ChallengeServiceConnector = challengeServiceConnector;
        }

        public async Task<IActionResult> Index()
        {
            var summary = await ChallengeServiceConnector.GetSummaryAsync();
            return View(summary);
        }
    }
}