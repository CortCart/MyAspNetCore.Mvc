namespace Photo.Services.Items.Models;

public class CamerasQueryServiceModel
{
    public int Id { get; init; }
    public string Brand { get; set; }

    public string Model { get; set; }

    public decimal Price { get; set; }

    public string Img { get; set; }

    public double Rating { get; set; }


}