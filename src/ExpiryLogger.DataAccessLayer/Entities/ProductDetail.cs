using System.ComponentModel.DataAnnotations.Schema;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("ProductDetails")]
public class ProductDetail : IEntity
{
    [NotMapped]
    public int Id { get => ProductId; set => ProductId = value; }

    public int ProductId { get; set; }
    public string Name { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime AddDate { get; set; }

    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }

    public int? ImageId { get; set; }
    public string? ImageName { get; set; }
    public string? ImageFile { get; set; }
    public string? ImageUrl { get; set; }

    public int? LocationId { get; set; }
    public string? LocationName { get; set; }

    public ProductDetail()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is ProductDetail detail &&
               ProductId == detail.ProductId &&
               Name == detail.Name &&
               ExpirationDate == detail.ExpirationDate &&
               AddDate == detail.AddDate &&
               CategoryId == detail.CategoryId &&
               CategoryName == detail.CategoryName &&
               ImageId == detail.ImageId &&
               ImageName == detail.ImageName &&
               ImageFile == detail.ImageFile &&
               ImageUrl == detail.ImageUrl &&
               LocationId == detail.LocationId &&
               LocationName == detail.LocationName;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(ProductId);
        hash.Add(Name);
        hash.Add(ExpirationDate);
        hash.Add(AddDate);
        hash.Add(CategoryId);
        hash.Add(CategoryName);
        hash.Add(ImageId);
        hash.Add(ImageName);
        hash.Add(ImageFile);
        hash.Add(ImageUrl);
        hash.Add(LocationId);
        hash.Add(LocationName);
        return hash.ToHashCode();
    }
}
