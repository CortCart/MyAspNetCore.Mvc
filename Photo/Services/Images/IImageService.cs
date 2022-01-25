using Microsoft.EntityFrameworkCore.Metadata;
using Photo.Model;

namespace Photo.Services.Images;

public interface IImageService
{
    Image GetImage(int Id);
}