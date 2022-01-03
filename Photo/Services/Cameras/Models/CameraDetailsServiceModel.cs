namespace Photo.Services.Items.Models;

public class CameraDetailsServiceModel
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    public decimal Price { get; set; }

    public double Rating { get; set; }

    public string Img { get; set; }

    public string Description { get; set; }

    public int DealerId { get; set; }

    public string DealerName { get; set; }


}