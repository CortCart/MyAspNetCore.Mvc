using Microsoft.AspNetCore.Mvc;
using Photo.Models.Cars;
using Photo.Services.Items;

namespace Photo.Controllers
{
    public class CamerasController : Controller
    {
        private  ICamerasServices camerasServices;

        public CamerasController( ICamerasServices cameras)
        {
            this.camerasServices = cameras;
        }
        public IActionResult All([FromQuery] AllCarmerasQueryModel   query)
        {
            var queryResult = this.camerasServices.All(
                query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarmerasQueryModel.CamerasPerPage);

            var carBrands = this.camerasServices.AllBrands();

            query.Brands = carBrands;
            query.TotalCars = queryResult.TotalCars;
            query.Cameras = queryResult.Cameras;

            return View(query);
        }
    }
}
