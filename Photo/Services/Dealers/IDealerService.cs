using Photo.Model;

namespace Photo.Services.Dealers;

public interface IDealerService
{
     bool IsDealer(string userId);

     Dealer GetDealer(string userId);

     int IdByUser(string userId);

     void Become(string name , string number, string id);
}