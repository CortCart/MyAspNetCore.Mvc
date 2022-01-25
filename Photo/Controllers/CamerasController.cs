using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Photo.Infrastructure.Extensions;
using Photo.Model;
using Photo.Models.Cameras;
using Photo.Services.Cameras;
using Photo.Services.Dealers;
using Photo.Services.Images;

namespace Photo.Controllers
{
    public class CamerasController : Controller
    {
        private ICamerasServices camerasServices;
        private IDealerService dealersServices;
        private IImageService imageService;

        public CamerasController(ICamerasServices cameras, IDealerService dealer, IImageService images)
        {
            this.camerasServices = cameras;
            this.dealersServices = dealer;
            this.imageService = images;
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
        public  IActionResult Add(CameraFormModel model)
        {
            if (!ModelState.IsValid)
            {
                  ModelState.AddModelError("cv", "Invalid data attempt.");
            }

            List<Image> images = new List<Image>();
            foreach (var img in model.Imgs)
            {
                var memoryStream = new MemoryStream();
                img.CopyToAsync(memoryStream);
                images.Add(new Image
                {
                    Binary = memoryStream.ToArray(),

                });
            }


            int id = this.camerasServices.Create(model.Brand, model.ModelCamera, model.Price, model.Description,
                images, model.Year, dealersServices.IdByUser(this.User.Id()),dealersServices.GetDealer(this.User.Id()));

             return RedirectToAction(nameof(Details), new { id = id });
        }

        public IActionResult GetImage(int id)
        {
            var image = imageService.GetImage(id);
            return File(image.Binary , "image/png");
        }

        public IActionResult Details(int id)
        {
            var camera = camerasServices.Details(id);
            return this.View(camera);
        }
    }
}