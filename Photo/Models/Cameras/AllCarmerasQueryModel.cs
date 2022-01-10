using Photo.Services.Cameras.Models;

namespace Photo.Models.Cameras
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllCarmerasQueryModel
    {
        public const int CamerasPerPage = 3;

        public string Brand { get; init; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public CamerasSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalCameras { get; set; }

        public IEnumerable<string> Brands { get; set; }

        public IEnumerable<CamerasServiceModel> Cameras { get; set; }
    }
}