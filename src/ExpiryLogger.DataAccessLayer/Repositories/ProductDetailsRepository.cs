﻿using ExpiryLogger.DataAccessLayer.Entities;

namespace ExpiryLogger.DataAccessLayer.Repositories;

public class ProductDetailsRepository : IRepository<ProductDetail>
{
    private readonly ExpirationLoggerContext _dbContext;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Image> _imageRepository;
    private readonly IRepository<Location> _locationRepository;
    private readonly IRepository<Product> _productRepository;

    public ProductDetailsRepository(ExpirationLoggerContext dbContext,
        IRepository<Category> categoryRepository,
        IRepository<Image> imageRepository,
        IRepository<Location> locationRepository,
        IRepository<Product> productRepository)
    {
        _dbContext = dbContext;
        _categoryRepository = categoryRepository;
        _imageRepository = imageRepository;
        _locationRepository = locationRepository;
        _productRepository = productRepository;
    }

    // create
    public int Add(ProductDetail productDetail)
    {
        var category = productDetail.GetCategory();
        if (category is not null && category.Id == 0)
            _categoryRepository.Add(category);

        var image = productDetail.GetImage();
        if (image is not null && image.Id == 0)
            _imageRepository.Add(image);

        var location = productDetail.GetLocation();
        if (location is not null && location.Id == 0)
            _locationRepository.Add(location);

        var product = productDetail.GetProduct();
        var productsInserted = _productRepository.Add(product);

        return productsInserted;
    }

    public int Add(IEnumerable<ProductDetail> productDetails)
    {
        var (categories, images, locations, products) = ExtractCollections(productDetails);
        if (categories is not null && categories.Any())
            _categoryRepository.Add(categories);

        if (images is not null && images.Any())
            _imageRepository.Add(images);

        if (locations is not null && locations.Any())
            _locationRepository.Add(locations);

        var productsInserted = _productRepository.Add(products);
        return productsInserted;
    }

    // read
    public ProductDetail? Get(int id)
    {
        var productDetail = _dbContext.ProductDetails.FirstOrDefault(pd => pd.ProductId == id);
        return productDetail;
    }

    public IEnumerable<ProductDetail>? Get(Func<ProductDetail, bool> predicate)
    {
        var productDetails = _dbContext.ProductDetails.Where(predicate);
        return productDetails;
    }

    public IEnumerable<ProductDetail>? Get()
    {
        return _dbContext.ProductDetails;
    }

    public ProductDetail GetFirst()
    {
        return _dbContext.ProductDetails.First();
    }

    public ProductDetail GetFirst(Func<ProductDetail, bool> predicate)
    {
        var productDetails = _dbContext.ProductDetails.First(predicate);
        return productDetails;
    }

    public ProductDetail? GetFirstOrDefault()
    {
        var productDetails = _dbContext.ProductDetails.FirstOrDefault();
        return productDetails;
    }

    public ProductDetail? GetFirstOrDefault(Func<ProductDetail, bool> predicate)
    {
        var productDetail = _dbContext.ProductDetails.FirstOrDefault(predicate);
        return productDetail;
    }

    // update
    public int Update(ProductDetail productDetail)
    {
        var category = productDetail.GetCategory();
        if (category is not null && category.Id > 0)
            _categoryRepository.Update(category);

        var image = productDetail.GetImage();
        if (image is not null && image.Id > 0)
            _imageRepository.Update(image);

        var location = productDetail.GetLocation();
        if (location is not null && location.Id > 0)
            _locationRepository.Update(location);

        var product = productDetail.GetProduct();
        return _productRepository.Update(product);
    }

    public int Update(IEnumerable<ProductDetail> productDetails)
    {
        var (categories, images, locations, products) = ExtractCollections(productDetails);

        if (categories.Any())
            _categoryRepository.Update(categories);

        if (images.Any())
            _imageRepository.Update(images);

        if (locations.Any())
            _locationRepository.Update(locations);

        return _productRepository.Update(products);
    }

    // delete
    public int Delete(int id)
    {
        var productDetail = Get(id);
        if (productDetail is null)
            return 0;
        return Delete(productDetail);
    }

    public int Delete(IEnumerable<ProductDetail> productDetails)
    {
        var (categories, images, locations, products) = ExtractCollections(productDetails);

        if (categories.Any())
            _categoryRepository.Delete(categories);
        if (images.Any())
            _imageRepository.Delete(images);
        if (locations.Any())
            _locationRepository.Delete(locations);

        return _productRepository.Delete(products);
    }

    public int Delete(ProductDetail productDetail)
    {
        var category = productDetail.GetCategory();
        if (category is not null && category.Id > 0)
            _categoryRepository.Delete(category);

        var image = productDetail.GetImage();
        if (image is not null && image.Id > 0)
            _imageRepository.Delete(image);

        var location = productDetail.GetLocation();
        if (location is not null && location.Id > 0)
            _locationRepository.Delete(location);

        var product = productDetail.GetProduct();
        return _productRepository.Delete(product);
    }

    public int Delete(Func<ProductDetail, bool> predicate)
    {
        var productDetails = Get(predicate);
        if (productDetails is null || !productDetails.Any())
            return 0;
        return Delete(productDetails);
    }

    public int Delete()
    {
        var productDetails = Get();
        if (productDetails is null || !productDetails.Any())
            return 0;
        return Delete(productDetails);
    }

    private static (List<Category> categories, List<Image> images, List<Location> locations, List<Product> products) ExtractCollections(IEnumerable<ProductDetail> productDetails)
    {
        var categories = new List<Category>();
        var images = new List<Image>();
        var locations = new List<Location>();
        var products = new List<Product>();

        foreach (var productDetail in productDetails)
        {
            var category = productDetail.GetCategory();
            if (category is not null)
                categories.Add(category);

            var image = productDetail.GetImage();
            if (image is not null)
                images.Add(image);

            var location = productDetail.GetLocation();
            if (location is not null)
                locations.Add(location);

            products.Add(productDetail.GetProduct());
        }
        return (categories, images, locations, products);
    }

}
