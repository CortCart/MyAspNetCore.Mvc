using System.ComponentModel.DataAnnotations;
using Photo.Model;
using System.IO;

namespace Photo.Models.Cameras;

public class CameraFormModel
{
    public string Brand { get; set; }
   
    public string ModelCamera { get; set; }
    
    public decimal Price { get; set; }

    public List<IFormFile> Imgs { get; set; }
    
    [Range(1950,2050)]
    public int Year { get; set; }

    public string Description { get; set; }


}

