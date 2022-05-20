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

    [ForeignKey("FK_Product_Image")]
    public int? ImageId { get; set; }

    [ForeignKey("FK_Product_Location")]
    public int? LocationId { get; set; }

    [Required]
    [ForeignKey("FK_Product_AddBy")]
    public int AddBy { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

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
               ImageId == product.ImageId &&
               LocationId == product.LocationId &&
               AddBy == product.AddBy &&
               AddDate == product.AddDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, ExpirationDate, CategoryId, ImageId, LocationId, AddBy, AddDate);
    }

}
