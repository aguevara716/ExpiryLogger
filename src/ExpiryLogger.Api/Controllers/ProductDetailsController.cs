using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;

namespace ExpiryLogger.Api.Controllers;

public class ProductDetailsController : CrudControllerBase<ProductDetail>
{
    public ProductDetailsController(IRepository<ProductDetail> repository)
        : base(repository)
    {

    }
}
