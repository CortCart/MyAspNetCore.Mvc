using AutoMapper.QueryableExtensions;
using Photo.Data;
using Photo.Model;
using Photo.Models.Cars;

using AutoMapper;
using Photo.Services.Cameras.Models;

namespace Photo.Services.Cameras;

public class CamerasService:ICamerasServices
{
    private  ApplicationDbContext _context;


    public CamerasService(ApplicationDbContext context, IMapper mapper)
    {
        _context=context;
    }

    public CamerasQueryServiceModel All(
        string brand = null,
        string searchTerm = null,
        CamerasSorting sorting = CamerasSorting.DateCreated,
        int currentPage = 1,
        int carsPerPage = int.MaxValue,
        bool publicOnly = true)
    {
        var camersQuery = this._context.Cameras
            .Where(c =>  c.Public);

        if (!string.IsNullOrWhiteSpace(brand))
        {
            camersQuery = camersQuery.Where(c => c.Brand == brand);
        }

        // Where(c => c.Brand == brand);
        //.Where(c => !publicOnly || c.IsPublic);


        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            camersQuery = camersQuery.Where(c =>
                (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower()) ||
                c.Description.ToLower().Contains(searchTerm.ToLower()));
        }

        camersQuery = sorting switch
        {
            CamerasSorting.Year => camersQuery.OrderByDescending(c => c.Year),
            CamerasSorting.BrandAndModel => camersQuery.OrderBy(c => c.Brand).ThenBy(c => c.Model),
            CamerasSorting.DateCreated or _ => camersQuery.OrderByDescending(c => c.Id)
        };

        var totalCars = camersQuery.Count();

        var cameras = GetCameras(camersQuery
            .Skip((currentPage - 1) * carsPerPage)
            .Take(carsPerPage));

        return new CamerasQueryServiceModel
        {
            TotalCars = totalCars,
            CurrentPage = currentPage,
            CarsPerPage = carsPerPage,
            Cameras = cameras
        };
    }


    public IEnumerable<string> AllBrands()
        => this._context
            .Cameras
            .Select(c => c.Brand)
            .Distinct()
            .OrderBy(br => br)
            .ToList();
    public CameraDetailsServiceModel Details(int cameraId)
    {
        return _context.Cameras.Where(x => x.Id == cameraId)
            .Select(x => new CameraDetailsServiceModel
            {
                Id = x.Id,
                Brand = x.Brand,
                ModelCamera = x.Model,
                Price = x.Price,
                Rating = x.Rating,
                Img = x.Img,
                Description = x.Description,
                DealerId = x.DealerId,
                DealerName = x.Dealer.Name,
            })
            .FirstOrDefault();
    }

    public int Create(string brand, string modelCamera, decimal price, string description, string imageUrl, int year, int dealerId)
    {
       var camera = new Camera()
       {
           Brand = brand,
           Model = modelCamera,
           Price = price,
           Rating = 0,
           Year = year,
           Img = imageUrl,
           Description = description,
           DealerId = dealerId
       };

        _context.Cameras.Add(camera);
        _context.SaveChanges();
        return camera.Id;
    }

    public bool Edit(int id ,string brand, string model, decimal price, string description, string imageUrl, int year, double rating)
    {
        var camera = _context.Cameras.Find(id);

        if (camera == null)
        {
            return false;
        }

        camera.Brand = brand;
        camera.Model = model;
        camera.Price = price;
        camera.Rating = rating;
        camera.Year = year;
        camera.Img = imageUrl;
        camera.Description = description;
        _context.SaveChanges();
        return true;
    }
    private IEnumerable<CamerasServiceModel> GetCameras(IQueryable<Camera> carQuery)
        => carQuery
            .Select(x => new CamerasServiceModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Img = x.Img,
                ModelCamera = x.Model,
                Price = x.Price,
                Descripton = x.Description,
                Rating = x.Rating
            }).ToList();
}