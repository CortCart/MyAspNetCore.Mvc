namespace Photo.Services.Dealers;

public interface IDealerService
{
     bool IsDealer(string userId);

     int IdByUser(string userId);

     void Become(string name , string number, string id);
}