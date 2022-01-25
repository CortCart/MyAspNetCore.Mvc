using Photo.Model;

namespace Photo.Services.Cameras.Models;

public class CamerasServiceModel
{
    public int Id { get; set; }
    public string Brand { get; set; }

    public string ModelCamera { get; set; }

    public decimal Price { get; set; }

    public List<Image> Imgs { get; set; }

    public double Rating { get; set; }

    public string Descripton { get; set; }

}