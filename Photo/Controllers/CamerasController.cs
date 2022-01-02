using Microsoft.AspNetCore.Mvc;

namespace Photo.Controllers
{
    public class CamerasController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
