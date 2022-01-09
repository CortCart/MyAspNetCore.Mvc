using Photo.Services.Cameras.Models;

namespace Photo.Services.Ads;

public class AdsService:IAdsServices
{
    public CamerasQueryServiceModel All(string searchTerm = null, int currentPage = 1, int camerasPerPage = Int32.MaxValue,
        bool publicOnly = true)
    {
        throw new NotImplementedException();
    }
}