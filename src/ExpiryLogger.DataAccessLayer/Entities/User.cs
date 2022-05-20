using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Users")]
[Index(nameof(User.Username), IsUnique = true, Name = "UX_User_Username")]
public class User
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
    public int AddBy { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

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
               AddBy == user.AddBy &&
               AddDate == user.AddDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Username, HashedPassword, AddBy, AddDate);
    }
}
