using System.ComponentModel.DataAnnotations.Schema;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("ProductDetails")]
public class ProductDetail : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string ImageUri { get; set; }
    
    public int? CategoryId { get; set; }
    public string? CategoryName { get; set; }
    
    public int? LocationId { get; set; }
    public string? LocationName { get; set; }

    public int CreatorUserId { get; set; }
    public string CreatorUsername { get; set; }
    public DateTime CreateDate { get; set; }

    public int UpdaterUserId { get; set; }
    public string UpdaterUsername { get; set; }
    public DateTime UpdateDate { get; set; }

    public ProductDetail()
    {
        Name = string.Empty;
        ImageUri = string.Empty;
        CreatorUsername = string.Empty;
        UpdaterUsername = string.Empty;
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
            CategoryId = CategoryId,
            CreateDate = CreateDate,
            CreatorUserId = CreatorUserId,
            ExpirationDate = ExpirationDate,
            Id = Id,
            LocationId = LocationId,
            Name = Name,
            UpdateDate = UpdateDate,
            UpdaterUserId = UpdaterUserId
        };
        return product;
    }

    public void SetProduct(Product product)
    {
        CategoryId = product.CategoryId;
        CreateDate = product.CreateDate;
        CreatorUserId = product.CreatorUserId;
        ExpirationDate = product.ExpirationDate;
        Id = product.Id;
        LocationId = product.LocationId;
        Name = product.Name;
        UpdateDate = product.UpdateDate;
        UpdaterUserId = product.UpdaterUserId;
    }

    public override bool Equals(object? obj)
    {
        return obj is ProductDetail detail &&
               Id == detail.Id &&
               Name == detail.Name &&
               ExpirationDate == detail.ExpirationDate &&
               ImageUri == detail.ImageUri &&
               CategoryId == detail.CategoryId &&
               CategoryName == detail.CategoryName &&
               LocationId == detail.LocationId &&
               LocationName == detail.LocationName &&
               CreatorUserId == detail.CreatorUserId &&
               CreatorUsername == detail.CreatorUsername &&
               CreateDate == detail.CreateDate &&
               UpdaterUserId == detail.UpdaterUserId &&
               UpdaterUsername == detail.UpdaterUsername &&
               UpdateDate == detail.UpdateDate;
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        hash.Add(Id);
        hash.Add(Name);
        hash.Add(ExpirationDate);
        hash.Add(ImageUri);
        hash.Add(CategoryId);
        hash.Add(CategoryName);
        hash.Add(LocationId);
        hash.Add(LocationName);
        hash.Add(CreatorUserId);
        hash.Add(CreatorUsername);
        hash.Add(CreateDate);
        hash.Add(UpdaterUserId);
        hash.Add(UpdaterUsername);
        hash.Add(UpdateDate);
        return hash.ToHashCode();
    }

}
