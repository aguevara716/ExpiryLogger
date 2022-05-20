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
    public int AddBy { get; set; }
    public string Username { get; set; }
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
        Username = string.Empty;
    }

    public Category? GetCategory()
    {
        if (!CategoryId.HasValue && CategoryName is null)
            return null;
        var category = new Category
        {
            Id = CategoryId.GetValueOrDefault(),
            Name = CategoryName is null ? string.Empty : CategoryName
        };
        return category;
    }

    public void SetCategory(Category? category)
    {
        CategoryId = category?.Id;
        CategoryName = category?.Name;
    }

    public Image? GetImage()
    {
        if (!ImageId.HasValue && ImageName is null && ImageFile is null && ImageUrl is null)
            return null;
        var image = new Image
        {
            File = ImageFile,
            Id = ImageId.GetValueOrDefault(),
            Name = ImageName is null ? string.Empty : ImageName,
            Url = ImageUrl
        };
        return image;
    }

    public void SetImage(Image? image)
    {
        ImageFile = image?.File;
        ImageId = image?.Id;
        ImageName = image?.Name;
        ImageUrl = image?.Url;
    }

    public Location? GetLocation()
    {
        if (!LocationId.HasValue && LocationName is null)
            return null;
        var location = new Location
        {
            Id = LocationId.GetValueOrDefault(),
            Name = LocationName is null ? string.Empty : LocationName
        };
        return location;
    }

    public void SetLocation(Location? location)
    {
        LocationId = location?.Id;
        LocationName = location?.Name;
    }

    public Product GetProduct()
    {
        var product = new Product
        {
            AddDate = AddDate,
            CategoryId = CategoryId,
            ExpirationDate = ExpirationDate,
            Id = ProductId,
            ImageId = ImageId,
            LocationId = LocationId,
            Name = Name
        };
        return product;
    }

    public void SetProduct(Product product)
    {
        AddDate = product.AddDate;
        CategoryId = product.CategoryId;
        ExpirationDate = product.ExpirationDate;
        ProductId = product.Id;
        ImageId = product.ImageId;
        LocationId = product.LocationId;
        Name = product.Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is ProductDetail detail &&
               Id == detail.Id &&
               ProductId == detail.ProductId &&
               Name == detail.Name &&
               ExpirationDate == detail.ExpirationDate &&
               AddBy == detail.AddBy &&
               Username == detail.Username &&
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
        hash.Add(Id);
        hash.Add(ProductId);
        hash.Add(Name);
        hash.Add(ExpirationDate);
        hash.Add(AddBy);
        hash.Add(Username);
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
