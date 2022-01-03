namespace Photo.Services.Cameras.Models;

public class CamerasQueryServiceModel
{
    public int CurrentPage { get; set; }

    public int CarsPerPage { get; set; }

    public int TotalCars { get; set; }

    public IEnumerable<CamerasServiceModel> Cameras { get; set; }

}