using Microsoft.AspNetCore.Mvc;
using Photo.Models.Ads;
using Photo.Services.Ads;

namespace Photo.Controllers
{
    public class AdsController : Controller
    {
        private IAdsServices AdsServices;

        public AdsController(IAdsServices adsServices)
        {
            AdsServices=adsServices;
        }
        public IActionResult All([FromQuery] AllAdsQueryModel query )
        {
            var queryResult = this.AdsServices.All(
                query.SearchTerm,
                query.CurrentPage,
                AllAdsQueryModel.AdsPerPage);

            return View();
        }
    }
}
