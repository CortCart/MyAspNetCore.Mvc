using Photo.Models.Cameras;
using Photo.Services.Cameras.Models;

namespace Photo.Services.Ads;

public interface IAdsServices
{
    public CamerasQueryServiceModel All(
        string searchTerm = null,
        int currentPage = 1,
        int camerasPerPage = int.MaxValue,
        bool publicOnly = true);

  //  CameraDetailsServiceModel Details(int cameraId);


    //int Create(string brand, string model, decimal price, string description, string imageUrl, int year, int dealerId);
}