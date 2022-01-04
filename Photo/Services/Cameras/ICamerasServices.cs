
using Photo.Models.Cars;
using Photo.Services.Cameras.Models;

namespace Photo.Services.Cameras;

public interface ICamerasServices
{
    public CamerasQueryServiceModel All(
        string brand = null,
        string searchTerm = null,
        CamerasSorting sorting = CamerasSorting.DateCreated,
        int currentPage = 1,
        int carsPerPage = int.MaxValue,
        bool publicOnly = true);

    CameraDetailsServiceModel Details(int cameraId);

    IEnumerable<string> AllBrands();

    int Create(string brand, string model, decimal price, string description, string imageUrl, int year, int dealerId);

    bool Edit(int id, string brand, string model, decimal price, string description, string imageUrl, int year, double rating);
}