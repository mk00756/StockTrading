using Microsoft.AspNetCore.Mvc;

namespace StockTrading.Receiver.Controllers {
    [Controller]
    public class HomeController : Controller {
        [Route("/Home")]
        public IActionResult Home() {
            return View();
        }
    }
}