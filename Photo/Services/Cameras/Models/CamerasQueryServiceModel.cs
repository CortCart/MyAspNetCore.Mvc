namespace Photo.Services.Cameras.Models;

public class CamerasQueryServiceModel
{
    public int CurrentPage { get; set; }

    public int CamerasPerPage { get; set; }

    public int TotalCameras { get; set; }

    public IEnumerable<CamerasServiceModel> Cameras { get; set; }

}