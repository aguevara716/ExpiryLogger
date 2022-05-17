using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;

namespace ExpiryLogger.Api.Controllers;

public class ImagesController : CrudControllerBase<Image>
{
    public ImagesController(IRepository<Image> repository)
        : base(repository)
    {

    }
}
