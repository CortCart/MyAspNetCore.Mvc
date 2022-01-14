using System.Linq;
using Photo.Data;
using Photo.Model;
using Photo.Services.Ads.Models;

namespace Photo.Services.Ads;

public class AdsService:IAdsServices
{
    private  ApplicationDbContext _context;

    public AdsService(ApplicationDbContext context)
    {
        this._context = context;
    }
    public AdsQueryServiceModel All(string searchTerm = null, int currentPage = 1, int adsPerPage = Int32.MaxValue,
        bool publicOnly = true)
    {
        var adsQuery = this._context.Ads
            .Where(c => c.Public);

        // Where(c => c.Brand == brand);
        //.Where(c => !publicOnly || c.IsPublic);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            adsQuery = adsQuery.Where(c =>
                (c.Head ).ToLower().Contains(searchTerm.ToLower()) ||
                c.Descripton.ToLower().Contains(searchTerm.ToLower()));
        }

        
        var totalAds = adsQuery.Count();

        var ads = GetAds(adsQuery
            .Skip((currentPage - 1) * adsPerPage)
            .Take(adsPerPage));

        return new AdsQueryServiceModel
        {
            TotalAds  = totalAds,
            CurrentPage = currentPage,
            AdsPerPage = adsPerPage,
            Ads = ads
        };
    }

    private IEnumerable<AdsServiceModel> GetAds(IQueryable<Ad> adsQuery)
        => adsQuery
            .Select(x => new AdsServiceModel
            {
                Id = x.Id,
                Head = x.Head,
                Author = x.User.Name,
                Descripton = x.Descripton,
                Price = x.Price
            }).ToList();
}