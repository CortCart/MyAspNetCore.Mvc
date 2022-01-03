using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model;

public class Camera
{
    [Key]
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    [Required]
    [Range(0.00, 100.00)]
    public decimal Price { get; set; }
    public bool Public { get; set; }=true;


    public double Rating { get; set; }

    public string Img { get; set; }

    public int Year { get; set; }

    public string Description { get; set; }

    [ForeignKey(nameof(Dealer))]
    public int DealerId { get; set; }

    public  Dealer Dealer { get; set; }
}