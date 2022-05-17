using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;

namespace ExpiryLogger.Api.Controllers;

public class CategoriesController : CrudControllerBase<Category>
{
    public CategoriesController(IRepository<Category> repository)
        : base(repository)
    {

    }
}
