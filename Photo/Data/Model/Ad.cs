using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model;

public class Ad
{
    public int Id { get; set; }

    public string Head { get; set; }

    public string Author { get; set; }

    public decimal Price { get; set; }

    public string Descripton { get; set; }

    [ForeignKey(nameof(User))]
    public string UserId { get; set; }

    public User User { get; set; }

    public bool Public { get; set; } = true;
    public IEnumerable<User> Users { get; set; } = new List<User>();
}