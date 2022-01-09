
using Photo.Services.Ads.Models;

public class AdsQueryServiceModel
{
    public int CurrentPage { get; set; }

    public int CarsPerPage { get; set; }

    public int TotalCars { get; set; }

    public IEnumerable<AdsServiceModel> Cameras { get; set; }
}