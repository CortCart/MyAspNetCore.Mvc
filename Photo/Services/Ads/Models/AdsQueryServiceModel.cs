
using Photo.Services.Ads.Models;

public class AdsQueryServiceModel
{
    public int CurrentPage { get; set; }

    public int AdsPerPage { get; set; }

    public int TotalAds { get; set; }

    public IEnumerable<AdsServiceModel> Ads { get; set; }
}