using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Categories")]
[Index(nameof(Category.Name), IsUnique = true, Name = "UX_Category_Name")]
public class Category : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [ForeignKey("FK_Category_AddBy")]
    public int AddBy { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

    public Category()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is Category category &&
               Id == category.Id &&
               Name == category.Name &&
               AddBy == category.AddBy &&
               AddDate == category.AddDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, AddBy, AddDate);
    }

}
