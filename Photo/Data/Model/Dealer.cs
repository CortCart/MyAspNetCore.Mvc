namespace Photo.Model;

public class Dealer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string UserId { get; set; }

    public IEnumerable<Camera> Cameras { get; set; } = new List<Camera>();

}