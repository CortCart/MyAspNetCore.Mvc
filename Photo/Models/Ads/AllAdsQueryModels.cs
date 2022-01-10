
using Photo.Services.Ads.Models;

namespace Photo.Models.Ads
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllAdsQueryModel
    {
        public const int AdsPerPage = 3;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalAds { get; set; }

        public IEnumerable<AdsServiceModel> Ads { get; set; }
    }
}