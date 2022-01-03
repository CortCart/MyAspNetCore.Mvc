using Photo.Data;
using Photo.Model;
using Photo.Services.Items;
using Photo.Services.Items.Models;

namespace CarRentingSystem.Services.Items;

public class CamerasService:ICamerasServices
{
    private  ApplicationDbContext _context;

    public CamerasService(ApplicationDbContext context)
    {
        _context=context;
    }

    public IEnumerable<CamerasQueryServiceModel> All()
    {
        return _context.Cameras.Select(x => new CamerasQueryServiceModel
        {
            Id = x.Id,
            Brand = x.Brand,
            Model = x.Model,
            Img = x.Img,
            Price = x.Price,
            Rating = x.Rating
        }).ToHashSet();
    }

    public CameraDetailsServiceModel Details(int cameraId)
    {
        return _context.Cameras.Where(x => x.Id == cameraId)
            .Select(x => new CameraDetailsServiceModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Price = x.Price,
                Rating = x.Rating,
                Img = x.Img,
                Description = x.Description,
                DealerId = x.DealerId,
                DealerName = x.Dealer.Name,
            })
            .FirstOrDefault();
    }

    public int Create(string brand, string model, decimal price, string description, string imageUrl, int year, int dealerId)
    {
       var camera = new Camera()
       {
           Brand = brand,
           Model = model,
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
}