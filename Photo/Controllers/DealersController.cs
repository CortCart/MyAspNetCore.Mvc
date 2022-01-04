using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photo.Infrastructure.Extensions;
using Photo.Models.Dealers;
using Photo.Services.Dealers;

namespace Photo.Controllers
{
        [Authorize]
        public class DealersController : Controller
        {
            private IDealerService dealerService;
        public DealersController(IDealerService dealerService)
        {
           this.dealerService = dealerService;
        }
        public IActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Become(DealersFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("cv", "Invalid data attempt.");
            }

            if (dealerService.IsDealer(this.User.Id()))
            {
                ModelState.AddModelError("cv", "Invalid data attempt.");
            }

            dealerService.Become(model.Name,model.PhoneNumber,this.User.Id());

            return this.Redirect("/");
        }
    }
}
