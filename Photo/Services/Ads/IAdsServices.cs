using Photo.Services.Ads.Models;

namespace Photo.Services.Ads;

public interface IAdsServices
{
    public AdsQueryServiceModel All
        (string searchTerm = null, int currentPage = 1, int adsPerPage = Int32.MaxValue,
    bool publicOnly = true);

    //  CameraDetailsServiceModel Details(int cameraId);


    //int Create(string brand, string model, decimal price, string description, string imageUrl, int year, int dealerId);
}