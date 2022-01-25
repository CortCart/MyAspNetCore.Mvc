using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Model;

public class Image
{
    [Key]
    public int Id { get; set; }

    public byte[]  Binary  { get; set; }

    [ForeignKey(nameof(Camera))]
    public int CameraId { get; set; }

    public Camera Camera { get; set; }
}