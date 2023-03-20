using Challenge.ApplicationService.Messages.Response;
using Challenge.ClientConnector.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        IChallengeServiceConnector ChallengeServiceConnector { get; }

        //no mundo real isso seria um servico de cache ou servico com a chamada para list individualmente as trasações de cada lojista
        //decidi utilizar essa classe estática para ser mais rapido o desenvolvimento
        static IEnumerable<MerchantResponse> _merchants;

        public HomeController(IChallengeServiceConnector challengeServiceConnector)
        {
            ChallengeServiceConnector = challengeServiceConnector;
        }

        public async Task<IActionResult> Index()
        {
            var summary = await ChallengeServiceConnector.GetSummaryAsync();
            return View(summary);
        }

        public IActionResult Details(long id)
        {
            var merchant = _merchants.FirstOrDefault(m => m.Id == id);

            return View(merchant);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
    }
}