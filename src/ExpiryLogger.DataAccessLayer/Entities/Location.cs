using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Locations")]
[Index(nameof(Location.Name), IsUnique = true, Name = "UX_Location_Name")]
public class Location : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [ForeignKey("FK_Location_CreatorUserId")]
    public int CreatorUserId { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    [ForeignKey("FK_Location_UpdaterUserId")]
    public int UpdaterUserId { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }

    public Location()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is Location location &&
               Id == location.Id &&
               Name == location.Name &&
               CreatorUserId == location.CreatorUserId &&
               CreateDate == location.CreateDate &&
               UpdaterUserId == location.UpdaterUserId &&
               UpdateDate == location.UpdateDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, CreatorUserId, CreateDate, UpdaterUserId, UpdateDate);
    }

}
