using Microsoft.AspNetCore.Mvc;

namespace Photo.Controllers
{
    public class AdsController1 : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
