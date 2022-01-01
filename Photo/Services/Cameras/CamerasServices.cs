using CarRentingSystem.Services.Items.Models;

namespace CarRentingSystem.Services.Items;

public interface CamerasServices
{
    IEnumerable<CamerasQueryServiceModel> All();


}