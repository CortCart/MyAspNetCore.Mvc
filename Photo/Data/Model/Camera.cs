namespace Photo.Model;

public class Camera
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    public decimal Price { get; set; }

    public double Rating { get; set; }

    public string Img { get; set; }

    public int Year { get; set; }

    public string Description { get; set; }

    public int DealerId { get; set; }

    public  Dealer Dealer { get; set; }
}