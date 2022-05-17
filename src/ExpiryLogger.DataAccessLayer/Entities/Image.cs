using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Images")]
[Index(nameof(Image.File), IsUnique = true, Name = "UX_Image_File")]
[Index(nameof(Image.Url), IsUnique = true, Name = "UX_Image_Url")]
public class Image : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    public string Name { get; set; }

    [StringLength(300)]
    public string? File { get; set; }

    [StringLength(300)]
    public string? Url { get; set; }

    public Image()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is Image image &&
               Id == image.Id &&
               Name == image.Name &&
               File == image.File &&
               Url == image.Url;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, File, Url);
    }
}
