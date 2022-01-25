using Photo.Data;
using Photo.Model;

namespace Photo.Services.Images;

public class ImageService:IImageService
{
     private  ApplicationDbContext _context { get; set; }

     public ImageService(ApplicationDbContext _context)
     {
         this._context = _context;
     }

     public Image GetImage(int id)=>_context.Images.FirstOrDefault(x => x.Id == id);
     

}