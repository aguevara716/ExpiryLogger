using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;

namespace ExpiryLogger.Api.Controllers
{
    public class LocationsController : CrudControllerBase<Location>
    {
        public LocationsController(IRepository<Location> repository)
            : base(repository)
        {

        }
    }
}

