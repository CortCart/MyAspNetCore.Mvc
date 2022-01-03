
using Photo.Services.Items.Models;

namespace Photo.Services.Items;

public interface ICamerasServices
{
    IEnumerable<CamerasQueryServiceModel> All();

    CameraDetailsServiceModel Details(int cameraId);

    int Create(string brand, string model, decimal price, string description, string imageUrl, int year, int dealerId);

    bool Edit(int id, string brand, string model, decimal price, string description, string imageUrl, int year, double rating);
}