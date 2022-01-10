using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photo.Infrastructure.Extensions;
using Photo.Model;
using Photo.Models.Cameras;
using Photo.Services.Cameras;
using Photo.Services.Dealers;

namespace Photo.Controllers
{
    public class CamerasController : Controller
    {
        private ICamerasServices camerasServices;
        private IDealerService dealersServices;

        public CamerasController(ICamerasServices cameras, IDealerService dealer)
        {
            this.camerasServices = cameras;
            this.dealersServices = dealer;
        }

        public IActionResult All([FromQuery] AllCarmerasQueryModel query)
        {
            var queryResult = this.camerasServices.All(
                query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarmerasQueryModel.CamerasPerPage);

            var carBrands = this.camerasServices.AllBrands();

            query.Brands = carBrands;
            query.TotalCameras = queryResult.TotalCameras;
            query.Cameras = queryResult.Cameras;

            return View(query);
        }
        [Authorize]
        public IActionResult Add()
        {
            if (!this.dealersServices.IsDealer(this.User.Id()))
            {
                return RedirectToAction(nameof(DealersController.Become), "Dealers");

            }
            return this.View();
        }

        [HttpPost]
        // [Authorize]
        public IActionResult Add(CameraFormModel model)
        {
            if (!ModelState.IsValid)
            {
                //  ModelState.AddModelError("cv", "Invalid data attempt.");
            }

            int id = this.camerasServices.Create(model.Brand, model.ModelCamera, model.Price, model.Description,
                model.Img, model.Year, dealersServices.IdByUser(this.User.Id()));

            return this.Redirect("/");
            //    return RedirectToAction(nameof(Details), new { id = id });
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}