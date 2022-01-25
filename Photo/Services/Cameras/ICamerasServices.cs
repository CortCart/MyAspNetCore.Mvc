using Photo.Model;
using Photo.Models.Cameras;
using Photo.Services.Cameras.Models;

namespace Photo.Services.Cameras;

public interface ICamerasServices
{
    public CamerasQueryServiceModel All(
        string brand = null,
        string searchTerm = null,
        CamerasSorting sorting = CamerasSorting.DateCreated,
        int currentPage = 1,
        int camerasPerPage = int.MaxValue,
        bool publicOnly = true);

    CameraDetailsServiceModel Details(int cameraId);

    IEnumerable<string> AllBrands();

    int Create(string brand, string model, decimal price, string description, List<Image> imagesUrl, int year, int dealerId, Dealer dealer);

}