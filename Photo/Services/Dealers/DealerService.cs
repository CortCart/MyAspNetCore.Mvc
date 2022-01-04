using Photo.Data;
using Photo.Model;

namespace Photo.Services.Dealers;

public class DealerService:IDealerService
{
    private  ApplicationDbContext _context;

    public DealerService(ApplicationDbContext context)
    {
        _context=context;
    }
    public bool IsDealer(string userId)
    {
        return _context.Dealers.Any(x => x.UserId == userId);
    }

    public int IdByUser(string userId)
    {
        return _context.Dealers.FirstOrDefault(x => x.UserId == userId).Id;
    }

    public void Become(string name, string number, string id)
    {
        Dealer dealer = new Dealer()
        {
            Name = name,
            PhoneNumber = number,
            UserId = id
        };
        _context.Dealers.Add(dealer);
        _context.SaveChanges();
    }
}