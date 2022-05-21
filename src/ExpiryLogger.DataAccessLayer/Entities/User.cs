using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Users")]
[Index(nameof(User.Username), IsUnique = true, Name = "UX_User_Username")]
public class User : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(320)]
    public string Username { get; set; }

    [Required]
    [StringLength(40)]
    public string HashedPassword { get; set; }

    [Required]
    [ForeignKey("FK_User_CreatorUserId")]
    public int CreatorUserId { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    [ForeignKey("FK_User_UpdaterUserId")]
    public int UpdaterUserId { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }

    public User()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Username = string.Empty;
        HashedPassword = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               Id == user.Id &&
               FirstName == user.FirstName &&
               LastName == user.LastName &&
               Username == user.Username &&
               HashedPassword == user.HashedPassword &&
               CreatorUserId == user.CreatorUserId &&
               CreateDate == user.CreateDate &&
               UpdaterUserId == user.UpdaterUserId &&
               UpdateDate == user.UpdateDate;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Id);
        hash.Add(FirstName);
        hash.Add(LastName);
        hash.Add(Username);
        hash.Add(HashedPassword);
        hash.Add(CreatorUserId);
        hash.Add(CreateDate);
        hash.Add(UpdaterUserId);
        hash.Add(UpdateDate);
        return hash.ToHashCode();
    }
}
