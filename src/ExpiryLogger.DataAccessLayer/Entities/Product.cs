using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Products")]
public class Product : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(500)]
    public string Name { get; set; }

    [Required]
    public DateTime ExpirationDate { get; set; }
    [ForeignKey("FK_Product_Category")]
    public int? CategoryId { get; set; }

    [ForeignKey("FK_Product_Location")]
    public int? LocationId { get; set; }

    [Required]
    [ForeignKey("FK_Product_CreatorUserId")]
    public int CreatorUserId { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    [ForeignKey("FK_Product_UpdaterUserId")]
    public int UpdaterUserId { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }

    public Product()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is Product product &&
               Id == product.Id &&
               Name == product.Name &&
               ExpirationDate == product.ExpirationDate &&
               CategoryId == product.CategoryId &&
               LocationId == product.LocationId &&
               CreatorUserId == product.CreatorUserId &&
               CreateDate == product.CreateDate &&
               UpdaterUserId == product.UpdaterUserId &&
               UpdateDate == product.UpdateDate;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Id);
        hash.Add(Name);
        hash.Add(ExpirationDate);
        hash.Add(CategoryId);
        hash.Add(LocationId);
        hash.Add(CreatorUserId);
        hash.Add(CreateDate);
        hash.Add(UpdaterUserId);
        hash.Add(UpdateDate);
        return hash.ToHashCode();
    }

}
