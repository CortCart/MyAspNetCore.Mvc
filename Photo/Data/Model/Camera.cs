using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model;

public class Camera
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(150)]
    public string Brand { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(150)]
    public string Model { get; set; }

    [Required]
    [Range(0.00, 100.00)]
    public decimal Price { get; set; }

    [Required]
    [Range(1950, 2022)]
    public int Year { get; set; }

    public bool Public { get; set; }=true;

    [Required]
    [MinLength(1)]
    [MaxLength(550)]
    public string Description { get; set; }


    [ForeignKey(nameof(Dealer))]
    public int DealerId { get; set; }
    [Required]
    public  Dealer Dealer { get; set; }


    public List<Image> Imgs { get; set; } = new List<Image>();
}