using Photo.Services.Ads.Models;

namespace Photo.Services.Ads;

public interface IAdsServices
{
    public AdsQueryServiceModel All(string searchTerm = null, int currentPage = 1, int adsPerPage = Int32.MaxValue, bool publicOnly = true);
}