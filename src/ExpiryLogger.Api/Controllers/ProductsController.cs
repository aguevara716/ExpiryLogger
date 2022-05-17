using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;

namespace ExpiryLogger.Api.Controllers;

public class ProductsController : CrudControllerBase<Product>
{
    public ProductsController(IRepository<Product> repository)
        : base(repository)
    {

    }
}
