using System.Net.Mime;
using AutoMapper.QueryableExtensions;
using Photo.Data;
using Photo.Model;

using AutoMapper;
using Photo.Models.Cameras;
using Photo.Services.Cameras.Models;

namespace Photo.Services.Cameras;

public class CamerasService : ICamerasServices
{
    private ApplicationDbContext _context;


    public CamerasService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public CamerasQueryServiceModel All(
        string brand = null,
        string searchTerm = null,
        CamerasSorting sorting = CamerasSorting.DateCreated,
        int currentPage = 1,
        int camerasPerPage = int.MaxValue,
        bool publicOnly = true)
    {
        var camersQuery = this._context.Cameras
            .Where(c => c.Public);

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

        var totalCameras = camersQuery.Count();

        var cameras= GetCameras(camersQuery
            .Skip((currentPage - 1) * camerasPerPage)
            .Take(camerasPerPage));

        return new CamerasQueryServiceModel
        {
            TotalCameras = totalCameras,
            CurrentPage = currentPage,
            CamerasPerPage = camerasPerPage,
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
                Imgs = x.Imgs,
                Description = x.Description,
                DealerId = x.DealerId,
                DealerName = x.Dealer.Name,
            })
            .FirstOrDefault();
    }

    public int Create(string brand, string modelCamera, decimal price, string description, List<Image> imagesUrl, int year, int dealerId, Dealer dealer)
    {
        var camera = new Camera()
        {
            Brand = brand,
            Model = modelCamera,
            Price = price,
            DealerId = dealerId,
            Year = year,
            Imgs = imagesUrl,
            Description = description
        };
        _context.Cameras.Add(camera);
        _context.SaveChanges();
        return camera.Id;
    }



    
    private IEnumerable<CamerasServiceModel> GetCameras(IQueryable<Camera> cameraQuery)
        => cameraQuery
            .Select(x => new CamerasServiceModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Imgs = x.Imgs,
                ModelCamera = x.Model,
                Price = x.Price,
                Descripton = x.Description
            }).ToList();

    
}